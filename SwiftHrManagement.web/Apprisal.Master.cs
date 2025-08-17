using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.web.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web
{
    public partial class Apprisal : System.Web.UI.MasterPage
    {
        clsDAO _clsdao = null;
        StringBuilder sb = new StringBuilder("");
        RoleMenuDAOInv _roleDao = null;
        UserDAO _userDao = null;
        SystemUser _userCore = null;
        //string sitePath = "";
        public Apprisal()
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
                
                string url = HttpUtility.UrlEncode(Request.Url.ToString());
                Response.Redirect("~/Default.aspx?ReturnUrl="+ url);
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
            Page.Header.DataBind();
            if (!IsPostBack)
            {
               
                this._userCore = _userDao.FindFullName(this.ReadSession().UserId);
                TxtUserName.Text = this._userCore.Name;
              
            }
        }


        private void LoadNewMenu(string menuSelected, string expandedGroup)
        {
            string qString = "HR";
            string mainMenu = "";
            sb.AppendLine("<li><a href=\"/DashBoard.aspx?q=HR\"><i class=\"fa fa-home\"></i><span>Home</span></a></li>");
            String Usr = "";
            Usr = ReadSession().UserId;
           // string menuType = ReadSession().MenuType;
            DataTable dt = _roleDao.getMeluList_For_User(Usr, qString);

            mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-user'></i><span>User Management</span> <span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            writeNewMenu(dt, "u", "User Management", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-building'></i><span>Company Management</span> <span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            writeNewMenu(dt, "c", "Company Management", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-male'></i><span>Employee Management</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            writeNewMenu(dt, "e", "Employee Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-line-chart'></i><span>Employee Attendance</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "a", "Employee Attendance", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-sign-out'></i><span>Leave Management</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "lm", "Leave Management", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-sign-out'></i><span>Employee Appraisal</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            writeNewMenu(dt, "app_new", "Employee Appraisal", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-suitcase'></i><span>Employee Movement</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            writeNewMenu(dt, "f", "Employee Movement", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-cog'></i><span>Training Management</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "t", "Training Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-medkit'></i><span>Medical Reimbursement</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "mr", "Medical Reimbursement", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-money'></i><span>Payroll Management</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "pr", "Payroll Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-list-alt'></i><span>Summary Report</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "z", "Summary Report", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-clock-o'></i><span>Over Time Management</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "ot", "Over Time Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-plane'></i><span>Travel Order</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "tr", "Travel Order", menuSelected, expandedGroup, mainMenu);

            mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-database'></i><span>General Data Setting</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            writeNewMenu(dt, "s", "General Data Setting", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-database'></i><span>Content Management</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "m", "Content Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-tasks'></i><span>Work Flow Management</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
            //writeNewMenu(dt, "w", "Work Flow Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-tachometer'></i><span>Inventory Management</span></a>";
            //writeNewMenu(dt, "prd_mgmt", "Inventory Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-area-chart'></i><span>Inventory Purchase</span></a>";
            //writeNewMenu(dt, "vou", "Inventory Purchase", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-line-chart'></i><span>Inventory Movement</span></a>";
            //writeNewMenu(dt, "prd_movmt", "Inventory Movement", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-building-o'></i><span>Assets Parameters</span></a>";
            //writeNewMenu(dt, "ass_per", "Assets Parameters", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-book'></i><span>Assets Acquisition</span></a>";
            //writeNewMenu(dt, "ass_acq", "Assets Acquisition", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-building'></i><span>Assets Management</span></a>";
            //writeNewMenu(dt, "ass_mgmt", "Assets Management", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-book'></i><span>Bill & Insurance</span></a>";
            //writeNewMenu(dt, "bill_insr", "Bill & Insurance", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-book'></i><span>Repair & Maintenance</span></a>";
            //writeNewMenu(dt, "repr_main", "Repair & Maintenance", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-home'></i><span>Gate Pass</span></a>";
            //writeNewMenu(dt, "gate_pass", "Gate Pass", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-book'></i><span>MIS Reporting</span></a>";
            //writeNewMenu(dt, "rpt", "MIS Reporting", menuSelected, expandedGroup, mainMenu);

            //mainMenu = @"<li class='treeview'><a href='#'><i class='fa fa-book'></i><span>Messaging Portal</span></a>";
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
            sb.AppendLine("<ul class=\"treeview-menu\">");
            foreach (DataRow item in rows)
            {
                if (expandedGroup == item["function_name"].ToString())
                {
                    sb.AppendLine("<li class=\"active\"> <span>");
                }
                else
                    sb.AppendLine("<li> ");
                sb.AppendLine("<a href=\"" + item["link_file"].ToString() + "\" onclick=\"menu_click('" + group_name + "','" + item["function_name"].ToString() + "');\"><i class='fa fa-plus-circle' aria-hidden='true'></i>");
                sb.AppendLine("" + item["function_name"].ToString() + "");
                sb.AppendLine("</a></li>");
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
            string menu= GetStatic.ReadSession("mainMenu", ""), submenu= GetStatic.ReadSession("subMenu", "");
            LoadNewMenu(menu,submenu );

        }

        private void GetNotifications(string userId, string empId, string branchId)
        {

            string sql= "EXEC proc_ActiveNotifications 'a', '" + userId + "', '" + empId + "', '" + branchId + "'";
            DataTable dt = _clsdao.getTable(sql);

            int counter = dt.Rows.Count;
            count.Text = counter.ToString();
            
            StringBuilder sb1 = new StringBuilder("");
            sb1.AppendLine("<li style='padding:10px;border-bottom:1px solid #e5e0e0;text-align:center;background:#2f648b;color:#fff'><b class='header' style='text-align:center'>Notification</b></li>");
            if (dt.Rows == null || dt.Rows.Count == 0)
            {
                LastNoti.InnerHtml="<h5>No Notification found</h5>";
      
            }
            foreach (DataRow item in dt.Rows)
            {
                sb1.AppendLine("<li class='list-group-item list-group-item-action'>" + item["Notification"].ToString());
                sb1.AppendLine("<span class='badge pull-right'>"+ item["TOTAL"].ToString() + "</span> </a></li>");
            }
            sb1.AppendLine("<li></li>");
            noti.InnerHtml = sb1.ToString();
        }

        protected void ClearNotification(object sender, EventArgs e)
        {
            string query = "update Notifications set ReadDate = GETDATE() where ReadDate  IS NULL and (ReceiverId = "+ ReadSession().Emp_Id + " OR SpecialId = "+ReadSession().Emp_Id+")";
            _clsdao.runSQL(query);
            GetNotifications(ReadSession().UserId,ReadSession().Emp_Id.ToString(),ReadSession().Branch_Id.ToString());


        }
        protected void mainButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DashBoard.aspx?q=" + ReadSession().MenuType + "");
        }
    }

}
