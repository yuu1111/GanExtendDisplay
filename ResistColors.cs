using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GanExtendDisplay
{
    public static class ResistColors
    {
        public static Color flameResistance = new Color(1f, 0.5f, 0.2f);
        public static Color coldResistance = new Color(0.2f, 0.5f, 1f);
        public static Color electricResistance = new Color(1f, 1f, 0.2f);
        public static Color darkResistance = new Color(0.5f, 0.2f, 0.5f);
        public static Color mesmerizeResistance = new Color(0.5f, 0.2f, 1f);
        public static Color poisonResistance = new Color(0.2f, 1f, 0.2f);
        public static Color hellResistance = new Color(1f, 0.2f, 0.2f);
        public static Color soundResistance = new Color(1f, 0.5f, 0.5f);
        public static Color nerveResistance = new Color(0.2f, 1f, 0.6f);
        public static Color chaosResistance = new Color(0.6f, 0.3f, 0.2f);
        public static Color divineResistance = new Color(1f, 1f, 0.5f);
        public static Color magicResistance = new Color(0.2f, 0.2f, 1f);
        public static Color aetherResistance = new Color(0.2f, 0.2f, 1f);
        public static Color acidResistance = new Color(0.2f, 1f, 0.2f);
        public static Color bleedingResistance = new Color(1f, 0.2f, 0.2f);
        public static Color impactResistance = new Color(0.2f, 0.2f, 1f);
        public static Color corruptionResistance = new Color(0.6f, 0.3f, 0.2f);
        public static Color damageResistance = new Color(0.5f, 0.5f, 0.5f);
        public static Color curseResistance = new Color(0.2f, 0.2f, 0.2f);

        public static string GetName(string res, int id)
        {
            switch (id)
            {
                case 950: res = res.TagColor(flameResistance); break;
                case 951: res = res.TagColor(coldResistance); break;
                case 952: res = res.TagColor(electricResistance); break;
                case 953: res = res.TagColor(darkResistance); break;
                case 954: res = res.TagColor(mesmerizeResistance); break;
                case 955: res = res.TagColor(poisonResistance); break;
                case 956: res = res.TagColor(hellResistance); break;
                case 957: res = res.TagColor(soundResistance); break;
                case 958: res = res.TagColor(nerveResistance); break;
                case 959: res = res.TagColor(chaosResistance); break;
                case 960: res = res.TagColor(divineResistance); break;
                case 961: res = res.TagColor(magicResistance); break;
                case 962: res = res.TagColor(aetherResistance); break;
                case 963: res = res.TagColor(acidResistance); break;
                case 964: res = res.TagColor(bleedingResistance); break;
                case 965: res = res.TagColor(impactResistance); break;
                case 970: res = res.TagColor(corruptionResistance); break;
                case 971: res = res.TagColor(damageResistance); break;
                case 972: res = res.TagColor(curseResistance); break;
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
