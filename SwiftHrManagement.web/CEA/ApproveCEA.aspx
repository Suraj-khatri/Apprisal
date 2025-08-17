<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ApproveCEA.aspx.cs" Inherits="SwiftHrManagement.web.CEA.ApproveCEA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
			<!-- BREAD CRUMBS START !-->
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						
						<img src="/images/big_bullit.gif"> 
						 Approve CEA
                       </td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
	            <table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center">

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="60%">
  <%--<tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Approve CEA</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container" width="100%">  

        <tr>
            <td colspan="4">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>          
        </tr>
        <tr>
            <td colspan="4" nowrap="nowrap">Employee Name : <asp:Label ID="lblEmployeeName" runat="server" CssClass="txtlbl"></asp:Label> 
            </td>
        </tr>
        <tr>
            <td> Bill Date </td>
            <td align="left">:
                <asp:label ID="lblbillDate" runat="server" CssClass="txtlbl"></asp:label>

            </td>
            <td>Bill Amount </td>
            <td>:
                <asp:label ID="lblBillAmt" runat="server" CssClass="txtlbl"></asp:label>
            </td>
        </tr>
        <tr>
            <td>From Fiscal Year </td>
            <td>:
                <asp:label ID="lblFromFy" runat="server" CssClass="txtlbl">
                </asp:label> 
            </td>
             <td>From Month </td>
            <td>:
                 <asp:label ID="lblFromMonth" runat="server" CssClass="txtlbl">
                </asp:label> 
             </td>
        </tr>

        <tr>
            <td>To Fiscal Year </td>
            <td>:
                <asp:label ID="lblToFy" runat="server" CssClass="txtlbl">
                </asp:label> 
            </td>
             <td>To Month </td>
            <td>:
                 <asp:label ID="lblToMonth" runat="server" CssClass="txtlbl">
                </asp:label> 
             </td>
        </tr>

        <tr>
            <td colspan="4" nowrap="nowrap">Approve By : 
                <asp:Label ID="lblappBy" runat="server" CssClass="txtlbl"></asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="4">Narration :<br />
                <asp:label ID="txtnarration" runat="server" TextMode="MultiLine" Width="450px" CssClass="txtlbl">
                </asp:label>
            </td>
        </tr>

        <asp:Panel id="pnlDisplayFile" runat="server" Visible="false">
        <tr>
            <td>
            <table>
                <tr>
                    <td><div class="txtlbl"> File Desc.:</div></td>
                    <td colspan="2"><asp:Label ID="lblFileDesc" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><div class="txtlbl">File Type :</div></td>
                    <td><asp:Label ID="lblFileType" runat="server"></asp:Label></td>
                    <td><asp:label ID="lblLink" runat="server"></asp:label> </td>
                </tr>
            </table>
            </td>
        </tr>
        </asp:panel>

         <tr>  
            <td colspan="4">
            
                     <asp:Button ID="btnApprove" runat="server" Text=" Approve " CssClass="button" 
                        onclick="btnApprove_Click" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        ConfirmText="Confirm To Delete?" TargetControlID="btnApprove">
                    </cc1:ConfirmButtonExtender>&nbsp;

                     <asp:Button ID="btnReject" runat="server" Text=" Reject " CssClass="button" 
                        onclick="btnReject_Click" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" 
                        ConfirmText="Confirm To Delete?" TargetControlID="btnReject">
                    </cc1:ConfirmButtonExtender>&nbsp;
                    
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="rpt" runat="server"></div>
            </td>
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
	</tbody>--%>
  </table>

<!--################ END FORM STYLE-->


	<!--		End  content	-->						
	                    </td>
					</tr>
	</table>			
			  </td>
		  </tr>
	</table>	</td>
  </tr>
</table>

</asp:Content>
