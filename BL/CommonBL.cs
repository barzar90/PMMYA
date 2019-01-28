using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CommonBL
    {


        #region Is Valid File
        private enum ImageFileExtension
        {
            none = 0,
            jpg = 1,
            jpeg = 2,
            bmp = 3,
            gif = 4,
            png = 5,
            tiff = 6
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
            AllImage = 6
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
            else if (imgfileExtn == ImageFileExtension.bmp)
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
            else if (imgfileExtn == ImageFileExtension.gif)
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
            else if (imgfileExtn == ImageFileExtension.png)
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
            else if ((vdofileExtn == VideoFileExtension.mpg || vdofileExtn == VideoFileExtension.mpeg))
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
            else if (vdofileExtn == VideoFileExtension.avi)
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
            else if (vdofileExtn == VideoFileExtension.flv)
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
        #endregion



    }
}
