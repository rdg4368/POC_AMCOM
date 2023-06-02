using OpenQA.Selenium;
using Org.BouncyCastle.Tsp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste.Drivers;

namespace teste.Support
{
    internal class Ultils
    {
        // Não está funcionando, inclusive foi aberto uma issue no https://github.com/SpecFlowOSS/SpecFlow/issues/2696
        public void Screenshot(IWebDriver driver, string screenshotsPasta)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
        }
    }
}
