using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using static GanExtendDisplay.CharaSettings;

namespace GanExtendDisplay
{
    [BepInPlugin("ExtendDisplay", "ExtendDisplay", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        private void Awake()
        {
            Logger = base.Logger;
            Logger.LogInfo("Initializing configuration for [ Gan Extend Display ] plugin...");
            ConfigInit.InitializeConfiguration(Config);
            Logger.LogInfo("Successfully initialized configuration for [ Gan Extend Display ] plugin.");
        }

        private void Start()
        {
            CharaDisplayLine1Settings = new CharaConfigClass(CharaDisplayLine1.Value, CharaDisplayLine1PCFactionOnly.Value, CharaDisplayLine1Size.Value);
            CharaDisplayLine2Settings = new CharaConfigClass(CharaDisplayLine2.Value, CharaDisplayLine2PCFactionOnly.Value, CharaDisplayLine2Size.Value);
            CharaDisplayLine3Settings = new CharaConfigClass(CharaDisplayLine3.Value, CharaDisplayLine3PCFactionOnly.Value, CharaDisplayLine3Size.Value);
            CharaDisplayLine4Settings = new CharaConfigClass(CharaDisplayLine4.Value, CharaDisplayLine4PCFactionOnly.Value, CharaDisplayLine4Size.Value);
            CharaDisplayLineResistSettings = new CharaConfigClass(CharaDisplayLineResist.Value, CharaDisplayLineResistPCFactionOnly.Value, CharaDisplayLineResistSize.Value);
            CharaDisplayLineAttributesSettings =
                new CharaConfigClass(CharaDisplayLineAttributes.Value, CharaDisplayLineAttributesPCFactionOnly.Value, CharaDisplayLineAttributesSize.Value);
            CharaDisplayLineFavgiftSettings =
                new CharaConfigClass(CharaDisplayLineFavgift.Value, CharaDisplayLineFavgiftPCFactionOnly.Value, CharaDisplayLineFavgiftSize.Value);
            CharaDisplayLineActSettings = new CharaConfigClass(CharaDisplayLineAct.Value, CharaDisplayLineActPCFactionOnly.Value, CharaDisplayLineActSize.Value);
            if (PluginSettings.CharaDisplay.Value != "Disable")
            {
                Harmony.CreateAndPatchAll(typeof(CharaDisplayPatch));
            }

            if (PluginSettings.ThingDisplay.Value != "Disable")
            {
                Harmony.CreateAndPatchAll(typeof(ThingDisplayPatch));
            }

            if (PluginSettings.InteractDisplay.Value != "Disable")
            {
                Harmony.CreateAndPatchAll(typeof(InteractDisplayPatch));
            }

            if (PluginSettings.NotificationUI.Value != "Disable")
            {
                Harmony.CreateAndPatchAll(typeof(NotificationUIPatch));
            }

            if (PluginSettings.EnchantDisplay.Value != "Disable")
            {
                Harmony.CreateAndPatchAll(typeof(EnchantDisplayPatch));
            }

            Logger.LogInfo("Successfully applied patches for [ Gan Extend Display ] plugin.");
        }

        public static bool ModEnable = true;
        public static bool IsAltKeyDown;
        public static bool ChangeDisplay;
        public static bool ChangeDisplayKeep;

        private void Update()
        {
            // 检测LeftAlt键是否被按下
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                IsAltKeyDown = true;
            }

            // 检测LeftAlt键是否松开，如果松开了，将相关变量重置
            if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
                IsAltKeyDown = false;
                if (!ChangeDisplayKeep)
                {
                    ChangeDisplay = false;
                }
            }

            if (IsAltKeyDown)
            {
                if (Input.GetKeyUp(KeyCode.CapsLock))
                {
                    ChangeDisplayKeep = !ChangeDisplayKeep;
                }
                else
                {
                    ChangeDisplay = true;
                }

                if (Input.GetKeyUp(KeyCode.End))
                {
                    ModEnable = !ModEnable;
                }

                if (Input.GetKeyUp(KeyCode.Home))
                {
                    EClass.debug.showExtra = !EClass.debug.showExtra;
                }
            }

            //保持显示
            if (ChangeDisplayKeep)
            {
                ChangeDisplay = true;
            }

        }
    }
}
