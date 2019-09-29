﻿using UIAutomationClient;
using Unicorn.Taf.Core.Logging;
using Unicorn.UI.Core.Controls.Interfaces;

namespace Unicorn.UI.Win.Controls.Typified
{
    /// <summary>
    /// Describes base list item control.
    /// </summary>
    public class ListItem : WinControl, ISelectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListItem"/> class.
        /// </summary>
        public ListItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListItem"/> class with wraps specific <see cref="IUIAutomationElement"/>
        /// </summary>
        /// <param name="instance"><see cref="IUIAutomationElement"/> instance to wrap</param>
        public ListItem(IUIAutomationElement instance)
            : base(instance)
        {
        }

        /// <summary>
        /// Gets UIA list item control type.
        /// </summary>
        public override int UiaType => UIA_ControlTypeIds.UIA_ListItemControlTypeId;

        /// <summary>
        /// Gets a value indicating whether item is selected.
        /// </summary>
        public virtual bool Selected => 
            this.SelectionItemPattern.CurrentIsSelected != 0;

        /// <summary>
        /// Gets selection pattern instance
        /// </summary>
        protected IUIAutomationSelectionItemPattern SelectionItemPattern => 
            this.GetPattern(UIA_PatternIds.UIA_SelectionItemPatternId) as IUIAutomationSelectionItemPattern;

        /// <summary>
        /// Selects the list item.
        /// </summary>
        /// <returns>true - if selection was made; false - if already selected</returns>
        public virtual bool Select()
        {
            Logger.Instance.Log(LogLevel.Debug, $"Selecting {this.ToString()}");

            if (this.Selected)
            {
                Logger.Instance.Log(LogLevel.Trace, "No need to select (already selected)");
                return false;
            }

            var pattern = this.SelectionItemPattern;

            if (pattern != null)
            {
                pattern.Select();
            }
            else
            {
                this.Click();
            }

            Logger.Instance.Log(LogLevel.Trace, "Selected");
            return true;
        }
    }
}
