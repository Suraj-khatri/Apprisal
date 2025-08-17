<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LFAHistory.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LFAHistory" Title="Swift HRM" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style10
        {
            height: 26px;
        }
    </style>
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
						<img src="/images/big_bullit.gif">&nbsp;LFA History Report</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="500" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->


<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="100%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>LFA History</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

<table border="0" cellspacing="2" cellpadding="2" class="container">            
  <tr>
  <td>
    <asp:HiddenField ID="HiddenFieldEmpID" runat="server" />
  </td>
  </tr>
  <tr>
  <td>
      <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
  </td>
  </tr>
    
  <tr>
        <td nowrap="nowrap"><div align="right" class="text_form1">From Date :</div></td>
        <td>
                
                <asp:TextBox ID="txtFromDate" runat="server" CssClass="inputTextBoxLP" 
                    ></asp:TextBox>
                    <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Required" ControlToValidate="txtFromDate" ValidationGroup="LFA"></asp:RequiredFieldValidator>
                    
                <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtFromDate">
                </cc1:CalendarExtender>
                    
       </td>
    </tr>
    <tr>
        <td class="style10"  nowrap="nowrap"><div align="right" class="text_form1">To Date :</div></td>
        <td class="style10">
                
                <asp:TextBox ID="txtToDate" runat="server" CssClass="inputTextBoxLP" 
                    ></asp:TextBox><span class="errormsg">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"  ControlToValidate="TxtToDate" ValidationGroup="LFA">
            </asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtToDate">
                </cc1:CalendarExtender>
       </td>
    </tr>
    <tr>
                            <td nowrap="nowrap"><div align="right" class="text_form1">Employee :</div></td>
                            <td>
                                <asp:TextBox ID="txtEmpId" runat="server" CssClass="inputTextBoxLP" AutoPostBack="true" 
                Width="450px" AutoComplete="Off" ></asp:TextBox>             
                               
                
                                <cc1:TextBoxWatermarkExtender ID="txtEmpId_TextBoxWatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtEmpId" WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                                
                                 <cc1:AutoCompleteExtender ID="txtEmpId_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                    DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                    MinimumPrefixLength="1" ServiceMethod="GetEmployeeList" 
                    ServicePath="~/Autocomplete.asmx" 
                         TargetControlID="txtEmpId"  OnClientItemSelected="AutocompleteOnSelected" >
                                </cc1:AutoCompleteExtender>
                        </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" CssClass="button" Text="Search" 
                                    onclick="ButtonSearch_Click" ValidationGroup="LFA"/>
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
  
  <!--################ START FORM STYLE-->
  
  
<!--################ END FORM STYLE-->
	                    </td>
					</tr>
			  </table>
			  </td>
		  </tr>
	</table>
	</td>
  </tr>
</table>
    
<script language=javascript>


        function AutocompleteOnSelected(sender, e) {
            var CustodianValueArray = (e._value).split("|");
            var HiddenFieldEmpID = document.getElementById("<%=HiddenFieldEmpID.ClientID %>");

            HiddenFieldEmpID.value = CustodianValueArray[1];
            //alert(HiddenFieldEmpID.value);
        }
</script>
</asp:Content>

