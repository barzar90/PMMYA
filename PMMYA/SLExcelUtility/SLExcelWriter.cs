using BL;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Color = DocumentFormat.OpenXml.Spreadsheet.Color;
using Font = DocumentFormat.OpenXml.Spreadsheet.Font;

namespace PMMYA.SLExcelUtility
{
    public class SLExcelWriter
    {
        private readonly LDMFunSchema objLDMFunSchema = new LDMFunSchema();
        private LDMFunBAL objLDMFunBAL = new LDMFunBAL();
        public DataTable dt;
        public DataSet ds;
        private int BID = 0;
        private int DID = 0;

        private string ColumnLetter(int intCol)
        {
            int intFirstLetter = ((intCol) / 676) + 64;
            int intSecondLetter = ((intCol % 676) / 26) + 64;
            int intThirdLetter = (intCol % 26) + 65;

            char firstLetter = (intFirstLetter > 64) ? (char)intFirstLetter : ' ';
            char secondLetter = (intSecondLetter > 64) ? (char)intSecondLetter : ' ';
            char thirdLetter = (char)intThirdLetter;

            return string.Concat(firstLetter, secondLetter, thirdLetter).Trim();
        }

        private Cell CreateTextCell(string header, uint index, string text)
        {
            Cell cell = new Cell
            {
                DataType = CellValues.InlineString,
                CellReference = header + index
            };

            InlineString istring = new InlineString();
            Text t = new Text { Text = text };
            istring.AppendChild(t);
            cell.AppendChild(istring);
            return cell;
        }

