using DAL;
using Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public class UserDataBL
    {
        #region Public variable declaration
        UserDAL objUserDAL;
        DataSet ds;
        DataSet res_user;
        string res_user1;
        int returnval;
        #endregion

        public int insertUserData(UserShema objuserShema)
        {
            try
            {
                objUserDAL = new UserDAL();
                returnval = objUserDAL.insertUserData(objuserShema);
                return returnval;
            }
            catch (Exception e) { return 0; }
            finally
            {
                objUserDAL = null;
                objuserShema = null;
            }
        }
        public int CheckDuplicate(UserShema objuserShema)
        {
            try
            {
                objUserDAL = new UserDAL();
                returnval = objUserDAL.CheckDuplicate(objuserShema);
                return returnval;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                //objUserDAL = null;
                //objuserShema = null;
            }
        }
    }
}
