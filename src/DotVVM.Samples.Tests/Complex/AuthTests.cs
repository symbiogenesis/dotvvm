﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Riganti.Utils.Testing.Selenium.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Testing.Abstractions;

namespace DotVVM.Samples.Tests.Complex
{
    [TestClass]
    public class AuthTests : AppSeleniumTest
    {
        [TestMethod]
        [SampleReference(nameof(SamplesRouteUrls.ComplexSamples_Auth_SecuredPage))]
        public void Complex_Auth_Login()
        {
            RunInAllBrowsers(browser =>
            {
                // try to visit the secured page and verify we are redirected
                browser.NavigateToUrl(SamplesRouteUrls.ComplexSamples_Auth_SecuredPage);
                browser.CheckUrl(u => u.Contains(SamplesRouteUrls.ComplexSamples_Auth_Login));

                // use the login page
                browser.NavigateToUrl(SamplesRouteUrls.ComplexSamples_Auth_Login);

                browser.SendKeys("input[type=text]", "user");
                browser.First("input[type=button]").Click().Wait(500);
                browser.Refresh();
                browser.Wait(2000);
                browser.Last("a").Click();
                browser.Wait(2000);

                browser.SendKeys("input[type=text]", "message");
                browser.First("input[type=button]").Click().Wait(500);

                browser.ElementAt("h1",1)
                    .CheckIfInnerText(
                        s =>
                            s.Contains("DotVVM Debugger: Error 403: Forbidden"),
                            "User is not in admin role"
                        );

                browser.NavigateToUrl(SamplesRouteUrls.ComplexSamples_Auth_Login);
                
                browser.ClearElementsContent("input[type=text]");
                browser.SendKeys("input[type=text]", "ADMIN");
                browser.First("input[type=checkbox]").Click();
                browser.First("input[type=button]").Click().Wait(500);
                browser.Last("a").Click();

                browser.SendKeys("input[type=text]", "message");
                browser.First("input[type=button]").Click().Wait(500);
                browser.First("span").CheckIfInnerText(s => s.Contains("ADMIN: message"), "User can't send message");

            });
        }
    }
}
