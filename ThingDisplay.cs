// ReSharper disable InconsistentNaming

using UnityEngine;

namespace GanExtendDisplay
{
    /// アイテムのホバーテキストにレアリティ・Lv・素材・価格・錠前Lvを追加
    internal static class ThingDisplay
    {
        public static string Thing_GetHoverText_Postfix(Thing __instance, string __result)
        {
            if (!__instance.isChara)
            {
                if (__instance.isNPCProperty)
                {
                    __result += "(x)";
                }

                RarityColors.GetSymbolAndColor(__instance.rarity, out string text, out Color c);
                text = text.TagColor(c);
                __result = $"{text} Lv.{__instance.LV} ".TagColor(c) + $"{__instance.material.GetName()} {__result}";
                string lockLv = __instance.c_lockLv > 0 ? $" Lock.Lv.{__instance.c_lockLv.ToString().TagColor(Color.yellow)}" : "";
                string scales = $"¤ {__instance.GetPrice()}".TagSize(14);
                __result = $"{__result} {scales} {lockLv}";
            }

            return __result;
        }
    }
}
