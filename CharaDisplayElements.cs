// ReSharper disable InconsistentNaming

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GanExtendDisplay
{
    /// キャラクターホバーテキストの各表示要素を生成するユーティリティ
    public static class CharaDisplayElements
    {
        /// 好感度をハートシンボルで表示 (75以上で塗りつぶし♥、それ以下で♡)
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

        /// レアリティシンボルを色付きで表示
        public static string Show_Rarity(Chara __instance, string __result)
        {
            RarityColors.GetSymbolAndColor(__instance.rarity, out string symbol, out Color c);
            return symbol.TagColor(c) + " " + __result;
        }

        /// PCとのLv比較による脅威度を色とドクロで表示 (5倍以上で☠)
        public static string Show_Lv(Chara __instance)
        {
            int num = 2;
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

        /// HP表示 (20%以下で赤系、それ以上で緑系)
        public static string Show_HP(Chara __instance)
        {
            return "HP:".TagColor(Color.red) + (__instance.hp + "/" + __instance.MaxHP).TagColor(__instance.hp > __instance.MaxHP * 0.2f
                ? new Color(0.73f, 1f, 0.82f) : new Color(1f, 0.67f, 0.67f));
        }

        /// MP表示
        public static string Show_MP(Chara __instance)
        {
            return " MP:".TagColor(Color.blue) + (__instance.mana.value + "/" + __instance.mana.max).TagColor(
                (__instance.mana.value > __instance.mana.max * 0.2f) ? new Color(0.73f, 1f, 0.82f) : new Color(1f, 0.67f, 0.67f));
        }

        /// SP(スタミナ)表示
        public static string Show_SP(Chara __instance)
        {
            return " SP: ".TagColor(Color.green) + (__instance.stamina.value + "/" + __instance.stamina.max).TagColor(
                (__instance.stamina.value > __instance.stamina.max * 0.2f) ? new Color(0.73f, 1f, 0.82f) : new Color(1f, 0.67f, 0.67f));
        }

        /// 性別・年齢・種族・職業・戦術を表示
        public static string Show_RaceJob(Chara __instance)
        {
            return $" {Lang._gender(__instance.bio.gender)} {__instance.bio.TextAge(__instance)} [{__instance.race.GetName()} {__instance.job.GetName()} {__instance.tactics.source.GetName()}]";
        }

        /// 空腹度表示
        public static string Show_Hunger(Chara __instance)
        {
            return $" {__instance.hunger.name}:{__instance.hunger.value}/{__instance.hunger.max}";
        }

        /// DV(回避)・PV(防御)表示
        public static string DVPV(Chara __instance)
        {
            return $" DV:{__instance.DV} PV:{__instance.PV}";
        }

        /// 防具スキル・攻撃スタイル表示
        public static string StyleShow(Chara __instance)
        {

            return $" {__instance.elements.GetOrCreateElement(__instance.GetArmorSkill()).Name} {("style" + __instance.body.GetAttackStyle()).lang()}";
        }

        /// 仕事・趣味の一覧表示
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

        /// 主能力(筋力〜魅力、ID 70-77)の名前と値を表示
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

        /// 所持重量/重量上限を表示 (80%超で赤系)
        public static string Show_Weight(Chara __instance)
        {
            float weight = __instance.ChildrenWeight / 1000f;
            float limit = __instance.WeightLimit / 1000f;
            return $" {Element.Get(11).GetName()}:" +
                   (((int)weight).ToString("F0") + "s/" + ((int)limit).ToString("F0") + "s").TagColor(
                       weight < limit * 0.8f ? new Color(0.86f, 1f, 0.89f) : new Color(1f, 0.8f, 0.8f));
        }

        /// 経験値表示
        public static string Show_EXP(Chara __instance)
        {
            return $" EXP:{__instance.exp + "/" + __instance.ExpToNext}";
        }

        /// 速度表示
        public static string Show_Speed(Chara __instance)
        {
            return $" {__instance.elements.GetElement(79).Name}:{__instance.Speed}";
        }

        /// 各耐性値を色付きで一覧表示
        public static string Show_Resist(Chara __instance)
        {
            var eleList = __instance.elements.ListElements(x => x.source.category == "resist" && x.Value != 0)
                .Select(x => $"{ResistColors.GetName(x.Name, x.id)}:{x.Value}")
                .ToList();
            return ResistColors.ShortOut(eleList);
        }
    }
}
