using BepInEx.Configuration;

namespace UsefullPatches
{
    internal static class ConfigManager
    {
        // ### Categories ###
        private static string cGeneral = "General";
        private static string cFishing = "Fishing";
        private static string cPlayer = "Player";
        private static string cGather = "Gather";
        private static string cField = "Field";
        private static string cNPC = "NPC";

        // ### General ###
        public static ConfigEntry<bool>? EnableMod;
        public static ConfigEntry<bool>? EnableLogging;

        // ### Fishing ###
        public static ConfigEntry<bool>? DisableHitModeDetectionBuildUp;
        public static ConfigEntry<bool>? EnableInstantHitFish;
        public static ConfigEntry<bool>? EnableInstantHookFish;

        // ### Player ###
        public static ConfigEntry<float>? SpeedMultiplier;
        public static ConfigEntry<float>? StaminaConsuption;

        // ### Gather ###
        public static ConfigEntry<int>? MineralYield;
        public static ConfigEntry<int>? WoodYield;
        public static ConfigEntry<bool>? MineralInstantBreak;
        public static ConfigEntry<int>? ToolHardness;
        public static ConfigEntry<bool>? TreeHitReq;
        public static ConfigEntry<bool>? InfiniteWaterTool;

        // ### Field ###
        public static ConfigEntry<bool>? FieldSpawnResource;
        public static ConfigEntry<bool>? FieldSpawnLargeResource;
        public static ConfigEntry<bool>? FieldSpawnTree;
        public static ConfigEntry<bool>? FieldSpawnTallGrass;

        // ### NPC ###
        public static ConfigEntry<bool>? DisableFriendshipDecay; 
        public static ConfigEntry<float>? FriendshipGain;
        

        public static void Init(ConfigFile config)
        {
            // ### General ###
            EnableMod = config.Bind(cGeneral, "EnableMod", true, "Enable or disable the mod.");
            EnableLogging = config.Bind(cGeneral, "EnableLogging", false, "Enable logging.");

            // ### Fishing ###
            DisableHitModeDetectionBuildUp = config.Bind(cFishing, "DisableHitModeDetectionBuildUp", false, "Disables fish detection increase.");
            EnableInstantHitFish = config.Bind(cFishing, "EnableInstantHitFish", false, "Enable instant catch fish in hit minigame.");
            EnableInstantHookFish = config.Bind(cFishing, "EnableInstantHookFish", false, "Enable instant catch fish in hook minigame. !!Experimental!!");

            // ### Player ###
            SpeedMultiplier = config.Bind(cPlayer, "SpeedMultiplier", -1f, "-1 Disabled. Speed is multiplied by your value (speed * value). You can use float numbers (1.2).");
            StaminaConsuption = config.Bind(cPlayer, "StaminaConsumption", -1f, "-1 Disabled. 1 for normal stamina consumption. value < 1 for less consumption (0 for none).\n value > 1 for more consumption. You can use float numbers (1.2).");

            // ### Gather ###
            MineralYield = config.Bind(cGather, "MineralYield", -1, "-1 Disabled. Value is how many extra minerals drop. Only int numbers allowed (1)");
            WoodYield = config.Bind(cGather, "WoodYield", -1, "-1 Disabled. Value is how many extra logs drop. Only int numbers allowed (1)");
            MineralInstantBreak = config.Bind(cGather, "MineralInstantBreak", false, "Enable instant break for minerals. !!Experimental!!");
            ToolHardness = config.Bind(cGather, "ToolHardness", -1, "-1 Disabled. Sets the hardness of the tool to your value. Also seems to lead to instant break at value >= 99.");
            TreeHitReq = config.Bind(cGather, "TreeHitReq", false, "Disable the tool requirement for trees !!Experimental!!");
            InfiniteWaterTool = config.Bind(cGather, "InfiniteWaterTool", false, "Enable infinte water for watertools.");

            // ### Field ###
            FieldSpawnResource = config.Bind(cField, "FieldSpawnResource", false, "Disable resource spawn on field. !!experimental!!");
            FieldSpawnLargeResource = config.Bind(cField, "FieldSpawnLargeResource", false, "Disable large resource spawn on field. !!experimental!!");
            FieldSpawnTree = config.Bind(cField, "FieldSpawnTree", false, "Disable tree spawn on field. !!experimental!!");
            FieldSpawnTallGrass = config.Bind(cField, "FieldSpawnTallGrass", false, "Disable tall grass spawn on field. !!experimental!!");

            // ### NPC ###
            DisableFriendshipDecay = config.Bind(cNPC, "DisableFriendshipDecay", false, "Disable friendship decay.");
            FriendshipGain = config.Bind(cNPC, "FriendshipGain", -1f, "-1 Disabled. Multply the friendship gain (value * friendship gain). You can use float numbers (1.2).");      
        }
    }
}