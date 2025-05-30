using HarmonyLib;
using SodaDen.Pacha;

namespace UsefullPatches.Patches
{
    [HarmonyPatch(typeof(AnimalEntity), "UpdateFriendshipAtStartOfDay")]
    internal class AnimalDailyFriendshipPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(AnimalEntity __instance)
        {
            if (!__instance.IsTamed || __instance.IsBreeding)
            {    
                return true;
            }
            int configValue = ConfigManager.AnimalDailyFriendshipGain!.Value;
            __instance.ChangeFriendship(configValue);
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("AnimalDailyFriendshipPatch: Added " + configValue + " friendship to animal!");
            }
            return false;
        }
    }

    [HarmonyPatch(typeof(AnimalEntity), "set_Sickness")]
    internal class AnimalSicknessPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref AnimalSickness value)
        {
            value = AnimalSickness.None;
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("AnimalSicknessPatch: Sickness set to none!");
            }
            return true;
        }
    }
}
