using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using System.Collections.Generic;
using System.Linq;

namespace LoanIQ.Desktop.Automation.Core.Elements
{
    public class MenuButtonPane : ElementBase, IElement
    {
        private readonly Dictionary<int, string> _indexKeys;

        private const string _favorites = "FAVORITES";
        private const string _hierarchy = "HIERARCHY";
        private const string _history = "HISTORY";
        private const string _actions = "ACTIONS";

        public MenuButtonPane() 
        {
            _indexKeys = new Dictionary<int, string>()
            {
                {0, _favorites },
                {1, _hierarchy },
                {2, _history },
                {3, _actions }
            };
        }

        public AutomationElement Favorites
        {
            get
            {
                return Context.FindChildAt(_indexKeys.Single(_ => _.Value == _favorites).Key);
            }
        }

        public AutomationElement Hierarchy
        {
            get
            {
                return Context.FindChildAt(_indexKeys.Single(_ => _.Value == _hierarchy).Key);
            }
        }

        public AutomationElement History
        {
            get
            {
                return Context.FindChildAt(_indexKeys.Single(_ => _.Value == _history).Key);
            }
        }

        public AutomationElement Actions
        {
            get
            {
                return Context.FindChildAt(_indexKeys.Single(_ => _.Value == _actions).Key);
            }
        }
    }
}
