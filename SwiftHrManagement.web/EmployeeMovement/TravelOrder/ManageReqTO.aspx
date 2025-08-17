<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageReqTO.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.ManageReqTO" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script src="../../Jsfunc.js" type="text/javascript"></script>
  
    <script type="text/javascript">
    function AutocompleteOnSelected(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%= hdnEmpHrId.ClientID %>").value = customerValueArray[1];
        document.getElementById("<%= txtHndEmpId.ClientID %>").value = customerValueArray[1];
        
    }

    function DeleteNotification(TOID) {
        if (confirm("Are you sure to delete this message?")) {
            document.getElementById("<% =HdnTravelOrderId.ClientID %>").value = TOID;
            document.getElementById("<% =BtnDelete.ClientID %>").click();
        }
    }

    function DateDifference() {

        var fromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
       
        var toDate = document.getElementById("<%=txtToDate.ClientID%>").value;
        var dat1 = new Date(fromDate);
        var dat2 = new Date(toDate);
        if (fromDate == '' || toDate == '') {
            alert('Please Enter From Date and To Date');
        }
        else {
            var DiffDays = DateDiffInDays(dat1, dat2);
            document.getElementById("<%=txtDays.ClientID%>").value = DiffDays;
        }
    }
  
  function TotalAllowance(){

      var day = document.getElementById("<%=txtDays.ClientID%>").value;
      var rate = document.getElementById("<%=txtPerDay.ClientID%>").value;
      document.getElementById("<%=txtTotal.ClientID%>").value = parseFloat(day.replace(/,/g, '')) * parseFloat(rate.replace(/,/g, ''));

  }
  
        
 
    
</script>

    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="UPDPANEL" runat="server">
    <ContentTemplate>

      <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
<tr>
<td valign="top">
<table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
<tr>
<td valign="top">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td align="left" class="wellcome" valign="bottom">
<img height="1" src="../../../../../../../images/spacer.gif" width="5" />
<img src="../../Images/big_bullit.gif" />&nbsp;Request Travel Order
    <asp:Label ID="LblBranchDept" runat="server" CssClass="subheading"></asp:Label>
   
</td>
    
</tr>
<tr>
<td bgcolor="#999999" height="1" valign="top">
<img height="1" src="../../../../../../../images/spacer.gif" width="100%" />
</td>
</tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="90%">
<tr>
<td align="center" valign="top">
<br />
<table border="0" cellpadding="0" cellspacing="0" class="container" width="40%">
<tr>
<td class="container_tl" width="1%">
<div>
</div>
</td>
<td class="container_tmid" width="91%">
<div align="left">
   Request Travel Order Entry</td>
