// ReSharper disable InconsistentNaming

using System;
using System.Linq;
using UnityEngine;

namespace GanExtendDisplay
{
    internal static class CharaDisplay
    {
        private static readonly char[] TrimChars = { ',', ' ' };

        public static string Chara_GetHoverText_Postfix(Chara __instance, string __result)
        {

            //顶行
            __result = CharaDisplayElements.Show_Affinity(__instance, __result); //亲密度
            __result = CharaDisplayElements.Show_Rarity(__instance, __result); //稀有度
            __result = CharaDisplayElements.Show_Lv(__instance) + __result; //威胁标志

            //第1行
            if (CharaSettings.CharaDisplayLine1Settings.CharaDisplayLineOut)
            {
                if (!CharaSettings.CharaDisplayLine1Settings.CharaDisplayPCFactionOnly || __instance.IsPCFaction)
                {
                    __result += Environment.NewLine;
                    __result += (CharaDisplayElements.Show_RaceJob(__instance) + CharaDisplayElements.StyleShow(__instance))
                        .TagSize(CharaSettings.CharaDisplayLine1Settings.Size); //种族职业模式
                }
            }

            //第2行
            if (CharaSettings.CharaDisplayLine2Settings.CharaDisplayLineOut)
            {
                if (!CharaSettings.CharaDisplayLine2Settings.CharaDisplayPCFactionOnly || __instance.IsPCFaction)
                {
                    __result += Environment.NewLine;
                    __result +=
                        (CharaDisplayElements.Show_HP(__instance) + CharaDisplayElements.DVPV(__instance) + CharaDisplayElements.Show_Speed(__instance)).TagSize(CharaSettings
                            .CharaDisplayLine2Settings.Size);
                }
            }

            //第3行
            if (CharaSettings.CharaDisplayLine3Settings.CharaDisplayLineOut)
            {
                if (!CharaSettings.CharaDisplayLine3Settings.CharaDisplayPCFactionOnly || __instance.IsPCFaction)
                {
                    __result += Environment.NewLine;
                    __result +=
                        (CharaDisplayElements.Show_SP(__instance) + CharaDisplayElements.Show_Hunger(__instance) + CharaDisplayElements.Show_Works(__instance)).TagSize(
                            CharaSettings.CharaDisplayLine3Settings.Size);
                }
            }


            //第4行
            if (CharaSettings.CharaDisplayLine4Settings.CharaDisplayLineOut)
            {
                if (!CharaSettings.CharaDisplayLine4Settings.CharaDisplayPCFactionOnly || __instance.IsPCFaction)
                {
                    __result += Environment.NewLine;
                    __result +=
                        (CharaDisplayElements.Show_MP(__instance) + CharaDisplayElements.Show_Weight(__instance) + CharaDisplayElements.Show_EXP(__instance)).TagSize(
                            CharaSettings.CharaDisplayLine4Settings.Size);
                }
            }

            //抗性行
            if (CharaSettings.CharaDisplayLineResistSettings.CharaDisplayLineOut)
            {
                if (!CharaSettings.CharaDisplayLineResistSettings.CharaDisplayPCFactionOnly || __instance.IsPCFaction)
                {
                    __result += CharaDisplayElements.Show_Resist(__instance).TagSize(CharaSettings.CharaDisplayLineResistSettings.Size);
                }
            }


            //属性行,按下显示
            if (CharaSettings.CharaDisplayLineAttributesSettings.CharaDisplayLineOut)
            {
                if (!CharaSettings.CharaDisplayLineAttributesSettings.CharaDisplayPCFactionOnly || __instance.IsPCFaction)
                {
                    __result += Environment.NewLine;
                    __result += CharaDisplayElements.Show_Attributes(__instance).TagSize(CharaSettings.CharaDisplayLineAttributesSettings.Size);
                }
            }

            return __result;
        }

