<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageCEACliam.aspx.cs" Inherits="SwiftHrManagement.web.CEA.ManageCEACliam" %>
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
						 CLaim CEA
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
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Claim CEA</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container" width="100%">  

        <tr>
            <td colspan="2">
                <span class="txtlbl" >Please enter valid data!</span>
                <span class="required" >(* Required fields)</span>
                <br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>          
        </tr>
        <tr>
            <td colspan="2">Employee Name : 
                <asp:Label ID="lblEmployeeName" runat="server" CssClass="txtlbl"></asp:Label>
                <br />
                <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="Off" 
                    Width="450px"
                    AutoPostBack="true"  CssClass="inputTextBoxLP"
                            ontextchanged="txtEmployee_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                    DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                    MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId" 
                    ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>   
            </td>
        </tr>
        <tr>
            <td colspan = "2"> CEA For:
             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                    runat="server" ControlToValidate="ddlCEAFor" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="jd">
                </asp:RequiredFieldValidator> 
                <asp:Label ID="lblChild" runat="server" CssClass="txtlbl"></asp:Label>
                <br />            
                <asp:DropDownList ID="ddlCEAFor" runat="server" CssClass="inputTextBoxLP">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td> Bill Date :<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="txtbillDate" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="jd">
                </asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtbillDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                
                <cc1:CalendarExtender ID="CalendarExtender12" 
                    runat="server" Enabled="True" TargetControlID="txtbillDate">
                </cc1:CalendarExtender>
            </td>
            <td>Bill Amount :<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                    runat="server" ControlToValidate="txtBillAmt" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="jd">
                </asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtBillAmt" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>From Fiscal Year :<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                    runat="server" ControlToValidate="ddlFromFy" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="jd">
                </asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="ddlFromFy" runat="server" CssClass="inputTextBoxLP">
                </asp:DropDownList> 
            </td>
             <td>From Month :<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="ddlFromMonth" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="jd">
                </asp:RequiredFieldValidator><br />

                 <asp:DropDownList ID="ddlFromMonth" runat="server" CssClass="inputTextBoxLP">
                </asp:DropDownList> 
             </td>
        </tr>

        <tr>
            <td>To Fiscal Year :<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate="ddlToFy" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="jd">
                </asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="ddlToFy" runat="server" CssClass="inputTextBoxLP">
                </asp:DropDownList> 
            </td>
             <td>To Month :<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="ddlToMonth" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="jd">
                </asp:RequiredFieldValidator><br />

                 <asp:DropDownList ID="ddlToMonth" runat="server" CssClass="inputTextBoxLP">
                </asp:DropDownList> 
             </td>
        </tr>

      
        <tr>
            <td colspan="2">Remarks :<br />
                <asp:textbox ID="txtnarration" runat="server" TextMode="MultiLine" Width="450px" CssClass="inputTextBoxLP">
                </asp:textbox>
            </td>
        </tr>

        <div id="fileUploadForm" runat="server">
        <tr>
            <td>
                File Description :<span class="errormsg">*</span>
                
              <%--  <asp:RequiredFieldValidator ID="rfv3" 
                    runat="server" ControlToValidate="TxtFileDescription" Display="None" 
                    ErrorMessage="*" SetFocusOnError="True" ValidationGroup="jd">
                </asp:RequiredFieldValidator>--%>
                <br />
                
                <asp:TextBox ID="TxtFileDescription" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
            </td>
            
            <td valign="top" nowrap="nowrap">
            
                    Select File :<span class="errormsg">*</span> 
                    <%--<asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="jd" ControlToValidate="fileUpload" Display="None" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                    <br />
                    <input id="fileUpload" runat="server" name="fileUpload" type="file" size="20" class="inputTextBoxLP" />
                        
            </td>
         </tr>
         </div>
         <asp:Panel id="pnlDisplayFile" runat="server" Visible="false">
         <tr>
            <td>
            <table>
                <tr>
                    <td><div class="txtlbl"> File Desc.:</div></td>
                    <td colspan="2"><asp:Label ID="lblFileDesc" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><div class="txtlbl">File Type:</div></td>
                    <td><asp:Label ID="lblFileType" runat="server"></asp:Label></td>
                    <td><asp:label ID="lblLink" runat="server"></asp:label> </td>
                </tr>
            </table>
            </td>
        </tr>
        </asp:panel>
         <tr>  
            <td colspan="2">
            
                    <asp:Button ID="BtnSave" runat="server" Text=" Save " CssClass="button" 
                        ValidationGroup="jd" onclick="BtnSave_Click"/>
                    <cc1:ConfirmButtonExtender ID="btnSave123" runat="server" 
                        ConfirmText="Confirm To Save?" TargetControlID="BtnSave">
                    </cc1:ConfirmButtonExtender>&nbsp;
                    
                     <asp:Button ID="btnDelete" runat="server" Text=" Delete " CssClass="button" onclick="btnDelete_Click"/>
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                        ConfirmText="Confirm To Delete?" TargetControlID="btnDelete">
                    </cc1:ConfirmButtonExtender>&nbsp;

                    <%-- <asp:Button ID="btnApprove" runat="server" Text=" Approve " CssClass="button" 
                        onclick="btnApprove_Click" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        ConfirmText="Confirm To Delete?" TargetControlID="btnApprove">
                    </cc1:ConfirmButtonExtender>&nbsp;

                     <asp:Button ID="btnReject" runat="server" Text=" Reject " CssClass="button" 
                        onclick="btnReject_Click" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" 
                        ConfirmText="Confirm To Delete?" TargetControlID="btnReject">
                    </cc1:ConfirmButtonExtender>&nbsp;--%>
                    
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
	</tbody>
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
