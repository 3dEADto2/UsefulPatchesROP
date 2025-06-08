using HarmonyLib;
using SodaDen.Pacha;

namespace UsefullPatches.Patches
{

    [HarmonyPatch(typeof(ScoreEntityItemsObtained), "AddItem")]
    internal class ItemExperiencePatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref InventoryItemWithProperties item, ref int q, ref ItemObtainedSource source)
        {
            if (source != ItemObtainedSource.Fished && source != ItemObtainedSource.Harvested)
            {
                return true;
            }

            if (source == ItemObtainedSource.Fished && ConfigManager.FishingExperienceIncrease!.Value > 0)
            {
                q *= ConfigManager.FishingExperienceIncrease!.Value;
                if (ConfigManager.EnableLogging!.Value)
                {
                    UsefullPatchesMain.Log?.LogInfo("ItemExperiencePatch: Fish " + item.Name + " got " + q + " to its obtained count added! (source: " + source + ")");
                }
            }
            if (source == ItemObtainedSource.Harvested && ConfigManager.FarmingExperienceIncrease!.Value > 0)
            {
                q *= ConfigManager.FarmingExperienceIncrease!.Value;
                if (ConfigManager.EnableLogging!.Value)
                {
                    UsefullPatchesMain.Log?.LogInfo("ItemExperiencePatch: Item " + item.Name + " got " + q + " to its obtained count added! (source: " + source + ")");
                }
            }

            return true;
        }
    }
}
