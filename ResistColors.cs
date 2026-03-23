using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GanExtendDisplay
{
    public static class ResistColors
    {
        public static Color FlameResistance = new Color(1f, 0.5f, 0.2f);
        public static Color ColdResistance = new Color(0.2f, 0.5f, 1f);
        public static Color ElectricResistance = new Color(1f, 1f, 0.2f);
        public static Color DarkResistance = new Color(0.5f, 0.2f, 0.5f);
        public static Color MesmerizeResistance = new Color(0.5f, 0.2f, 1f);
        public static Color PoisonResistance = new Color(0.2f, 1f, 0.2f);
        public static Color HellResistance = new Color(1f, 0.2f, 0.2f);
        public static Color SoundResistance = new Color(1f, 0.5f, 0.5f);
        public static Color NerveResistance = new Color(0.2f, 1f, 0.6f);
        public static Color ChaosResistance = new Color(0.6f, 0.3f, 0.2f);
        public static Color DivineResistance = new Color(1f, 1f, 0.5f);
        public static Color MagicResistance = new Color(0.2f, 0.2f, 1f);
        public static Color AetherResistance = new Color(0.2f, 0.2f, 1f);
        public static Color AcidResistance = new Color(0.2f, 1f, 0.2f);
        public static Color BleedingResistance = new Color(1f, 0.2f, 0.2f);
        public static Color ImpactResistance = new Color(0.2f, 0.2f, 1f);
        public static Color CorruptionResistance = new Color(0.6f, 0.3f, 0.2f);
        public static Color DamageResistance = new Color(0.5f, 0.5f, 0.5f);
        public static Color CurseResistance = new Color(0.2f, 0.2f, 0.2f);

        public static string GetName(string res, int id)
        {
            switch (id)
            {
                case 950: res = res.TagColor(FlameResistance); break;
                case 951: res = res.TagColor(ColdResistance); break;
                case 952: res = res.TagColor(ElectricResistance); break;
                case 953: res = res.TagColor(DarkResistance); break;
                case 954: res = res.TagColor(MesmerizeResistance); break;
                case 955: res = res.TagColor(PoisonResistance); break;
                case 956: res = res.TagColor(HellResistance); break;
                case 957: res = res.TagColor(SoundResistance); break;
                case 958: res = res.TagColor(NerveResistance); break;
                case 959: res = res.TagColor(ChaosResistance); break;
                case 960: res = res.TagColor(DivineResistance); break;
                case 961: res = res.TagColor(MagicResistance); break;
                case 962: res = res.TagColor(AetherResistance); break;
                case 963: res = res.TagColor(AcidResistance); break;
                case 964: res = res.TagColor(BleedingResistance); break;
                case 965: res = res.TagColor(ImpactResistance); break;
                case 970: res = res.TagColor(CorruptionResistance); break;
                case 971: res = res.TagColor(DamageResistance); break;
                case 972: res = res.TagColor(CurseResistance); break;
            }
            return res;
        }

        public static string ShortOut(List<string> inList, int lineSize = 5)
        {
            if (inList.Count == 0) { return ""; }
            StringBuilder res = new StringBuilder();
            int count = 0;
            foreach (string s in inList)
            {
                count++;
                if (count % lineSize == 1)
                {
                    res.Append(Environment.NewLine).Append(s);
                }
                else
                {
                    res.Append(" ").Append(s);
                }
            }
            return res.ToString();
        }
    }
}
