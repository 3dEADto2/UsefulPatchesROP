using HarmonyLib;
using SodaDen.Pacha;

namespace UsefullPatches.Patches
{
    [HarmonyPatch(typeof(SpawnedFish), "UpdateDetectionChance")]
    internal class HitModeDetectionChance
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (ConfigManager.EnableLogging!.Value) {
                UsefullPatchesMain.Log?.LogInfo("SpawnedFish UpdateDetectionChance canceld!");
            }            
            return false;
        }
    }

    [HarmonyPatch(typeof(SpawnedFish), "get_FocusedValue")]
    internal class HitModeInstantFocusValue
    {
        [HarmonyPrefix]
        public static bool Prefix(ref float __result)
        {
            __result = 1f;
            if (ConfigManager.EnableLogging!.Value) {
                UsefullPatchesMain.Log?.LogInfo("SpawnedFish GetFocusedValue overwritten!");
            }
            return false;
        }
    }

    [HarmonyPatch(typeof(HookedFishTarget), "Pull")]
    internal class HookModeInstantPull
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            __result = true;
            if (ConfigManager.EnableLogging!.Value) {
                UsefullPatchesMain.Log?.LogInfo("HookedFishTarget Pull overwritten!");
            }
            return false;
        }
    }
}
