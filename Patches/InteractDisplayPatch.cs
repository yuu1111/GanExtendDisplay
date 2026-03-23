// ReSharper disable InconsistentNaming

using HarmonyLib;
using static GanExtendDisplay.DisplayConfigBaseClass;

namespace GanExtendDisplay
{
	public class InteractDisplayPatch
	{
		public static ConfigClass InteractDisplayConfig = new ConfigClass(PluginSettings.InteractDisplay.Value);

		[HarmonyPrefix]
		[HarmonyPatch(typeof(WidgetMouseover), nameof(WidgetMouseover.Show))]
		public static void WidgetMouseover_Show_Prefix(WidgetMouseover __instance, ref string s) {
			if (!Main.ModEnable) { return; }
			if (!InteractDisplayConfig.CheckStatus) { return; }
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
			__result = InteractDisplay.ExtendGetText(__instance, __result);
		}
	}
}
