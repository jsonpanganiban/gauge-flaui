using System;
using System.Linq;
using System.Text;
using DTAF.Core.Desktop.Exceptions;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FluentAssertions;

namespace DTAF.Core.Desktop.Actions
{
    public static class Verify
    {
        public static void Enabled(AutomationElement automationElement, bool shouldBeEnabled)
        {
            try
            {
                automationElement.IsEnabled.Should().Be(shouldBeEnabled);
            }
            catch (Exception)
            {
                var sb = new StringBuilder();
                sb.Append(automationElement.Name);
                sb.Append(' ');
                sb.Append(automationElement.ControlType.ToString());
                sb.Append(" should be ");
                sb.Append(((shouldBeEnabled) ? "enabled" : "disabled"));
                throw new AssertionException(sb.ToString());
            }
        }

        public static void Visible(AutomationElement automationElement, bool shouldBeVisible)
        {
            try
            {
                automationElement.IsOffscreen.Should().Be(!shouldBeVisible);
            }
            catch (Exception)
            {
                var sb = new StringBuilder();
                sb.Append(automationElement.Name);
                sb.Append(' ');
                sb.Append(automationElement.ControlType.ToString());
                sb.Append(" should be ");
                sb.Append(((shouldBeVisible) ? "visible" : "invisible"));
                throw new AssertionException(sb.ToString());
            }
        }

        public static void Value(AutomationElement automationElement, string value)
        {
            try
            {
                if (automationElement.ControlType == ControlType.Edit)
                {
                    automationElement.AsTextBox().Text.Should().Be(value);
                }
                if (automationElement.ControlType == ControlType.ComboBox)
                {
                    automationElement.AsComboBox().SelectedItem.Text.Trim().Should().Be(value);
                }
                if (automationElement.ControlType == ControlType.List)
                {
                    automationElement.AsListBox().SelectedItem.Text.Trim().Should().Be(value);
                }
                if (automationElement.ControlType == ControlType.Tree)
                {
                    automationElement.AsTree().SelectedTreeItem.Text.Trim().Should().Be(value);
                }
            }
            catch (Exception)
            {
                var sb = new StringBuilder();
                sb.Append(automationElement.Name);
                sb.Append(' ');
                sb.Append(automationElement.ControlType.ToString());
                sb.Append("'s value should be '");
                sb.Append(value);
                sb.Append("'");
                throw new AssertionException(sb.ToString());
            }
        }

        public static void Values(AutomationElement automationElement, string[] values)
        {
            try
            {
                if (automationElement.ControlType == ControlType.ComboBox)
                {
                    automationElement.AsComboBox().Items.Select(i => i.Text).ToList().Should().BeEquivalentTo(values.ToList());
                }
            }
            catch (Exception)
            {
                var sb = new StringBuilder();
                sb.Append(automationElement.Name);
                sb.Append(' ');
                sb.Append(automationElement.ControlType.ToString());
                sb.Append("'s items should be '");
                sb.Append(values);
                sb.Append("'");
                throw new AssertionException(sb.ToString());
            }
        }
    }
}
