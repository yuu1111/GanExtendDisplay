using System;
using BepInEx.Configuration;
using static GanExtendDisplay.DisplayConfigBaseClass;

namespace GanExtendDisplay
{
    public class DisplayConfigBaseClass
    {
        public enum DisplayOption
        {
            Keep,
            Hide,
            Disable
        }

        public static DisplayOption StringToDisplayOption(string value)
        {
            if (Enum.TryParse(value, out DisplayOption result))
            {
                return result;
            }

            // 如果解析失败，返回默认值 Keep
            return DisplayOption.Keep;
        }

        //通过获取配置得到本地变量缓存
        public class ConfigClass
        {
            //父类
            public DisplayOption OptionStatus { get; set; }

            public ConfigClass(String option)
            {
                // 初始化 DisplayOption 属性
                OptionStatus = StringToDisplayOption(option);
            }

            public bool CheckStatus
            {
                get
                {
                    // 默认显示内容
                    if (OptionStatus == DisplayOption.Keep)
                    {
                        return true;
                    }

                    //按下按键，显示隐藏内容
                    if (Main.ChangeDisplay)
                    {
                        if (OptionStatus == DisplayOption.Hide)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }
    }

    public class PluginSettings
    {
        public static ConfigEntry<String> CharaDisplay;
        public static ConfigEntry<String> ThingDisplay;
        public static ConfigEntry<String> InteractDisplay;
        public static ConfigEntry<String> NotificationUI;
        public static ConfigEntry<String> EnchantDisplay;

        public static void CharaDisplayConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Affected Display", "Character Display");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription =
                new ConfigDescription("Affect how additional information is displayed when the mouse hovers over a character. Options: \"Keep\", \"Hide\", \"Disable\".", acceptableValues);
            CharaDisplay = config.Bind(configDefinition, "Keep", configDescription);
        }

        public static void ThingDisplayConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Affected Display", "Thing Display");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription =
                new ConfigDescription(
                    "Affect the display mode of additional information (level, rarity, material) when the mouse hovers over items on the ground. Options: \"Keep\", \"Hide\", \"Disable\"",
                    acceptableValues);
            ThingDisplay = config.Bind(configDefinition, "Keep", configDescription);
        }

        public static void EnchantDisplayConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Affected Display", "Enchant Display");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription =
                new ConfigDescription(
                    "Affect the display mode of additional information (enchantment entries) when the mouse hovers over equipment and DNA. Options: \"Keep\", \"Hide\", \"Disable\"",
                    acceptableValues);
            EnchantDisplay = config.Bind(configDefinition, "Keep", configDescription);
        }

        public static void InteractDisplayConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Affected Display", "Interact Display");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription =
                new ConfigDescription(
                    "Affect how additional information (enchantment entries) is displayed when the mouse hovers over an item in the backpack. Options: \"Keep\", \"Hide\", \"Disable\"",
                    acceptableValues);
            InteractDisplay = config.Bind(configDefinition, "Keep", configDescription);
        }

