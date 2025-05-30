using BepInEx.Configuration;

namespace UsefullPatches
{
    internal static class ConfigManager
    {
        // ### Categories ###
        private static string cGeneral = "General";
        private static string cAnimal = "Animal";
        private static string cFishing = "Fishing";
        private static string cPlayer = "Player";
        private static string cGather = "Gather";
        private static string cField = "Field";
        private static string cNPC = "NPC";

        // ### General ###
        public static ConfigEntry<bool>? EnableMod;
        public static ConfigEntry<bool>? EnableLogging;

        // ### Animal ###
        public static ConfigEntry<int>? AnimalDailyFriendshipGain;

        // ### Fishing ###
        public static ConfigEntry<bool>? EnableInstantHookFish;
        public static ConfigEntry<float>? HitModeFocusBuildUp;
        public static ConfigEntry<float>? HitModeTensionBuildUp;
        public static ConfigEntry<float>? HitModeDetectionBuildUp;

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
            EnableMod = config.Bind(cGeneral, "EnableMod", true, " Enable or disable the mod.");
            EnableLogging = config.Bind(cGeneral, "EnableLogging", false, " Enable logging.");

            // ### Animal ###
            AnimalDailyFriendshipGain = config.Bind(cAnimal, "AnimalDailyFriendshipGain", -1, " Adds daily friendship gain to animals.\n value of 20 would be equal to feeding the animals with grain\n -1 Disabled.\n Use int numbers (1).");

            // ### Fishing ###
            EnableInstantHookFish = config.Bind(cFishing, "EnableInstantHookFish", false, " Enable instant catch fish in hook minigame. !!Experimental!!");
            HitModeFocusBuildUp = config.Bind(cFishing, "HitModeFocusBuildUp", -1f, " Adjust hit fishing minigame focus increase.\n -1 Disabled.\n 0 Instant Catch.\n value < 1f = slower increase.\n value > 1f = faster.\n Calculation is focusValue * yourValue.\n Use float numbers (1.0).");
            HitModeTensionBuildUp = config.Bind(cFishing, "HitModeTensionBuildUp", -1f, " Adjust hit fishing minigame tension increase.\n -1 Disabled.\n 0 Disable tension build up.\n value < 1f = slower increase.\n value > 1f = faster.\n Calculation is tensionValue * yourValue.\n Use float numbers (1.0).");
            HitModeDetectionBuildUp = config.Bind(cFishing, "HitModeDetectionBuildUp", -1f, " Adjust hit fishing minigame detection increase.\n -1 Disabled.\n 0 Disable detection build up.\n value < 1.0f = slower increase.\n value > 1f = faster.\n Calculation is detectionValue * yourValue.\n Use float numbers (1.0).");

            // ### Player ###
            SpeedMultiplier = config.Bind(cPlayer, "SpeedMultiplier", -1f, " Increase/Decrease player speed.\n -1 Disabled.\n value > 1f = faster.\n value < 1f = slower.\n Calculation is speed * yourValue.\n Use float numbers (1.0).");
            StaminaConsuption = config.Bind(cPlayer, "StaminaConsumption", -1f, " Increase/Decrease player stamina consumption.\n -1 Disabled.\n 0 for infinte stamina.\n value > 1f = more consumption.\n value < 1f less consumption.\n Calculation is staminaDecrease * yourValue.\n Use float numbers (1.0).");

            // ### Gather ###
            MineralYield = config.Bind(cGather, "MineralYield", -1, " How many extra minerals drop.\n -1 Disabled.\n Use int numbers (1).");
            WoodYield = config.Bind(cGather, "WoodYield", -1, " How many extra logs drop.\n -1 Disabled.\n Use int numbers (1).");
            MineralInstantBreak = config.Bind(cGather, "MineralInstantBreak", false, " Enable instant break for minerals. !!Experimental!!");
            ToolHardness = config.Bind(cGather, "ToolHardness", -1, " Sets the hardness of tools.\n High numbers lead to instant break/chop.\n -1 Disabled.\n Use int numbers (1).");
            TreeHitReq = config.Bind(cGather, "TreeHitReq", false, " Disable the tool requirement for trees !!Experimental!!");
            InfiniteWaterTool = config.Bind(cGather, "InfiniteWaterTool", false, " Enable infinte water for watertools.");

            // ### Field ###
            FieldSpawnResource = config.Bind(cField, "FieldSpawnResource", false, " Disable resource spawn on field. !!experimental!!");
            FieldSpawnLargeResource = config.Bind(cField, "FieldSpawnLargeResource", false, " Disable large resource spawn on field. !!experimental!!");
            FieldSpawnTree = config.Bind(cField, "FieldSpawnTree", false,  "Disable tree spawn on field. !!experimental!!");
            FieldSpawnTallGrass = config.Bind(cField, "FieldSpawnTallGrass", false, " Disable tall grass spawn on field. !!experimental!!");

            // ### NPC ###
            DisableFriendshipDecay = config.Bind(cNPC, "DisableFriendshipDecay", false, " Disable friendship decay.");
            FriendshipGain = config.Bind(cNPC, "FriendshipGain", -1f, " Increase/Decrease friendship gain.\n -1 Disabled.\n value > 1f = more friendship gain.\n value < 1f = less friendship gain.\n Calculation is friendshipAddValue * yourValue.\n Use float numbers (1.0).");      
        }
    }
}