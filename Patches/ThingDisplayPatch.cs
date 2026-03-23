// ReSharper disable InconsistentNaming

using HarmonyLib;
using static GanExtendDisplay.DisplayConfigBaseClass;

namespace GanExtendDisplay
{
	public class ThingDisplayPatch
	{
		public static ConfigClass ThingDisplayConfig = new ConfigClass(PluginSettings.ThingDisplay.Value);

		[HarmonyPostfix]
		[HarmonyPatch(typeof(Thing), nameof(Thing.GetHoverText))]
		public static void Thing_GetHoverText_Postfix(Thing __instance, ref string __result) {
			if (!Main.ModEnable) { return; }
			if (!ThingDisplayConfig.CheckStatus) { return; }
			__result = ThingDisplay.Thing_GetHoverText_Postfix(__instance, __result);
		}
	}
}
