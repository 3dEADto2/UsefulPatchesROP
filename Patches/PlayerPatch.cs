using HarmonyLib;
using SodaDen.Pacha;

namespace UsefullPatches.Patches
{
    [HarmonyPatch(typeof(PlayerStateController), "get_Speed")]
    internal class SpeedPatch
    {
        [HarmonyPostfix]
        public static void Postfix(ref float __result)
        {
            __result *= ConfigManager.SpeedMultiplier!.Value;
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("PlayerSpeed set to " + __result + "!");
            }
        }
    }

    [HarmonyPatch(typeof(PlayerStats), "DecreaseStamina")]
    internal class StaminaPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref float q)
        {
            q *= ConfigManager.StaminaConsuption!.Value;
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("Stamina consumption set to " + q + "!");
            }
            return true;
        }
    }
}
