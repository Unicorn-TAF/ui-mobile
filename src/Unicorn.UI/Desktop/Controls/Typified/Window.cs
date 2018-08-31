﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using Unicorn.Core.Logging;
using Unicorn.UI.Core.Controls;
using Unicorn.UI.Core.Controls.Interfaces.Typified;
using Unicorn.UI.Desktop.Driver;

namespace Unicorn.UI.Desktop.Controls.Typified
{
    public class Window : GuiContainer, IWindow
    {
        public Window()
        {
        }

        public Window(AutomationElement instance)
            : base(instance)
        {
        }

        public override ControlType Type => ControlType.Window;

        public string Title => this.Text;

        public virtual void Close()
        {
            Logger.Instance.Log(LogLevel.Debug, $"Close {this.ToString()}");
            GetPattern<WindowPattern>().Close();
        }

        public void Focus()
        {
            try
            {
                Logger.Instance.Log(LogLevel.Debug, $"Focusing {this.ToString()}");
                Instance.SetFocus();
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(LogLevel.Warning, $"Unable to focus window: {ex.Message}");
            }
        }

        public void WaitForClosed(int timeout = 5000)
        {
            Logger.Instance.Log(LogLevel.Debug, $"Wait for {this.ToString()} closing");
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var originalTimeout = GuiDriver.ImplicitlyWaitTimeout;
            GuiDriver.ImplicitlyWaitTimeout = TimeSpan.FromSeconds(0);

            try
            {
                do
                {
                    Thread.Sleep(50);
                }
                while (this.Visible && timer.ElapsedMilliseconds < timeout);
            }
            catch (ControlNotFoundException)
            {
            }

            timer.Stop();

            GuiDriver.ImplicitlyWaitTimeout = originalTimeout;

            if (timer.ElapsedMilliseconds > timeout)
            {
                throw new ControlInvalidStateException("Failed to wait for window is closed!");
            }

            Logger.Instance.Log(LogLevel.Trace, $"\tClosed. [Wait time = {timer.Elapsed}]");
        }
    }
}