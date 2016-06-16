using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AutoArtist.Util
{
    public class FileUtil
    {
        public static string GetCurPath(String path)
        {
            return Directory.GetCurrentDirectory() + path;
        }

        public static T ReadConfig<T>(string path)
        {
            return DeSerializeObject<T>(path);
        }

        public static void WriteConfig<T>(T config, string path)
        {
            SerializeObject<T>(config, path);
        }


        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                string attributeXml = string.Empty;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
                throw ex;
            }

            return objectOut;
        }


        public static List<string> LoadListColors(string path, string rootPath)
        {
            try
            {
                List<string> result = new List<string>();
                string[] colors = File.ReadAllLines(path);
                for (int i = 0; i < colors.Length; i++)
                {
                    result.Add(rootPath + colors[i]);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetLastWord(string words)
        {
            int index = words.LastIndexOf(" ");
            if (index == -1)
                return "";
            string temp = words.Substring(0, index + 1);
            return words.Replace(temp, "");
        }

        public static string GetWordAt(string words, int posIndex)
        {
            string[] temp = words.Split(' ');
            if (temp != null && temp.Length > 0)
                return temp[posIndex];
            else if (!string.IsNullOrEmpty(words))
                return words;
            return null;
        }

        public static int GetWordCount(string words)
        {
            return words.Count(c => c == ' ') + 1;
        }

    }
}
