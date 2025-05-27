using HarmonyLib;
using SodaDen.Pacha;

namespace UsefullPatches.Patches
{
    [HarmonyPatch(typeof(Field), "SpawnResource")]
    internal class FieldSpawnResourcePatch
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("Field: ResourceSpawn denied!");
            }
            return false;
        }
    }

    [HarmonyPatch(typeof(Field), "TrySpawnTree")]
    internal class FieldSpawnTreePatch
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("Field: TreeSpawn denied!");
            }
            return false;
        }
    }

    [HarmonyPatch(typeof(Field), "TrySpawnLargeResource")]
    internal class FieldSpawnLargeResourcePatch
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("Field: LargeResourceSpawn denied!");
            }
            return false;
        }
    }

    [HarmonyPatch(typeof(Field), "SpawnTallGrass")]
    internal class FieldSpawnTallGrassPatch
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("Field: TallGrassSpawn denied!");
            }
            return false;
        }
    }
}
