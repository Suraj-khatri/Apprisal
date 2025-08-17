<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="CustomerManage.aspx.cs" Inherits="SwiftHrManagement.web.WorkFlowManagement.Customer.CustomerManage" %>
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
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;Customer Entry Details</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Customer Entry Details </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container"> 
        <tr>
            <td colspan="2">
                <span class="txtlbl">Please Enter Valid Data!</span>
                <span class="required" >(* Required fields)</span><br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>     
        </tr>
        <tr>
           <td class="style10">
                    Customer Code <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="TxtCustCode" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Program" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtCustCode" runat="server"
                    CssClass="inputTextBoxLP" Width="134px"></asp:TextBox> 
            </td>
             <td class="style14">
               Customer Name  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                     runat="server" ControlToValidate="TxtCustName" Display="None" 
                     ErrorMessage="RequiredFieldValidator" ValidationGroup="Program" 
                     SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtCustName" runat="server"
                    CssClass="inputTextBoxLP" Width="310px"></asp:TextBox>          
            </td>
        </tr>
        
        </table>
        <table border="0" cellspacing="5" cellpadding="5" class="container">
            <tr>
                <td class="style13">
               Customer Address  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                     runat="server" ControlToValidate="TxtAddress" Display="None" 
                     ErrorMessage="RequiredFieldValidator" ValidationGroup="Program" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtAddress" runat="server" 
               CssClass="inputTextBoxLP" Width="457px"></asp:TextBox>
               </td>
            </tr>
        
        </table>        
        <%--<table border="0" cellspacing="5" cellpadding="5" class="container">--%>
        <table border="0" cellspacing="5" cellpadding="5" class="container">                   
         <tr>                
             <td class="txtlbl">
               Tel. No 1:  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                     runat="server" ControlToValidate="TxtTelNo" Display="None" 
                     ErrorMessage="RequiredFieldValidator" ValidationGroup="Program" 
                     SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtTelNo" runat="server"
                    CssClass="inputTextBoxLP" Width="200px"></asp:TextBox>          
            </td>   
                    <td class="txtlbl">
               Tel. No 2:  
                 <br />
                <asp:TextBox ID="TxtTelNo2" runat="server"
                    CssClass="inputTextBoxLP" Width="200px"></asp:TextBox>          
            </td>                            
              </tr>
              <tr>
               <td class="txtlbl">
                   Fax Number<br />
                <asp:TextBox ID="TxtFaxNo" runat="server"
                    CssClass="inputTextBoxLP" Width="200px"></asp:TextBox>          
               </td> 
               <td class="txtlbl">
                   Mobile Number<br />
                <asp:TextBox ID="TxtMobileNo" runat="server"
                    CssClass="inputTextBoxLP" Width="200px"></asp:TextBox>          
            </td>  
              </tr>
            
                                    
            <%--<table border="0" cellspacing="5" cellpadding="5" class="container">                   --%>
            <tr>
             <td class="style15">
                Email Address:<br />
                <asp:TextBox ID="TxtEmail" runat="server" 
               CssClass="inputTextBoxMultiLine"  Height="18px"></asp:TextBox>
             </td>   
            <td class="txtlbl">
                Website:<br />
                <asp:TextBox ID="TxtWebsite" runat="server" 
               CssClass="inputTextBoxMultiLine"  Height="18px"></asp:TextBox>
             </td>  
            </tr>     
            </table>            
            <table border="0" cellspacing="5" cellpadding="5" class="container">               
        <tr>
            <td class="style16">
                Business Details<br />
                <asp:TextBox ID="TxtBusinessDetails" runat="server" 
                    CssClass="inputTextBoxMultiLine" Height="45px" TextMode="MultiLine" 
                    Width="457px"></asp:TextBox>
                </td>            
            </table>
            <table border="0" cellspacing="5" cellpadding="5" class="container">
                <tr>                  
                <td class="txtlbl">
                    Contact Person I :<br />
                <asp:TextBox ID="TxtContact1" runat="server"
                    CssClass="inputTextBoxLP" Height="17px" Width="136px"></asp:TextBox>          
               </td> 
                <td>
                     Mobile No :<br />
                <asp:TextBox ID="TxtMobile1" runat="server"
                    CssClass="inputTextBoxLP" Width="145px"></asp:TextBox>
               </td>
               <td>
                    Email :<br />
                <asp:TextBox ID="TxtEmail1" runat="server"
                    CssClass="inputTextBoxLP" Width="145px"></asp:TextBox>
               </td>                
          </tr>
          <tr>
              <td class="txtlbl">
                  Contact Person II :<br />
                <asp:TextBox ID="TxtContact2" runat="server"
                    CssClass="inputTextBoxLP" Width="136px"></asp:TextBox>          
               </td>
               <td>
                    Mobile No :<br />
                <asp:TextBox ID="TxtMobile2" runat="server"
                    CssClass="inputTextBoxLP" Width="145px"></asp:TextBox>
               </td>
               <td>
                    Email :<br />
                <asp:TextBox ID="TxtEmail2" runat="server"
                    CssClass="inputTextBoxLP" Width="144px"></asp:TextBox>
               </td>
          </tr>
           <tr>                
                <td class="txtlbl">
                    Contact Person III :<br />
                <asp:TextBox ID="TxtContact3" runat="server"
                    CssClass="inputTextBoxLP" Width="133px"></asp:TextBox>          
               </td>
                <td>
                     Mobile No :<br />
                <asp:TextBox ID="TxtMobile3" runat="server"
                    CssClass="inputTextBoxLP" Width="144px" Height="16px"></asp:TextBox>
               </td>
               <td>
                     Email :<br />
                <asp:TextBox ID="TxtEmail3" runat="server"
                    CssClass="inputTextBoxLP" Width="145px"></asp:TextBox>
               </td> 
            </tr>
            </table>
            <table>
                <tr>
                    <td class="style11">
                        <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                            onclick="Btn_Save_Click" Text="Save" ValidationGroup="Program" 
                            Width="75px" />
                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm to save ?" Enabled="True" TargetControlID="Btn_Save">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;<asp:Button ID="Btn_Update" runat="server" CssClass="button" 
                            onclick="Btn_Update_Click" Text="Save" ValidationGroup="Program" 
                            Width="75px" />
                        <cc1:ConfirmButtonExtender ID="Btn_Update_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm to Update ?" Enabled="True" TargetControlID="Btn_Update">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                            onclick="BtnDelete_Click" Text="Delete" Width="75px" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm to Delete ?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;<asp:Button ID="BtnBack" runat="server" CssClass="button" 
                            OnClick="BtnBack_Click" Text="&lt;&lt; Back" Width="75px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </tr>
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