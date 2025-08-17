<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="TNAReport.aspx.cs" Inherits="SwiftHrManagement.web.TrainingManagement.TrainingNeedAssessment.TNAReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            font-size: large;
            font-weight: bold;
        }
        .style11
        {
            height: 33px;
        }
        </style>
            <script type="text/javascript">

            function AutocompleteOnSelected(sender, e) {
                var customerValueArray = (e._value).split("|");
                document.getElementById("<%=txtHdnEmpId.ClientID %>").value = customerValueArray[1];
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table width="980" border="0" cellspacing="3" cellpadding="3">
  <tr>
    <td><div align="center" class="style10">Training Needs Assessment (TNA)</div></td>
    <td width="150px" align="right"><img src="../../Images/megaLogo.jpg"/></td>
  </tr>
  <tr>
    <td colspan="2"><em><b>A Training Needs Assessment is being carried out to determine the various training that is required by the staff at Mega Bank Nepal Limited. 
    Results obtained from this form will be used as a basis to identify and prioritize different types of training to help develop a Training Calender. 
    Please answer these questions.</b></em></td>
  </tr>
</table>
<br />
<table>
    <tr>
        <td>
        <asp:Label ID="lblmsg" runat="server" CssClass="errormsg"></asp:Label>
            <asp:TextBox ID="txtHdnEmpId" runat="server" style="display:none;"></asp:TextBox>        
        </td>
        
    </tr>
    <tr>
        <td>
        <table align="left" border="1" cellspacing="1" cellpadding="5" class="FormDesign">
            <tr>
                <td><div align="right">From Date:</div></td>
                <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="CMBDesign"></asp:TextBox> 
                    <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtFromDate">
                    </cc1:CalendarExtender>
                </td>
                <td><div align="right">To Date:</div></td>
                <td><asp:TextBox ID="txtToDate" runat="server" CssClass="CMBDesign"></asp:TextBox> 
                    <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtToDate">
                    </cc1:CalendarExtender>
                </td>
            </tr>        
            <tr>
                <td nowrap="nowrap"><div align="right">Name:</div></td>
                <td>       
                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="inputTextBoxLP1" 
                                Width="400px" AutoPostBack="true" ontextchanged="txtEmployee_TextChanged">
                        </asp:TextBox>
                        <cc1:textboxwatermarkextender ID="TextBoxWatermarkExtender1" 
                        runat="server" Enabled="True" TargetControlID="txtEmployee" 
                        WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                        </cc1:textboxwatermarkextender>

                        <cc1:autocompleteextender ID="AutoCompleteExtender1" runat="server" 
                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                        DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                        MinimumPrefixLength="1"  OnClientItemSelected="AutocompleteOnSelected"
                        ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                        TargetControlID="txtEmployee">
                        </cc1:autocompleteextender>
                    
                    
                        
                         </td>
                <td><div align="right">Job Title/Position:</div></td>
                <td><asp:DropDownList ID="DdlEmpPosition" runat="server" CssClass="CMBDesign"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><div align="right">Branch Name:</div></td>
                <td><asp:DropDownList ID="DdlBranchName" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>
                <td><div align="right">Department:</div></td>
                <td><asp:DropDownList ID="DdlDeptName" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>
            </tr>
            <tr>
                <td><div align="right">Immediate Supervisor :</div></td>
                <td><asp:DropDownList ID="DdlISupName" runat="server" CssClass="CMBDesign"  
                        AutoPostBack = "true"></asp:DropDownList> 
                    <asp:Button ID="BtnSearchRpt" runat="server" Text="Search" CssClass="button" 
                        onclick="BtnSearchRpt_Click"/>
                        
                        </td>
                <td><div align="right">Position:</div></td>
                <td><asp:DropDownList ID="DdlISupPosition" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>
            </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table align="left" border="1" cellspacing="1" cellpadding="5" class="FormDesign">
                <tr>
                    <td class="TableCellHead">Training Previously Attended</td>
                </tr>
                <tr>
                    <td><div id="rptTPA" runat="server"></div></td>
                </tr>
                <tr>
                    <td class="TableCellHead">Difficulties While Discharging Duties</td>
                </tr>
                 <tr>
                    <td><div id="rptDWDD" runat="server"></div></td>
                </tr>
                <tr>
                    <td class="TableCellHead">What Can Be Done To Remove These Problems</td>
                </tr>
                 <tr>
                    <td><div id="rptWCBDTRTP" runat="server"></div></td>
                </tr>
                <tr>
                    <td class="TableCellHead">Training Requirements Foreseen</td>
                </tr>
                <tr>
                    <td><div id="rptTRF" runat="server"></div></td>
                </tr>
                <tr>
                    <td class="TableCellHead">Soft Skills Training</td>
                </tr>
                 <tr>
                    <td><div id="rptSST" runat="server"></div></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
 </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
