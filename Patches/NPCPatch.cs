using HarmonyLib;
using SodaDen.Pacha;
using System;

namespace UsefullPatches.Patches
{
    [HarmonyPatch(typeof(NPCController), "UpdateFriendship")]
    internal class FriendshipPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref string with, ref int by, NPCController __instance, ref Friendship ___friendship)
        {
            if (by <= 0)
            {
                return true;
            }

            int oldBy = by;
            by = (int)Math.Ceiling(by * ConfigManager.FriendshipGain!.Value);
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("Current friendship with " + __instance.NPCAsset.Name + " is " + ___friendship.CurrentFriendshipWith(with) + "!");
                UsefullPatchesMain.Log?.LogInfo("Friendship gain increased from " + oldBy + " to " + by + " for " + __instance.NPCAsset.Name + "!");
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Talkable), "TalkedYesterday")]
    internal class TalkedYesterdayPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("TalkedYesterday overwritten!");
            }
            __result = true;
            return false;
        }
    }
}
