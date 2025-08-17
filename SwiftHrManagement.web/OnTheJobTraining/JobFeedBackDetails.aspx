<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="JobFeedBackDetails.aspx.cs" Inherits="SwiftHrManagement.web.OnTheJobTraining.JobFeedBackDetails" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style11
        {
            height: 60px;
        }
        </style>
<%--    <script type="text/javascript" language="javascript">
    function GetEmpID(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=Hdnempid.ClientID%>").Value = customerValueArray[1];
     

    }
    
    
</script>--%>


<script type="text/javascript" language="javascript">
    function checkComma(Obj) {
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        Obj.value = Obj.value.replace(",", " ");
        
        
}
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>

    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;OJT/Buddy System Feedback Entry</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"></td>
					</tr>
				</table>
				<table width="60%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class=""><div></div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>   
    <table border="0" cellspacing="5" cellpadding="5" class="container"> 
     
                      <tr>
                         <td>
                             <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
                         </td>
                      
                      </tr>  
      
                      <tr>
                               <td colspan="3">  <div id="rptDiv" runat="server"></div>                  
                               </td>

                       </tr>

      <tr>
       
         <td><div align="center">
            <asp:Button ID="btnSave" runat="server" CssClass="button" 
                 Text="Save" ValidationGroup="ojt" onclick="btnSave_Click" />
             <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="button" 
                 onclick="BtnBack_Click" />
                 </div>
            
          </td>
      </tr>
</table>
  </ContentTemplate>
            </asp:UpdatePanel>


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

</asp:Content>

