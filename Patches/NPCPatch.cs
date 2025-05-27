using HarmonyLib;
using SodaDen.Pacha;
using System;

namespace UsefullPatches.Patches
{
    [HarmonyPatch(typeof(Friendship), "UpdateFriendship")]
    internal class FriendshipPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref string with, ref int by)
        {
            int oldBy = by;
            by = (int)Math.Ceiling(by * ConfigManager.FriendshipGain!.Value);
            if (ConfigManager.EnableLogging!.Value)
            {
                UsefullPatchesMain.Log?.LogInfo("Friendship gain increased from " + oldBy + " to " + by + "!");
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
