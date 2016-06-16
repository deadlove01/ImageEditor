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

        private string CreateNewSunfrogData(string name, string logoPath)
        {
            string exportName = name.Replace(Settings.Default.SplitString, Settings.Default.ExportSplitString);
            string[] temp = name.Split(new string[] { Settings.Default.SplitString }, StringSplitOptions.None);

            UploadModel model = new UploadModel();
            model.ArtOwnerID = SunfrogController.Instance.AM;
            model.Category = ContentConfig.Category;
            model.IAgree = true;
            model.Description = ContentConfig.Description;
            if (temp != null && temp.Length > 0)
            {
                model.Title = ContentConfig.Title;
                for (int i = 0; i < temp.Length; i++)
                {
                    model.Title = model.Title.Replace("{" + i + "}", temp[i]);
                    model.Keywords.Add(temp[i]);
                }
            }
            else
            {
                model.Title = string.Format(ContentConfig.Title, name);
                model.Keywords.Add(string.Format(ContentConfig.SiteTags, name));
            }
            
            model.imageFront = "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" width=\"2400px\" height=\"3200px\" " +
                "xmlns:xlink=\"http://www.w3.org/1999/xlink\">" +
                "<g id=\"SvgjsG1048\" transform=\"rotate(0 1200 1600) translate({0}) scale({1}) \">" +
                "<image id=\"SvgjsImage1049\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" " +
                "xlink:href=\"__dataURI:0__\" width=\"2400\" height=\"3200\"></image></g></svg>";

            model.imageFront = string.Format(model.imageFront, LogoConfig.MockupPosition,
                LogoConfig.MockupScale);

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
            guys.colors.AddRange(LogoConfig.GuysColor.Split(','));

            ShirtType ladies = new ShirtType();
            ladies.id = "34";
            ladies.name = "Ladies Tee";
            ladies.price = ContentConfig.LadiesPrice.ToString();
            ladies.colors.AddRange(LogoConfig.LadiesColor.Split(','));

            ShirtType hoodie = new ShirtType();
            hoodie.id = "19";
            hoodie.name = "Hoodie";
            hoodie.price = ContentConfig.HoodiesPrice.ToString();
            hoodie.colors.AddRange(LogoConfig.HoodieColor.Split(','));

            model.images.Add(imgLink);

            if (LogoConfig.PrimaryMockupName.ToLower().StartsWith("hoodie"))
            {
                model.types.Add(hoodie);
                model.types.Add(guys);
                model.types.Add(ladies);
            }
            else if (LogoConfig.PrimaryMockupName.ToLower().StartsWith("guys"))
            {
                model.types.Add(guys);
                model.types.Add(ladies);
                model.types.Add(hoodie);
            }
            else if (LogoConfig.PrimaryMockupName.ToLower().StartsWith("ladies"))
            {
                model.types.Add(ladies);
                model.types.Add(guys);
                model.types.Add(hoodie);
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

        public void LoadNameList(string listNamePath)
        {
            
            nameList.Clear();
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

        public bool Step2(System.Windows.Forms.ProgressBar progCurrentName, System.Windows.Forms.Label lblCurName,
                System.Windows.Forms.Label lblNameIndex, bool isScaleAll)
        {
            try
            {
                string folderPath = Directory.GetCurrentDirectory();
                string exportLogoPath = folderPath + Settings.Default.LogoExportPath;
                string logoName = SunfrogConfig.Logo;
                //string logoName = "Logo 83";
                string logoRootPath = folderPath + Settings.Default.LogoPath + logoName + "\\";
                
                if (SunfrogConfig.StartRange + SunfrogConfig.EndRange > nameList.Count)
                {
                    nameList = nameList.Skip(SunfrogConfig.StartRange).Take(nameList.Count).DefaultIfEmpty().ToList();
                }
                else
                {
                    nameList = nameList.Skip(SunfrogConfig.StartRange).Take(SunfrogConfig.EndRange).DefaultIfEmpty().ToList();
                }

                if (nameList.Count > 0)
                {
                    progCurrentName.Invoke(new Action(() => progCurrentName.Value = progCurrentName.Minimum));
                   
                    for (int i = 0; i < nameList.Count; i++)
                    //int i = 0;
                    // Parallel.ForEach(nameList, (name) =>
                    {
                        string name = nameList[i];
                        try
                        {
                            string realName = name.Replace(Settings.Default.SplitString, Settings.Default.ExportSplitString);
                            lblCurName.Invoke(new Action(() => lblCurName.Text = realName));
                            ArtModel model = MongoController.Instance.FindModel(realName, logoName);
                            if (model == null)
                            {
                                string logoPath = LoadNewSunfrogData(name, exportLogoPath, folderPath + Settings.Default.LogoPath,
                                    logoName, Settings.Default.SplitString, Settings.Default.ExportSplitString, isScaleAll);
                                string jsonData = CreateNewSunfrogData(name, logoPath);
                                string result = SunfrogController.Instance.UplodNewMockup(jsonData);
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
                                //SaveNewToDB(name, modelResult, Settings.Default.SplitString, Settings.Default.ExportSplitString);
                                File.AppendAllLines(folderPath + Settings.Default.ListNameSuccess, new String[] { name });
                                File.AppendAllLines(folderPath + Settings.Default.UploadedLinks, new String[] { SunfrogLink });
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

    }
}
