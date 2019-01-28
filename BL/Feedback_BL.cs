using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DAL;
using Schema;
using System.Data;

namespace BL
{
    public class Feedback_BL
    {

        #region Public variable declaration
        FeedbackDAL objFeedbackDAL = new FeedbackDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public int SaveFeedbackDeatails(FeddbackSchema objFeedback_Schema)
        {
            try
            {
                result = objFeedbackDAL.SaveFeedbackDeatails(objFeedback_Schema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public DataSet GetDistrict(FeddbackSchema objFeedback_Schema)
        {
            try
            {
                ds = objFeedbackDAL.GetDistrict(objFeedback_Schema);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }


        public DataSet GetDPOEmail(FeddbackSchema objFeedback_Schema)
        {
            try
            {
                ds = objFeedbackDAL.GetDPOEmail(objFeedback_Schema);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetComplaintsDetails()
        {
            try
            {
                ds = objFeedbackDAL.GetComplaintsDetails();
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

    }
}
