using FlaUI.Core.AutomationElements;

namespace DTAF.Core.Desktop.Contracts
{
    public interface IElement
    {
        AutomationElement Context { get; set; }
    }
}
