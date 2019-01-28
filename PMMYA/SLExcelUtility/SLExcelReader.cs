using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using PMMYA.Admin.MenuManagement;

namespace PMMYA.SLExcelUtility
{
    public class SLExcelReader
    {
        private string GetColumnName(string cellReference)
        {
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }

        private int ConvertColumnNameToNumber(string columnName)
        {
            Regex alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName))
            {
                throw new ArgumentException();
            }

            char[] colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);
            int convertedValue = 0;
            for (int i = 0; i < colLetters.Length; i++)
            {
                char letter = colLetters[i];
                int current = i == 0 ? letter - 65 : letter - 64; // ASCII 'A' = 65
                convertedValue += current * (int)Math.Pow(26, i);
            }
            return convertedValue;
        }

        private IEnumerator<Cell> GetExcelCellEnumerator(Row row)
        {
            int currentCount = 0;
            foreach (Cell cell in row.Descendants<Cell>())
            {
                string columnName = GetColumnName(cell.CellReference);
                int currentColumnIndex = ConvertColumnNameToNumber(columnName);
                for (; currentCount < currentColumnIndex; currentCount++)
                {
                    Cell emptycell = new Cell() { DataType = null, CellValue = new CellValue(string.Empty) };
                    yield return emptycell;
                }
                yield return cell;
                currentCount++;
            }
        }

        private string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            CellValue cellValue = cell.CellValue;
            string text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            string textEmail = (cellValue == null) ? cell.InnerText : cellValue.Text;
            //if (text == "" || textEmail == "")
            //{
            //    string msgempty = "Required";
            //    text = msgempty;
            //}
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }
            return (text ?? string.Empty).Trim();
        }

        //public SLExcelData ReadExcel(HttpPostedFileBase file)        
        public SLExcelData ReadExcel(HttpPostedFile file)
        {
            #region
            SLExcelData data = new SLExcelData();
            // Check if the file is excel
            if (file.ContentLength <= 0)
            {
                data.Status.Message = "You uploaded an empty file";
                return data;
            }
            if (file.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                data.Status.Message = "Please upload a valid excel file of version 2007 and above";
                return data;
            }
            // Open the excel document
            WorkbookPart workbookPart; List<Row> rows;
            try
            {
                SpreadsheetDocument document = SpreadsheetDocument.Open(file.InputStream, false);
                workbookPart = document.WorkbookPart;
                IEnumerable<Sheet> sheets = workbookPart.Workbook.Descendants<Sheet>();
                Sheet sheet = sheets.First();
                data.SheetName = sheet.Name;
                Worksheet workSheet = ((WorksheetPart)workbookPart.GetPartById(sheet.Id)).Worksheet;
                Columns columns = workSheet.Descendants<Columns>().FirstOrDefault();
                data.ColumnConfigurations = columns;
                SheetData sheetData = workSheet.Elements<SheetData>().First();
                rows = sheetData.Elements<Row>().ToList();
            }
            catch (Exception)
            {
                data.Status.Message = "Unable to open the file";
                return data;
            }

            // Read the header
            if (rows.Count > 0)
            {
                Row row = rows[0];
                IEnumerator<Cell> cellEnumerator = GetExcelCellEnumerator(row);
                while (cellEnumerator.MoveNext())
                {
                    Cell cell = cellEnumerator.Current;
                    string text = ReadExcelCell(cell, workbookPart).Trim();
                    data.Headers.Add(text);
                }
            }
            #endregion
            // Read the sheet data
            if (rows.Count > 1)
            {
                for (int i = 1; i < rows.Count; i++)
                {
                    List<string> dataRow = new List<string>();
                    data.DataRows.Add(dataRow);
                    Row row = rows[i];
                    IEnumerator<Cell> cellEnumerator = GetExcelCellEnumerator(row);
                    //var CatLA = "";
                    //var CellInc = 0;
                    while (cellEnumerator.MoveNext())
                    {
                        Cell cell = cellEnumerator.Current;
                        string text = ReadExcelCell(cell, workbookPart).Trim();
                        //Validation Record add
                        dataRow.Add(text);

                    }
                }
            }
            return data;
        }

        #region Enum All
        public enum EnumCatagory
        {
            Shishu = 1,
            Kishore = 2,
            Tarun = 3,
        }
        public enum EnumGen
        {
            Male = 1,
            Female = 2,
            FeMale = 3,
        }
        public enum EnumMStatus
        {
            Maried = 1,
            UnMaried = 2,
        }
        public enum EnumReligion
        {
            Hindus = 1,
            Muslims = 2,
            Christians = 3,
            Sikhs = 4,
            Buddhists = 5,
            Jains = 6,
            Zoroastrians = 7,
            Others = 8,
        }
        public enum EnumLoanType
        {
            CC = 1, //Cash Credit
            OD = 2, //Over Draft
            TL = 3, //Term Loan
        }
        public enum EnumSocialCate
        {
            General = 1,
            SC = 2,
            ST = 3,
            OBC = 4,
            //MinorityCommunity=5,
        }
        public enum EnumStatus
        {
            Correct = 1,
            InCorrect = 2,
        }     
        #endregion
    }
}