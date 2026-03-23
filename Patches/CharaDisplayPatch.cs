// ReSharper disable InconsistentNaming

using HarmonyLib;
using static GanExtendDisplay.DisplayConfigBaseClass;

namespace GanExtendDisplay
{
	public class CharaDisplayPatch
	{
		public static ConfigClass CharaDisplayConfig = new ConfigClass(PluginSettings.CharaDisplay.Value);

		[HarmonyPostfix]
		[HarmonyPatch(typeof(Chara), nameof(Chara.GetHoverText))]
		public static void Chara_GetHoverText_Postfix(Chara __instance, ref string __result) {
			if (!Main.ModEnable) { return; }
			if (!CharaDisplayConfig.CheckStatus) { return; }
			__result = CharaDisplay.Chara_GetHoverText_Postfix(__instance, __result);
		}

		[HarmonyPrefix]
		[HarmonyPatch(typeof(Chara), nameof(Chara.GetHoverText2))]
		public static bool Chara_GetHoverText2_Prefix(Chara __instance, ref string __result) {
			if (!Main.ModEnable) { return true; }
			if (!CharaDisplayConfig.CheckStatus) { return true; }
			__result = CharaDisplay.Chara_GetHoverText2_Prefix(__instance, __result);
			return false;
		}
	}
}
