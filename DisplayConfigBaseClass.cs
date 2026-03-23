using System;

namespace GanExtendDisplay
{
    /// 表示モード(Keep/Hide/Disable)の定義と設定値キャッシュ
    public static class DisplayConfigBaseClass
    {
        /// Keep: 常に表示, Hide: Alt押下時のみ表示, Disable: 無効
        public enum DisplayOption
        {
            Keep,
            Hide,
            Disable
        }

        public static DisplayOption StringToDisplayOption(string value)
        {
            if (Enum.TryParse(value, out DisplayOption result))
            {
                return result;
            }
            return DisplayOption.Keep;
        }

        /// 起動時に設定値を読み取り、表示判定をキャッシュするクラス
        public class ConfigClass
        {
            private DisplayOption OptionStatus { get; set; }

            public ConfigClass(string option)
            {
                OptionStatus = StringToDisplayOption(option);
            }

            public bool CheckStatus
            {
                get
                {
                    if (OptionStatus == DisplayOption.Keep)
                    {
                        return true;
                    }
                    if (Main.ChangeDisplay)
                    {
                        if (OptionStatus == DisplayOption.Hide)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
    }
}
