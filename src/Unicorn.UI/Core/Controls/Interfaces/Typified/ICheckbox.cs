﻿namespace Unicorn.UI.Core.Controls.Interfaces.Typified
{
    public interface ICheckbox
    {
        bool Checked
        {
            get;
        }

        bool Check();

        bool Uncheck();
    }
}