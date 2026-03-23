// ReSharper disable InconsistentNaming
namespace GanExtendDisplay
{
	internal class InteractDisplayClass
	{
		public static string ExtendGetText(BaseTaskHarvest __instance, string __result) {
			string tool = null;
			string growth = null;
			if (__instance.tool != null) {
				tool = __instance.tool.Name + ".";
			}

			string hard = __instance.IsTooHard ? $"Lv:{__instance.toolLv.ToString()}<{__instance.reqLv.ToString()}" : $"Lv:{__instance.toolLv.ToString()} >= " + __instance.reqLv;
			
			if (__instance.pos.cell.growth != null) {
				int growthNow = __instance.pos.cell.growth.stage.idx ;
				int growthMax = __instance.pos.cell.growth.HarvestStage;
				growth = "\n" + (growthNow > growthMax&&growthMax>0 ? "Withering:" : "Growth:") + growthNow;
				if (growthMax > 0) {
					growth = growth + "/" + __instance.pos.cell.growth.HarvestStage;
				}
			}
			__result = string.Concat(__result, "\n", tool, hard, growth);

			return __result;
		}
	}
}
