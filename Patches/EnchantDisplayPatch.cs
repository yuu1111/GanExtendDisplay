// ReSharper disable InconsistentNaming

using System;
using HarmonyLib;
using static GanExtendDisplay.DisplayConfigBaseClass;

namespace GanExtendDisplay
{
	public class EnchantDisplayPatch
	{
		public static ConfigClass EnchantDisplayConfig = new ConfigClass(PluginSettings.EnchantDisplay.Value);

		[HarmonyPrefix]
		[HarmonyPatch(typeof(DNA), nameof(DNA.WriteNote))]
		public static bool DNA_WriteNote_Prefix(DNA __instance, UINote n) {
			if (!Main.ModEnable) { return true; }
			if (!EnchantDisplayConfig.CheckStatus) { return true; }
			EnchantDisplay.DNA_WriteNote_Prefix(__instance, n);
			return false;
		}

		[HarmonyPrefix]
		[HarmonyPatch(typeof(Element), nameof(Element.AddEncNote))]
		public static bool TingInfoShowExtend_AddEncNote_Prefix(Element __instance, UINote n, Card Card, ElementContainer.NoteMode mode = ElementContainer.NoteMode.Default, Func<Element, string, string> funcText = null, Action<UINote, Element> onAddNote = null) {
			if (!Main.ModEnable) { return true; }
			if (!EnchantDisplayConfig.CheckStatus) { return true; }
			EnchantDisplay.Enchant_AddEncNote_Prefix(__instance, n, Card, mode, funcText, onAddNote);
			return false;
		}
	}
}
