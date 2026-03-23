// ReSharper disable InconsistentNaming
namespace GanExtendDisplay
{
	/// 採集・採掘などのインタラクション表示を拡張
	internal static class InteractDisplay
	{
		/// 採集タスクのテキストに道具名・必要Lv・成長段階を追加
		public static string ExtendGetText(BaseTaskHarvest __instance, string __result) {
			string tool = null;
			if (__instance.tool != null) {
				tool = __instance.tool.Name + ".";
			}

			// 道具Lvと要求Lvの比較表示
			string hard = __instance.IsTooHard
				? $"Lv:{__instance.toolLv}<{__instance.reqLv}"
				: $"Lv:{__instance.toolLv} >= {__instance.reqLv}";

			// 成長段階の表示 (収穫期を超えていれば枯れ表示)
			string growth = null;
			if (__instance.pos.cell.growth != null) {
				int growthNow = __instance.pos.cell.growth.stage.idx;
				int growthMax = __instance.pos.cell.growth.HarvestStage;
				growth = "\n" + (growthNow > growthMax && growthMax > 0 ? "Withering:" : "Growth:") + growthNow;
				if (growthMax > 0) {
					growth = growth + "/" + growthMax;
				}
			}

			return string.Concat(__result, "\n", tool, hard, growth);
		}
	}
}
