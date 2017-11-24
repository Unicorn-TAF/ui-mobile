﻿namespace Unicorn.UI.Core.UI.Controls
{
    public interface ITextInput
    {
        string Value
        {
            get;
        }

        void SendKeys(string text);
    }
}