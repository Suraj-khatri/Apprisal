<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="MonthSetting.aspx.cs" Inherits="SwiftHrManagement.web.StaticView.MonthSetting" Title="Swift HRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script language="javascript" type="text/javascript">   
    function Update(monthId,ctl) {
        var btn = document.getElementById("<%=btnUpdate.ClientID%>");
        var txtMonthId = document.getElementById("<%=hddMonthId.ClientID%>");
        var txtMonthName = document.getElementById("<%=hddMonthName.ClientID%>");        
        txtMonthId.value = monthId;
        txtMonthName.value = document.getElementById(ctl).value;
        btn.click();
        
    }
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Nepali Month Setup Details</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="99%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Nepali Month Setup</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
 <table border="0" cellspacing="5" cellpadding="5" class="container" width="60%">  
        <asp:HiddenField ID="hddMonthId" runat="server" Value="" />
        <asp:HiddenField ID="hddMonthName" runat="server" Value="" />
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><b><asp:Label ID="Label13" runat="server" Text="Month Number"></asp:Label></b></td>
            <td><b><asp:Label ID="Label14" runat="server" Text="Month Name"></asp:Label></b></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="1"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth1" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(1,'<%=txtMonth1.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="2"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth2" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(2,'<%=txtMonth2.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="3"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth3" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(3,'<%=txtMonth3.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="4"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth4" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(4,'<%=txtMonth4.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label5" runat="server" Text="5"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth5" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(5,'<%=txtMonth5.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label6" runat="server" Text="6"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth6" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(6,'<%=txtMonth6.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label7" runat="server" Text="7"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth7" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(7,'<%=txtMonth7.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label8" runat="server" Text="8"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth8" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(8,'<%=txtMonth8.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label9" runat="server" Text="9"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth9" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(9,'<%=txtMonth9.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label10" runat="server" Text="10"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth10" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(10,'<%=txtMonth10.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label11" runat="server" Text="11"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth11" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(11,'<%=txtMonth11.ClientID%>');">Update</a></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label12" runat="server" Text="12"></asp:Label></td>
            <td><asp:TextBox ID="txtMonth12" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td><a href="javascript:Update(12,'<%=txtMonth12.ClientID%>');">Update</a></td>
        </tr>        
    </table>
    
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

<!--################ END FORM STYLE-->


	<!--		End  content	-->						</td>
					</tr>
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>
    <asp:UpdatePanel ID="updPanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" RenderMode="Inline">
        <ContentTemplate>
            <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" style="display:none" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="click" />
        </Triggers>        
    </asp:UpdatePanel>
    
</asp:Content>