        public byte[] GenerateExcel(SLExcelData data)
        {
            MemoryStream stream = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
            WorkbookPart workbookpart = document.AddWorkbookPart();//
            workbookpart.Workbook = new Workbook();//        
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet();
            SheetData sheetData = new SheetData();
            worksheetPart.Worksheet = new Worksheet(sheetData);

            // Adding style
            WorkbookStylesPart stylePart = workbookpart.AddNewPart<WorkbookStylesPart>();
            stylePart.Stylesheet = GenerateStylesheet();
            stylePart.Stylesheet.Save();
            Sheets sheets = document.WorkbookPart.Workbook.
                AppendChild<Sheets>(new Sheets());

            Sheet sheet = new Sheet()
            {
                Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = data.SheetName ?? "Sheet 1"
            };
            sheets.AppendChild(sheet);
            
            // Add header
            uint rowIdex = 0;
            Row row = new Row { RowIndex = ++rowIdex };
            sheetData.AppendChild(row);
            int cellIdex = 0;

            foreach (string header in data.Headers)
            {
                Cell c = CreateTextCell(ColumnLetter(cellIdex++), rowIdex, header ?? string.Empty);
                c.StyleIndex = 2;
                row.AppendChild(c);
            }
            if (data.Headers.Count > 0)
            {
                // Add the column configuration if available
                if (data.ColumnConfigurations != null)
                {
                    Columns columns = (Columns)data.ColumnConfigurations.Clone();
                    double width = GetWidth("Calibri", 10, columns.ToString());
                }
            }
            // Add sheet data
            foreach (List<string> rowData in data.DataRows)
            {
                string CatLA = "";
                int CellInc = 0;
                cellIdex = 0; //
                row = new Row { RowIndex = ++rowIdex }; //
                sheetData.AppendChild(row); //
                foreach (string callData in rowData) //
                {
                    //var cell = CreateTextCell(ColumnLetter(cellIdex++), rowIdex, callData ?? string.Empty); //
                    Cell cell = CreateTextCell(ColumnLetter(cellIdex++), rowIdex, callData ?? string.Empty); //
                    //cell.StyleIndex = 2;
                    CellValue cellValue = cell.CellValue;
                    string columnName = GetColumnName(cell.CellReference);
                    string textEmail = (cellValue == null) ? cell.InnerText : cellValue.Text;
                    if (CellInc == 5)
                    {
                        CatLA = callData;
                    }
                    if (callData == "")
                    {
                        double width = GetWidth("Calibri", 10, callData);
                        cell.StyleIndex = 2;
                        cell.AppendChild(new InlineString().AppendChild(new Text() { Text = "Required" }).CloneNode(true));
                        row.AppendChild(cell.CloneNode(true));
                    }
                    if (columnName == "B")
                    {
                        //if (callData == eBankName.AllahabadBank.ToString() || callData == eBankName.AndhraBank.ToString() || callData == eBankName.BankofBaroda.ToString() || callData == eBankName.BankofIndia.ToString() || callData == eBankName.BankofMaharashtra.ToString() || callData == eBankName.CanaraBank.ToString() || callData == eBankName.CentralBankofIndia.ToString() || callData == eBankName.CorporationBank.ToString() || callData == eBankName.DenaBank.ToString() || callData == eBankName.IDBIBank.ToString() || callData == eBankName.IndianBank.ToString() || callData == eBankName.IndianOverseasBank.ToString() || callData == eBankName.OrientalBankofCommerce.ToString() || callData == eBankName.PunjabNationalBank.ToString() || callData == eBankName.PunjabandSindBank.ToString() || callData == eBankName.StateBankofIndia.ToString() || callData == eBankName.SyndicateBank.ToString() || callData == eBankName.UCOBank.ToString() || callData == eBankName.UnionBankofIndia.ToString() || callData == eBankName.UnitedBankofIndia.ToString() || callData == eBankName.VijayaBank.ToString() || callData == eBankName.AxisBank.ToString() || callData == eBankName.BandhanBank.ToString() || callData == eBankName.DCBBank.ToString() || callData == eBankName.FederalBank.ToString() || callData == eBankName.HDFCBankLtd.ToString() || callData == eBankName.ICICIBankLtd.ToString() || callData == eBankName.IndusIndBank.ToString() || callData == eBankName.KarnatakaBankLtd.ToString() || callData == eBankName.KotakMahindraBank.ToString() || callData == eBankName.RBLBank.ToString() || callData == eBankName.YesBankLtd.ToString() || callData == eBankName.AUSmallFinanceBank.ToString() || callData == eBankName.CapitalBankFinancial.ToString() || callData == eBankName.DishaSmallFinanceBank.ToString() || callData == eBankName.EquitasSmallFinanceBank.ToString() || callData == eBankName.ESAFSmallFinanceBank.ToString() || callData == eBankName.JanaSmallFinanceBankLtd.ToString() || callData == eBankName.SuryodaySmallFinanceBankLtd.ToString() || callData == eBankName.ujjivansmallfinancebank.ToString() || callData == eBankName.UtkarshSmallFinanceBankLtd.ToString() || callData == eBankName.MaharashtraGraminBank.ToString() || callData == eBankName.VidarbhaKonkanGraminBank.ToString() || callData == eBankName.RAIGADDCCBANKLTD.ToString() || callData == eBankName.AhmednagarDCCBank.ToString())                                             
                        //if (callData== GetAllBankDetails(callData))
                        if (callData == GetAllBankDetails(callData))
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "D")
                    {
                        bool isIFSC = Regex.IsMatch(callData, @"^[A-Za-z]{4}[a-zA-Z0-9]{7}$", RegexOptions.IgnoreCase);
                        if (!isIFSC)
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "F")
                    {
                        if (callData == SLExcelReader.EnumCatagory.Shishu.ToString() || callData == SLExcelReader.EnumCatagory.Kishore.ToString() || callData == SLExcelReader.EnumCatagory.Tarun.ToString())
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "J")
                    {
                        if (callData == SLExcelReader.EnumGen.Male.ToString() || callData == SLExcelReader.EnumGen.Female.ToString() || callData == SLExcelReader.EnumGen.FeMale.ToString())
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "K")
                    {
                        if (callData == SLExcelReader.EnumMStatus.Maried.ToString() || callData == SLExcelReader.EnumMStatus.UnMaried.ToString())
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "L")
                    {
                        try
                        {
                            DateTime d = DateTime.FromOADate(double.Parse(callData));
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        DateTime datedob = DateTime.FromOADate(double.Parse(callData));
                        //var datedob = Convert.ToDateTime(callData);                        
                        string sval = datedob.ToString("MM/dd/yyyy");

                        //bool isDOB = Regex.IsMatch(sval, @"^((0|1)\d{1})-((0|1|2)\d{1})-((19|20)\d{2})", RegexOptions.IgnoreCase); //mm-dd-yyyy
                        bool isDOB = Regex.IsMatch(sval, @"(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d", RegexOptions.IgnoreCase); //mm/dd/yyyy

                        if (!isDOB)
                        {
                            double width = GetWidth("Calibri", 10, sval);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = sval }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, sval);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = sval }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "Q")
                    {
                        //if (callData== GetAllBankDetails(callData))
                        if (callData == GetAllDistrictDetails(callData))
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "R")
                    {
                        if (callData == SLExcelReader.EnumReligion.Hindus.ToString() || callData == SLExcelReader.EnumReligion.Muslims.ToString() || callData == SLExcelReader.EnumReligion.Christians.ToString() || callData == SLExcelReader.EnumReligion.Sikhs.ToString() || callData == SLExcelReader.EnumReligion.Buddhists.ToString() || callData == SLExcelReader.EnumReligion.Jains.ToString() || callData == SLExcelReader.EnumReligion.Zoroastrians.ToString() || callData == SLExcelReader.EnumReligion.Others.ToString())
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "S")
                    {
                        if (callData == SLExcelReader.EnumReligion.Hindus.ToString() || callData == SLExcelReader.EnumReligion.Muslims.ToString() || callData == SLExcelReader.EnumReligion.Christians.ToString() || callData == SLExcelReader.EnumReligion.Sikhs.ToString() || callData == SLExcelReader.EnumReligion.Buddhists.ToString() || callData == SLExcelReader.EnumReligion.Jains.ToString() || callData == SLExcelReader.EnumReligion.Zoroastrians.ToString() || callData == SLExcelReader.EnumReligion.Others.ToString())
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "T")
                    {
                        if (callData == SLExcelReader.EnumSocialCate.General.ToString() || callData == SLExcelReader.EnumSocialCate.SC.ToString() || callData == SLExcelReader.EnumSocialCate.ST.ToString() || callData == SLExcelReader.EnumSocialCate.OBC.ToString() || callData == "Minority Community")
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "U")
                    {
                        bool isAadhar = Regex.IsMatch(callData, @"^\d{4}\-\d{4}\-\d{4}$", RegexOptions.IgnoreCase);
                        if (!isAadhar)
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        //if (UID.length = 12)
                        //{
                        //    var FirstChar = UID.charAt(0);
                        //    if (FirstChar == "0" || FirstChar == "1")
                        //    {
                        //        return false;
                        //    }
                        //}
                        else if (callData.First().Equals(0) || callData.First().Equals(1))
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = "Aadhar Can't Start 0 and 1 Incorrect" }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "V")
                    {
                        bool isPAN = Regex.IsMatch(callData, @"[A-Z]{5}\d{4}[A-Z]{1}", RegexOptions.IgnoreCase);
                        if (!isPAN)
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "W")
                    {
                        //bool isMobile = Regex.IsMatch(callData, @"^\d{3}\.\d{3}\.\d{4}$", RegexOptions.IgnoreCase);
                        bool isMobile = Regex.IsMatch(callData, @"^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[789]\d{9}$", RegexOptions.IgnoreCase); // /^[789]\d{9}$/
                        if (!isMobile)
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "X")
                    {
                        bool isEmailValid = Regex.IsMatch(callData, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                        if (!isEmailValid)
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "Y")
                    {
                        //string valueCell = int.Parse(cell.CellValue.Text).ToString();
                        string columnNameF = GetColumnName("F");
                        if (columnNameF == "F")
                        {

                            if (CatLA == SLExcelReader.EnumCatagory.Shishu.ToString())
                            {
                                if (int.Parse(CatLA) > 50000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                            else if (CatLA == SLExcelReader.EnumCatagory.Kishore.ToString())
                            {
                                if (Convert.ToInt32(CatLA) < 50000 || Convert.ToInt32(CatLA) > 500000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                            else if (CatLA == SLExcelReader.EnumCatagory.Tarun.ToString())
                            {
                                if (Convert.ToInt32(CatLA) < 500000 || Convert.ToInt32(CatLA) > 1000000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                        }
                    }
                    CellInc++;
                    if (columnName == "Z")
                    {
                        //string valueCell = int.Parse(cell.CellValue.Text).ToString();
                        string columnNameF = GetColumnName("F");
                        if (columnNameF == "F")
                        {

                            if (CatLA == SLExcelReader.EnumCatagory.Shishu.ToString())
                            {
                                if (int.Parse(CatLA) > 50000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                            else if (CatLA == SLExcelReader.EnumCatagory.Kishore.ToString())
                            {
                                if (Convert.ToInt32(CatLA) < 50000 || Convert.ToInt32(CatLA) > 500000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                            else if (CatLA == SLExcelReader.EnumCatagory.Tarun.ToString())
                            {
                                if (Convert.ToInt32(CatLA) < 500000 || Convert.ToInt32(CatLA) > 1000000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                        }
                    }
                    CellInc++;
                    if (columnName == "AA")
                    {
                        try
                        {
                            DateTime d = DateTime.FromOADate(double.Parse(callData));
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        DateTime datedob = DateTime.FromOADate(double.Parse(callData));
                        //var datedob = Convert.ToDateTime(callData);                        
                        string sval = datedob.ToString("MM/dd/yyyy");
                        bool isSEndD = Regex.IsMatch(sval, @"(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d", RegexOptions.IgnoreCase);
                        if (!isSEndD)
                        {
                            double width = GetWidth("Calibri", 10, sval);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = sval }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, sval);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = sval }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "AC")
                    {
                        if (callData == SLExcelReader.EnumLoanType.CC.ToString() || callData == SLExcelReader.EnumLoanType.OD.ToString() || callData == SLExcelReader.EnumLoanType.TL.ToString())
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, callData);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "AD")
                    {
                        //string valueCell = int.Parse(cell.CellValue.Text).ToString();
                        string columnNameF = GetColumnName("F");
                        if (columnNameF == "F")
                        {

                            if (CatLA == SLExcelReader.EnumCatagory.Shishu.ToString())
                            {
                                if (int.Parse(CatLA) > 50000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                            else if (CatLA == SLExcelReader.EnumCatagory.Kishore.ToString())
                            {
                                if (Convert.ToInt32(CatLA) < 50000 || Convert.ToInt32(CatLA) > 500000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                            else if (CatLA == SLExcelReader.EnumCatagory.Tarun.ToString())
                            {
                                if (Convert.ToInt32(CatLA) < 500000 || Convert.ToInt32(CatLA) > 1000000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                        }
                    }
                    CellInc++;
                    if (columnName == "AE")
                    {
                        try
                        {
                            DateTime d = DateTime.FromOADate(double.Parse(callData));
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        DateTime datedob = DateTime.FromOADate(double.Parse(callData));
                        //var datedob = Convert.ToDateTime(callData);
                        string sval = datedob.ToString("MM/dd/yyyy");
                        bool isDDisbursement = Regex.IsMatch(sval, @"(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d", RegexOptions.IgnoreCase);
                        if (!isDDisbursement)
                        {
                            double width = GetWidth("Calibri", 10, sval);
                            cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = sval }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                        else
                        {
                            double width = GetWidth("Calibri", 10, sval);
                            //cell.StyleIndex = 2;
                            cell.AppendChild(new InlineString().AppendChild(new Text() { Text = sval }).CloneNode(true));
                            row.AppendChild(cell.CloneNode(true));
                        }
                    }
                    if (columnName == "AF")
                    {
                        //string valueCell = int.Parse(cell.CellValue.Text).ToString();
                        string columnNameF = GetColumnName("F");
                        if (columnNameF == "F")
                        {

                            if (CatLA == SLExcelReader.EnumCatagory.Shishu.ToString())
                            {
                                if (int.Parse(CatLA) > 50000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                            else if (CatLA == SLExcelReader.EnumCatagory.Kishore.ToString())
                            {
                                if (Convert.ToInt32(CatLA) < 50000 || Convert.ToInt32(CatLA) > 500000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                            else if (CatLA == SLExcelReader.EnumCatagory.Tarun.ToString())
                            {
                                if (Convert.ToInt32(CatLA) < 500000 || Convert.ToInt32(CatLA) > 1000000)
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    //cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                                else
                                {
                                    double width = GetWidth("Calibri", 10, callData);
                                    cell.StyleIndex = 2;
                                    cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                                    row.AppendChild(cell.CloneNode(true));
                                }
                            }
                        }
                    }
                    CellInc++;
                    //if (columnName == "AG")
                    //{
                    //    if (callData == SLExcelReader.EnumStatus.Correct.ToString() || callData == SLExcelReader.EnumStatus.InCorrect.ToString())
                    //    {
                    //        double width = GetWidth("Calibri", 10, callData);
                    //        //cell.StyleIndex = 2;
                    //        cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                    //        row.AppendChild(cell.CloneNode(true));
                    //    }
                    //    else
                    //    {
                    //        double width = GetWidth("Calibri", 10, callData);
                    //        cell.StyleIndex = 2;
                    //        cell.AppendChild(new InlineString().AppendChild(new Text() { Text = callData }).CloneNode(true));
                    //        row.AppendChild(cell.CloneNode(true));
                    //    }
                    //}
                    row.AppendChild(cell);
                }
            }
            workbookpart.Workbook.Save();
            document.Close();
            return stream.ToArray();
        }

        public string GetColumnName(string cellReference)
        {
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }

        public int ConvertColumnNameToNumber(string columnName)
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

        private static double GetWidth(string font, int fontSize, string text)
        {
            System.Drawing.Font stringFont = new System.Drawing.Font(font, fontSize);
            return GetWidth(stringFont, text);
        }

        private static double GetWidth(System.Drawing.Font stringFont, string text)
        {
            // This formula is based on this article plus a nudge ( + 0.2M )
            // http://msdn.microsoft.com/en-us/library/documentformat.openxml.spreadsheet.column.width.aspx
            // Truncate(((256 * Solve_For_This + Truncate(128 / 7)) / 256) * 7) = DeterminePixelsOfString

            Size textSize = System.Windows.Forms.TextRenderer.MeasureText(text, stringFont);
            double width = (((textSize.Width / (double)7) * 256) - (128 / 7)) / 256;
            width = (double)decimal.Round((decimal)width + 0.2M, 2);

            return width;
        }

        private Stylesheet GenerateStylesheet()
        {
            Stylesheet styleSheet = null;

            Fonts fonts = new Fonts(
                new Font( // Index 0 - default
                    new FontSize() { Val = 10 }

                ),
                new Font( // Index 1 - header
                    new FontSize() { Val = 10 },
                    new Bold(),
                    new Color() { Rgb = "000000" } //Black fore color

                ));


            Fills fills = new Fills(
                    new Fill(new PatternFill() { PatternType = PatternValues.None }), // Index 0 - default
                    new Fill(new PatternFill() { PatternType = PatternValues.DarkGray }), // Index 1 - default   
                    new Fill(new PatternFill(new ForegroundColor { Rgb = new HexBinaryValue() { Value = "ffff00" } }) //back color yellow
                    { PatternType = PatternValues.Solid }) // Index 2 - header
                );

            Borders borders = new Borders(
                    new Border(), // index 0 default
                    new Border( // index 1 black border
                        new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                );

            CellFormats cellFormats = new CellFormats(
                    new CellFormat(), // default
                    new CellFormat { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }, // body
                    new CellFormat { FontId = 1, FillId = 2, BorderId = 1, ApplyFill = true } // header
                );

            styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);

            return styleSheet;
        }

        public enum eBankName
        {
            [Display(Name = "Allahabad Bank")]
            AllahabadBank,
            [Display(Name = "Andhra Bank")]
            AndhraBank,
            [Display(Name = "Bank of Baroda")]
            BankofBaroda,
            [Display(Name = "Bank of India")]
            BankofIndia,
            [Display(Name = "Bank of Maharashtra")]
            BankofMaharashtra,
            [Display(Name = "Canara Bank")]
            CanaraBank,
            [Display(Name = "Central Bank of India")]
            CentralBankofIndia,
            [Display(Name = "Corporation Bank")]
            CorporationBank,
            [Display(Name = "Dena Bank")]
            DenaBank,
            [Display(Name = "IDBI Bank")]
            IDBIBank,
            [Display(Name = "Indian Bank")]
            IndianBank,
            [Display(Name = "Indian Overseas Bank")]
            IndianOverseasBank,
            [Display(Name = "Oriental Bank of Commerce")]
            OrientalBankofCommerce,
            [Display(Name = "Punjab National Bank")]
            PunjabNationalBank,
            [Display(Name = "Punjab & Sind Bank")]
            PunjabandSindBank,
            [Display(Name = "State Bank of India")]
            StateBankofIndia,
            [Display(Name = "Syndicate Bank")]
            SyndicateBank,
            [Display(Name = "UCO Bank")]
            UCOBank,
            [Display(Name = "Union Bank of India")]
            UnionBankofIndia,
            [Display(Name = "United Bank of India")]
            UnitedBankofIndia,
            [Display(Name = "Vijaya Bank")]
            VijayaBank,
            [Display(Name = "Axis Bank")]
            AxisBank,
            [Display(Name = "Bandhan Bank")]
            BandhanBank,
            [Display(Name = "DCB Bank")]
            DCBBank,
            [Display(Name = "Federal Bank")]
            FederalBank,
            [Display(Name = "HDFC Bank Ltd")]
            HDFCBankLtd,
            [Display(Name = "ICICI Bank Ltd")]
            ICICIBankLtd,
            [Display(Name = "IndusInd Bank")]
            IndusIndBank,
            [Display(Name = "Karnataka Bank Ltd")]
            KarnatakaBankLtd,
            [Display(Name = "Kotak Mahindra Bank")]
            KotakMahindraBank,
            [Display(Name = "RBL Bank")]
            RBLBank,
            [Display(Name = "Yes Bank Ltd")]
            YesBankLtd,
            [Display(Name = "AU Small Finance Bank")]
            AUSmallFinanceBank,
            [Display(Name = "Capital Bank Financial")]
            CapitalBankFinancial,
            [Display(Name = "Disha Small Finance Bank")]
            DishaSmallFinanceBank,
            [Display(Name = "Equitas Small Finance Bank")]
            EquitasSmallFinanceBank,
            [Display(Name = "ESAF Small Finance Bank")]
            ESAFSmallFinanceBank,
            [Display(Name = "Jana Small Finance Bank Ltd")]
            JanaSmallFinanceBankLtd,
            [Display(Name = "Suryoday Small Finance Bank Ltd.")]
            SuryodaySmallFinanceBankLtd,
            [Display(Name = "ujjivan small finance bank")]
            ujjivansmallfinancebank,
            [Display(Name = "Utkarsh Small Finance Bank Ltd")]
            UtkarshSmallFinanceBankLtd,
            [Display(Name = "Maharashtra Gramin Bank")]
            MaharashtraGraminBank,
            [Display(Name = "Vidarbha Konkan Gramin Bank")]
            VidarbhaKonkanGraminBank,
            [Display(Name = "Bhandara DCC Bank")]
            BhandaraDCCBank,
            [Display(Name = "RAIGAD DCC BANK LTD")]
            RAIGADDCCBANKLTD,
            [Display(Name = "Ahmednagar DCC Bank")]
            AhmednagarDCCBank,
        }

        //Get Bank Id
        public string GetAllBankDetails(string BankName)
        {
            ds = new DataSet();
            ds = objLDMFunBAL.GetAllBank(BankName);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                int bid = Convert.ToInt32(dt.Rows[0]["Id"]);
                string bnm = dt.Rows[0]["BankName"].ToString();
                BankName = bnm;
                BID = bid;
            }
            else
            {
                return "Incorrect Bank Name";
            }
            return BankName;
        }
        //Get District Id
        public string GetAllDistrictDetails(string DistrictName)
        {
            ds = new DataSet();
            ds = objLDMFunBAL.GetAllDistrict(DistrictName);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                int did = Convert.ToInt32(dt.Rows[0]["Districtcode"]);
                string dnm = dt.Rows[0]["DistrictName"].ToString();
                DistrictName = dnm;
                DID = did;
            }
            else
            {
                return "Incorrect Bank Name";
            }
            return DistrictName;
        }



    }
}

