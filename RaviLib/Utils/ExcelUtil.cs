using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RaviLib.Utils
{
    public class ExcelUtil
    {
        public static List<string> ReadExcel(string path)
        {
            {
                var excelRows = new List<string>();
                using (ExcelPackage pack = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelWorksheet sheet = pack.Workbook.Worksheets[1];
                    for (int i = sheet.Dimension.Start.Column;
                        i <= sheet.Dimension.End.Column;
                        i++)
                    {
                        for (int j = sheet.Dimension.Start.Row;
                                j <= sheet.Dimension.End.Row;
                                j++)
                        {
                            object cellValue = sheet.Cells[j, i].Value;
                            if (cellValue != null)
                                excelRows.Add(cellValue.ToString());
                        }
                    }
                }
                excelRows.RemoveAll(p => p.Trim().Length == 0);

                return excelRows;

            }
        }

        public static List<T> GetModelFromExcel<T>(string path, int fromRow, int fromColumn, int toColumn = 0)
        {
            List<T> retList = new List<T>();
            using (var pck = new ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                //Retrieve first Worksheet
                var ws = pck.Workbook.Worksheets.First();
                //If the to column is empty or 0, then make the tocolumn to the count of the properties
                //Of the class object inserted
                toColumn = toColumn == 0 ? typeof(T).GetProperties().Count() : toColumn;

                //Read the first Row for the column names and place into a list so that
                //it can be used as reference to properties
                List<string> columnNames = new List<string>();
                // wsRow = ws.Row(0);
                foreach (var cell in ws.Cells[1, 1, 1, ws.Cells.Count()])
                {
                    columnNames.Add(cell.Value.ToString().Replace(" ", ""));
                }
                //Loop through the rows of the excel sheet
                int i = 0;
                for (var rowNum = fromRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    //create a instance of T
                    T objT = Activator.CreateInstance<T>();
                    //Retrieve the type of T
                    Type myType = typeof(T);
                    //Get all the properties associated with T
                    PropertyInfo[] myProp = myType.GetProperties();

                    var wsRow = ws.Cells[rowNum, fromColumn, rowNum, ws.Cells.Count()];

                    Console.WriteLine("i: " + (i++));
                    foreach (var propertyInfo in myProp)
                    {
                        if (columnNames.Contains(propertyInfo.Name))
                        {
                            int position = columnNames.IndexOf(propertyInfo.Name);
                            //To prevent an exception cast the value to the type of the property.
                            propertyInfo.SetValue(objT, Convert.ChangeType(wsRow[rowNum, position + 1].Value, propertyInfo.PropertyType));
                        }
                    }

                    retList.Add(objT);
                }

            }
            return retList;
        }


        
        public static void AppendExcelFile<T>(string path, T obj)
        {
            {
                FileInfo newFile = new FileInfo(path);
                if (!newFile.Exists)
                {
                    using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                    {
                        var sheet = xlPackage.Workbook.Worksheets.Add("default");
                        Type myType = typeof(T);
                        //Get all the properties associated with T
                        var myProp = myType.GetProperties().OrderBy(p => p.Name).ToList();
                        int i = 1;
                        int row = 1;
                        foreach (var propertyInfo in myProp)
                        {
                            sheet.Cells[row, i++].Value = propertyInfo.Name;
                        }

                        row++;
                        i = 1;
                        foreach (var propertyInfo in myProp)
                        {
                            sheet.Cells[row, i++].Value = obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null);
                        }
                        xlPackage.Save();
                    }
                }
                else
                {
                    using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                    {
                        var sheet = xlPackage.Workbook.Worksheets["default"];

                        Type myType = typeof(T);
                        //Get all the properties associated with T
                        var myProp = myType.GetProperties().OrderBy(p => p.Name).ToList();
                        int i = 1;
                        int row = sheet.Dimension.End.Row + 1;
                        foreach (var propertyInfo in myProp)
                        {
                            sheet.Cells[row, i++].Value = obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null);
                        }
                        xlPackage.Save();
                    }
                }

            }

        }

        public static void WriteExcelFile<T>(string path, T obj)
        {
            {
                FileInfo newFile = new FileInfo(path);               
                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    var sheet = xlPackage.Workbook.Worksheets.Add("default");
                    Type myType = typeof(T);
                    //Get all the properties associated with T
                    var myProp = myType.GetProperties().OrderBy(p => p.Name).ToList();
                    int i = 1;
                    int row = 1;
                    foreach (var propertyInfo in myProp)
                    {
                        sheet.Cells[row, i++].Value = propertyInfo.Name;
                    }

                    row++;
                    i = 1;
                    foreach (var propertyInfo in myProp)
                    {
                        sheet.Cells[row, i++].Value = obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null);
                    }
                    xlPackage.Save();
                }
            }

        }

        public static void WriteExcelFile<T>(string path, List<T> objList)
        {
            {
                FileInfo newFile = new FileInfo(path);
                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    var sheet = xlPackage.Workbook.Worksheets.Add("default");
                    Type myType = typeof(T);
                    //Get all the properties associated with T
                    var myProp = myType.GetProperties().OrderBy(p => p.Name).ToList();
                    int i = 1;
                    int row = 1;
                    foreach (var propertyInfo in myProp)
                    {
                        sheet.Cells[row, i++].Value = propertyInfo.Name;
                    }

                    row++;
                    foreach (var obj in objList)
                    {
                        i = 1;
                        foreach (var propertyInfo in myProp)
                        {
                            sheet.Cells[row, i++].Value = obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null);
                        }
                        row++;
                    }
                   
                    xlPackage.Save();
                }
            }

        }

    }
}
