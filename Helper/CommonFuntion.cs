using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Data;

namespace Helper
{
    public class CommonFuntion
    {
        #region "Encrypt Decrypt"
        private static byte[] key = { 8, 12, 1, 6, 20, 5, 14, 4, 19, 2, 9, 11, 17, 3, 22, 16, 15, 24, 7, 10, 18, 21, 13, 23 };
        private static byte[] iv = { 200, 151, 72, 64, 29, 189, 53, 219 };

        public static string Encrypt(string plainText)
        {
            // Declare a UTF8Encoding object so we may use the GetByte 
            // method to transform the plainText into a Byte array. 
            UTF8Encoding utf8encoder = new UTF8Encoding();
            byte[] inputInBytes = utf8encoder.GetBytes(plainText);
            // Create a new TripleDES service provider 
            TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();
            // The ICryptTransform interface uses the TripleDES 
            // crypt provider along with encryption key and init vector 
            // information 
            ICryptoTransform cryptoTransform = tdesProvider.CreateEncryptor(key, iv);
            // All cryptographic functions need a stream to output the 
            // encrypted information. Here we declare a memory stream 
            // for this purpose. 
            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);
            // Write the encrypted information to the stream. Flush the information 
            // when done to ensure everything is out of the buffer. 
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
            cryptStream.FlushFinalBlock();
            encryptedStream.Position = 0;
            // Read the stream back into a Byte array and return it to the calling 
            // method. 
            byte[] result = new byte[encryptedStream.Length];
            encryptedStream.Read(result, 0, Convert.ToInt32(encryptedStream.Length));
            cryptStream.Close();
            //test section
            //Convert to / fro the memory stream to a base64 string
            //compare decText to result
            string encText = Convert.ToBase64String(encryptedStream.ToArray());
            //Dim decText As Byte() = Convert.FromBase64String(encText)
            //Dim sDec As String = Decrypt(decText)
            //Return result
            //End Sub

            return encText;
        }

        public static string Decrypt(byte[] inputInBytes)
        {
            // UTFEncoding is used to transform the decrypted Byte Array 
            // information back into a string. 
            UTF8Encoding utf8encoder = new UTF8Encoding();
            TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();
            // As before we must provide the encryption/decryption key along with 
            // the init vector. 
            ICryptoTransform cryptoTransform = tdesProvider.CreateDecryptor(key, iv);
            // Provide a memory stream to decrypt information into 
            MemoryStream decryptedStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write);
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
            cryptStream.FlushFinalBlock();
            decryptedStream.Position = 0;
            // Read the memory stream and convert it back into a string 
            byte[] result = new byte[decryptedStream.Length];
            decryptedStream.Read(result, 0, Convert.ToInt32(decryptedStream.Length));
            cryptStream.Close();
            UTF8Encoding myutf = new UTF8Encoding();
            //Return myutf.GetString(result)

