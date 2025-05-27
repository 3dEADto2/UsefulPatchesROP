using BepInEx.Configuration;

namespace UsefullPatches
{
    internal static class ConfigManager
    {
        public static ConfigEntry<bool>? EnableMod;
        public static ConfigEntry<bool>? EnableLogging;
        public static ConfigEntry<bool>? DisableHitModeDetectionBuildUp;
        public static ConfigEntry<bool>? EnableInstantHitFish;
        public static ConfigEntry<bool>? EnableInstantHookFish;
        public static ConfigEntry<bool>? DisableFriendshipDecay;
        public static ConfigEntry<float>? SpeedMultiplier;
        public static ConfigEntry<int>? MineralYield;
        public static ConfigEntry<bool>? MineralInstantBreak;
        public static ConfigEntry<bool>? ToolHardness;
        public static ConfigEntry<float>? StaminaConsuption;
        public static ConfigEntry<bool>? TreeHitReq;
        public static ConfigEntry<bool>? InfiniteWaterTool;
        public static ConfigEntry<float>? FriendshipGain;
        public static ConfigEntry<bool>? FieldSpawnResource;
        public static ConfigEntry<bool>? FieldSpawnLargeResource;
        public static ConfigEntry<bool>? FieldSpawnTree;
        public static ConfigEntry<bool>? FieldSpawnTallGrass;

        public static void Init(ConfigFile config)
        {
            EnableMod = config.Bind("General", "EnableMod", true, "Enable or disable the mod.");
            EnableLogging = config.Bind("General", "EnableLogging", false, "Enable logging.");
            DisableHitModeDetectionBuildUp = config.Bind("Fishing", "DisableHitModeDetectionBuildUp", false, "Disables fish detection increase.");
            EnableInstantHitFish = config.Bind("Fishing", "EnableInstantHitFish", false, "Enable instant catch fish in hit minigame.");
            EnableInstantHookFish = config.Bind("Fishing", "EnableInstantHookFish", false, "Enable instant catch fish in hook minigame. !!Experimental!!");
            DisableFriendshipDecay = config.Bind("NPC", "DisableFriendshipDecay", false, "Disable friendship decay.");
            SpeedMultiplier = config.Bind("Player", "SpeedMultiplier", -1f, "-1 Disabled. Speed is multiplied by your value (speed * value). You can use float numbers (1.2).");
            MineralYield = config.Bind("Gather", "MineralYield", -1, "-1 Disabled. Value is how many minerals yield. Only int numbers allowed (1)");
            MineralInstantBreak = config.Bind("Gather", "MineralInstantBreak", false, "Enable instant break for minerals. !!Experimental!!");
            ToolHardness = config.Bind("Gather", "ToolHardness", false, "Sets the hardness of the tool to 99. Also seems to lead to instant break.");
            StaminaConsuption = config.Bind("Player", "StaminaConsumption", -1f, "-1 Disabled. 1 for normal stamina consumption. value < 1 for less consumption (0 for none).\n value > 1 for more consumption. You can use float numbers (1.2).");
            TreeHitReq = config.Bind("Gather", "TreeHitReq", false, "Disable the tool requirement for trees !!Experimental!!");
            InfiniteWaterTool = config.Bind("Gather", "InfiniteWaterTool", false, "Enable infinte water for watertools.");
            FriendshipGain = config.Bind("NPC", "FriendshipGain", -1f, "-1 Disabled. Multply the friendship gain (value * friendship gain). You can use float numbers (1.2).");
            FieldSpawnResource = config.Bind("Field", "FieldSpawnResource", false, "Disable resource spawn on field. !!experimental!!");
            FieldSpawnLargeResource = config.Bind("Field", "FieldSpawnLargeResource", false, "Disable large resource spawn on field. !!experimental!!");
            FieldSpawnTree = config.Bind("Field", "FieldSpawnTree", false, "Disable tree spawn on field. !!experimental!!");
            FieldSpawnTallGrass = config.Bind("Field", "FieldSpawnTallGrass", false, "Disable tall grass spawn on field. !!experimental!!");
        }
    }
}