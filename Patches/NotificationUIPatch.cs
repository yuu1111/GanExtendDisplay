// ReSharper disable InconsistentNaming

using HarmonyLib;
using static GanExtendDisplay.DisplayConfigBaseClass;

namespace GanExtendDisplay
{
	public class NotificationUIPatch
	{
		public static ConfigClass NotificationUiConfig = new ConfigClass(PluginSettings.NotificationUI.Value);

		[HarmonyPrefix]
		[HarmonyPatch(typeof(NotificationCondition), nameof(NotificationCondition.OnRefresh))]
		public static bool NotificationCondition_OnRefresh(NotificationCondition __instance) {
			if (!Main.ModEnable) { return true; }
			if (!NotificationUiConfig.CheckStatus) { return true; }
			__instance.text = __instance.condition.GetText() + (" " + __instance.condition.value);
			__instance.item.button.mainText.color = __instance.condition.GetColor(__instance.item.button.skinRoot.GetButton().colorProf);
			return false;
		}

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
}
