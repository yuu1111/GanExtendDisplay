using UnityEngine;

namespace GanExtendDisplay
{
    /// レアリティごとの表示色とシンボル文字の定義
    public static class RarityColors
    {
        public static Color Crude = new Color(0.44705883f, 0.21176471f, 0.21176471f);
        public static Color Normal = new Color(0.4f, 0.4f, 0.4f);
        public static Color Superior = new Color(0f, 0.6745098f, 1f);
        public static Color Legendary = new Color(0.9137255f, 0.4745098f, 1f);
        public static Color Mythical = new Color(1f, 0.89411765f, 0.3137255f);
        public static Color Artifact = new Color(1f, 0.15686275f, 0.15686275f);

        public static void GetSymbolAndColor(Rarity rarity, out string symbol, out Color color)
        {
            switch (rarity)
            {
                case Rarity.Crude:     symbol = "x"; color = Crude; break;
                case Rarity.Normal:    symbol = "";  color = Normal; break;
                case Rarity.Superior:  symbol = "△"; color = Superior; break;
                case Rarity.Legendary: symbol = "◇"; color = Legendary; break;
                case Rarity.Mythical:  symbol = "☆"; color = Mythical; break;
                case Rarity.Artifact:  symbol = "★"; color = Artifact; break;
                default:               symbol = "";  color = Normal; break;
            }
        }
    }
}
