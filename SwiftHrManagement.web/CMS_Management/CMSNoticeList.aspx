<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMSNoticeList.aspx.cs" Inherits="SwiftHrManagement.web.CMS_Management.CMSNoticeList" %>
<%@ Import Namespace="System.Data"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Swift HR Management System 1.0</title>
    <link href="../Css/style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
             <%                                  
                            DataSet ds = PopulateCMSNotice(this.Id);
                            DataTable dt = new DataTable();
                            DataTable cms = ds.Tables[0];
                            DataTable doc = ds.Tables[1];
                            { %> 
    <table>                       
    <tr>
        <td width="87%"> <span class="wellcome"><strong><%=cms.Rows[0]["func_head"].ToString()%></strong></span></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td><%=cms.Rows[0]["func_detail"].ToString()%>
            <br />
            <br />
        </td>
    </tr>
</table>
    </div>
    </form>
</body>
</html>