        public static void NotificationUiDisplayConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Affected Display", "Notification UI Display");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription =
                new ConfigDescription(
                    "Affect how additional information is displayed when interacting with the controls for character status and buff notifications in the UI interface. Options: \"Keep\", \"Hide\", \"Disable\"",
                    acceptableValues);
            NotificationUI = config.Bind(configDefinition, "Keep", configDescription);
        }
    }

    public class CharaSettings
    {
        public class CharaConfigClass
        {
            private ConfigClass _charaDisplayLine;
            private bool _charaDisplayPCFactionOnly;
            private int _size;

            // 构造函数，用于初始化父类属性和新增属性
            public CharaConfigClass(string charaDisplayLine, bool charaDisplayLine1PCFactionOnly, int size)
            {
                _charaDisplayLine = new ConfigClass(charaDisplayLine);
                _charaDisplayPCFactionOnly = charaDisplayLine1PCFactionOnly;
                _size = size;
            }

            // 新增属性访问器 CharaDisplayLine1PCFactionOnly
            public bool CharaDisplayLineOut
            {
                get { return _charaDisplayLine.CheckStatus; }
            }

            // 新增属性访问器 CharaDisplayLine1PCFactionOnly
            public bool CharaDisplayPCFactionOnly
            {
                get { return _charaDisplayPCFactionOnly; }
            }

            // 新增属性访问器 Size
            public int Size
            {
                get { return _size; }
            }
        }

        public static ConfigEntry<String> CharaDisplayLine1;
        public static ConfigEntry<bool> CharaDisplayLine1PCFactionOnly;
        public static ConfigEntry<int> CharaDisplayLine1Size;

        public static ConfigEntry<String> CharaDisplayLine2;
        public static ConfigEntry<bool> CharaDisplayLine2PCFactionOnly;
        public static ConfigEntry<int> CharaDisplayLine2Size;

        public static ConfigEntry<String> CharaDisplayLine3;
        public static ConfigEntry<bool> CharaDisplayLine3PCFactionOnly;
        public static ConfigEntry<int> CharaDisplayLine3Size;

        public static ConfigEntry<String> CharaDisplayLine4;
        public static ConfigEntry<bool> CharaDisplayLine4PCFactionOnly;
        public static ConfigEntry<int> CharaDisplayLine4Size;

        public static ConfigEntry<String> CharaDisplayLineResist;
        public static ConfigEntry<bool> CharaDisplayLineResistPCFactionOnly;
        public static ConfigEntry<int> CharaDisplayLineResistSize;

        public static ConfigEntry<String> CharaDisplayLineAttributes;
        public static ConfigEntry<bool> CharaDisplayLineAttributesPCFactionOnly;
        public static ConfigEntry<int> CharaDisplayLineAttributesSize;

        public static ConfigEntry<String> CharaDisplayLineFavgift;
        public static ConfigEntry<bool> CharaDisplayLineFavgiftPCFactionOnly;
        public static ConfigEntry<int> CharaDisplayLineFavgiftSize;

        public static ConfigEntry<String> CharaDisplayLineAct;
        public static ConfigEntry<bool> CharaDisplayLineActPCFactionOnly;
        public static ConfigEntry<int> CharaDisplayLineActSize;

        //line1
        public static void CharaDisplayLine1Config(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line1");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription = new ConfigDescription("Line1: Sex Age [Race Job Ai] ArmorSkill AttackStyle. Options: \"Keep\", \"Hide\", \"Disable\".", acceptableValues);
            CharaDisplayLine1 = config.Bind(configDefinition, "Keep", configDescription);

        }

        public static void CharaDisplayLine1PCFactionOnlyConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line1 PCFactionOnly");
            ConfigDescription configDescription = new ConfigDescription("Line1: Sex Age [Race Job Ai] ArmorSkill AttackStyle. Options: \"true\", \"false\".");
            CharaDisplayLine1PCFactionOnly = config.Bind(configDefinition, false, configDescription);
        }

        public static void CharaDisplayLine1SizeConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line1 Size");
            ConfigDescription configDescription = new ConfigDescription("Line1: Sex Age [Race Job Ai] ArmorSkill AttackStyle. Default: \"18\".");
            CharaDisplayLine1Size = config.Bind(configDefinition, 18, configDescription);
        }

        //line2 
        public static void CharaDisplayLine2Config(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line2");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription = new ConfigDescription("Line2: HP DV PV Speed. Options: \"Keep\", \"Hide\", \"Disable\".", acceptableValues);
            CharaDisplayLine2 = config.Bind(configDefinition, "Keep", configDescription);
        }

        public static void CharaDisplayLine2PCFactionOnlyConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line2 PCFactionOnly");
            var acceptableValues = new AcceptableValueList<bool>(true, false);
            ConfigDescription configDescription = new ConfigDescription("Line2: HP DV PV Speed. Options: \"true\", \"false\".", acceptableValues);
            CharaDisplayLine2PCFactionOnly = config.Bind(configDefinition, false, configDescription);
        }

        public static void CharaDisplayLine2SizeConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line2 Size");
            ConfigDescription configDescription = new ConfigDescription("Line2: HP DV PV Speed. Default: \"18\".");
            CharaDisplayLine2Size = config.Bind(configDefinition, 18, configDescription);
        }

        //line3
        public static void CharaDisplayLine3Config(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line3");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription = new ConfigDescription("Line3: SP Hunger Hobby(s). Options: \"Keep\", \"Hide\", \"Disable\".", acceptableValues);
            CharaDisplayLine3 = config.Bind(configDefinition, "Hide", configDescription);
        }

        public static void CharaDisplayLine3PCFactionOnlyConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line3 PCFactionOnly");
            var acceptableValues = new AcceptableValueList<bool>(true, false);
            ConfigDescription configDescription = new ConfigDescription("Line3: SP Hunger Hobby(s). Options: \"true\", \"false\".", acceptableValues);
            CharaDisplayLine3PCFactionOnly = config.Bind(configDefinition, false, configDescription);
        }

        public static void CharaDisplayLine3SizeConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line3 Size");
            ConfigDescription configDescription = new ConfigDescription("Line3: SP Hunger Hobby(s). Default: \"18\".");
            CharaDisplayLine3Size = config.Bind(configDefinition, 18, configDescription);
        }

        //line4
        public static void CharaDisplayLine4Config(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line4");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription = new ConfigDescription("Line4: MP Weight EXP. Options: \"Keep\", \"Hide\", \"Disable\".", acceptableValues);
            CharaDisplayLine4 = config.Bind(configDefinition, "Hide", configDescription);
        }

        public static void CharaDisplayLine4PCFactionOnlyConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line4 PCFactionOnly");
            var acceptableValues = new AcceptableValueList<bool>(true, false);
            ConfigDescription configDescription = new ConfigDescription("Line4: MP Weight EXP. Options: \"true\", \"false\".", acceptableValues);
            CharaDisplayLine4PCFactionOnly = config.Bind(configDefinition, false, configDescription);
        }

        public static void CharaDisplayLine4SizeConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line4 Size");
            ConfigDescription configDescription = new ConfigDescription("Line4: MP Weight EXP.  Default: \"18\".");
            CharaDisplayLine4Size = config.Bind(configDefinition, 18, configDescription);
        }

        //LineResist
        public static void CharaDisplayLineResistConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Resist");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription = new ConfigDescription("LineResist: Resist(s). Options: \"Keep\", \"Hide\", \"Disable\".", acceptableValues);
            CharaDisplayLineResist = config.Bind(configDefinition, "Hide", configDescription);
        }

        public static void CharaDisplayLineResistPCFactionOnlyConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Resist PCFactionOnly");
            var acceptableValues = new AcceptableValueList<bool>(true, false);
            ConfigDescription configDescription = new ConfigDescription("LineResist: Resist(s). Options: \"true\", \"false\".", acceptableValues);
            CharaDisplayLineResistPCFactionOnly = config.Bind(configDefinition, false, configDescription);
        }

        public static void CharaDisplayLineResistSizeConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Resist Size");
            ConfigDescription configDescription = new ConfigDescription("LineResist: Resist(s).  Default: \"14\".");
            CharaDisplayLineResistSize = config.Bind(configDefinition, 14, configDescription);
        }

        //LineAttributes
        public static void CharaDisplayLineAttributesConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Attributes");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription = new ConfigDescription("LineAttributes: Attributes. Options: \"Keep\", \"Hide\", \"Disable\".", acceptableValues);
            CharaDisplayLineAttributes = config.Bind(configDefinition, "Hide", configDescription);
        }

        public static void CharaDisplayLineAttributesPCFactionOnlyConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Attributes PCFactionOnly");
            var acceptableValues = new AcceptableValueList<bool>(true, false);
            ConfigDescription configDescription = new ConfigDescription("LineAttributes: Attributes. Default: \"true\", \"false\".", acceptableValues);
            CharaDisplayLineAttributesPCFactionOnly = config.Bind(configDefinition, false, configDescription);
        }

        public static void CharaDisplayLineAttributesSizeConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Attributes Size");
            ConfigDescription configDescription = new ConfigDescription("LineAttributes: Attributes.  Default: \"14\".");
            CharaDisplayLineAttributesSize = config.Bind(configDefinition, 14, configDescription);
        }

        //LineFavgift
        public static void CharaDisplayLineFavgiftConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Favgift");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription =
                new ConfigDescription(
                    "LineFavgift: Favgift(s).(Even if it is disabled, if you know the preferences of the NPCs, it will still be displayed according to the original) Options: \"Keep\", \"Hide\", \"Disable\".",
                    acceptableValues);
            CharaDisplayLineFavgift = config.Bind(configDefinition, "Hide", configDescription);
        }

        public static void CharaDisplayLineFavgiftPCFactionOnlyConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Favgift PCFactionOnly");
            var acceptableValues = new AcceptableValueList<bool>(true, false);
            ConfigDescription configDescription =
                new ConfigDescription(
                    "LineFavgift: Favgift(s).(Even if it is disabled, if you know the preferences of the NPCs, it will still be displayed according to the original) Options: \"true\", \"false\".",
                    acceptableValues);
            CharaDisplayLineFavgiftPCFactionOnly = config.Bind(configDefinition, false, configDescription);
        }

        public static void CharaDisplayLineFavgiftSizeConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Favgift Size");
            ConfigDescription configDescription = new ConfigDescription("LineFavgift: Favgift(s).  Default: \"14\".");
            CharaDisplayLineFavgiftSize = config.Bind(configDefinition, 14, configDescription);
        }

        //LineAct
        public static void CharaDisplayLineActConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Act");
            var acceptableValues = new AcceptableValueList<string>("Keep", "Hide", "Disable");
            ConfigDescription configDescription = new ConfigDescription("LineAct: Act(s). Options: \"Keep\", \"Hide\", \"Disable\".", acceptableValues);
            CharaDisplayLineAct = config.Bind(configDefinition, "Hide", configDescription);
        }

        public static void CharaDisplayLineActPCFactionOnlyConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Act PCFactionOnly");
            var acceptableValues = new AcceptableValueList<bool>(true, false);
            ConfigDescription configDescription = new ConfigDescription("LineAct: Act(s). Options: \"true\", \"false\".", acceptableValues);
            CharaDisplayLineActPCFactionOnly = config.Bind(configDefinition, false, configDescription);
        }

        public static void CharaDisplayLineActSizeConfig(ConfigFile config)
        {
            ConfigDefinition configDefinition = new ConfigDefinition("Extend Charater Display", "Display Line Act Size");
            ConfigDescription configDescription = new ConfigDescription("LineAct: Favgift(s).  Default: \"14\".");
            CharaDisplayLineActSize = config.Bind(configDefinition, 14, configDescription);
        }


        public static CharaConfigClass CharaDisplayLine1Settings = null;
        public static CharaConfigClass CharaDisplayLine2Settings = null;
        public static CharaConfigClass CharaDisplayLine3Settings = null;
        public static CharaConfigClass CharaDisplayLine4Settings = null;
        public static CharaConfigClass CharaDisplayLineResistSettings = null;
        public static CharaConfigClass CharaDisplayLineAttributesSettings = null;
        public static CharaConfigClass CharaDisplayLineFavgiftSettings = null;
        public static CharaConfigClass CharaDisplayLineActSettings = null;
    }

    public class ConfigInit
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
