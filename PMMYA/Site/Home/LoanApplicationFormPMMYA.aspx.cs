using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net;
using System.Data;
using Schema;
using BL;
using System.Configuration;

namespace PMMYA.Site.Home
{
    public partial class LoanApplicationFormPMMYA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(Convert.ToString(Session["Application_ID"])!=null )
            //{// GetDetails();
            //   // ConvertToPDF();
            //}
            if (!Page.IsPostBack)
            {
               // if (Convert.ToString(Session["Application_ID"]) != null)
               // {
                    GetDetails();
                    ConvertToPDF();
               // }

               // else
               // {
                 //   ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "No Records Found", true);
               // }

            }
        }



        private void ConvertToPDF()

        {
            //string imagepath = Server.MapPath("~/Images");
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //this.Page.RenderControl(hw);
            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath + "/mudra.jpg");
            //pdfDoc.Open();
            //pdfDoc.Add(gif);
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();

            string imagepath = Server.MapPath("~/Images"); Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            string fromusername = ConfigurationManager.AppSettings["userNameEmail"];
            string Tousername = ConfigurationManager.AppSettings["TouserName"];
            string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"];
            string cc1username = ConfigurationManager.AppSettings["NotificationtoDepartment1"];
            string cc2username = ConfigurationManager.AppSettings["NotificationtoDepartment2"];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                iTextSharp.text.Image addLogo = default(iTextSharp.text.Image);
                // iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath + "/mudra.jpg");
                addLogo = iTextSharp.text.Image.GetInstance(imagepath + "/mudra.jpg");

                iTextSharp.text.Image BankLogo = default(iTextSharp.text.Image);
                // iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath + "/mudra.jpg");
                BankLogo = iTextSharp.text.Image.GetInstance(imagepath + "/mudra.jpg");
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                
                // addLogo.SetAbsolutePosition(0, docWorkingDocument.PageSize.Height - 100)
               
                pdfDoc.Open();
                addLogo.ScaleToFit(128, 37);
                addLogo.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                pdfDoc.Add(addLogo);
                //BankLogo.ScaleToFit(128, 37);
               // BankLogo.SetAbsolutePosition(pdfDoc.Right, pdfDoc.Top - 180);
                //BankLogo.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
               // pdfDoc.Add(BankLogo);

                htmlparser.Parse(sr);

                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                //MailMessage mm = new MailMessage("rechargeme2016@gmail.com", "manishshende.87@gmail.com");
                using (MailMessage mm = new MailMessage(fromusername, Convert.ToString(lblBusiInfo_EmailValue.Text)))
                {
                    mm.CC.Add(cc1username);
                    mm.CC.Add(cc2username);
                    mm.Subject = "Acknowledgement Receipt PMMY";
                    mm.Body = "Dear Sir,Madam<br/> Your Mudra Loan Registration is done Successfully with Mundra Loan No :" + Convert.ToString(ViewState["appid"]) + "<br/> Regards,<br/> PMMY committee ,Maharashtra";
                    //mm.Body = "Dear Sir,Madam<br/> Your Mudra Loan Registration is done Successfully with Mundra Loan No :" + Convert.ToString(Session["Application_ID"]) + "<br/> Regards,<br/> PMMY committee ,Maharashtra";
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "AcknowledgementMudra.pdf"));
                    mm.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = ConfigurationManager.AppSettings["host"];
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = fromusername;//"rechargeme2016@gmail.com ";
                        NetworkCred.Password = EmailPassword;//"Pass@123";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                        smtp.TargetName = "STARTTLS/smtp.gmail.com";
                        smtp.Send(mm);
                        Response.Redirect("~/Site/Home/Index.aspx");
                    }
                }
            }



        }


        private void GetDetails()
        {
            LoanApplicatinFormSchema objLoanApplicatinFormSchema = new LoanApplicatinFormSchema();
            LoanApplicationFormBL objLoanApplicationFormBL = new LoanApplicationFormBL();
            //Guid g = new Guid("6451DEB9-CCBB-45C5-8ADC-8DAEDCABCAD4");
           // long appid = Convert.ToInt64(Session["Application_ID"]);
            long appid = Convert.ToInt64("2018080425");
            ViewState["appid"] = appid;
            objLoanApplicatinFormSchema.Application_ID = appid;
            DataSet ds = new DataSet();
            ds = objLoanApplicationFormBL.SearchDetails(objLoanApplicatinFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblBusiInfo_Enterprise_NameValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Enterprise_Name"]);
                lblBusiInfo_ConstitutionValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Constitution"]); ;
                //lblNameOfTheBranch.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Curr_Address"]); 
                lblBusiInfo_Curr_AddressValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Curr_Address"]);

                lblBusiInfo_Act_ExistingValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Act_Existing"]);
                lblBusiInfo_Act_ProposedValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Act_Proposed"]);
                lblBusiInfo_Commencement_DtValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Commencement_Dt"]);
                lblBusiInfo_IsUnitRegValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_IsUnitReg"]);
                lblBusiInfo_Reg_NumberValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Reg_Number"]);
                lblBusiInfo_Resi_AddressValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Resi_Address"]);
                lblBusiInfo_Social_CatValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Social_Cat"]);
                lblBusiInfo_MonorityCommValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_MonorityComm"]);
                lblPartenersNameValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_Name"]);
                lblPartnersDOBValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_DOB"]);
                lblPartnerPartner_GenderValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_Gender"]);
                lblResidentialAddWithMobNoValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_Resi_Address"]);
                lbllpartnerQualificationValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_Qualification"]);
                lblBusiInfo_MobileValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Mobile"]);
                lblBusiInfo_EmailValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Email"]);
                lblPartnerExperienceValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_Exp"]);

                //Relationship with the officials / Director of the bank if any
                lblRelationshipwithanyIdProof.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_ID_Proof"]);
                lblRelationshipwithanyDidProofno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_ID_Number"]);
                lblRelationshipwithanyAddressProof.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_Addr_Proof"]);
                lblRelationshipwithanyAddressProofNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_AddrProof_Num"]);
                lblRelationshipwithanyPanCard.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_PAN_DIN_Num"]);
                lblRelationship.Text = Convert.ToString(ds.Tables[0].Rows[0]["Partner_Relation"]);

                //D. Names of Associate Concerns and Nature of Association
                lblNameofAssociates.Text = Convert.ToString(ds.Tables[0].Rows[0]["Associate_Name"]);
                lblAddressofAssociates.Text = Convert.ToString(ds.Tables[0].Rows[0]["Associate_Addr"]);
                lblPresentlyBanking.Text = Convert.ToString(ds.Tables[0].Rows[0]["Associate_Present_Banking"]);
                lblNatureOfAssociates.Text = Convert.ToString(ds.Tables[0].Rows[0]["Associate_Nature"]);
                lblInvestorAssociation.Text = Convert.ToString(ds.Tables[0].Rows[0]["Associate_Interest"]);

                lblSavingAccount.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_SA_Banking"]);
                lblSavingOutstanding.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_SA_Outstanding"]);
                lblSavingAssessetClassification.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_SA_Status"]);

                lblCurrentAccount.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_CA_Banking"]);
                lblCurrentOutstanding.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_CA_Outstanding"]);
                lblCurrentAssessetClassification.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_CA_Status"]);

                lblCashCredit.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_CC_Banking"]);
                lblCashCreditLimitAvailed.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_CC_LimitAvailed"]);
                lblCashCreditOutstanding.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_CC_Outstanding"]);
                lblSecurityLodgedOutstanding.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_CC_SecurityLodg"]);
                lblCashCredittAssessetClassification.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_CC_Status"]);

                
                // H. In case of Term loan requirements, the details of machinery/equipment may be given as under
                lblCCL_TL_MachineEquip.Text= Convert.ToString(ds.Tables[0].Rows[0]["CCL_TL_MachineEquip"]);
                lblCCL_TL_Purpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_TL_Purpose"]);
                lblCCL_TL_SupplierName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_TL_SupplierName"]);
                lblCCL_TL_Loan_Req.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_TL_Loan_Req"]);
                lblCCL_TL_Promote_Contri.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_TL_Promote_Contri"]);
                lblCCL_TL_MachineCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_TL_MachineCost"]);

                lblTermLoan.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_TL_Banking"]);
                lblTermLoanLimit.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_TL_LimitAvailed"]);
                lblTermLoanOutstanding.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_TL_Outstanding"]);
                lblTermLoanSecurity.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_TL_SecurityLodg"]);
                lblTermLoanAssessetClassification.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_TL_Status"]);

                lblLGBG.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_LGBG_Banking"]);
                lblLGBGLimit.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_LGBG_Limit"]);
                lblLGBGOutstanding.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_LGBG_Outstanding"]);
                lblLGBGSecurityLodged.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_LGBG_SecurityLodg"]);
                lblLGBGAssetClassification.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Exist_LGBG_Status"]);



                lblCashcreditDetailsSecurityAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Prop_CC_Amount"]);
                lblCashcreditDetailsSecurityPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Prop_CC_Purpose"]);
                lblCashcreditDetailsSecurityDetailsOfPrimarySecurityOffered.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Prop_CC_SecurityOffer"]);
                lblTermLoanAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Prop_TL_Amount"]);
                lblTermLoanPurposeForWhichRequired.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Prop_TL_Purpose"]);
                lblTermLoanDetailsSecurityOffered.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Prop_TL_SecurityOffer"]);
                lblLCBGAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Prop_LGBG_Amount"]);
                lblLCBGPurposeForWhicRequired.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Prop_LGBG_Purpose"]);
                lblLGBGDetailsOfPrimarySecurityOffered.Text = Convert.ToString(ds.Tables[0].Rows[0]["CR_Prop_LGBG_SecurityOffer"]);


                lblTotalAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["lblTotalAmount"]);
                lblTotalPurposeForWhichRequired.Text = Convert.ToString(ds.Tables[0].Rows[0]["lblTotalPurposeForWhichRequired"]);
                lblDetailsOFPrimarySecurityOffered.Text = Convert.ToString(ds.Tables[0].Rows[0]["lblDetailsOFPrimarySecurityOffered"]);

                lblCCL_WC_ActSale_previousFY.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_ActSale_previousFY"]);
                lblCCL_WC_Proj_Sale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_Proj_Sale"]);
                lblCCL_WC_Proj_Cycle.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_Proj_Cycle"]);
                lblCCL_WC_Proj_Inventory.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_Proj_Inventory"]);
                lblCCL_WC_Proj_Debtors.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_Proj_Debtors"]);
                lblCCL_WC_Proj_Creditors.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_Proj_Creditors"]);
                lblCCL_WC_ActSale_currFY.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_ActSale_currFY"]);
                lblCCL_WC_Proj_Promot_Contri.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_Proj_Promot_Contri"]);
                lblCCL_WC_Proj_Limit.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_Proj_Limit"]);

                lblCCL_TL_MachineCostTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_ActSale_currFY"]);
                lblCCL_TL_Promote_ContriTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_Proj_Promot_Contri"]);
                lblCCL_TL_Loan_ReqTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_WC_Proj_Limit"]);
                lblCCL_TL_Repayment_Period.Text = Convert.ToString(ds.Tables[0].Rows[0]["CCL_TL_Repayment_Period"]);

                lblPastPerf_PYII_Act_NetSale.Text = Convert.ToString(ds.Tables[0].Rows[0]["PastPerf_PYII_Act_NetSale"]);
                lblPastPerf_PYI_Act_NetSale.Text = Convert.ToString(ds.Tables[0].Rows[0]["PastPerf_PYI_Act_NetSale"]);
                lblPastPerf_PY0_Act_NetSale.Text = Convert.ToString(ds.Tables[0].Rows[0]["PresentYear_Est_NetSale"]);
                lblPastPerf_PYNext_Act_NetSale.Text = Convert.ToString(ds.Tables[0].Rows[0]["NextYear_Proj_NetSale"]);
                lblPastPerf_PYII_Act_NetProfit.Text = Convert.ToString(ds.Tables[0].Rows[0]["PastPerf_PYII_Act_NetProfit"]);
                lblPastPerf_PYI_Act_NetProfit.Text = Convert.ToString(ds.Tables[0].Rows[0]["PastPerf_PYI_Act_NetProfit"]);
                lblPresentYear0_Est_NetProfit.Text = Convert.ToString(ds.Tables[0].Rows[0]["PresentYear_Est_NetProfit"]);
                lblPresentYearNext_Est_NetProfit.Text = Convert.ToString(ds.Tables[0].Rows[0]["NextYear_Proj_NetProfit"]);
                lblPastPerf_PYII_Act_Capital.Text = Convert.ToString(ds.Tables[0].Rows[0]["PastPerf_PYII_Act_Capital"]);
                lblPastPerf_PYI_Act_Capital.Text = Convert.ToString(ds.Tables[0].Rows[0]["PastPerf_PYI_Act_Capital"]);
                lblPresentYear_Est_Capital.Text = Convert.ToString(ds.Tables[0].Rows[0]["PresentYear_Est_Capital"]);
                lblPresentYearNext_Est_Capital.Text = Convert.ToString(ds.Tables[0].Rows[0]["NextYear_Proj_Capital"]);

                lblSatutoryObl_Reg_Shop.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_Reg_Shop"]);
                lblSatutoryObl_Reg_ShopRemark.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_Reg_ShopRemark"]);
                lblSatutoryObl_Reg_MSME.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_Reg_MSME"]);
                lblSatutoryObl_Reg_MSMERemark.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_Reg_MSMERemark"]);
                lblSatutoryObl_DrugLicense.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_DrugLicense"]);
                lblSatutoryObl_DrugLicense_Remark.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_DrugLicense_Remark"]);
                lblSatutoryObl_SaleReturn_File.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_SaleReturn_File"]);
                lblSatutoryObl_SaleReturn_File_Remark.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_SaleReturn_File_Remark"]);
                lblSatutoryObl_ITReturn_File.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_ITReturn_File"]);
                lblSatutoryObl_ITReturn_File_Remark.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_ITReturn_File_Remark"]);
                lblSatutoryObl_Dues_Remain.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_Dues_Remain"]);
                lblSatutoryObl_Dues_RemainRemark.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatutoryObl_Dues_RemainRemark"]);
                lblDateValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Created_Date"]);
                lblPlaceValue.Text = "NA";//Convert.ToString(ds.Tables[0].Rows[0]["NextYear_Proj_Capital"]); 


                lblDataOfApplication_AckSlip.Text= Convert.ToString(ds.Tables[0].Rows[0]["Created_Date"]);
                lblNameofApplicant_AckSlip.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Enterprise_Name"]);
                lblLoanAmtReq_AckSlip.Text= Convert.ToString(ds.Tables[0].Rows[0]["CCL_TL_Loan_Req"]);
                lblSignOfApplicant_AckSlip.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Enterprise_Name"]);
                lblSignOfBranch_AckSlip.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Enterprise_Name"]);
                lblApplicationGenerated_AckSlip.Text = Convert.ToString(ViewState["appid"]);

                lblApplicantName_ApplicantsCopy.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Enterprise_Name"]);
                lblApplicationNo_ApplicantsCopy.Text = Convert.ToString(ViewState["appid"]);
                lblDateofApp_ApplicantsCopy.Text = Convert.ToString(ds.Tables[0].Rows[0]["Created_Date"]);
                lblAppLoanAmtRequested_ApplicantsCopy.Text= Convert.ToString(ds.Tables[0].Rows[0]["CCL_TL_Loan_Req"]);
                lblSignofapplicant_ApplicantsCopy.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Enterprise_Name"]);
                lblSignofbranch_ApplicantsCopy.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiInfo_Enterprise_Name"]);

                lblDateValue.Text= Convert.ToString(ds.Tables[0].Rows[0]["Created_Date"]);
               // lblPlaceValue.Text= Convert.ToString(ds.Tables[0].Rows[0]["Created_Date"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "No Records Found", true);
            }

        }
    }
}