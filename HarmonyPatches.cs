// ReSharper disable InconsistentNaming

using System;
using HarmonyLib;
using static GanExtendDisplay.DisplayConfigBaseClass;

namespace GanExtendDisplay
{


	public class CharaDisplay
	{
		/* 
		角色显示
		*/

		public static ConfigClass CharaDisplayConfig = new ConfigClass (PluginSettings.CharaDisplay.Value);


		//角色主要显示，鼠标指向角色头上的控件程序
		[HarmonyPostfix]
		[HarmonyPatch(typeof(Chara), nameof(Chara.GetHoverText))]
		public static void Chara_GetHoverText_Postfix(Chara __instance, ref string __result) {
			if (!Main.ModEnable) { return; }
			if (!CharaDisplayConfig.CheckStatus) { return; }
			__result = CharaDisplayClass.Chara_GetHoverText_Postfix(__instance, __result);
		}

		[HarmonyPrefix]
		[HarmonyPatch(typeof(Chara), nameof(Chara.GetHoverText2))]
		public static bool Chara_GetHoverText2_Prefix(Chara __instance, ref string __result) {
			if (!Main.ModEnable) { return true; }
			if (!CharaDisplayConfig.CheckStatus) { return true; }
			__result = CharaDisplayClass.Chara_GetHoverText2_Prefix(__instance, __result);
			return false;
		}




	}
	public class NotificationUI
	{
		/* 
		通知UI
		*/

		public static ConfigClass NotificationUiConfig = new ConfigClass(PluginSettings.NotificationUI.Value);

		//通知显示
		[HarmonyPrefix]
		[HarmonyPatch(typeof(NotificationCondition), nameof(NotificationCondition.OnRefresh))]
		public static bool NotificationCondition_OnRefresh(NotificationCondition __instance) {
			if (!Main.ModEnable) { return true; }
			if (!NotificationUiConfig.CheckStatus) { return true; }
			__instance.text = __instance.condition.GetText() + (" " + __instance.condition.value);
			__instance.item.button.mainText.color = __instance.condition.GetColor(__instance.item.button.skinRoot.GetButton().colorProf);
			return false;
		}


		//状态显示
		[HarmonyPrefix]
		[HarmonyPatch(typeof(NotificationStats), nameof(NotificationStats.OnRefresh))]
		public static bool NotificationStats_OnRefresh(NotificationStats __instance) {
			if (!Main.ModEnable) { return true; }
			if (!NotificationUiConfig.CheckStatus) { return true; }
			BaseStats baseStats = __instance.stats();
			string statusText = baseStats.GetText();
			__instance.text = statusText + (!statusText.IsEmpty() ? ("(" + baseStats.GetValue() + ")") : "");
			__instance.item.button.mainText.color = baseStats.GetColor(__instance.item.button.skinRoot.GetButton().colorProf);
			return false;
		}
		//buff显示
		[HarmonyPrefix]
		[HarmonyPatch(typeof(NotificationBuff), nameof(NotificationBuff.OnRefresh))]
		public static bool NotificationBuff_OnRefresh(NotificationBuff __instance) {
			if (!Main.ModEnable) { return true; }
			if (!NotificationUiConfig.CheckStatus) { return true; }
			if (__instance.item.button.icon.sprite == EClass.core.refs.spriteDefaultCondition) {
				__instance.OnInstantiate();
			}
			__instance.text = __instance.condition.GetText() + " " + __instance.condition.value;
			__instance.item.textDuration.SetText(__instance.condition.TextDuration);
			return false;
		}

	}
	public class ThingDisplay
	{
		/*	
		道具显示
		*/

		public static ConfigClass ThingDisplayConfig = new ConfigClass(PluginSettings.ThingDisplay.Value);


		//悬停文本 显示道具等级、材质
		[HarmonyPostfix]
		[HarmonyPatch(typeof(Thing), nameof(Thing.GetHoverText))]
		public static void Thing_GetHoverText_Postfix(Thing __instance, ref string __result) {
			if (!Main.ModEnable) { return; }
			if (!ThingDisplayConfig.CheckStatus) { return ; }
			__result = ThingDisplayClass.Thing_GetHoverText_Postfix(__instance, __result);
		}


	}
	public class InteractDisplay
	{
		public static ConfigClass InteractDisplayConfig = new ConfigClass(PluginSettings.InteractDisplay.Value);

		[HarmonyPrefix]
		[HarmonyPatch(typeof(WidgetMouseover), nameof(WidgetMouseover.Show))]
		public static void WidgetMouseover_Show_Prefix(WidgetMouseover __instance, ref string s) {
			if (!Main.ModEnable) { return; }
			if (!InteractDisplayConfig.CheckStatus) { return ; }
			PointTarget mouseTarget = EMono.scene.mouseTarget;
			if (mouseTarget.target != null && mouseTarget.target is Zone zone) {
				s = s + " Lv." + zone.DangerLv;
			}
		}

		[HarmonyPostfix]
		[HarmonyPatch(typeof(BaseTaskHarvest), nameof(BaseTaskHarvest.GetText))]
		public static void BaseTaskHarvest_GetText_Postfix(BaseTaskHarvest __instance, ref string __result) {
			if (!Main.ModEnable) { return; }
			if (!InteractDisplayConfig.CheckStatus) { return; }
			__result = InteractDisplayClass.ExtendGetText(__instance, __result);
		}
	}
	public class EnchantDisplay
	{
		public static ConfigClass EnchantDisplayConfig = new ConfigClass(PluginSettings.EnchantDisplay.Value);
		//显示面板-基因
		[HarmonyPrefix]
		[HarmonyPatch(typeof(DNA), nameof(DNA.WriteNote))]
		public static bool DNA_WriteNote_Prefix(DNA __instance, UINote n) {
			if (!Main.ModEnable) { return true; }
			if (!EnchantDisplayConfig.CheckStatus) { return true; }
			EnchantDisplayClass.DNA_WriteNote_Prefix(__instance, n);
			return false;
		}

		//显示面板，这里主要修补附魔内容
		[HarmonyPrefix]
		[HarmonyPatch(typeof(Element), nameof(Element.AddEncNote))]
		public static bool TingInfoShowExtend_AddEncNote_Prefix(Element __instance, UINote n, Card Card, ElementContainer.NoteMode mode = ElementContainer.NoteMode.Default, Func<Element, string, string> funcText = null, Action<UINote, Element> onAddNote = null) {
			if (!Main.ModEnable) { return true; }
			if (!EnchantDisplayConfig.CheckStatus) { return true; }
			EnchantDisplayClass.Enchant_AddEncNote_Prefix(__instance, n, Card, mode, funcText, onAddNote);
			return false;
		}
	}
}