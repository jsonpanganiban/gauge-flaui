using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class UpdateAddressWindow : WindowBase, IWindowElement
    {
        private const int _addressCode = 0;
        private const int _line1 = 1;
        private const int _line2 = 2;
        private const int _line3 = 3;
        private const int _line4 = 4;
        private const int _city = 5;
        private const int _zipPostalCode = 6;
        private const int _defaultPhoneNumber = 7;

        public UpdateAddressWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        public AutomationElement AddressCode
        {
            get
            {
                return this.Context.FindAllDescendants(x => x
                .ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[_addressCode];
            }
        }

        public AutomationElement Line1
        {
            get
            {
                return this.Context.FindAllDescendants(x => x
                .ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[_line1];
            }
        }

        public AutomationElement Line2
        {
            get
            {
                return this.Context.FindAllDescendants(x => x
                .ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[_line2];
            }
        }

        public AutomationElement Line3
        {
            get
            {
                return this.Context.FindAllDescendants(x => x
                .ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[_line3];
            }
        }

        public AutomationElement Line4
        {
            get
            {
                return this.Context.FindAllDescendants(x => x
                .ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[_line4];
            }
        }

        public AutomationElement City
        {
            get
            {
                return this.Context.FindAllDescendants(x => x
                .ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[_city];
            }
        }

        public AutomationElement ZipPostalCode
        {
            get
            {
                return this.Context.FindAllDescendants(x => x
                .ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[_zipPostalCode];
            }
        }

        public AutomationElement DefaultPhoneNumber
        {
            get
            {
                return this.Context.FindAllDescendants(x => x
                .ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[_defaultPhoneNumber];
            }
        }

        public AutomationElement Country
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x
                .ByControlType(FlaUI.Core.Definitions.ControlType.ComboBox));
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("OK"));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Update Address") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
