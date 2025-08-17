<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayIntranet.aspx.cs" Inherits="SwiftHrManagement.web.CMS_Management.DisplayIntranet" %>
<%@ Import Namespace="System.Data"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Swift ERP System 1.0</title>
<link href="../Css/style.css" rel="Stylesheet" type="text/css" />
   
</head>
<body>
<form id="form1" runat="server">
<div class="wraper">
   
<table width="100%" border="0" style="border-collapse:collapse" cellpadding="0" cellspacing="0">
  <tr>
    <td width="10%" nowrap="nowrap"><img src="../Images/left1.jpg"/></td>
    <td style=" background-image:url(../Images/middle1.jpg);" width="75%">
   	<div>
        <table cellspacing="2" cellpadding="2" align="right">
            <tr>
                <td colspan="2"><b><asp:Label ID="LblMsg" runat="server" CssClass="errormsg"></asp:Label></b>
                </td>
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>  
            </tr>
        </table>
   </div>
    </td>	
    <td width="100%" style=" background-image:url(../Images/right1.jpg);"></td>
</tr>
</table>
</div>

        <%                                  
                DataSet ds = PopulateCMSMenu();
                DataTable dt = new DataTable();
                DataTable main = ds.Tables[0];
                DataTable sub1 = ds.Tables[1];
                string tid;      
            
        %>                 


<table  width="100%" border="0" cellpadding="10" cellspacing="10">                              
<tr>

    <td width="15%" valign="top">   
       <table cellpadding="2" cellspacing="0">   
            <tr class="menuCss1">
                <td><a class="menu" href="../Default.aspx"><b><img src="../Images/iconInfo.gif" border="0"/>Sign Out</b></a></td>
            </tr>
            <tr>
                <td><a class="menu" href="../Main.aspx?q=HR"><b><img src="../Images/iconInfo.gif" border="0"/>Main Page</b></a></td>                
            </tr>
          <%
               
           var CNT = 0;
           foreach(DataRow row in main.Rows)
             {

                 CNT = CNT + 1;
                 %>
                     <tr class="menuCss1">
           
                        <td onclick="javascript:showHideMenu('menu_<%=CNT %>')" nowrap="nowrap" width="200px">
                                    <a class="menu" target="MainFrame" href="CMSPageList.aspx?ID=<%=row["func_id"].ToString() %>"> 
                            <img src="../Images/iconFolderClosed.gif" border="0"/><%=row["menu_name"].ToString() %></a> 
                        </td>
                     </tr>
                <%
                 
                tid = row["id"].ToString();
                DataRow[] row1 = sub1.Select("linked_id='" + tid + "'");

                if (row1.Length > 0)
                    {
                       %>                    
                     
                     <tr> 
                         <td>                       
                             <table cellpadding="0" cellspacing="0" id="menu_<%=CNT %>" style="display:none;"> 
                                   <%
                                        foreach (DataRow sub_row in row1)
                                        { 
                                            %>                     
                                               
                                            <tr>
                                                <td style="padding-left:15px" nowrap="nowrap"> 
                                                <a  class="subMenu" target="MainFrame" href="CMSPageList.aspx?ID=<%=sub_row["func_id"].ToString()%>"> 
                                              <img src="../Images/orangearrrow.png" border="0"/>  <%=sub_row["menu_name"].ToString()%></a> 
                                                </td>
                                                
                                            </tr>
                                       
                                       
                                        <%} %> 
                                             
                               </table>
                        </td>
                    </tr> 
                    
                       <%
                     }
               %>
                
                <% 
               } %> 

         </table>
         
    </td>
    <td>    
        <iframe src="CMSPageList.aspx?ID=1" name="MainFrame" id="MainFrame" style="width: 900px; height: 500px;" frameborder="0">
        </iframe>
    </td>
    <td valign="top" style="border-left:1px solid #EEEEEE; padding-left:3px; padding-top:5px;">
    <div>
         <h2>HR Notice Board</h2>
         <marquee height="150px" style="margin-bottom: 10px;" onmouseout="this.start()" onmouseover="this.stop()" scrolldelay="10" 
        scrollamount="1" behavior="scroll" direction="up">
                <div id="rpt" runat="server"></div></marquee>
    </div>
    <div>
        <h2>Latest Uploaded Files</h2>
        <marquee height="150px" width="200px" style="margin-bottom: 10px;" onmouseout="this.start()" onmouseover="this.stop()" scrolldelay="10" 
        scrollamount="1" behavior="scroll" direction="up">
                <div id="rpt1" runat="server"></div></marquee>
        </div>
    </td>
</tr>
<tr>
    <td colspan="2">Copyright © 2009 Powered by <a target="_blank" href="http://www.swifttech.com.np" class="footerLink">Swift Technology Pvt. Ltd.</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Intranet site  &copy; 2009&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;disclaimer&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;sitemap&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;FAQ </td>
</tr>
</table>

</form>
</body>
</html>
 <script type="text/javascript" language="javascript">
     function showHideMenu(obj) {
         var listElementStyle = document.getElementById(obj).style;
         if (listElementStyle.display == "none") {
             listElementStyle.display = "block";
         }
         else {
             listElementStyle.display = "none";
         }
     }
</script>   
   