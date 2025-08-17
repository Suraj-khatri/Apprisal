<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="SwiftHrManagement.web.Show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title> 
    <link href="Css/style.css" rel="stylesheet" type="text/css" />       
<script type="text/javascript" language="javascript">      

      
      function moveMonth(nav)
      {
          var ddlMonth = "<%=month.ClientID%>";
          var ddlYear = "<%=year.ClientID%>"; 
          var btnGo = "<%=btnGo.ClientID%>";          
          
          var m = document.getElementById(ddlMonth);
          var y = document.getElementById(ddlYear);
          var b = document.getElementById(btnGo);
          
          
          if(m !=null && y != null && b !=null)
          {
            
            if (nav=="p")
            {                
                if(m.selectedIndex==0)
                {
                    if(y.selectedIndex==0)
                        return;
                        
                    m.selectedIndex = 11;
                    
                    if(y.selectedIndex>0){
                        y.selectedIndex = y.selectedIndex - 1;
                    }
                }
                else
                {
                     m.selectedIndex = m.selectedIndex - 1;
                }
                 b.click();
            }
            else
            {
               if(m.selectedIndex>=11)
                {
                    if (y.selectedIndex == y.options.length - 1 ) 
                        return;
                    m.selectedIndex = 0;
                    
                    if(y.selectedIndex < y.options.length - 1){
                        y.selectedIndex = y.selectedIndex + 1;
                    }
                }
                else
                {
                     m.selectedIndex = m.selectedIndex + 1;
                }
                 b.click();            
            }
          }
      }  
    </script>  
</head>
<body>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br />
<br />
						

 <table class="container" border="0" cellpadding="0" cellspacing="0" width="30%">
  <tbody><tr>`
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Event/Holiday Calendar</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td>
        <!--Begin Calender Search-->

<table border="0" cellspacing="2" cellpadding="2" class="container"> 

<tr>
    <td align="center">
        <table align="center">
        <tr>
            <td><span class="txtlbl">Year</span><br />
            <div align="center"><asp:DropDownList ID="year" runat="server" CssClass="CMBDesign" Width="81px" Height="20px">
            </asp:DropDownList></div></td>
            <td><span class="txtlbl">Month</span>
            <div align="center"><asp:DropDownList ID="month" runat="server" CssClass="CMBDesign" Width="95px" Height="20px">
            </asp:DropDownList></div></td>
            <td><br>
            <div align="left"><asp:Button ID="btnGo" runat="server" onclick="btnGo_Click" Text="GO" CssClass="button" /></div></td>
        </tr>
    </table>
    </td>
</tr>
<tr>
    <td>
        <table align="center"> 
        <tr>
            <td>
            
            <asp:UpdatePanel ID="upd1" runat="server">
            
                <ContentTemplate>      
                    <div id="divEvents" runat="server">  
                        <asp:HiddenField ID="hddDate" runat="server" Value="" />
                    </div>
                    <div ID="cal" runat="server"></div>
                </ContentTemplate>
                
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGo" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>            
            </td>            
        </tr>      

        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </td>
</tr>
</table>


        <!--End Calender Search-->

<!--################ START FORM STYLE-->

	</td>
    <td class="container_r"></td>
  </tr>
  <tr>
    <td class="container_bl"></td>
    <td class="container_bmid"></td>
    <td class="container_br"></td>
  </tr>
	</tbody>
  </table>

	                    </td>
					</tr>
			  </table>
			</td>
			<td>
			    
			</td>
		  </tr>
	</table>
	</td>
  </tr>
</table>

    <table width="40%" align="center">
    <tr>
        <td class="style11" align="left">&nbsp;</td>
    </tr>
    <tr>
        <td class="style11" align="left">
                <div id="rptDiv" runat="server">
                </div>
            </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table> 
    </form>
</body>
</html>
