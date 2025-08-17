using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SwiftHrManagement.web
{
    public class Global : System.Web.HttpApplication
    {
        clsDAO _clsDao = new clsDAO();
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Server.Transfer("/ErrorPage.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            _clsDao.runSQL("UPDATE Admins SET session='' where session='" + Session.SessionID + "'");
            Session.Clear();
            Session.Abandon();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
        }
    }
}