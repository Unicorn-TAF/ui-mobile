﻿namespace Unicorn.UI.Core.Controls.Interfaces.Typified
{
    /// <summary>
    /// Interface for checkboxes implementation.
    /// </summary>
    public interface ICheckbox
    {
        /// <summary>
        /// Gets value indicating if checkbox is checked.
        /// </summary>
        bool Checked
        {
            get;
        }

        /// <summary>
        /// Set specified state of checkbox bool value.
        /// </summary>
        /// <param name="isChecked">true - to check the checkbox; false - to uncheck</param>
        /// <returns>true - if state was changed; false - if already in specified state</returns>
        bool SetCheckedState(bool isChecked);
    }
}
