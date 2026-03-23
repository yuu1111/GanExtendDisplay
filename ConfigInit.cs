using BepInEx.Configuration;

namespace GanExtendDisplay
{
    /// BepInEx設定ファイルへの全設定項目のバインドを一括実行
    public static class ConfigInit
    {
        public static void InitializeConfiguration(ConfigFile config)
        {
            PluginSettings.CharaDisplayConfig(config);
            PluginSettings.InteractDisplayConfig(config);
            PluginSettings.NotificationUiDisplayConfig(config);
            PluginSettings.ThingDisplayConfig(config);
            PluginSettings.EnchantDisplayConfig(config);

            CharaSettings.CharaDisplayLine1Config(config);
            CharaSettings.CharaDisplayLine1PCFactionOnlyConfig(config);
            CharaSettings.CharaDisplayLine1SizeConfig(config);

            CharaSettings.CharaDisplayLine2Config(config);
            CharaSettings.CharaDisplayLine2PCFactionOnlyConfig(config);
            CharaSettings.CharaDisplayLine2SizeConfig(config);

            CharaSettings.CharaDisplayLine3Config(config);
            CharaSettings.CharaDisplayLine3PCFactionOnlyConfig(config);
            CharaSettings.CharaDisplayLine3SizeConfig(config);

            CharaSettings.CharaDisplayLine4Config(config);
            CharaSettings.CharaDisplayLine4PCFactionOnlyConfig(config);
            CharaSettings.CharaDisplayLine4SizeConfig(config);

            CharaSettings.CharaDisplayLineResistConfig(config);
            CharaSettings.CharaDisplayLineResistPCFactionOnlyConfig(config);
            CharaSettings.CharaDisplayLineResistSizeConfig(config);

            CharaSettings.CharaDisplayLineAttributesConfig(config);
            CharaSettings.CharaDisplayLineAttributesPCFactionOnlyConfig(config);
            CharaSettings.CharaDisplayLineAttributesSizeConfig(config);

            CharaSettings.CharaDisplayLineFavgiftConfig(config);
            CharaSettings.CharaDisplayLineFavgiftPCFactionOnlyConfig(config);
            CharaSettings.CharaDisplayLineFavgiftSizeConfig(config);

            CharaSettings.CharaDisplayLineActConfig(config);
            CharaSettings.CharaDisplayLineActPCFactionOnlyConfig(config);
            CharaSettings.CharaDisplayLineActSizeConfig(config);
        }
    }
}
