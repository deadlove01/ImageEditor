using AutoArtist.Controller;
using AutoArtist.Model;
using log4net;
using SunfrogUploader.Model;
using SunfrogUploader.Properties;
using SunfrogUploader.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SunfrogUploader.Controller
{
    public class BackendController : Singleton<BackendController>
    {
        private static readonly ILog logger =
             LogManager.GetLogger(typeof(BackendController));
        public LogoConfig LogoConfig { get; set; }
        public SunfrogConfig SunfrogConfig { get; set; }

        public ContentConfig ContentConfig { get; set; }

        public string SunfrogLink { get; set; }

        private List<string> nameList;


        public static bool IsMaintain = false;

        public int NameCount
        {
            get
            {
                return nameList.Count;
            }
        }
        public BackendController()
        {
            nameList = new List<string>();
        }

        private string CreateNewSunfrogData(string names, string logoPath, ref string refTitle)
        {
            string exportName = names.Replace(Settings.Default.SplitString, Settings.Default.ExportSplitString);
            //string[] temp = name.Split(new string[] { Settings.Default.SplitString }, StringSplitOptions.None);

            string[] temp = names.Split(new string[] { Settings.Default.SplitString }, StringSplitOptions.None);
            string realName = names;
            if (temp != null)
                realName = temp[0];
            UploadModel model = new UploadModel();
            model.ArtOwnerID = SunfrogController.Instance.AM;
            model.Category = ContentConfig.Category;
            model.IAgree = true;
            model.Description = ContentConfig.Description.Replace("{NAME}", realName);
            string[] titleArr = ContentConfig.Title.Split(';');
            Random rand = new Random();
            int randIndex = rand.Next(0, titleArr.Length);
            if (temp != null && temp.Length > 0)
            {
                //model.Title = UploadContent.Title;
                model.Title = titleArr[randIndex];
                for (int i = 0; i < temp.Length; i++)
                {
                    model.Title = model.Title.Replace("{" + i + "}", temp[i]);
                    // model.Keywords.Add(temp[i]);
                }
                model.Keywords.Add(string.Format(ContentConfig.SiteTags, realName));
            }
            else
            {
                model.Title = string.Format(titleArr[randIndex], realName);
                model.Keywords.Add(string.Format(ContentConfig.SiteTags, realName));
            }

            refTitle = model.Title;

            model.imageFront = "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" width=\"2400px\" height=\"3200px\" " +
                "xmlns:xlink=\"http://www.w3.org/1999/xlink\">" +
                "<g id=\"SvgjsG1048\" transform=\"rotate(0 1200 1600) translate({0}) scale({1}) \">" +
                "<image id=\"SvgjsImage1049\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" " +
                "xlink:href=\"__dataURI:0__\" width=\"2400\" height=\"3200\"></image></g></svg>";
            //model.imageFront = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http:/www.w3.org/1999/xlink\" "
            //    + "id=\"SvgjsSvg1000\" version=\"1.1\" width=\"2400\" height=\"3200\" " +
            //    "viewBox=\"311.00000000008 230 387.99999999984004 517.33333333312\"><g id=\"SvgjsG1048\" transform=\"scale(0.15749999999993336 0.15749999999993336) translate({0})\">" +
            //    "<image id=\"SvgjsImage1049\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" xlink:href=\"__dataURI:0__\" width=\"2400\" height=\"3200\">" +
            //    "</image></g><defs id=\"SvgjsDefs1001\"></defs></svg>";
            model.imageFront = string.Format(model.imageFront, LogoConfig.MockupPosition, LogoConfig.MockupScale);
            ////   model.imageFront = "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" width=\"2400\" height=\"3200\" viewBox=\"311.00000000008 230 387.99999999984004 517.33333333312\" "+
            ////  "xmlns:xlink=\"http://www.w3.org/1999/xlink\">" +
            ////  "<g id=\"SvgjsG1048\" transform=\"rotate(0 1200 1600) translate({0}) scale({1}) \">" +
            ////  "<image id=\"SvgjsImage1049\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" " +
            ////  "xlink:href=\"__dataURI:0__\" width=\"2400\" height=\"3200\"></image></g></svg>";

            ////   model.imageFront = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" id=\"SvgjsSvg1000\" version=\"1.1\" width=\"2400\" height=\"3200\" viewBox=\"311.00000000008 230 387.99999999984004 517.33333333312\"><g id=\"SvgjsG1048\" transform=\"scale(0.15749999999993336 0.15749999999993336) translate(2006.349206350563 1502.645502646138)\"><image id=\"SvgjsImage1049\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" xlink:href=\"__dataURI:0__\" width=\"2400\" height=\"3200\"></image></g><defs id=\"SvgjsDefs1001\"></defs></svg>";
            model.imageBack = "";
            ImageLink imgLink = new ImageLink();
            imgLink.id = "__dataURI:0__";
            imgLink.uri = "data:image/png;base64," +
                LogoUtil.ImageToBase64(Image.FromFile(logoPath),
                System.Drawing.Imaging.ImageFormat.Png);

            ShirtType guys = new ShirtType();
            guys.id = "8";
            guys.name = "Guys Tee";
            guys.price = ContentConfig.GuysPrice.ToString();
            guys.price = guys.price.Replace(',', '.');
            // guys.colors.AddRange(LogoScript.GuysColor.Split(','));
            guys.colors.Add(LogoConfig.GuysColor.Split(',')[0]);

            ShirtType ladies = new ShirtType();
            ladies.id = "34";
            ladies.name = "Ladies Tee";
            ladies.price = ContentConfig.LadiesPrice.ToString();
            ladies.price = ladies.price.Replace(',', '.');
            //ladies.colors.AddRange(LogoScript.LadiesColor.Split(','));
            ladies.colors.Add(LogoConfig.LadiesColor.Split(',')[0]);

            ShirtType sweatShirt = new ShirtType();
            sweatShirt.id = "27";
            sweatShirt.name = "Sweat Shirt";
            sweatShirt.price = ContentConfig.SweatShirtPrice.ToString();
            sweatShirt.price = sweatShirt.price.Replace(',', '.');
            //sweatShirt.colors.AddRange(LogoScript.SweatShirtColor.Split(','));
            sweatShirt.colors.Add(LogoConfig.SweatShirtColor.Split(',')[0]);

            ShirtType youthTee = new ShirtType();
            youthTee.id = "35";
            youthTee.name = "Youth Tee";
            youthTee.price = ContentConfig.YouthTeePrice.ToString();
            youthTee.price = youthTee.price.Replace(',', '.');
            //sweatShirt.colors.AddRange(LogoScript.SweatShirtColor.Split(','));
            youthTee.colors.Add(LogoConfig.YouthTeeColor.Split(',')[0]);

            ShirtType guysVNeck = new ShirtType();
            guysVNeck.id = "50";
            guysVNeck.name = "Guys V-Neck";
            guysVNeck.price = ContentConfig.GuysVNeckPrice.ToString();
            guysVNeck.price = guysVNeck.price.Replace(',', '.');
            //guysVNeck.colors.AddRange(LogoScript.GuysVNeck.Split(','));
            guysVNeck.colors.Add(LogoConfig.GuysVNeck.Split(',')[0]);

            ShirtType ladiesVNeck = new ShirtType();
            ladiesVNeck.id = "116";
            ladiesVNeck.name = "Ladies V-Neck";
            ladiesVNeck.price = ContentConfig.LadiesVNeckPrice.ToString();
            ladiesVNeck.price = ladiesVNeck.price.Replace(',', '.');
            // ladiesVNeck.colors.AddRange(LogoScript.LadiesVNeck.Split(','));
            ladiesVNeck.colors.Add(LogoConfig.LadiesVNeck.Split(',')[0]);

            ShirtType unisexTankTop = new ShirtType();
            unisexTankTop.id = "118";
            unisexTankTop.name = "Unisex Tank Top";
            unisexTankTop.price = ContentConfig.UnisexTankTopPrice.ToString();
            unisexTankTop.price = unisexTankTop.price.Replace(',', '.');
            //unisexTankTop.colors.AddRange(LogoScript.UnisexTankTop.Split(','));
            unisexTankTop.colors.Add(LogoConfig.UnisexTankTop.Split(',')[0]);

            ShirtType unisexLongSleeve = new ShirtType();
            unisexLongSleeve.id = "119";
            unisexLongSleeve.name = "Unisex Long Sleeve";
            unisexLongSleeve.price = ContentConfig.UnisexLongSleeve.ToString();
            unisexLongSleeve.price = unisexLongSleeve.price.Replace(',', '.');
            //unisexLongSleeve.colors.AddRange(LogoScript.UnisexLongSleeve.Split(','));
            unisexLongSleeve.colors.Add(LogoConfig.UnisexLongSleeve.Split(',')[0]);


            ShirtType hoodie = new ShirtType();
            hoodie.id = "19";
            hoodie.name = "Hoodie";
            hoodie.price = ContentConfig.HoodiesPrice.ToString();
            hoodie.price = hoodie.price.Replace(',', '.');
            //hoodie.colors.AddRange(LogoScript.HoodieColor.Split(','));
            hoodie.colors.Add(LogoConfig.HoodieColor.Split(',')[0]);

            model.images.Add(imgLink);

            if (LogoConfig.PrimaryMockupName.ToLower().StartsWith("hoodie"))
            {
                //hoodie.colors.RemoveRange(1, hoodie.colors.Count - 1);
                model.types.Add(hoodie);
                model.types.Add(guys);
                model.types.Add(ladies);
                model.types.Add(guysVNeck);
                model.types.Add(ladiesVNeck);
                model.types.Add(unisexLongSleeve);
                model.types.Add(unisexTankTop);
                model.types.Add(sweatShirt);
                model.types.Add(youthTee);
            }
            else if (LogoConfig.PrimaryMockupName.ToLower().StartsWith("guys"))
            {
                //guys.colors.RemoveRange(1, guys.colors.Count - 1);
                model.types.Add(guys);
                model.types.Add(ladies);
                model.types.Add(hoodie);
                model.types.Add(guysVNeck);
                model.types.Add(ladiesVNeck);
                model.types.Add(unisexLongSleeve);
                model.types.Add(unisexTankTop);
                model.types.Add(sweatShirt);
                model.types.Add(youthTee);
            }
            else if (LogoConfig.PrimaryMockupName.ToLower().StartsWith("ladies"))
            {
                //ladies.colors.RemoveRange(1, ladies.colors.Count - 1);
                model.types.Add(ladies);
                model.types.Add(guys);
                model.types.Add(hoodie);
                model.types.Add(guysVNeck);
                model.types.Add(ladiesVNeck);
                model.types.Add(unisexLongSleeve);
                model.types.Add(unisexTankTop);
                model.types.Add(sweatShirt);
                model.types.Add(youthTee);
            }


            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        private string LoadNewSunfrogData(string name, string exportPath, string logoRootPath, string logoName,
            string splitString, string exportSplitString, bool isScaleAll)
        {
            ArtistController.Instance.ExportLogo(name, exportPath, logoRootPath, logoName,
                splitString, exportSplitString, isScaleAll);
            string exportName = name.Replace(splitString, exportSplitString);
            return exportPath + exportName + ".png";

        }


        private void SaveNewToDB(string name, UploadNewResult modelResult, string groupID, string title, System.Windows.Forms.RichTextBox lbError)
        {
            try
            {
                if (modelResult != null)
                {
                    lbError.Invoke(new Action(() => lbError.Text += "\n" + modelResult.description));
                    if (modelResult.products != null && modelResult.products.Count > 0)
                    {
                        string[] temp = name.Split(new string[] { Settings.Default.SplitString}, StringSplitOptions.None);
                        string realName = name;
                        if (temp != null)
                            realName = temp[0];
                        ArtModel model = new ArtModel();
                        model.AccountUpload = SunfrogController.Instance.SFAcc;                        
                        model.LogoName = SunfrogConfig.Logo;
                        model.Name = name;
                        model.Title = title;
                        string primaryMockup = LogoConfig.PrimaryMockupName;
                        string sunfrogPage = "https://www.sunfrog.com/";
                        for (int i = 0; i < modelResult.products.Count; i++)
                        {
                            var product = modelResult.products[i];
                            if (product.id == "19"
                                && primaryMockup.ToLower().EndsWith(product.color.ToLower()))
                            {
                                model.HoodieLink = sunfrogPage + product.pageName;
                                model.HoodieImage = "http:" + product.imageFront;
                                //SunfrogToolKit.UploadLink = model.SunfrogLink;
                            }
                            else if (product.id == "8"
                               && primaryMockup.ToLower().EndsWith(product.color.ToLower()))
                            {
                                model.GuysLink = sunfrogPage + product.pageName;
                                model.GuysImage = "http:" + product.imageFront;
                            }
                            else if (product.id == "34"
                               && primaryMockup.ToLower().EndsWith(product.color.ToLower()))
                            {
                                model.LadiesLink = sunfrogPage + product.pageName;
                                model.LadiesImage = "http:" + product.imageFront;
                            }
                        }

                        MongoController.Instance.InsertArtModel(model);
                        lbError.Invoke(new Action(() => {
                            lbError.Text += "\r\n" + model.HoodieLink;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                lbError.Invoke(new Action(() => lbError.Text += "\r\n"+name + " error: " + ex.Message));
                logger.Error(ex.Message);
            }

        }

        private void SaveNewToDB(string name, UploadNewResult modelResult, string splitString, string exportSplitString)
        {
            try
            {
                if (modelResult != null)
                {
                    if (modelResult.products != null && modelResult.products.Count > 0)
                    {
                        string exportName = name.Replace(splitString, exportSplitString);
                        string[] temp = name.Split(new string[] { splitString }, StringSplitOptions.None);
                        //string realName = name;
                        //if (temp != null)
                           // realName = temp[0];
                        ArtModel model = new ArtModel();
                        model.AccountUpload = SunfrogConfig.SFAcc;
                        model.LogoName = SunfrogConfig.Logo;
                        model.Name = exportName;
                        if (temp != null && temp.Length > 0)
                        {
                            model.Title = ContentConfig.Title;
                            for (int i = 0; i < temp.Length; i++)
                            {
                                model.Title = model.Title.Replace("{" + i + "}", temp[i]);
                            }
                        }
                        else
                        {
                            model.Title = string.Format(ContentConfig.Title, name);
                        }
                        string primaryMockup = LogoConfig.PrimaryMockupName;
                        string sunfrogPage = "https://www.sunfrog.com/";
                        for (int i = 0; i < modelResult.products.Count; i++)
                        {
                            var product = modelResult.products[i];
                            if (product.id == "19"
                                && primaryMockup.ToLower().EndsWith(product.color.ToLower()))
                            {
                                model.HoodieLink = sunfrogPage + product.pageName;
                                model.HoodieImage = "http:" + product.imageFront;
                                SunfrogLink = model.HoodieLink;
                            }
                            else if (product.id == "8"
                               && primaryMockup.ToLower().EndsWith(product.color.ToLower()))
                            {
                                model.GuysLink = sunfrogPage + product.pageName;
                                model.GuysImage = "http:" + product.imageFront;
                            }
                            else if (product.id == "34"
                               && primaryMockup.ToLower().EndsWith(product.color.ToLower()))
                            {
                                model.LadiesLink = sunfrogPage + product.pageName;
                                model.LadiesImage = "http:" + product.imageFront;
                            }
                        }
                        MongoController.Instance.InsertArtModel(model);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        public void LoadNameList(string listNamePath, bool isAutoLogo)
        {
            
            nameList.Clear();
            if(!isAutoLogo)
            {
                var files = Directory.GetFiles(listNamePath, "*.png");
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        nameList.Add(files[i]);
                    }
                }
            }
            else
            {
                string[] names = File.ReadAllLines(listNamePath);
                for (int i = 0; i < names.Length; i++)
                {
                    string name = names[i];
                    if (LogoConfig.NameType == (int)NameType.UPPER)
                    {
                        name = name.ToUpper();
                    }
                    else if (LogoConfig.NameType == (int)NameType.LOWER)
                    {
                        name = name.ToLower();
                    }
                    else if (LogoConfig.NameType == (int)NameType.FIRST_UPPER)
                    {
                        name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
                    }
                    nameList.Add(name);
                }
            }


        }

        public bool Step1()
        {
            try
            {
                return SunfrogController.Instance.Login(SunfrogConfig.SFAcc, FileUtil.Decrypt(SunfrogConfig.SFPass));
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error Message: {0}\nStacktrace: {1}", ex.Message, ex.StackTrace);
            }
            return false;
        }

        public bool Step2(System.Windows.Forms.RichTextBox lbError, System.Windows.Forms.ProgressBar progCurrentName, System.Windows.Forms.Label lblCurName,
                System.Windows.Forms.Label lblNameIndex, bool isScaleAll, bool isAutoLogo = true, bool isSaveDb = true)
        {
            try
            {
                string folderPath = Directory.GetCurrentDirectory();
                string exportLogoPath = folderPath + Settings.Default.LogoExportPath;
                string logoName = SunfrogConfig.Logo;
                ////string logoName = "Logo 83";
                string logoRootPath = folderPath + Settings.Default.LogoPath + logoName + "\\";

                for (int i = 0; i < nameList.Count; i++)
                {
                    if(string.IsNullOrEmpty(nameList[i]))
                    {
                        nameList.RemoveAt(i);
                        i--;
                    }
                }

                if(isAutoLogo)
                {
                    if (SunfrogConfig.StartRange + SunfrogConfig.EndRange > nameList.Count)
                    {
                        nameList = nameList.Skip(SunfrogConfig.StartRange).Take(nameList.Count).DefaultIfEmpty().ToList();
                    }
                    else
                    {
                        nameList = nameList.Skip(SunfrogConfig.StartRange).Take(SunfrogConfig.EndRange).DefaultIfEmpty().ToList();
                    }

                }

                if(!isSaveDb)
                {
                    if (File.Exists(folderPath + Settings.Default.ListNameSuccess))
                    {
                        var existedList = File.ReadLines(folderPath + Settings.Default.ListNameSuccess).ToList();
                        for (int i = 0; i < existedList.Count; i++)
                        {
                            nameList.Remove(existedList[i]);
                        }
                    }
                }
              
                if (nameList.Count > 0)
                {
                    progCurrentName.Invoke(new Action(() => progCurrentName.Value = progCurrentName.Minimum));
                   
                    for (int i = 0; i < nameList.Count; i++)
                    //int i = 0;
                    // Parallel.ForEach(nameList, (name) =>
                    {
                        string logoPath = string.Empty;
                        string name = nameList[i];
                        if(!isAutoLogo)
                        {
                            logoPath = nameList[i];
                            name = Path.GetFileNameWithoutExtension(logoPath);
                        }
                        

                        try
                        {
                            string[] temp = name.Split(new string[] { Settings.Default.SplitString }, StringSplitOptions.None);
                            string realName = name;
                            if (temp != null)
                                realName = temp[0];

                            //string realName = name.Replace(Settings.Default.SplitString, Settings.Default.ExportSplitString);
                            lblCurName.Invoke(new Action(() => lblCurName.Text = realName));
                            ArtModel model = null;
                            if(isSaveDb)
                            {
                                model = MongoController.Instance.FindModel(name, logoName);
                            }
                            if (model == null)
                            {
                               
                                if(isAutoLogo)
                                {
                                    logoPath = LoadNewSunfrogData(name, exportLogoPath, folderPath + Settings.Default.LogoPath,
                                    logoName, Settings.Default.SplitString, Settings.Default.ExportSplitString, isScaleAll);
                                }

                                string title = string.Empty;
                                string jsonData = CreateNewSunfrogData(name, logoPath, ref title);

                                SunfrogController.Instance.web.SendRequest("https://manager.sunfrogshirts.com/Designer/", "GET", null);

                                string result = SunfrogController.Instance.UplodNewMockup(jsonData);
                                if (result.Contains("Temporarily Unavailable")
                                    || result.Contains("Sorry, this service is currently unavailable"))
                                {
                                    lbError.Invoke(new Action(() => lbError.Text += "\nSunfrog bảo trì rồi"));
                                    BackendController.IsMaintain = true;
                                    i--;
                                    SchedulerController.Instance.Start();
                                    while (BackendController.IsMaintain)
                                    {
                                        Thread.Sleep(1000 * 60 * 5);
                                    }
                                }
                                logger.Debug("result: " + result);
                                UploadNewResult modelResult = Newtonsoft.Json.JsonConvert.DeserializeObject<UploadNewResult>(result);
                                if (modelResult != null)
                                {

                                    string description = modelResult.description.ToLower();
                                    if (description.Contains("error creating mockup image."))
                                    {
                                        logger.Error("upload error: " + description);
                                        break;
                                    }
                                    else if (description.Contains("please refresh this page to login"))
                                    {
                                        SunfrogController.Instance.Login(SunfrogConfig.SFAcc, SunfrogConfig.SFPass);
                                        i--;
                                        continue;
                                    }
                                }
                                string rawLink = modelResult.products[0].pageName;
                                string groupID = ExtractGroupID(rawLink);
                                string jsonUpdateData = CreateUpdatingMockupJson(groupID, SunfrogController.Instance.AM);
                                Task task = SunfrogController.Instance.UpdateMockup(jsonUpdateData);
                                Task.WhenAll(task);
                                Console.WriteLine("test");

                                if(isSaveDb)
                                {
                                    SaveNewToDB(name, modelResult, groupID, title, lbError);
                                }

                                lbError.Invoke(new Action(() => {
                                    if (lbError.TextLength >= 500)
                                    {
                                        lbError.Text = "";
                                    }
                                }));

                                //SaveNewToDB(name, modelResult, Settings.Default.SplitString, Settings.Default.ExportSplitString);
                                File.AppendAllLines(folderPath + Settings.Default.ListNameSuccess, new String[] { name });
                               // File.AppendAllLines(folderPath + Settings.Default.UploadedLinks, new String[] { SunfrogLink });
                            }
                            //else
                            {
                                lbError.Invoke(new Action(() => {
                                    lbError.Text += "\r\n" + name + " da upload!";
                                }));
                            }

                        }
                        catch (Exception)
                        {
                            File.AppendAllLines(folderPath + Settings.Default.ErrorNameList, new String[] { name });
                        }
                        progCurrentName.Invoke(new Action(() => progCurrentName.Value = (i + 1) * 100 / nameList.Count));
                        lblNameIndex.Invoke(new Action(() => lblNameIndex.Text = string.Format("{0}/{1}", i + 1, nameList.Count)));

                    };

                }

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error Message: {0}\nStacktrace: {1}", ex.Message, ex.StackTrace);
            }
            return false;
        }


        private string ExtractGroupID(string rawLink)
        {
            Regex regex = new Regex("\\d+-");
            Match matcher = regex.Match(rawLink);
            if (matcher.Success)
            {
                return matcher.Groups[0].Value.Replace("-", "");
            }
            else
                return null;
        }

        private string CreateUpdatingMockupJson(string groupID, string am)
        {
            UpdateMockupModel model = new UpdateMockupModel();
            model.ArtOwnerID = am;
            model.IsAddVariantGroup = groupID;
            model.IAgree = true;
            model.isAddVariant = true;


            ShirtType guys = new ShirtType();
            guys.id = "8";
            guys.name = "Guys Tee";
            guys.price = ContentConfig.GuysPrice.ToString();
            guys.price = guys.price.Replace(',', '.');
            guys.colors.AddRange(LogoConfig.GuysColor.Split(','));

            ShirtType ladies = new ShirtType();
            ladies.id = "34";
            ladies.name = "Ladies Tee";
            ladies.price = ContentConfig.LadiesPrice.ToString();
            ladies.price = ladies.price.Replace(',', '.');
            ladies.colors.AddRange(LogoConfig.LadiesColor.Split(','));

            ShirtType sweatShirt = new ShirtType();
            sweatShirt.id = "27";
            sweatShirt.name = "Sweat Shirt";
            sweatShirt.price = ContentConfig.SweatShirtPrice.ToString();
            sweatShirt.price = sweatShirt.price.Replace(',', '.');
            sweatShirt.colors.AddRange(LogoConfig.SweatShirtColor.Split(','));

            ShirtType guysVNeck = new ShirtType();
            guysVNeck.id = "50";
            guysVNeck.name = "Guys V-Neck";
            guysVNeck.price = ContentConfig.GuysVNeckPrice.ToString();
            guysVNeck.price = guysVNeck.price.Replace(',', '.');
            guysVNeck.colors.AddRange(LogoConfig.GuysVNeck.Split(','));

            ShirtType ladiesVNeck = new ShirtType();
            ladiesVNeck.id = "116";
            ladiesVNeck.name = "Ladies V-Neck";
            ladiesVNeck.price = ContentConfig.LadiesVNeckPrice.ToString();
            ladiesVNeck.price = ladiesVNeck.price.Replace(',', '.');
            ladiesVNeck.colors.AddRange(LogoConfig.LadiesVNeck.Split(','));

            ShirtType unisexTankTop = new ShirtType();
            unisexTankTop.id = "118";
            unisexTankTop.name = "Unisex Tank Top";
            unisexTankTop.price = ContentConfig.UnisexTankTopPrice.ToString();
            unisexTankTop.price = unisexTankTop.price.Replace(',', '.');
            unisexTankTop.colors.AddRange(LogoConfig.UnisexTankTop.Split(','));

            ShirtType unisexLongSleeve = new ShirtType();
            unisexLongSleeve.id = "119";
            unisexLongSleeve.name = "Unisex Long Sleeve";
            unisexLongSleeve.price = ContentConfig.UnisexLongSleeve.ToString();
            unisexLongSleeve.price = unisexLongSleeve.price.Replace(',', '.');
            unisexLongSleeve.colors.AddRange(LogoConfig.UnisexLongSleeve.Split(','));


            ShirtType hoodie = new ShirtType();
            hoodie.id = "19";
            hoodie.name = "Hoodie";
            hoodie.price = ContentConfig.HoodiesPrice.ToString();
            hoodie.price = hoodie.price.Replace(',', '.');
            hoodie.colors.AddRange(LogoConfig.HoodieColor.Split(','));

            ShirtType youthTee = new ShirtType();
            youthTee.id = "35";
            youthTee.name = "Youth Tee";
            youthTee.price = ContentConfig.YouthTeePrice.ToString();
            youthTee.price = youthTee.price.Replace(',', '.');
            youthTee.colors.AddRange(LogoConfig.YouthTeeColor.Split(','));

            youthTee.colors.RemoveAt(0);
            hoodie.colors.RemoveAt(0);
            guys.colors.RemoveAt(0);
            ladies.colors.RemoveAt(0);
            guysVNeck.colors.RemoveAt(0);
            ladiesVNeck.colors.RemoveAt(0);
            unisexLongSleeve.colors.RemoveAt(0);
            unisexTankTop.colors.RemoveAt(0);
            sweatShirt.colors.RemoveAt(0);

            if (LogoConfig.PrimaryMockupName.ToLower().StartsWith("hoodie"))
            {

                model.types.Add(hoodie);
                model.types.Add(guys);
                model.types.Add(ladies);
                model.types.Add(guysVNeck);
                model.types.Add(ladiesVNeck);
                model.types.Add(unisexLongSleeve);
                model.types.Add(unisexTankTop);
                model.types.Add(sweatShirt);
                model.types.Add(youthTee);

                //model.styles.Add(new ShirtStyle { id = guys.id, name = guys.name });
                //model.styles.Add(new ShirtStyle { id = ladies.id, name = ladies.name });
                //model.styles.Add(new ShirtStyle { id = sweatShirt.id, name = sweatShirt.name });
                //model.styles.Add(new ShirtStyle { id = guysVNeck.id, name = guysVNeck.name });
                //model.styles.Add(new ShirtStyle { id = ladiesVNeck.id, name = ladiesVNeck.name });
                //model.styles.Add(new ShirtStyle { id = unisexTankTop.id, name = unisexTankTop.name });
                //model.styles.Add(new ShirtStyle { id = unisexLongSleeve.id, name = unisexLongSleeve.name });
            }
            else if (LogoConfig.PrimaryMockupName.ToLower().StartsWith("guys"))
            {
                model.types.Add(guys);
                model.types.Add(ladies);
                model.types.Add(hoodie);
                model.types.Add(guysVNeck);
                model.types.Add(ladiesVNeck);
                model.types.Add(unisexLongSleeve);
                model.types.Add(unisexTankTop);
                model.types.Add(sweatShirt);
                model.types.Add(youthTee);
                //model.styles.Add(new ShirtStyle { id = hoodie.id, name = hoodie.name });
                //model.styles.Add(new ShirtStyle { id = ladies.id, name = ladies.name });
                //model.styles.Add(new ShirtStyle { id = sweatShirt.id, name = sweatShirt.name });
                //model.styles.Add(new ShirtStyle { id = guysVNeck.id, name = guysVNeck.name });
                //model.styles.Add(new ShirtStyle { id = ladiesVNeck.id, name = ladiesVNeck.name });
                //model.styles.Add(new ShirtStyle { id = unisexTankTop.id, name = unisexTankTop.name });
                //model.styles.Add(new ShirtStyle { id = unisexLongSleeve.id, name = unisexLongSleeve.name });
            }
            else if (LogoConfig.PrimaryMockupName.ToLower().StartsWith("ladies"))
            {
                model.types.Add(ladies);
                model.types.Add(guys);
                model.types.Add(hoodie);
                model.types.Add(guysVNeck);
                model.types.Add(ladiesVNeck);
                model.types.Add(unisexLongSleeve);
                model.types.Add(unisexTankTop);
                model.types.Add(sweatShirt);
                model.types.Add(youthTee);
                //model.styles.Add(new ShirtStyle { id = guys.id, name = guys.name });
                //model.styles.Add(new ShirtStyle { id = hoodie.id, name = hoodie.name });
                //model.styles.Add(new ShirtStyle { id = sweatShirt.id, name = sweatShirt.name });
                //model.styles.Add(new ShirtStyle { id = guysVNeck.id, name = guysVNeck.name });
                //model.styles.Add(new ShirtStyle { id = ladiesVNeck.id, name = ladiesVNeck.name });
                //model.styles.Add(new ShirtStyle { id = unisexTankTop.id, name = unisexTankTop.name });
                //model.styles.Add(new ShirtStyle { id = unisexLongSleeve.id, name = unisexLongSleeve.name });
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

    }
}
