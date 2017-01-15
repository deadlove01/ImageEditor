using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeepublicTool.Controllers
{
    using log4net;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Support.UI;
    using RaviLib.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using RaviLib.Utils;

    namespace RedBubbleUploader.Controllers
    {
        public class PhantomController : Singleton<PhantomController>, IDisposable
        {
            private static readonly ILog logger =
                  LogManager.GetLogger(typeof(PhantomController));


            private IWebDriver webDriver;

            public PhantomController()
            {

            }


            public void Login(string email, string pass)
            {
                //try
                {
                    Init();


                    string homeUrl = "https://www.teepublic.com/users/sign_up";
                    webDriver.Navigate().GoToUrl(homeUrl);
                    Thread.Sleep(2000);


                    var emailInput = GetElement(webDriver, By.Name("session[email]"));
                    emailInput.Clear();
                    emailInput.SendKeys(email);
                    Thread.Sleep(500);

                    var passInput = GetElement(webDriver, By.Name("session[password]"));
                    passInput.Clear();
                    passInput.SendKeys(pass);
                    Thread.Sleep(500);

                    var loginBtn = GetElement(webDriver, By.XPath("//input[@class='btn big green']"));
                    DivClick(webDriver, loginBtn); 
                    Thread.Sleep(2000);

                }
                //catch (Exception ex)
                //{
                //    logger.ErrorFormat("Login error:  {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                //}

            }


            public void UploadArt(string logoPath)
            {
               // try
                {
                    string url = "https://www.teepublic.com/design/quick_create";
                    webDriver.Navigate().GoToUrl(url);
                    Thread.Sleep(2500);

                    var fileInput = GetElement(webDriver, By.Name("file"), 30);
                    //fileInput.Clear();
                    fileInput.SendKeys(logoPath);
                    Thread.Sleep(2000);

                   // var div = GetElement(webDriver, By.Id("existing"));

                    do
                    {
                        try
                        {
                            var imgTag = GetElement(webDriver, By.Id("uploader-preview-image"), 3);
                            break;
                        }
                        catch 
                        {
                        }
                    } while (true);
                }
                //catch (Exception ex)
                //{
                //    logger.ErrorFormat("Login error:  {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                //}
            }

            public string UploadDesign(ProductTemplate template, string logoName)
            {
               // try
                {
                    Thread.Sleep(1000);
                    string title = template.Title.Replace("{NAME}", logoName);
                    var titleInput = GetElement(webDriver, By.Name("design[design_title]"));
                    titleInput.Clear();
                    titleInput.SendKeys(title);
                    Thread.Sleep(500);

                   

                    if (!string.IsNullOrEmpty(template.Description))
                    {
                        string des = template.Description.Replace("{NAME}", logoName);
                        var desInput = webDriver.FindElement(By.Name("design[design_description]"));
                        desInput.Clear();
                        desInput.SendKeys(des);
                        Thread.Sleep(500);
                    }

                    string mainTag = template.MainTag.Replace("{NAME}", logoName);
                    var mainTagInput = webDriver.FindElement(By.Name("design[primary_tag]"));
                    mainTagInput.Clear();
                    mainTagInput.SendKeys(mainTag);
                    Thread.Sleep(1500);

                    //if (!string.IsNullOrEmpty(template.Tags))
                    //{
                    //    var tagInput = webDriver.FindElement(By.XPath("//input[@class='select2-input select2-default']"));
                    //    tagInput.Clear();
                    //    tagInput.SendKeys(template.Tags);
                    //    Thread.Sleep(500);
                    //    tagInput.SendKeys(",");
                    //    Thread.Sleep(1000);
                    //}


                    //
                    for (int i = 0; i < template.Products.Count; i++)
                    {
                        var product = template.Products[i];
                       
                        if(product.ProductType == (int)ProductType.APPAREL)
                        {
                            if (!product.UseDefault)
                            {
                                ClickPanel("T-Shirt");
                                // update slider
                                var input = webDriver.FindElement(By.XPath("//input[@name='design[print_mockup_config_attributes][image_size]']"));
                                ChangeToInputAndSetText(webDriver, input, ((int)product.SizePercent).ToString());


                            }

                            for (int k = 0; k < product.ShirtColors.Count; k++)
                            {
                                var shirtColor = product.ShirtColors[k];
                                if (shirtColor.Name == "Baseball Tee"
                                    || shirtColor.Name == "T-Shirt")
                                {
                                    SelectOption("primary_color_" + shirtColor.Name.ToLower().Replace("-", "")
                                        .Replace(" ", ""), shirtColor.Color);
                                }
                            }
                           
                        }else if(product.ProductType == (int) ProductType.PRINTS)
                        {
                            if(!product.UseDefault)
                            {
                                ClickPanel(product.Name);

                                
                                if(product.FullBleedPrint)
                                {
                                    var bleedInput = webDriver.FindElement(By.XPath("//input[@name='design[print_mockup_config_attributes][scale_to_fill]']"));
                                    var divParent = bleedInput.FindElement(By.XPath(".."));
                                    DivClick(webDriver, divParent, 1);
                                }
                                else
                                {
                                    // update slider
                                    var input = webDriver.FindElement(By.XPath("//input[@name='design[print_mockup_config_attributes][image_size]']"));
                                    ChangeToInputAndSetText(webDriver, input, ((int)product.SizePercent).ToString());

                                    // update color 
                                    var colorInput = webDriver.FindElement(By.XPath("//input[@name='design[print_mockup_config_attributes][bg_color]']"));
                                    colorInput.Clear();
                                    colorInput.SendKeys(product.HexColor);
                                    Thread.Sleep(500);
                                }

                                var orientInput = webDriver.FindElement(By.XPath("//input[@class='"+product.OrientationType.ToLower()+"']"));
                                DivClick(webDriver, orientInput, 1);

                                var aspectInput = webDriver.FindElement(By.XPath("//input[@data-name='"+product.AspectRatio+"']"));
                                DivClick(webDriver, aspectInput, 1);
                            }
                        }else
                        {
                            if(!product.UseDefault)
                            {
                                ClickPanel(product.Name);

                                string item1 = string.Empty;
                                string color1 = string.Empty;
                                string color2 = string.Empty;
                                string item2 = string.Empty;
                                if(product.Name == "CASE")
                                {
                                    item1 = "design[case_mockup_config_attributes][image_size]";
                                    color1 = "design[case_mockup_config_attributes][bg_color]";
                                    item2 = "design[laptop_case_mockup_config_attributes][image_size]";
                                    color2 = "design[laptop_case_mockup_config_attributes][bg_color]";
                                }
                                else if(product.Name == "NOTEBOOK")
                                {
                                    item1 = "design[hardcover_notebook_mockup_config_attributes][image_size]";
                                    color1 = "design[hardcover_notebook_mockup_config_attributes][bg_color]";
                                    item2 = "design[spiral_notebook_mockup_config_attributes][image_size]";
                                    color2 = "design[spiral_notebook_mockup_config_attributes][bg_color]";
                                }
                                else if(product.Name == "MUG")
                                {
                                    item1 = "design[coffee_mug_mockup_config_attributes][image_size]";
                                    color1 = "design[coffee_mug_mockup_config_attributes][bg_color]";
                                    item2 = "design[travel_mug_mockup_config_attributes][image_size]";
                                    color2 = "design[travel_mug_mockup_config_attributes][bg_color]";
                                }

                                // update slider
                                var input = webDriver.FindElement(By.XPath("//input[@name='"+item1+"']"));
                                ChangeToInputAndSetText(webDriver, input, ((int)product.SizePercent).ToString());

                                // update color 
                                var colorInput = webDriver.FindElement(By.XPath("//input[@name='"+ color1 + "']"));
                                colorInput.Clear();
                                colorInput.SendKeys(product.HexColor);
                                Thread.Sleep(1000);

                                // update slider
                                var input2 = webDriver.FindElement(By.XPath("//input[@name='" + item2 + "']"));
                                ChangeToInputAndSetText(webDriver, input2, ((int)product.SizePercent).ToString());

                                // update color 
                                var colorInput2 = webDriver.FindElement(By.XPath("//input[@name='" + color2 + "']"));
                                colorInput2.Clear();
                                colorInput2.SendKeys(product.HexColor);
                                Thread.Sleep(1000);
                            }
                        }
                    }
                    //SelectOption("primary_color_tshirt", "Black");
                    //SelectOption("primary_color_baseballtee", "Black/White");
                    //var tshirtInput = webDriver.FindElement(By.Id("primary_color_tshirt"));
                    //var label = tshirtInput.FindElement(By.XPath(".//label[contains(., Black)]"));
                    //var ahref = label.FindElement(By.XPath(".."));
                    //ahref.Click();

                    // term
                    var ahref = webDriver.FindElement(By.Id("terms"));
                    ahref.Click();
                    Thread.Sleep(1000);

                    var submitBtn = webDriver.FindElement(By.XPath("//input[@class='publish-and-promote-button btn big green']"));
                    submitBtn.Click();
                    Thread.Sleep(2000);

                    return webDriver.Url;
                }
                ////catch (Exception ex)
                ////{
                ////    logger.ErrorFormat("Login error:  {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                ////}
            }

            #region private methods

            private void ClickPanel(string controlName)
            {
                var divInput = webDriver
                    .FindElement(By.XPath("//div[@data-canvas-name='"+ StringUtil.ToFirstUpperCase(controlName) + "']"));
                
                Thread.Sleep(500);

                //var divChild = divInput.FindElement(By.XPath(".//div[@class='enabled mockup-display-preview']"));
                DivClick(webDriver, divInput, 2);
            }

            private void SelectOption(string id, string colorName)
            {

                var divInput = webDriver.FindElement(By.Id(id));
                new Actions(webDriver).MoveToElement(divInput).Perform();
                
                IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", divInput);
                // js.ExecuteScript("document.getElementById('"+id+"').focus();");
                Thread.Sleep(500);
                //var ulInput = divInput.FindElement(By.XPath(".//ul[@class='dd-options dd-click-off-close']"));
                DivClick(webDriver, divInput, 2);
                //divInput.Click();
                // DivClick(webDriver, divInput, 1);
                //   Thread.Sleep(800);
                var label = divInput.FindElement(By.XPath(".//label[contains(., '"+ colorName + "')]"));
                var ahref = label.FindElement(By.XPath("../.."));
                ahref.Click();
              
                Thread.Sleep(1500);
            }
            private void Init()
            {
                if (webDriver != null)
                    webDriver.Quit();
                //webDriver = new PhantomJSDriver();
                var options = new ChromeOptions();
                //use the block image extension to prevent images from downloading.
               // options.AddExtension("Block-image_v1.0.crx");
                webDriver = new ChromeDriver(options);
                webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60 * 5));
            }


            private IWebElement GetElement(IWebDriver driver, By by, int sleep = 5)
            {
                if (sleep > 0)
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sleep));
                    //return wait.Until(drv => drv.FindElement(by));
                    return wait.Until(ExpectedConditions.ElementExists(by));
                }
                return driver.FindElement(by);

            }

            public void Dispose()
            {
                if (webDriver != null)
                    webDriver.Quit();
            }

            private void DivClick(IWebDriver driver, IWebElement div, int sleep = 0)
            {
                try
                {
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(div);
                    actions.Click();
                    actions.Build().Perform();

                    if (sleep > 0)
                        Thread.Sleep(sleep * 1000);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    logger.Error(ex.StackTrace);
                }

            }


            private void MoveSlider(IWebDriver driver, IWebElement slider, int offetX, int offsetY, int sleep = 0)
            {
                try
                {

                    Actions moveSlider = new Actions(driver);
                    //moveSlider.DragAndDropToOffset(slider, 0.01f, offetX).Build().Perform();
                    // moveSlider.SendKeys(Keys.ArrowLeft);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                    js.ExecuteScript("arguments[0].setAttribute('type', 'input')", slider);
                    slider.Clear();
                    slider.SendKeys("50");
                    Thread.Sleep(300);

                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    logger.Error(ex.StackTrace);
                }
            }

            private void ChangeToInputAndSetText(IWebDriver driver, IWebElement input, string text, int sleep = 1)
            {
                try
                {

                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].setAttribute('style', '')", input);
                    Thread.Sleep(300);
                    js.ExecuteScript("arguments[0].setAttribute('type', 'input')", input);
                    input.Clear();
                    input.SendKeys(text);
                    Thread.Sleep(sleep * 1000);

                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    logger.Error(ex.StackTrace);
                }
            }



            #endregion
        }
    }

}
