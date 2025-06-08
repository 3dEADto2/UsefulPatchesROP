using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SodaDen.Pacha;
using System.Reflection;
using UnityEngine;
using UsefullPatches.Patches;

namespace UsefullPatches
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    [BepInProcess("Roots of Pacha.exe")]
    public class UsefullPatchesMain : BaseUnityPlugin
    {
        private const string pluginGUID = "3dEADto.UsefullPatches";
        private const string pluginName = "Usefull Patches";
        private const string pluginVersion = "1.4.0";
        private readonly Harmony harmony = new Harmony(pluginGUID);

        private static UsefullPatchesMain? Instance;
        internal static ManualLogSource? Log;

        void Awake()
        {
            Log = BepInEx.Logging.Logger.CreateLogSource(pluginGUID);
            Log.LogInfo("UsefullPatches loaded!");

            ConfigManager.Init(Config);

            if (ConfigManager.EnableMod == null)
            {
                Log.LogInfo("Could not load config. Mod disabled!");
                return;
            }

            if (!ConfigManager.EnableMod!.Value)
            {
                Log.LogInfo("UsefullPatches is disabled!");
                return;
            }

            if (Instance == null) { 
                Instance = this;
            }

            // ### Shared Patches ###
            if (ConfigManager.FishingExperienceIncrease!.Value > 0 || ConfigManager.FarmingExperienceIncrease!.Value > 0)
            {
                harmony.PatchAll(typeof(ItemExperiencePatch));
            }

            // ### Animal ###
            if (ConfigManager.AnimalDailyFriendshipGain!.Value > 0 || ConfigManager.PetDailyFriendshipGain!.Value > 0)
            {
                harmony.PatchAll(typeof(AnimalDailyFriendshipPatch));
            }

            if (ConfigManager.DisableAnimalSickness!.Value)
            {
                harmony.PatchAll(typeof(AnimalSicknessPatch));
            }

            harmony.PatchAll(typeof(AnimalSicknessPatch));

            // ### Fishing ###
            if (ConfigManager.EnableInstantHookFish!.Value)
            {
                harmony.PatchAll(typeof(HookModeInstantPull));
            }

            if (ConfigManager.HitModeFocusBuildUp!.Value >= 0)
            {
                harmony.PatchAll(typeof(HitModeAdjustFocusValue));
            }

            if (ConfigManager.HitModeTensionBuildUp!.Value >= 0)
            {
                harmony.PatchAll(typeof(HitModeAdjustTensionValue));
            }

            if (ConfigManager.HitModeDetectionBuildUp!.Value >= 0)
            {
                harmony.PatchAll(typeof(HitModeAdjustdDetectionValue));
            }

            // ### Player ###
            if (ConfigManager.SpeedMultiplier!.Value > 0)
            {
                harmony.PatchAll(typeof(SpeedPatch));
            }

            if(ConfigManager.StaminaConsuption!.Value >= 0)
            {
                harmony.PatchAll(typeof(StaminaPatch));
            }

            // ### Gather ###
            if (ConfigManager.TreeHitReq!.Value)
            {
                harmony.PatchAll(typeof(TreeHitPatch));
            }

            if(ConfigManager.InfiniteWaterTool!.Value)
            {
                harmony.PatchAll(typeof(InfiniteWaterTool));
            }

            if (ConfigManager.ToolHardness!.Value > 0)
            {
                harmony.PatchAll(typeof(ToolHardnessPatch));
            }

            if (ConfigManager.MineralYield!.Value > 0)
            {
                harmony.PatchAll(typeof(OreYieldPatch));
            }

            if (ConfigManager.MineralInstantBreak!.Value)
            {
                harmony.PatchAll(typeof(OreInstantBreakPatch));
            }

            if (ConfigManager.WoodYield!.Value > 0)
            {
                harmony.PatchAll(typeof(WoodYieldPatch));
            }

            // ### Field ###
            if (ConfigManager.FieldSpawnResource!.Value)
            {
                harmony.PatchAll(typeof(FieldSpawnResourcePatch));
            }

            if (ConfigManager.FieldSpawnLargeResource!.Value)
            {
                harmony.PatchAll(typeof(FieldSpawnLargeResourcePatch));
            }

            if (ConfigManager.FieldSpawnTree!.Value)
            {
                harmony.PatchAll(typeof(FieldSpawnTreePatch));
            }

            if (ConfigManager.FieldSpawnTallGrass!.Value)
            {
                harmony.PatchAll(typeof(FieldSpawnTallGrassPatch));
            }
            
            // ### NPC ###
            if(ConfigManager.FriendshipGain!.Value > 0)
            {
                harmony.PatchAll(typeof(FriendshipPatch));
            }

            if (ConfigManager.DisableFriendshipDecay!.Value)
            {
                harmony.PatchAll(typeof(TalkedYesterdayPatch));
            }
        }
    }
}
