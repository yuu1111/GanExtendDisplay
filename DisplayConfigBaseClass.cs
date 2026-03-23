using System;

namespace GanExtendDisplay
{
    public static class DisplayConfigBaseClass
    {
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