        public static string Chara_GetHoverText2_Prefix(Chara __instance, string __result)
        {
            string text = "";
            if (__instance.knowFav || (CharaSettings.CharaDisplayLineFavgiftSettings.CharaDisplayLineOut &&
                                       (!CharaSettings.CharaDisplayLineAttributesSettings.CharaDisplayPCFactionOnly || __instance.IsPCFaction)))
            {
                text += Environment.NewLine;
                text = text + $"<size={CharaSettings.CharaDisplayLineFavgiftSettings.Size}>" + "favgift".lang(__instance.GetFavCat().GetName().ToLower(), __instance.GetFavFood().GetName()) +
                       "</size>";
            }

            string text2 = "";
            if (EClass.debug.showExtra)
            {
                text2 += Environment.NewLine;
                text2 += Environment.NewLine;
                text2 = text2 + "Global:" + __instance.IsGlobal + "  AI:" + __instance.ai + " " +
                        __instance.source.tactics.IsEmpty(EClass.sources.tactics.map.TryGetValue(__instance.id)?.id ??
                                                          EClass.sources.tactics.map.TryGetValue(__instance.job.id)?.id ?? "predator");
                text2 += Environment.NewLine;
                text2 = text2 + __instance.uid + __instance.IsMinion + "/" + __instance.c_uidMaster + "/" + __instance.master;
                text2 = text2 + " dir:" + __instance.dir + " skin:" + __instance.idSkin;
            }

            if (EClass.pc.held?.trait is TraitWhipLove && __instance.IsPCFaction)
            {
                text2 += Environment.NewLine;
                text2 += "<size=14>";
                foreach (Hobby item in __instance.ListWorks())
                {
                    text2 = text2 + item.Name + ", ";
                }

                foreach (Hobby item2 in __instance.ListHobbies())
                {
                    text2 = text2 + item2.Name + ", ";
                }

                text2 = text2.TrimEnd(TrimChars) + "</size>";
            }

            string text3 = "";
            var enumerable = __instance.conditions.Concat(!__instance.IsPCFaction ? Array.Empty<BaseStats>() : new BaseStats[] { __instance.hunger, __instance.stamina }).ToList();
            if (enumerable.Count > 0)
            {
                text3 += Environment.NewLine;
                text3 += "<size=14>";
                int num = 0;
                foreach (BaseStats item3 in enumerable)
                {
                    string text4 = item3.GetPhaseStr();
                    if (text4.IsEmpty() || text4 == "#")
                    {
                        continue;
                    }

                    Color c = Color.white;
                    switch (item3.source.group)
                    {
                        case "Bad":
                        case "Debuff":
                        case "Disease":
                            c = EClass.Colors.colorDebuff;
                            break;
                        case "Buff":
                            c = EClass.Colors.colorBuff;
                            break;
                    }


                    text4 = text4 + "(" + item3.GetValue() + ")";
                    if (__instance.resistCon != null && __instance.resistCon.TryGetValue(item3.id, out int resistVal))
                    {
                        text4 = text4 + "{" + resistVal + "}";
                    }


                    num++;
                    text3 = text3 + text4.TagColor(c) + ", ";
                }

                if (num == 0)
                {
                    text3 = "";
                }
                else
                {
                    text = "";
                    text3 = text3.TrimEnd(TrimChars) + "</size>";
                }
            }

            if (CharaSettings.CharaDisplayLineActSettings.CharaDisplayLineOut && (!CharaSettings.CharaDisplayLineActSettings.CharaDisplayPCFactionOnly || __instance.IsPCFaction))
            {
                text3 += Environment.NewLine;
                foreach (ActList.Item item4 in __instance.ability.list.items)
                {
                    string aliasParentName = null;
                    if (!string.IsNullOrWhiteSpace(item4.act.source.aliasParent))
                    {
                        string aliasParentElement = Element.GetName(item4.act.source.aliasParent);
                        if (aliasParentElement != null)
                        {
                            aliasParentName = "(" + aliasParentElement + ")";
                        }
                    }

                    text3 = text3 + (item4.act.Name + aliasParentName + ", ").TagSize(CharaSettings.CharaDisplayLineActSettings.Size);
                }

                text3 = text3.TrimEnd(TrimChars);
            }

            return text + text2 + text3;
        }
    }
}