<td class="container_tr" width="8%">
<div>
</div>
</td>
</tr>
<tr>
<td class="container_l">
</td>
<td class="container_content">
<!--################ END FORM STYLE-->
<table border="0" cellpadding="5" cellspacing="5" class="container">
    <tr>
        <td>
            <span class="txtlbl">Please enter valid data! <span class="errormsg">(* are required fields!)</span><br /><br />
            <asp:Label ID="LblMsg" runat="server" CssClass="errormsg"></asp:Label>
            <asp:HiddenField ID = "HdnTravelOrderId" runat="server" /> 
            <asp:HiddenField ID="hdnEmployeeId" runat="server" />
              <asp:HiddenField ID="hdnEmpHrId" runat="server" />
            <asp:HiddenField ID="hdnTotal" runat="server" />
            <asp:HiddenField ID="hdnRateId" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="downPanel" runat="server" GroupingText="Travel Order information" CssClass="">
            <table cellpadding="0" cellspacing="0" width="80%">
                <tr>
                    <td></td>
                </tr>    
                <tr>
                    <td colspan="3">                   
                        Request By :                        
                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtReqBy" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                        <br />
                        
                         <div id="ShowReqText" runat="server" visible="false">
                                 <asp:TextBox ID="txtReqestedBy" runat="server" CssClass="inputTextBox" Width="360px">
                                 </asp:TextBox>
                    
                        </div>
                       <div id="showReqText1" runat="server" visible="false">
                        <asp:TextBox ID="txtReqBy" runat="server" CssClass="inputTextBox" Width="360px" 
                               AutoPostBack="true" ontextchanged="txtReqBy_TextChanged"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                        runat="server" Enabled="True" TargetControlID="txtReqBy" 
                        WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>

                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                        DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                        MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelected" 
                        ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                        TargetControlID="txtReqBy">
                        </cc1:AutoCompleteExtender>
                        </div>
                        <asp:TextBox ID="txtHndEmpId" runat="server" style="display:none;"></asp:TextBox>
                        <br />
                    </td>  
                </tr>
            
                <tr>
                 <td>
                        Place of Visit :<br />
                        
                       <%-- <asp:DropDownList ID="ddlPlaceOfVisit" runat="server" CssClass="CMBDesign" 
                            onselectedindexchanged="ddlPlaceOfVisit_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>--%>
                        <asp:TextBox ID="txtPlaceOfVisit" runat="server" CssClass="inputTextBox" Width="170px"></asp:TextBox>
                    </td>
                     <td>
                      Region :
                         <asp:Label ID="lblRegionMsg" runat="server" Text="" CssClass="errormsg"></asp:Label>
                      
                       <br />
                        <asp:DropDownList ID="ddlRegion" runat="server" 
                            AutoPostBack="true"  CssClass="CMBDesign" Width="170px"
                              onselectedindexchanged="ddlRegion_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--<asp:TextBox ID="txtPlaceOfVisit" runat="server" CssClass="inputTextBox" ></asp:TextBox>--%>
                    </td>  
                    
                    <td>
                       Mode Of Trasportation :<br />
                        <asp:DropDownList ID="ddlTransport" runat="server" CssClass="CMBDesign" Width="180px"></asp:DropDownList>
                    </td>
                  
                </tr>
                
                <tr>
                    <td>
                        Request Date :
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtReqDate" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txtReqDate" runat="server" CssClass="inputTextBox" Width="170px"></asp:TextBox>
                        <cc1:CalendarExtender ID="RequestDateCalendar" runat="server" Enabled="true" EnabledOnClient="true"
                             TargetControlID="txtReqDate"></cc1:CalendarExtender>
                    </td>

                    <td>
                        From Date : <span class= "errormsg"><asp:Label ID="lblFromDate" runat="server" Text="">
                                    </asp:Label>
                                </span><br />
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="inputTextBox" Width="170px" ></asp:TextBox>
                        <cc1:CalendarExtender ID="FromDateCalendar" runat="server" Enabled="true" EnabledOnClient="true"
                             TargetControlID="txtFromDate"></cc1:CalendarExtender>
                    </td>
                    <td>
                       To Date : <span class= "errormsg"><asp:Label ID="lblToDate" runat="server" Text=""></asp:Label></span><br />
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="inputTextBox" Width="180px"></asp:TextBox>
                        <cc1:CalendarExtender ID="ToDateCalendar" runat="server" Enabled="true" EnabledOnClient="true"
                             TargetControlID="txtToDate"></cc1:CalendarExtender>
                       
                    </td>
                </tr>
                    <tr>
                    <td colspan="6">
                        Purpose of Visit :<br />
                        <asp:TextBox ID="txtPurposeOfVisit" runat="server" CssClass="inputTextBox"
                         TextMode="MultiLine" Height="30px" Width= "670px" ></asp:TextBox>
                    </td>   
                    
                </tr>
            </table>
            </asp:Panel>
        </td>
    </tr> 

    <tr>
        <td nowrap="nowrap">                
        <asp:Panel ID="ProductListPanel" runat="server" GroupingText="Allowance Info" CssClass="legend">
            <table cellpadding="5" cellspacing="5">
            <tr>
            <td>
            
                <asp:Label ID="lblShowALlow" runat="server" Text=""></asp:Label>
            </td>
            
            </tr>
                <tr>
                    <td align="left">
                        Allowance Type :
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtPerDay" ErrorMessage="Required"  
                            ValidationGroup="add"></asp:RequiredFieldValidator>
                            <br />
                         <asp:DropDownList ID="ddlAllowance" runat="server" AutoPostBack="true" 
                            CssClass="CMBDesign" onselectedindexchanged="ddlAllowance_SelectedIndexChanged" 
                            ValidationGroup="requisition" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Days:<br />
                        <asp:TextBox ID="txtDays" runat="server" CssClass="inputTextBox" Width="90px"></asp:TextBox>
                        
                    </td>
                    <td align="left">
                        Per Day :
                        <asp:RequiredFieldValidator ID="RfvQuantity" runat="server" 
                            ControlToValidate="txtPerDay" ErrorMessage="Required"  
                            ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                        <asp:TextBox ID="txtPerDay" runat="server" CssClass="inputTextBox" Width="90px" ReadOnly="true">
                        </asp:TextBox>                                
                                                  
                    </td>
                     <td align="left">
                        Currency :<br />
                        <asp:TextBox ID="txtCurrency" runat="server" CssClass="inputTextBox" Width="90px" ReadOnly="true">
                        </asp:TextBox>                                
                                                  
                    </td>
                    <td>
                        Total :<br />
                        <asp:TextBox ID="txtTotal" runat="server" CssClass="inputTextBox" 
                            ReadOnly="true" Width="90px"></asp:TextBox>
                    </td>
                    <td valign="bottom">
                        <asp:Button ID="BtnAdd" runat="server" CssClass="button" Text="Add" 
                        ValidationGroup="add"  Width="50" onclick="BtnAdd_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" width="100%" class="style11">
                        <div id="rpt" runat="server">
                            <asp:Table ID="Table1" runat="server" Width="100%">
                            </asp:Table>
                        </div>
                    </td>
                    <td class="style11"></td>
               </tr>
               <tr>
                  <td>
                       Reqested Advance(In NPR) : <span class= "errormsg"><asp:Label ID="lblAdv" runat="server" Text=""></asp:Label></span><br />
                        <asp:TextBox ID="txtReqAdv" runat="server" 
                        CssClass="inputTextBox"></asp:TextBox>
               <%--        <cc1:FilteredTextBoxExtender ID="txtFilter" runat="server" Enabled="true" 
                            FilterType="Numbers" TargetControlID="txtReqAdv"></cc1:FilteredTextBoxExtender>--%>
                       
                    </td>
                    <td colspan="2">
                        Recommended By :
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="ddlRecommend" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator>
                        <br />
                        <asp:DropDownList ID="ddlRecommend" runat="server" CssClass="CMBDesign" Width="150px"></asp:DropDownList>
                    </td>
               </tr>
               
                  <tr>
                    <td colspan="6">
                        Remarks:
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtRemarks" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator><br />
                             <asp:TextBox ID="txtRemarks" runat="server" CssClass="inputTextBox"
                         TextMode="MultiLine" Height="30px" Width= "670px" ></asp:TextBox>
                        <br />
                    </td>
               </tr>
               
               <tr>
                    <td colspan="3" align="right">
                        <asp:Panel ID="PnDelete" runat="server">
                        <div align="left">
                        <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" Width="50" 
                                onclick="BtnSave_Click" ValidationGroup ="save"/>
                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                         </div>
                        </asp:Panel>
                        
                    </td>
                    <td>
                    <asp:Button ID="BtnDelete" runat="server" Text="" onclick="BtnDelete_Click" style="display:none;" />
                    </td>
               </tr>
            </table> 
        </asp:Panel>                   
        </td>
    </tr>


</table>
<!--################ START FORM STYLE-->
</td>
<td class="container_r">
</td>
</tr>
<tr>
<td class="container_bl">
</td>
<td class="container_bmid">
</td>
<td class="container_br">
</td>
</tr>
</table>

<!--################ END FORM STYLE-->


<!--		End  content	-->						
</td>
</tr>
</table>
</td>
</tr>
</table>
</td>
</tr>
</table>

    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

