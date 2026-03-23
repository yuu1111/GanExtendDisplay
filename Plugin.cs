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

        /// MOD全体の有効/無効 (Alt+End で切替)
        public static bool ModEnable = true;

        /// Hide設定の表示を一時的に切り替える (Alt押下中に有効)
        public static bool ChangeDisplay;

        private static bool _isAltKeyDown;

        /// Hide設定の表示を維持する (Alt+CapsLock でトグル)
        private static bool _changeDisplayKeep;

        /// キーボード入力によるMOD状態の制御
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
                _isAltKeyDown = true;

            if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
                _isAltKeyDown = false;
                if (!_changeDisplayKeep)
                    ChangeDisplay = false;
            }

            if (_isAltKeyDown)
            {
                if (Input.GetKeyUp(KeyCode.CapsLock))
                    _changeDisplayKeep = !_changeDisplayKeep;
                else
                    ChangeDisplay = true;

                if (Input.GetKeyUp(KeyCode.End))
                    ModEnable = !ModEnable;

                if (Input.GetKeyUp(KeyCode.Home))
                    EClass.debug.showExtra = !EClass.debug.showExtra;
            }

            if (_changeDisplayKeep)
                ChangeDisplay = true;
        }
    }
}
