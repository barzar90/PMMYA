using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Security.Cryptography;

namespace Helper
{
    public class QueryStringEncryptDecrypt
    {
        private static string EncryptionKey = "!#853g`de";
        private static byte[] key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public static String EncryptQueryString(String strQueryString)
        {
            //key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8))
            byte[] byt = Encoding.UTF8.GetBytes(strQueryString);
            MemoryStream ms = new MemoryStream();
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            return "str=" + Convert.ToBase64String(ms.ToArray());
        }

        public static String EncryptString(String strQueryString)
        {
            //key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8))
            byte[] byt = Encoding.UTF8.GetBytes(strQueryString);
            MemoryStream ms = new MemoryStream();
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            return "str=" + Convert.ToBase64String(ms.ToArray());
        }

        public static QryStringsCollection DecryptQueryString(String strQueryString)
        {

            byte[] byt = Convert.FromBase64String(strQueryString.Replace(" ", "+"));
            MemoryStream ms = new MemoryStream();
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8;

            String str = encoding.GetString(ms.ToArray());
            QryStringsCollection qsCollection = new QryStringsCollection(str);

            return qsCollection;
        }
    }

    [Serializable]
    public class QryString
    {
        public String QryStr { get; set; }
        public String QryStrValue { get; set; }

        public QryString(String QryStrng, String QryStrVal)
        {
            this.QryStr = QryStrng;
            this.QryStrValue = QryStrVal;
        }
    }

    [Serializable]
    public class QryStringsCollection : CollectionBase, IEnumerable, IEnumerator
    {
        private int index = -1;

        public QryStringsCollection()
        {
            this.index = -1;
        }

        public QryStringsCollection(String str)
        {
            String[] arLst = str.Split('&');
            QryString qryStr;
            String[] arLstPair;
            foreach (String str1 in arLst)
            {
                arLstPair = str1.Split('=');
                qryStr = new QryString(arLstPair[0], arLstPair[1]);
                this.Add(qryStr);
            }
        }

        public void Add(QryString qs)
        {
            this.List.Add(qs);
        }

        public void Remove(QryString qs)
        {
            this.List.Remove(qs);
        }

        public QryString this[int index]
        {
            get { return (QryString)this.List[index]; }
            set { this.List[index] = value; }
        }
      

        public String this[String str]
        {
            get
            {
                Int32 iCount = 0;
                this.Reset();
                foreach (QryString lstItem in this.List)
                {
                    if (lstItem.QryStr == str)
                    {
                        return ((QryString)this.List[iCount]).QryStrValue;
                    }
                    iCount++;
                }
                return String.Empty; //((QryString)this.List[iCount]).QryStrValue;
            }

        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        #endregion

        #region IEnumerator Members

        public Object Current
        {
            get
            {
                return this.List[index];
            }
        }

        public bool MoveNext()
        {
            this.index++;
            return (this.index < this.List.Count);
        }

        public void Reset()
        {
            this.index = -1;
        }

        #endregion

       
    }
}
