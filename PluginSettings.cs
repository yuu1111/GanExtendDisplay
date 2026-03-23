using BepInEx.Configuration;

namespace GanExtendDisplay
{
    /// MOD全体の表示機能ごとの有効/無効設定 (BepInEx設定ファイルにバインド)
    public static class PluginSettings
    {
        public static ConfigEntry<string> CharaDisplay;
        public static ConfigEntry<string> ThingDisplay;
        public static ConfigEntry<string> InteractDisplay;
        public static ConfigEntry<string> NotificationUI;
        public static ConfigEntry<string> EnchantDisplay;

        public static void CharaDisplayConfig(ConfigFile config)
        {
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            CharaDisplay = config.Bind(
                new ConfigDefinition("Affected Display", "Character Display"), "Keep",
                new ConfigDescription("Affect how additional information is displayed when the mouse hovers over a character. Options: \"Keep\", \"Hide\", \"Disable\".", acceptableValues));
        }

        public static void ThingDisplayConfig(ConfigFile config)
        {
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ThingDisplay = config.Bind(
                new ConfigDefinition("Affected Display", "Thing Display"), "Keep",
                new ConfigDescription("Affect the display mode of additional information (level, rarity, material) when the mouse hovers over items on the ground. Options: \"Keep\", \"Hide\", \"Disable\"", acceptableValues));
        }

        public static void EnchantDisplayConfig(ConfigFile config)
        {
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            EnchantDisplay = config.Bind(
                new ConfigDefinition("Affected Display", "Enchant Display"), "Keep",
                new ConfigDescription("Affect the display mode of additional information (enchantment entries) when the mouse hovers over equipment and DNA. Options: \"Keep\", \"Hide\", \"Disable\"", acceptableValues));
        }

        public static void InteractDisplayConfig(ConfigFile config)
        {
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            InteractDisplay = config.Bind(
                new ConfigDefinition("Affected Display", "Interact Display"), "Keep",
                new ConfigDescription("Affect how additional information (enchantment entries) is displayed when the mouse hovers over an item in the backpack. Options: \"Keep\", \"Hide\", \"Disable\"", acceptableValues));
        }

        public static void NotificationUiDisplayConfig(ConfigFile config)
        {
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            NotificationUI = config.Bind(
                new ConfigDefinition("Affected Display", "Notification UI Display"), "Keep",
                new ConfigDescription("Affect how additional information is displayed when interacting with the controls for character status and buff notifications in the UI interface. Options: \"Keep\", \"Hide\", \"Disable\"", acceptableValues));
        }
    }
}
