using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schema;
using DAL;
using System.Data;

namespace BL
{
    public class UploadFileBL
    {
        UploadFileDL objUploadFileDL;
        int retnVal = 0;
        DataSet ds;

        public int SaveUploadFileBL(UploadFileSchema objUploadFile)
        {
            UploadFileDL objUploadFileDL = new UploadFileDL();
            try
            { return retnVal = objUploadFileDL.SaveUploadFileDL(objUploadFile); }
            catch (Exception ex) { return retnVal; throw ex; }
        }

        public DataSet ShowUploadFileBL(UploadFileSchema objUploadFile)
        {
            ds = new DataSet();
            UploadFileDL objUploadFileDL = new UploadFileDL();
            try
            { return ds = objUploadFileDL.ShowUploadFileDL(objUploadFile); }
            catch (Exception Ex) { throw Ex; }
        }

        public int DeleteFileBL(UploadFileSchema objUploadFileSchema)
        {
            UploadFileDL objUploadFileDL = new UploadFileDL();
            try { return retnVal = objUploadFileDL.DeleteFileDL(objUploadFileSchema); }
            catch (Exception ex) { throw ex; }
        }

        public DataSet ShowFileDetailsdBL(UploadFileSchema objUploadFileSchema)
        {
            ds = new DataSet();
            UploadFileDL objUploadFileDL = new UploadFileDL();
            try { return ds = objUploadFileDL.ShowFileDetailsdDL(objUploadFileSchema); }
            catch (Exception ex) { throw ex; }
        }

        public int UpdateUploadFileBL(UploadFileSchema objUploadFile)
        {
            UploadFileDL objUploadFileDL = new UploadFileDL();
            try
            { return retnVal = objUploadFileDL.UpdateUploadFileDL(objUploadFile); }
            catch (Exception ex) { return retnVal; throw ex; }
        }
        public DataSet BindCategory()
        {
            ds = new DataSet();
            UploadFileDL objUploadFileDL = new UploadFileDL();
            try { return ds = objUploadFileDL.BindCategory(); }
            catch (Exception ex) { throw ex; }
        }


    }
}
