using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Util
{
    public class FileUtil
    {
        public static void WriteObjectsToCSV<T>(List<T> objList, string savePath, string fileName)
        {
            try
            {

                // check path
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                Type type = typeof(T);
                var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(p => p.Name);

                using (StreamWriter sw = new StreamWriter(savePath + fileName))
                {
                    sw.WriteLine(String.Join(",", props.Select(p => p.Name)));

                    foreach (var item in objList)
                    {
                        sw.WriteLine(String.Join(",", props.Select(p => p.GetValue(item, null))));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        public static List<T> ReadObjectsFromCSV<T>(string savePath, string fileName) where T : new()
        {
            List<T> result = new List<T>();
            Type type = typeof(T);
            //var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(p => p.Name);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //using (StreamReader sr = new StreamReader(savePath + fileName))
            {
                string[] lines = File.ReadAllLines(savePath + fileName);
                if (lines != null && lines.Length > 0)
                {

                    foreach (var line in lines)
                    {
                        T t = new T();

                        string[] data = line.Split(',');
                        int i = 0;

                        foreach (var prop in props)
                        {
                            //if(prop.Name != "Id")
                            prop.SetValue(t, data[i++], null);
                        }

                        result.Add(t);
                    }

                }
            }

            return result;
        }


        private static string ENCRYPT_KEY = "Ravile@123";
        public static string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRYPT_KEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRYPT_KEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


    }
}
