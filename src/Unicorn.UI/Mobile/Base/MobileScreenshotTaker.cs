﻿using System;
using System.IO;
using Unicorn.Taf.Core.Logging;
using Unicorn.UI.Core;

namespace Unicorn.UI.Mobile.Base
{
    /// <summary>
    /// Provides ability to take screenshots from mobile phone screen.
    /// </summary>
    public class MobileScreenshotTaker : ScreenshotTakerBase
    {
        private const string LogPrefix = nameof(MobileScreenshotTaker);

        private readonly OpenQA.Selenium.ScreenshotImageFormat _format;
        private readonly OpenQA.Selenium.IWebDriver _driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileScreenshotTaker"/> class with screenshots directory.
        /// </summary>
        /// <param name="driver"><see cref="OpenQA.Selenium.IWebDriver"/> instance</param>
        /// <param name="screenshotsDir">directory to save screenshots to</param>
        public MobileScreenshotTaker(OpenQA.Selenium.IWebDriver driver, string screenshotsDir) : base(screenshotsDir)
        {
            _driver = driver;
            _format = OpenQA.Selenium.ScreenshotImageFormat.Png;
            ImageFormat = _format.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileScreenshotTaker"/> class with default directory.<para/>
        /// Default directory is ".\Screenshots" (created automatically if it does not exist).
        /// </summary>
        /// <param name="driver"><see cref="OpenQA.Selenium.IWebDriver"/> instance</param>
        public MobileScreenshotTaker(OpenQA.Selenium.IWebDriver driver) : this(driver, DefaultDirectory)
        {
        }

        /// <summary>
        /// Gets image format string.
        /// </summary>
        protected override string ImageFormat { get; }

        /// <summary>
        /// Takes screenshot and saves by specified path as png file. If target file name is longer than 250 symbols 
        /// it's trimmed and ended with "~" + number of trimmed symbols.
        /// </summary>
        /// <param name="folder">folder to save screenshot to</param>
        /// <param name="fileName">screenshot file name without extension</param>
        /// <returns>path to the screenshot file</returns>
        /// <exception cref="PathTooLongException"> is thrown when directory name is longer than 250 symbols</exception>
        public string TakeScreenshot(string folder, string fileName)
        {
            OpenQA.Selenium.Screenshot printScreen = GetScreenshot();

            if (printScreen == null)
            {
                return string.Empty;
            }

            try
            {
                ULog.Debug("{0}: Saving browser print screen...", LogPrefix);
                string filePath = BuildFileName(folder, fileName);
                printScreen.SaveAsFile(filePath, _format);
                return filePath;
            }
            catch (Exception e)
            {
                ULog.Warn("{0}: Failed to save browser print screen: {1}", LogPrefix, e);
                return string.Empty;
            }
        }

        /// <summary>
        /// Takes screenshot with specified name and saves to screenshots directory.
        /// </summary>
        /// <param name="fileName">screenshot file name without extension</param>
        /// <returns>path to the screenshot file</returns>
        public override string TakeScreenshot(string fileName) => TakeScreenshot(ScreenshotsDir, fileName);

        private OpenQA.Selenium.Screenshot GetScreenshot()
        {
            try
            {
                ULog.Debug("{0}: Creating browser print screen...", LogPrefix);
                return (_driver as OpenQA.Selenium.ITakesScreenshot).GetScreenshot();
            }
            catch (Exception e)
            {
                ULog.Warn("{0}: Failed to get browser print screen: {1}", LogPrefix, e);
                return null;
            }
        }
    }
}