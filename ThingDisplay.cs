// ReSharper disable InconsistentNaming

using UnityEngine;

namespace GanExtendDisplay
{
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

                string text = "";
                Color c = Color.black;
                switch (__instance.rarity)
                {
                    case Rarity.Crude:
                        text = "x";
                        c = RarityColors.Color_Crude;
                        break;
                    case Rarity.Normal:
                        text = "";
                        c = RarityColors.Color_Normal;
                        break;
                    case Rarity.Superior:
                        text = "△";
                        c = RarityColors.Color_Superior;
                        break;
                    case Rarity.Legendary:
                        text = "◇";
                        c = RarityColors.Color_Legendary;
                        break;
                    case Rarity.Mythical:
                        text = "☆";
                        c = RarityColors.Color_Mythical;
                        break;
                    case Rarity.Artifact:
                        text = "★";
                        c = RarityColors.Color_Artifact;
                        break;
                }

                text = text.TagColor(c);
                __result = $"{text} Lv.{__instance.LV.ToString()} ".TagColor(c) + $"{__instance.material.GetName()} {__result}";
                string lockLv = (__instance.c_lockLv > 0) ? ($" Lock.Lv.{__instance.c_lockLv.ToString().TagColor(Color.yellow)}") : "";
                string Scales = $"¤ {__instance.GetPrice().ToString()}".TagSize(14);
                __result = $"{__result} {Scales} {lockLv}";
            }

            return __result;
        }
    }
}
