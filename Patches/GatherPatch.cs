using HarmonyLib;
using SodaDen.Pacha;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace UsefullPatches.Patches
{
    [HarmonyPatch(typeof(CaveOreShim), "SpawnMineralOnHealth0")]
    internal class OreYieldPatch
    {
        [HarmonyPostfix]
        public static void Postfix(CaveOreShim __instance, ref Transform ___center)
        {
            int count = ConfigManager.MineralYield!.Value;
            if (__instance.Mineral != null)
            {
                for(int i = 0; i < count; i++)
                {
                    //Transform center = (Transform)AccessTools.Field(typeof(CaveOreShim), "center").GetValue(__instance);
                    MagneticItemData entity = new MagneticItemData
                    {
                        ID = __instance.ID + $"-{100 + i}",
                        ItemWithProperties = __instance.Mineral,
                        FromPosition = (UnityEngine.Vector2)___center.position,
                        ToPosition = SpawnBehaviorUtils.GetDistanceForBounce(___center.position, SpawnBehavior.BounceShort),
                        SpawnBehavior = SpawnBehavior.BounceShort,
                        Q = 1,
                        Source = ItemObtainedSource.Picked
                    };
                    GenericEntityManager.Instance.LocalInstantiate(entity);
                }
                if (ConfigManager.EnableLogging!.Value)
                {
                    UsefullPatchesMain.Log?.LogInfo("MineralYield: " + count + " minerals spawned!");
                }
            } else
            {
                if (ConfigManager.EnableLogging!.Value)
                {
                    UsefullPatchesMain.Log?.LogInfo("MineralYield: Mineral was null!");
                }
            }
        }
    }

    [HarmonyPatch(typeof(TreeEntity), "GenerateWood")]
    internal class WoodYieldPatch
    {
        [HarmonyPostfix]
        public static void Postfix(TreeEntity __instance, ref bool stump, ref TreeRenderer ___treeRenderer)
        {
            int count = 10;
            if (__instance.Tree.TreeType.WoodItem != null && stump != true)
            {
                InventoryItem inventoryItem = __instance.Tree.TreeType.WoodItem;
                UnityEngine.Vector2 vector = ___treeRenderer.transform.position;

                for (int i = 0; i < count; i++)
                {
                    UnityEngine.Vector2 validDistanceForBounce = SpawnBehaviorUtils.GetValidDistanceForBounce(vector, SpawnBehavior.BounceShort);
                    MagneticItemData entity = new MagneticItemData
                    {
                        ID = __instance.EntityID + (100 + i),
                        ItemWithProperties = inventoryItem,
                        Visible = true,
                        FromPosition = vector,
                        ToPosition = validDistanceForBounce,
                        SpawnBehavior = SpawnBehavior.BounceShort,
                        Source = ItemObtainedSource.Picked
                    };
                    GenericEntityManager.Instance.LocalInstantiate(entity);
                }
                if (ConfigManager.EnableLogging!.Value)
                {
                    UsefullPatchesMain.Log?.LogInfo("WoodYield: " + count + " logs spawned!");
                }
            }
            else if (stump == true)
            {
                if (ConfigManager.EnableLogging!.Value)
                {
                    UsefullPatchesMain.Log?.LogInfo("WoodYield: Item was a stump!");
                }
            } else
            {
                if (ConfigManager.EnableLogging!.Value)
                {
                    UsefullPatchesMain.Log?.LogInfo("WoodYield: WoodItem was null!");
                }
            }
        }
    }

    [HarmonyPatch(typeof(CaveOreShim), "OnHealthChange")]
    internal class OreInstantBreakPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref float newHealth)
        {
            newHealth = 0;
            if (ConfigManager.EnableLogging!.Value) {
                UsefullPatchesMain.Log?.LogInfo("Mineral Health set to 0!");
            }   
            return true;
        }
    }

    [HarmonyPatch(typeof(ToolItem), "get_Power")]
    internal class ToolHardnessPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref int __result)
        {
            __result = ConfigManager.ToolHardness!.Value;
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("Tool hardness overwritten!");
            }
            return false;
        }
    }

    [HarmonyPatch(typeof(WaterToolItem), nameof(WaterToolItem.HasEnoughWater))]
    internal class InfiniteWaterTool
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            __result = true;
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("HasWaterCheck ignored!");
            }
            return false;
        }
    }

    [HarmonyPatch(typeof(TreeEntity), nameof(TreeEntity.Hit))]
    public static class TreeHitPatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var code = new List<CodeInstruction>(instructions);

            // search for the pattern of the TreeType.Tools.Contains call
            for (int i = 0; i < code.Count - 5; i++)
            {
                if (
                    code[i].opcode == OpCodes.Ldarg_0 &&
                    code[i + 1].opcode == OpCodes.Call &&
                    code[i + 2].opcode == OpCodes.Callvirt &&
                    code[i + 3].opcode == OpCodes.Callvirt &&
                    code[i + 4].opcode == OpCodes.Ldloc_0 &&
                    code[i + 5].opcode == OpCodes.Call &&
                    code[i + 5].operand is MethodInfo method &&
                    method.Name == "Contains" &&
                    method.DeclaringType?.FullName?.StartsWith("System.Linq.Enumerable") == true
                )
                {
                    // replace instruction with ldc.i4.1
                    code[i] = new CodeInstruction(OpCodes.Ldc_I4_1);
                    // nop the rest of the matched instructions
                    for (int j = 1; j <= 5; j++)
                    {
                        code[i + j] = new CodeInstruction(OpCodes.Nop);
                    }

                    // 0nly replace the first match
                    break;
                }
            }
            return code;
        }
    }
}
