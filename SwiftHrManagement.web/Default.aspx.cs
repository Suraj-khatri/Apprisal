using System;
using System.Data;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CMS_Management;
using System.Text;
using System.Web;

namespace SwiftHrManagement.web
{
    public partial class Default : BasePage
    {
        clsDAO CLsDAo = null;
        CMSDAO cmsdao = null;
        CMSCore cmsCore = null;

        UserDAO _usrDao = null;
        SystemUser _sysUsr = null;

        LoginInformationCore _logininfo = null;
        public Default()
        {
            this.cmsCore = new CMSCore();
            this.cmsdao = new CMSDAO();
            this.CLsDAo = new clsDAO();

            this._usrDao = new UserDAO();
            this._sysUsr = new SystemUser();
            this._logininfo = new LoginInformationCore();      
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Session["sessionStore"] == null)
                {
                    string url = Request.Url.ToString();                    
                   // Response.Redirect("Default.aspx?url="+ url);
                }
                else
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    {

                        Response.Redirect(HttpUtility.UrlDecode(Request.QueryString["ReturnUrl"]));
                    }
                    else
                    {
                        Response.Redirect("DashBoard.aspx?q=HR");
                    }
                }
               
            }
        }
        
        private string CheckSession(string UserName,string Password)
        {
            string MSG = CLsDAo.GetSingleresult("EXEC [ProcCheckSessionUserLogin] @user='" + UserName + "',@pass='" + Password + "',@SESSION_ID='" + ReadSession().Sessionid + "'");
            return MSG;
        }
        protected void ImgLogin_Click(object sender, EventArgs e)
        {
            SessionStore sessionStore = new SessionStore();
            DataTable dt = new DataTable();
            String UserName = txtUserName.Text;
            String Password = txtPassword.Text;

            String FiscalYear = "2009";
            _logininfo = _usrDao.Getsessioninformation(UserName, Password);
            if (_logininfo != null)
            {
                //checking session for avoiding multiple login                
                this.WriteSession(sessionStore);
                this.ReadSession().Sessionid =Session.SessionID;
                string MSG = CLsDAo.GetSingleresult("EXEC [ProcCheckSessionUserLogin] @user='" + UserName + "',@pass='" + Password + "',"+" @SESSION_ID='" + ReadSession().Sessionid + "'");
                if (MSG == "User Already Login!")
                {
                    LblMsg.Text = MSG;
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    sessionStore.UserId = _logininfo.lUsername;
                    this.WriteSession(sessionStore);
                    this.ReadSession().AdminId = long.Parse(_logininfo.lAdminid.ToString());
                    this.ReadSession().Emp_Id = long.Parse(_logininfo.Lempid.ToString());
                    this.ReadSession().Branch_Id = int.Parse(_logininfo.Lbranchid.ToString());
                    this.ReadSession().Department = _logininfo.Ldepartmentid.ToString();
                    this.ReadSession().UserName = _logininfo.lUsername.ToString();
                    this.ReadSession().Current_Fiscal_Year = FiscalYear;
                    this.ReadSession().Designation = _logininfo.lPositionid;
                    this.ReadSession().Position_hierarchy = int.Parse("0");
                    this.ReadSession().Fiscal_english = _logininfo.Fiscalenglish;
                    this.ReadSession().Fiscal_nepali = _logininfo.Fiscalnepali;
                    this.ReadSession().BranchLevelAccess = _logininfo.BranchLevelAccess;
                    this.ReadSession().UserType = _logininfo.Lusertype;
                    if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    {

                        Response.Redirect(HttpUtility.UrlDecode(Request.QueryString["ReturnUrl"]));
                    }
                    else
                    {
                        Response.Redirect("DashBoard.aspx?q=HR");
                    }

                }
            }
            else
            {
                LblMsg.Text = "Your IP is recorded, Please try with valid login information!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
