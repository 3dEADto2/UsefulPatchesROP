using HarmonyLib;
using SodaDen.Pacha;

namespace UsefullPatches.Patches
{
    [HarmonyPatch(typeof(SpawnedFish), "UpdateFocusedValue")]
    internal class HitModeAdjustFocusValue
    {
        [HarmonyPrefix]
        public static bool Prefix(ref float changeValue)
        {
            float configValue = ConfigManager.HitModeFocusBuildUp!.Value;
            changeValue *= configValue;
            if (configValue == 0) {
                changeValue = 1f;
            }
       
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("HitModeAdjustFocusValue: Multiplied changeValue by " + configValue + "!");
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(SpawnedFish), "UpdateTensionValue")]
    internal class HitModeAdjustTensionValue
    {
        [HarmonyPrefix]
        public static bool Prefix(ref float changeValue)
        {
            float configValue = ConfigManager.HitModeTensionBuildUp!.Value;
            changeValue *= configValue;
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("HitModeAdjustTensionValue: Multiplied changeValue by " + configValue + "!");
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(SpawnedFish), "UpdateDetectionChance")]
    internal class HitModeAdjustdDetectionValue
    {
        [HarmonyPrefix]
        public static bool Prefix(ref float changeValue)
        {
            float configValue = ConfigManager.HitModeDetectionBuildUp!.Value;
            changeValue *= configValue;
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("HitModeAdjustdDetectionValue: Multiplied changeValue by " + configValue + "!");
            }
            return true;
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
