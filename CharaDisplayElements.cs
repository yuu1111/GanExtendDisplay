// ReSharper disable InconsistentNaming

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GanExtendDisplay
{
    public class CharaDisplayElementsClass
    {
        public static string Show_Affinity(Chara __instance, string __result)
        {
            int affinity = __instance._affinity;
            if (affinity > 0)
            {
                string text = (affinity > 74) ? "♥" : "♡";
                text = text.TagSize(Mathf.Clamp(affinity / 10 + 10, 12, 20)).TagColor(new Color(0.5f, Math.Min(1f, 0.5f + affinity * 1f / 100f), 0.5f));
                __result = " " + text + " " + __result;
            }

            return __result;
        }

        public static string Show_Rarity(Chara __instance, string __result)
        {
            string text2 = "";
            Color c = Color.black;
            switch (__instance.rarity)
            {
                case Rarity.Crude:
                    text2 = "x";
                    c = RarityColors.Color_Crude;
                    break;
                case Rarity.Normal:
                    text2 = "";
                    c = RarityColors.Color_Normal;
                    break;
                case Rarity.Superior:
                    text2 = "△";
                    c = RarityColors.Color_Superior;
                    break;
                case Rarity.Legendary:
                    text2 = "◇";
                    c = RarityColors.Color_Legendary;
                    break;
                case Rarity.Mythical:
                    text2 = "☆";
                    c = RarityColors.Color_Mythical;
                    break;
                case Rarity.Artifact:
                    text2 = "★";
                    c = RarityColors.Color_Artifact;
                    break;
            }

            text2 = text2.TagColor(c);
            __result = text2 + " " + __result;
            return __result;
        }

        public static string Show_Lv(Chara __instance)
        {
            int num = 2;
            int lv = EClass.pc.LV;
            bool flag2 = __instance.LV >= EClass.pc.LV * 5;
            if (flag2)
            {
                num = 0;
            }
            else
            {
                bool flag3 = __instance.LV >= EClass.pc.LV * 2;
                if (flag3)
                {
                    num = 1;
                }
                else
                {
                    bool flag4 = __instance.LV <= EClass.pc.LV / 4;
                    if (flag4)
                    {
                        num = 4;
                    }
                    else
                    {
                        bool flag5 = __instance.LV <= EClass.pc.LV / 2;
                        if (flag5)
                        {
                            num = 3;
                        }
                    }
                }
            }

            string s = "";
            bool flag6 = num == 0;
            if (flag6)
            {
                s = " ☠ ";
            }

            return (" Lv." + __instance.LV).TagColor(EClass.Colors.gradientLVComparison.Evaluate(0.25f * num)) +
                   s.TagSize(30).TagColor(EClass.Colors.gradientLVComparison.Evaluate(0.25f * num));
        }

        public static string Show_HP(Chara __instance)
        {
            return "HP:".TagColor(Color.red) + (__instance.hp + "/" + __instance.MaxHP).TagColor(__instance.hp > __instance.MaxHP * 0.2f
                ? new Color(0.73f, 1f, 0.82f) : new Color(1f, 0.67f, 0.67f));
        }

        public static string Show_MP(Chara __instance)
        {
            return " MP:".TagColor(Color.blue) + (__instance.mana.value + "/" + __instance.mana.max).TagColor(
                (__instance.mana.value > __instance.mana.max * 0.2f) ? new Color(0.73f, 1f, 0.82f) : new Color(1f, 0.67f, 0.67f));
        }

        public static string Show_SP(Chara __instance)
        {
            return " SP: ".TagColor(Color.green) + (__instance.stamina.value + "/" + __instance.stamina.max).TagColor(
                (__instance.stamina.value > __instance.stamina.max * 0.2f) ? new Color(0.73f, 1f, 0.82f) : new Color(1f, 0.67f, 0.67f));
        }

        public static string Show_RaceJob(Chara __instance)
        {
            string res =
                $" {Lang._gender(__instance.bio.gender)} {__instance.bio.TextAge(__instance)} [{__instance.race.GetName()} {__instance.job.GetName()} {__instance.tactics.source.GetName()}]";
            return res;
        }

        public static string Show_Hunger(Chara __instance)
        {
            return $" {__instance.hunger.name}:{__instance.hunger.value}/{__instance.hunger.max}";
        }

        public static string DVPV(Chara __instance)
        {
            return $" DV:{__instance.DV} PV:{__instance.PV}";
        }

        public static string StyleShow(Chara __instance)
        {

            return $" {__instance.elements.GetOrCreateElement(__instance.GetArmorSkill()).Name} {("style" + __instance.body.GetAttackStyle()).lang()}";
        }

        public static string Show_Works(Chara __instance)
        {
            string res = "";
            foreach (Hobby work in __instance.ListWorks())
            {
                res += $" {work.Name}";
            }

            foreach (Hobby Hobbies in __instance.ListHobbies())
            {
                res += $" {Hobbies.Name}";
            }

            return res;
        }

        public static string Show_Attributes(Chara __instance)
        {
            string res = "";
            for (int id = 70; id <= 77; id++)
            {
                var e = __instance.elements.GetElement(id);
                res += $" {e.Name}:{e.Value}";
            }

            return res;
        }

        public static string Show_Debug(Chara __instance)
        {
            string res = "";
            res += "Global:" + __instance.IsGlobal + "  AI:" + __instance.ai + " " + __instance.ai.Current + "" +
                   __instance.source.tactics.IsEmpty(EClass.sources.tactics.map.TryGetValue(__instance.id)?.id ??
                                                     EClass.sources.tactics.map.TryGetValue(__instance.job.id)?.id ?? "predator");
            res += "\n" + __instance.uid + __instance.IsMinion + "/" + __instance.c_uidMaster + "/" + __instance.master;
            return res;
        }

        public static string Show_Weight(Chara __instance)
        {
            float weight = __instance.ChildrenWeight / 1000f;
            float limit = __instance.WeightLimit / 1000f;
            string result = $" {Element.Get(11).GetName()}:" +
                            (((int)weight).ToString("F0") + "s/" + ((int)limit).ToString("F0") + "s").TagColor(
                                (weight < limit * 0.8f) ? new Color(0.86f, 1f, 0.89f) : new Color(1f, 0.8f, 0.8f));
            return result;
        }

        public static string Show_EXP(Chara __instance)
        {
            return $" EXP:{__instance.exp + "/" + __instance.ExpToNext}";
        }

        public static string Show_Speed(Chara __instance)
        {
            return $" {__instance.elements.GetElement(79).Name}:{__instance.Speed}";
        }

        public static string Show_Resist(Chara __instance)
        {
            List<string> eleList = __instance.elements.ListElements(x => x.source.category == "resist" && x.Value != 0).Select(x => $"{ResistColors.GetName(x.Name, x.id)}:{x.Value}")
                .ToList();
            string resist = ResistColors.ShortOut(eleList);
            return resist;
        }
    }
}
