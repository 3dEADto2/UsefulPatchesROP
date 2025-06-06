using HarmonyLib;
using SodaDen.Pacha;

namespace UsefullPatches.Patches
{
    [HarmonyPatch(typeof(AnimalEntity), "UpdateFriendshipAtStartOfDay")]
    internal class AnimalDailyFriendshipPatch
    {
        [HarmonyPostfix]
        public static void Postfix(AnimalEntity __instance)
        {
            int configValue = 0;
            string animal = "undefined animal";

            if (!(__instance.IsTamed || __instance.IsPet) || __instance.IsBreeding)
            {
                return;
            }

            if (__instance.IsTamed && ConfigManager.AnimalDailyFriendshipGain!.Value > 0)
            {
                configValue = ConfigManager.AnimalDailyFriendshipGain!.Value;
                animal = "tamed animal";
            }

            if (__instance.IsPet && ConfigManager.PetDailyFriendshipGain!.Value > 0)
            {
                configValue = ConfigManager.PetDailyFriendshipGain!.Value;
                animal = "pet";
            }

            if (configValue <= 0)
            {
                return;
            }

            __instance.ChangeFriendship(configValue);
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("AnimalDailyFriendshipPatch: Added " + configValue + " friendship to " + animal + "!");
            }
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
