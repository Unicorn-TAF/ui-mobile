﻿using System;
using Unicorn.UI.Core.Driver;

namespace Unicorn.UI.Core.Controls.Dynamic
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public sealed class DefineDropdownAttribute : DefineAttribute
    {
        public DefineDropdownAttribute(DropdownElement subElement, Using how, string locator)
            : base((int)subElement, how, locator)
        {
        }
    }
}
