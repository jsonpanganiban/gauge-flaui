using FlaUI.Core.AutomationElements;

namespace DTAF.Core.Desktop.Helpers
{
    public static class ElementHelper
    {
        public static bool CanBeClicked(this AutomationElement element)
        {
            return element.IsEnabled;
        }
    }
}
