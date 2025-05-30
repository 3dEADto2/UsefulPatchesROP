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

            __instance.ChangeFriendship(1000);
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("AnimalDailyFriendshipPatch: Added " + 1000 + " friendship to animal!");
            }
            return false;
        }
    }
}
