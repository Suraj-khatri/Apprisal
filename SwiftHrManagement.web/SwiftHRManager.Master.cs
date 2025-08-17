using System;
using System.IO;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.DAL.Role;
using System.Text;
using SwiftHrManagement.web.Library;


namespace SwiftHrManagement.web
{
    public partial class SwiftHRManager : System.Web.UI.MasterPage
    {
        //BasePage _basePage = null;
        clsDAO _clsdao = null;
        StringBuilder sb = new StringBuilder("");
        RoleMenuDAOInv _roleDao = null;
        UserDAO _userDao = null;
        SystemUser _userCore = null;
        //string sitePath = "";
        public SwiftHRManager()
        {
            _clsdao = new clsDAO();
            _roleDao = new RoleMenuDAOInv();
            _userDao = new UserDAO();
            _userCore = new SystemUser();
        }
        protected SessionStore ReadSession()
        {
            SessionStore sessionStore = (SessionStore)Session["sessionStore"];
            if (Session["sessionStore"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            Session["sessionStore"] = sessionStore;
            GetNotifications(sessionStore.UserId, sessionStore.Emp_Id.ToString(), sessionStore.Branch_Id.ToString());
            return sessionStore;
        }

        public string GetCssStyle()
        {
            return (ReadSession().MenuType);
        }

        string currPage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            makeMenu();
            //PopulateMessages();
            Page.Header.DataBind();
            if (!IsPostBack)
            {
                //this._userCore = _userDao.FindFullUserName(this.ReadSession().UserId);
                this._userCore = _userDao.FindFullName(this.ReadSession().UserId);
                TxtUserName.Text = this._userCore.Name;
                user.Text = this._userCore.Name;
            }
        }

        //private void PopulateMessages()
        //{
        //    StringBuilder sb = new StringBuilder("");
        //    var ds = _clsdao.getDataset("EXEC proc_messagePortal @flag = 'n', @receiverId = '" + ReadSession().Emp_Id.ToString() + "'");

        //    if (ds.Tables == null || ds.Tables.Count == 0)
        //    {
        //        sb.AppendLine("<li class=\"new\"><a href=\"#\">No Messages</a></li>");
        //    }

        //    DataTable dt1 = ds.Tables[0];
        //    DataTable dt2 = ds.Tables[1];

        //    string count1 = null;

        //    foreach (DataRow item in dt1.Rows)
        //    {
        //        string sender = item["Sender"].ToString();
        //        string message = item["Message"].ToString();
        //        string isSeen = item["Is_Seen"].ToString();
        //        if (isSeen == "N")
        //        {
        //            sb.AppendLine("<li class=\"new\">");
        //            sb.AppendLine("<a href=\"#\">");
        //            sb.AppendLine("<span class=\"thumb\">");
        //            sb.AppendLine("<i class=\"fa fa-envelope-o\" aria-hidden=\"true\" style=\"font-size:25px; color:green;\"></i></span>");
        //            sb.AppendLine("<span class=\"desc\">");
        //            sb.AppendLine("<span class=\"name\">");
        //            sb.AppendLine("" + sender + "");
        //            sb.AppendLine("<span class=\"badge badge-success\">new</span></span>");
        //            sb.AppendLine("<span class=\"msg\">");
        //            sb.AppendLine("" + message + "");
        //            sb.AppendLine("</span></span></a></li>");
        //        }
        //        else
        //        {
        //            sb.AppendLine("<li>");
        //            sb.AppendLine("<a href=\"#\">");
        //            sb.AppendLine("<span class=\"thumb\">");
        //            sb.AppendLine("<i class=\"fa fa-envelope-o\" aria-hidden=\"true\" style=\"font-size:25px; color:green;\"></i></span>");
        //            sb.AppendLine("<span class=\"desc\">");
        //            sb.AppendLine("<span class=\"name\">");
        //            sb.AppendLine("" + sender + "");
        //            sb.AppendLine("test");
        //            sb.AppendLine("</span>");
        //            sb.AppendLine("<span class=\"msg\">");
        //            sb.AppendLine("" + message + "");
        //            sb.AppendLine("test");
        //            sb.AppendLine("</span></span></a></li>");
        //        }
                
        //    }
        //    sb.AppendLine("<li class=\"new\"><a href=\"#\">Read All Messages</a></li>");
        //    count1 = dt2.Rows[0]["Count"].ToString();
        //    countMsg.Text = count1;
        //    counMessages.InnerHtml = "<h5 class=\"title\">You have "+count1+" New Message(s)</h5>";
        //    msgPopulate.InnerHtml = sb.ToString();
        //}

        private void LoadNewMenu(string menuSelected, string expandedGroup)
        {
            string qString = Request.QueryString["q"];
            string mainMenu = "";
            sb.AppendLine("<li><a href=\"/DashBoard.aspx?q=HR\"><i class=\"fa fa-home\"></i><span>Home</span></a></li>");
            String Usr = "";
            Usr = ReadSession().UserId;
            string menuType = ReadSession().MenuType;
            DataTable dt = _roleDao.getMeluList_For_User(Usr, menuType);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-user'></i><span>User Management</span></a>";
            writeNewMenu(dt, "u", "User Management", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-building'></i><span>Company Management</span></a>";
            writeNewMenu(dt, "c", "Company Management", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-male'></i><span>Employee Management</span></a>";
            writeNewMenu(dt, "e", "Employee Management", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-line-chart'></i><span>Employee Attendance</span></a>";
            writeNewMenu(dt, "a", "Employee Attendance", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-sign-out'></i><span>Leave Management</span></a>";
            writeNewMenu(dt, "lm", "Leave Management", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-sign-out'></i><span>Employee Appraisal</span></a>";
            writeNewMenu(dt, "app_new", "Employee Appraisal", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-suitcase'></i><span>Employee Movement</span></a>";
            writeNewMenu(dt, "f", "Employee Movement", menuSelected, expandedGroup, mainMenu);

//            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-cog'></i><span>Training Management</span></a>";
//            writeNewMenu(dt, "t", "Training Management", menuSelected, expandedGroup, mainMenu);

//            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-male' aria-hidden='true'></i>
//            <span>Employee Appraisal</span></a>"; writeNewMenu(dt, "app", "Employee Appraisal", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-book'></i><span>CEA Reimbursement</span></a>";
            //writeNewMenu(dt, "cea", "Training Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-medkit'></i><span>Medical Reimbursement</span></a>";
            //writeNewMenu(dt, "mr", "Medical Reimbursement", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-money'></i><span>Payroll Management</span></a>";
            writeNewMenu(dt, "pr", "Payroll Management", menuSelected, expandedGroup,mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-list-alt'></i><span>Summary Report</span></a>";
            writeNewMenu(dt, "z", "Summary Report", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-clock-o'></i><span>Over Time Management</span></a>";
            //writeNewMenu(dt, "ot", "Over Time Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-plane'></i><span>Travel Order</span></a>";
            //writeNewMenu(dt, "tr", "Travel Order", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-database'></i><span>General Data Setting</span></a>";
            writeNewMenu(dt, "s", "General Data Setting", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-database'></i><span>Content Management</span></a>";
            writeNewMenu(dt, "m", "Content Management", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-tasks'></i><span>Work Flow Management</span></a>";
            writeNewMenu(dt, "w", "Work Flow Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-tachometer'></i><span>Inventory Management</span></a>";
            //writeNewMenu(dt, "prd_mgmt", "Inventory Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-area-chart'></i><span>Inventory Purchase</span></a>";
            //writeNewMenu(dt, "vou", "Inventory Purchase", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-line-chart'></i><span>Inventory Movement</span></a>";
            //writeNewMenu(dt, "prd_movmt", "Inventory Movement", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-building-o'></i><span>Assets Parameters</span></a>";
            //writeNewMenu(dt, "ass_per", "Assets Parameters", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-book'></i><span>Assets Acquisition</span></a>";
            //writeNewMenu(dt, "ass_acq", "Assets Acquisition", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-building'></i><span>Assets Management</span></a>";
            //writeNewMenu(dt, "ass_mgmt", "Assets Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-book'></i><span>Bill & Insurance</span></a>";
            //writeNewMenu(dt, "bill_insr", "Bill & Insurance", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-book'></i><span>Repair & Maintenance</span></a>";
            //writeNewMenu(dt, "repr_main", "Repair & Maintenance", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-home'></i><span>Gate Pass</span></a>";
            //writeNewMenu(dt, "gate_pass", "Gate Pass", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-book'></i><span>MIS Reporting</span></a>";
            //writeNewMenu(dt, "rpt", "MIS Reporting", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='menu-list'><a href='#'><i class='fa fa-book'></i><span>Messaging Portal</span></a>";
            //writeNewMenu(dt, "Msg_port", "Messaging Portal", menuSelected, expandedGroup, mainMenu);

            Menu.InnerHtml = sb.ToString();
        }

        private void writeNewMenu(DataTable dt, string group_code, string group_name, string menuSelected, string expandedGroup, string mainMenu)
        {
            DataRow[] rows = dt.Select("menu_group='" + group_code + "'");
            if (rows.Length == 0) return;
            if (group_name == menuSelected)
            {
                string newMenu = mainMenu.Replace("menu-list", "menu-list nav-active");
                sb.AppendLine(newMenu);
            }
            else
            {
                sb.AppendLine(mainMenu);
            }
            sb.AppendLine("<ul class=\"sub-menu-list\">");
            foreach (DataRow item in rows)
            {
                if (expandedGroup == item["function_name"].ToString())
                {
                    sb.AppendLine("<li class=\"sub-active\">");
                }
                else
                    sb.AppendLine("<li>");
                sb.AppendLine("<a href=\"" + item["link_file"].ToString() + "\" onclick=\"menu_click('" + group_name + "','" + item["function_name"].ToString() + "');\"><i class=\"fa fa-arrow-circle-right\"></i><span>");
                sb.AppendLine("" + item["function_name"].ToString() + "");
                sb.AppendLine("</span></a></li>");
                GetStatic.WriteCookie("select", group_name);
            }
            sb.AppendLine("</ul>");
        }


        protected void btnClick_Click(object sender, EventArgs e)
        {
            if (currPage != "")
                Response.Redirect(currPage);
        }
        //private static String currentPage;

        public static String CurrentPage
        {
            set
            {
                HttpContext.Current.Session["currPage"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["currPage"] == null)
                {
                    return "";
                }
                else
                    return HttpContext.Current.Session["currPage"].ToString();
            }
        }
       // private static String currentGroup;

        public static String CurrentGroup
        {
            set
            {
                HttpContext.Current.Session["currentGroup"] = value;
            }

            get
            {
                if (HttpContext.Current.Session["currentGroup"] == null)
                {
                    return "";
                }
                else
                    return HttpContext.Current.Session["currentGroup"].ToString();
            }
        }
        private void makeMenu()
        {
            string mainM = mainMenu.Value;
            string subM = subMenu.Value;

            if (mainM != "" && subM != "")
            {
                GetStatic.WriteSession("mainMenu", mainM);
                GetStatic.WriteSession("subMenu", subM);
            }
            LoadNewMenu(GetStatic.ReadSession("mainMenu", ""), GetStatic.ReadSession("subMenu", ""));
            
        }

        private void GetNotifications(string userId, string empId, string branchId)
        {

            DataTable dt = _clsdao.getTable("EXEC proc_ActiveNotifications 'a', '"+userId+"', '"+empId+"', '"+branchId+"'");

            int counter = dt.Rows.Count;
            count.Text = counter.ToString();

            StringBuilder sb1 = new StringBuilder("");
            if (dt.Rows == null || dt.Rows.Count == 0)
            {
                sb1.AppendLine("<li class=\"new\"><a href=\"#\"><span class=\"label label-danger\"><i class=\"fa fa-bell-slash-o\"></i></span>");
                sb1.AppendLine("<span class=\"name\" style=\"color:black;\">No new Notifications</a></li>");
            }
            foreach (DataRow item in dt.Rows)
            {
                sb1.AppendLine("<li class=\"new\">" + item["Notification"].ToString() + "");
                sb1.AppendLine("<span style=\"color:red; padding-left:5px;\"><em class=\"small\">" + item["TOTAL"].ToString() + "</em></span></li>");
            }           
            noti.InnerHtml = sb1.ToString();
        }
       
        protected void mainButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Main.aspx?q=" + ReadSession().MenuType + "");
        }
    }
}
