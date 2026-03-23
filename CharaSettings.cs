using System;
using BepInEx.Configuration;
using static GanExtendDisplay.DisplayConfigBaseClass;

namespace GanExtendDisplay
{
    public static class CharaSettings
    {
        public class CharaConfigClass
        {
            private readonly ConfigClass _charaDisplayLine;

            public CharaConfigClass(string charaDisplayLine, bool charaDisplayLinePCFactionOnly, int size)
            {
                _charaDisplayLine = new ConfigClass(charaDisplayLine);
                CharaDisplayPCFactionOnly = charaDisplayLinePCFactionOnly;
                Size = size;
            }

            public bool CharaDisplayLineOut => _charaDisplayLine.CheckStatus;
            public bool CharaDisplayPCFactionOnly { get; }
            public int Size { get; }
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

        public static void CharaDisplayLine1Config(ConfigFile config) { CharaDisplayLine1 = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line1"), "Keep", new ConfigDescription("Line1: Sex Age [Race Job Ai] ArmorSkill AttackStyle. Options: \"Keep\", \"Hide\", \"Disable\".", new AcceptableValueList<string>("Keep", "Hide", "Disable"))); }
        public static void CharaDisplayLine1PCFactionOnlyConfig(ConfigFile config) { CharaDisplayLine1PCFactionOnly = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line1 PCFactionOnly"), false, new ConfigDescription("Line1: Sex Age [Race Job Ai] ArmorSkill AttackStyle. Options: \"true\", \"false\".")); }
        public static void CharaDisplayLine1SizeConfig(ConfigFile config) { CharaDisplayLine1Size = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line1 Size"), 18, new ConfigDescription("Line1: Sex Age [Race Job Ai] ArmorSkill AttackStyle. Default: \"18\".")); }

        public static void CharaDisplayLine2Config(ConfigFile config) { CharaDisplayLine2 = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line2"), "Keep", new ConfigDescription("Line2: HP DV PV Speed. Options: \"Keep\", \"Hide\", \"Disable\".", new AcceptableValueList<string>("Keep", "Hide", "Disable"))); }
        public static void CharaDisplayLine2PCFactionOnlyConfig(ConfigFile config) { CharaDisplayLine2PCFactionOnly = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line2 PCFactionOnly"), false, new ConfigDescription("Line2: HP DV PV Speed. Options: \"true\", \"false\".", new AcceptableValueList<bool>(true, false))); }
        public static void CharaDisplayLine2SizeConfig(ConfigFile config) { CharaDisplayLine2Size = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line2 Size"), 18, new ConfigDescription("Line2: HP DV PV Speed. Default: \"18\".")); }

        public static void CharaDisplayLine3Config(ConfigFile config) { CharaDisplayLine3 = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line3"), "Hide", new ConfigDescription("Line3: SP Hunger Hobby(s). Options: \"Keep\", \"Hide\", \"Disable\".", new AcceptableValueList<string>("Keep", "Hide", "Disable"))); }
        public static void CharaDisplayLine3PCFactionOnlyConfig(ConfigFile config) { CharaDisplayLine3PCFactionOnly = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line3 PCFactionOnly"), false, new ConfigDescription("Line3: SP Hunger Hobby(s). Options: \"true\", \"false\".", new AcceptableValueList<bool>(true, false))); }
        public static void CharaDisplayLine3SizeConfig(ConfigFile config) { CharaDisplayLine3Size = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line3 Size"), 18, new ConfigDescription("Line3: SP Hunger Hobby(s). Default: \"18\".")); }

        public static void CharaDisplayLine4Config(ConfigFile config) { CharaDisplayLine4 = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line4"), "Hide", new ConfigDescription("Line4: MP Weight EXP. Options: \"Keep\", \"Hide\", \"Disable\".", new AcceptableValueList<string>("Keep", "Hide", "Disable"))); }
        public static void CharaDisplayLine4PCFactionOnlyConfig(ConfigFile config) { CharaDisplayLine4PCFactionOnly = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line4 PCFactionOnly"), false, new ConfigDescription("Line4: MP Weight EXP. Options: \"true\", \"false\".", new AcceptableValueList<bool>(true, false))); }
        public static void CharaDisplayLine4SizeConfig(ConfigFile config) { CharaDisplayLine4Size = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line4 Size"), 18, new ConfigDescription("Line4: MP Weight EXP. Default: \"18\".")); }

        public static void CharaDisplayLineResistConfig(ConfigFile config) { CharaDisplayLineResist = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Resist"), "Hide", new ConfigDescription("LineResist: Resist(s). Options: \"Keep\", \"Hide\", \"Disable\".", new AcceptableValueList<string>("Keep", "Hide", "Disable"))); }
        public static void CharaDisplayLineResistPCFactionOnlyConfig(ConfigFile config) { CharaDisplayLineResistPCFactionOnly = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Resist PCFactionOnly"), false, new ConfigDescription("LineResist: Resist(s). Options: \"true\", \"false\".", new AcceptableValueList<bool>(true, false))); }
        public static void CharaDisplayLineResistSizeConfig(ConfigFile config) { CharaDisplayLineResistSize = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Resist Size"), 14, new ConfigDescription("LineResist: Resist(s). Default: \"14\".")); }

        public static void CharaDisplayLineAttributesConfig(ConfigFile config) { CharaDisplayLineAttributes = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Attributes"), "Hide", new ConfigDescription("LineAttributes: Attributes. Options: \"Keep\", \"Hide\", \"Disable\".", new AcceptableValueList<string>("Keep", "Hide", "Disable"))); }
        public static void CharaDisplayLineAttributesPCFactionOnlyConfig(ConfigFile config) { CharaDisplayLineAttributesPCFactionOnly = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Attributes PCFactionOnly"), false, new ConfigDescription("LineAttributes: Attributes. Default: \"true\", \"false\".", new AcceptableValueList<bool>(true, false))); }
        public static void CharaDisplayLineAttributesSizeConfig(ConfigFile config) { CharaDisplayLineAttributesSize = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Attributes Size"), 14, new ConfigDescription("LineAttributes: Attributes. Default: \"14\".")); }

        public static void CharaDisplayLineFavgiftConfig(ConfigFile config) { CharaDisplayLineFavgift = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Favgift"), "Hide", new ConfigDescription("LineFavgift: Favgift(s).(Even if it is disabled, if you know the preferences of the NPCs, it will still be displayed according to the original) Options: \"Keep\", \"Hide\", \"Disable\".", new AcceptableValueList<string>("Keep", "Hide", "Disable"))); }
        public static void CharaDisplayLineFavgiftPCFactionOnlyConfig(ConfigFile config) { CharaDisplayLineFavgiftPCFactionOnly = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Favgift PCFactionOnly"), false, new ConfigDescription("LineFavgift: Favgift(s).(Even if it is disabled, if you know the preferences of the NPCs, it will still be displayed according to the original) Options: \"true\", \"false\".", new AcceptableValueList<bool>(true, false))); }
        public static void CharaDisplayLineFavgiftSizeConfig(ConfigFile config) { CharaDisplayLineFavgiftSize = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Favgift Size"), 14, new ConfigDescription("LineFavgift: Favgift(s). Default: \"14\".")); }

        public static void CharaDisplayLineActConfig(ConfigFile config) { CharaDisplayLineAct = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Act"), "Hide", new ConfigDescription("LineAct: Act(s). Options: \"Keep\", \"Hide\", \"Disable\".", new AcceptableValueList<string>("Keep", "Hide", "Disable"))); }
        public static void CharaDisplayLineActPCFactionOnlyConfig(ConfigFile config) { CharaDisplayLineActPCFactionOnly = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Act PCFactionOnly"), false, new ConfigDescription("LineAct: Act(s). Options: \"true\", \"false\".", new AcceptableValueList<bool>(true, false))); }
        public static void CharaDisplayLineActSizeConfig(ConfigFile config) { CharaDisplayLineActSize = config.Bind(new ConfigDefinition("Extend Charater Display", "Display Line Act Size"), 14, new ConfigDescription("LineAct: Act(s). Default: \"14\".")); }

        public static CharaConfigClass CharaDisplayLine1Settings = null;
        public static CharaConfigClass CharaDisplayLine2Settings = null;
        public static CharaConfigClass CharaDisplayLine3Settings = null;
        public static CharaConfigClass CharaDisplayLine4Settings = null;
        public static CharaConfigClass CharaDisplayLineResistSettings = null;
        public static CharaConfigClass CharaDisplayLineAttributesSettings = null;
        public static CharaConfigClass CharaDisplayLineFavgiftSettings = null;
        public static CharaConfigClass CharaDisplayLineActSettings = null;
    }
}