            return myutf.GetString(result);

        }
        #endregion

        #region DoubleExtension
        public static bool check_Extensions(string fileName)
        {
            bool checkExtensions = false;
            string file_path = fileName;

            string[] strArr = null;
            int count = 0;
            char[] splitchar = { '.' };
            strArr = file_path.Split(splitchar);
            count = strArr.Length;
            if (count != 2)
            {
                checkExtensions = false;
            }
            else
            {
                checkExtensions = true;
            }
            return checkExtensions;
        }
        #endregion

        #region "File Validation"

        private enum ImageFileExtension
        {
            none = 0,
            jpg = 1,
            jpeg = 2,
            bmp = 3,
            gif = 4,
            png = 5
        }

        private enum VideoFileExtension
        {
            none = 0,
            wmv = 1,
            mpg = 2,
            mpeg = 3,
            mp4 = 4,
            avi = 5,
            flv = 6
        }

        private enum PDFFileExtension
        {
            none = 0,
            PDF = 1
        }

        public enum FileType
        {
            Image = 1,
            Video = 2,
            PDF = 3,
            DOC = 4,
            DOCX = 5,
            XLS = 6,
            XLSX = 7
        }


        private enum ExcelFileExtension
        {
            none = 0,
            XLS = 1,
            XLSX = 2

        }


        private enum DOCFileExtension
        {
            none = 0,
            DOC = 1,
            DOCX = 2

        }



        public static bool isValidFile(byte[] bytFile, FileType flType, String FileContentType)
        {
            bool isvalid = false;

            if (flType == FileType.Image)
            {
                isvalid = isValidImageFile(bytFile, FileContentType);
            }
            else if (flType == FileType.Video)
            {
                isvalid = isValidVideoFile(bytFile, FileContentType);
            }
            else if (flType == FileType.PDF)
            {
                isvalid = isValidPDFFile(bytFile, FileContentType);
            }

            else if (flType == FileType.DOC)
            {
                isvalid = isValidDOCFile(bytFile, FileContentType);
            }
            else if (flType == FileType.DOCX)
            {
                isvalid = isValidDOCXFile(bytFile, FileContentType);
            }
            else if (flType == FileType.XLS)
            {
                isvalid = isValidXLSFile(bytFile, FileContentType);
            }
            else if (flType == FileType.XLSX)
            {
                isvalid = isValidXLSXFile(bytFile, FileContentType);
            }



            return isvalid;



        }

        private static bool isValidImageFile(byte[] bytFile, String FileContentType)
        {
            byte[] chkBytejpg = { 255, 216, 255, 224 };
            byte[] chkBytebmp = { 66, 77 };
            byte[] chkBytegif = { 71, 73, 70, 56 };
            byte[] chkBytepng = { 137, 80, 78, 71 };
            bool isvalid = false;

            ImageFileExtension imgfileExtn = ImageFileExtension.none;
            if (FileContentType.Contains("jpg") | FileContentType.Contains("jpeg"))
            {
                imgfileExtn = ImageFileExtension.jpg;
            }
            else if (FileContentType.Contains("bmp"))
            {
                imgfileExtn = ImageFileExtension.bmp;
            }
            else if (FileContentType.Contains("gif"))
            {
                imgfileExtn = ImageFileExtension.gif;
            }
            else if (FileContentType.Contains("png"))
            {
                imgfileExtn = ImageFileExtension.png;
            }

            if (imgfileExtn == ImageFileExtension.jpg || imgfileExtn == ImageFileExtension.jpeg)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytejpg[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (imgfileExtn == ImageFileExtension.bmp )
            {
                if (bytFile.Length >= 2)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 1; i++)
                    {
                        if (bytFile[i] == chkBytebmp[i])
                        {
                            j = j + 1;
                            if (j == 1)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (imgfileExtn == ImageFileExtension.gif )
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytegif[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (imgfileExtn == ImageFileExtension.png )
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytepng[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }

        private static bool isValidVideoFile(byte[] bytFile, String FileContentType)
        {
            byte[] chkBytewmv = { 48, 38, 178, 117 };
            byte[] chkByteavi = { 82, 73, 70, 70 };
            byte[] chkByteflv = { 70, 76, 86, 1 };
            byte[] chkBytempg = { 0, 0, 1, 186 };
            byte[] chkBytemp4 = { 0, 0, 0, 20 };
            bool isvalid = false;

            VideoFileExtension vdofileExtn = VideoFileExtension.none;
            if (FileContentType.Contains("wmv"))
            {
                vdofileExtn = VideoFileExtension.wmv;
            }
            else if (FileContentType.Contains("mpg") || FileContentType.Contains("mpeg"))
            {
                vdofileExtn = VideoFileExtension.mpg;
            }
            else if (FileContentType.Contains("mp4"))
            {
                vdofileExtn = VideoFileExtension.mp4;
            }
            else if (FileContentType.Contains("avi"))
            {
                vdofileExtn = VideoFileExtension.avi;
            }
            else if (FileContentType.Contains("flv"))
            {
                vdofileExtn = VideoFileExtension.flv;
            }

            if (vdofileExtn == VideoFileExtension.wmv)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytewmv[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if ((vdofileExtn == VideoFileExtension.mpg || vdofileExtn == VideoFileExtension.mpeg) )
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytempg[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (vdofileExtn == VideoFileExtension.mp4)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytemp4[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (vdofileExtn == VideoFileExtension.avi )
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteavi[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (vdofileExtn == VideoFileExtension.flv )
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteflv[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;

            //if (isinvalid)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        private static bool isValidPDFFile(byte[] bytFile, String FileContentType)
        {
            byte[] chkBytepdf = { 37, 80, 68, 70 };
            bool isvalid = false;

            PDFFileExtension pdffileExtn = PDFFileExtension.none;
            if (FileContentType.Contains("pdf"))
            {
                pdffileExtn = PDFFileExtension.PDF;
            }

            if (pdffileExtn == PDFFileExtension.PDF)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytepdf[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }

        private static bool isValidXLSFile(byte[] bytFile, String FileContentType)
        {
            byte[] chkByteDocx = { 208, 207, 17, 224 }; // Magic Number For Docx
            bool isvalid = false;

            ExcelFileExtension docfileExtn = ExcelFileExtension.none;
            if (FileContentType.Contains("application/vnd.ms-excel"))
            {
                docfileExtn = ExcelFileExtension.XLS;
            }

            if (docfileExtn == ExcelFileExtension.XLS)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteDocx[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }


        private static bool isValidXLSXFile(byte[] bytFile, String FileContentType)
        {
            byte[] chkByteDocx = { 80, 75, 3, 4 }; // Magic Number For Docx
            bool isvalid = false;

            ExcelFileExtension docfileExtn = ExcelFileExtension.none;
            if (FileContentType.Contains("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                docfileExtn = ExcelFileExtension.XLSX;
            }

            if (docfileExtn == ExcelFileExtension.XLSX)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteDocx[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }


        private static bool isValidDOCFile(byte[] bytFile, String FileContentType)
        {
            byte[] chkByteDoc = { 208, 207, 17, 224 }; // Magic Number For Doc
            bool isvalid = false;

            DOCFileExtension docfileExtn = DOCFileExtension.none;
            if (FileContentType.Contains("application/msword"))
            {
                docfileExtn = DOCFileExtension.DOC;
            }

            if (docfileExtn == DOCFileExtension.DOC)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteDoc[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }

        private static bool isValidDOCXFile(byte[] bytFile, String FileContentType)
        {
            byte[] chkByteDocx = { 80, 75, 3, 4 }; // Magic Number For Docx
            bool isvalid = false;

            DOCFileExtension docfileExtn = DOCFileExtension.none;
            if (FileContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
            {
                docfileExtn = DOCFileExtension.DOCX;
            }

            if (docfileExtn == DOCFileExtension.DOCX)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteDocx[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }

        #endregion

        public static bool IsValid(string value)
        {
            Regex _check_1 = new Regex(@"<script[^>]*>.*?<\/script>|<[^>]*(click|mousedown|mouseup|mousemove|keypress|keydown|keyup)[^>]*>", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex _check_2 = new Regex(@"</?(?i:script|body|embed|object|frameset|frame|iframe|meta|link|style|input|javascript)(.|\n)*?>", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex _check_3 = new Regex(@"^[0-9]|[a-z]|[A-Z]|[<>;:\-.,?!@&\$%#*+=/]$", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
            if (value != null && _check_1.IsMatch(value.ToString()))
            {
                return false;
            }
            else if (value != null && _check_2.IsMatch(value.ToString()))
            {
                return false;
            }
            else if (value != null && _check_3.IsMatch(value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
