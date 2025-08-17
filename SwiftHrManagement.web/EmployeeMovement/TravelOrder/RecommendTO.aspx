<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="RecommendTO.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TravelOrder.RecommendTO" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
        <script language ="javascript">
            var GB_ROOT_DIR = "greybox/";
        </script>

    <script src="../../Jsfunc.js" type="text/javascript"></script>
    
     <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
        <script type="text/javascript">
          
        
       function GetId() {
           var notificationList = document.getElementById("notificationList");
           var ids = notificationList.contentWindow.GetIdListForNotification();
           var HiddenFieldempEmail = document.getElementById("<%=HiddenFieldEmpEmail.ClientID %>");
           HiddenFieldempEmail.value = ids;
           return false;
       }
       function DeleteTravelAllowance(TOID) {
           if (confirm("Are you sure to delete this message?")) {
               document.getElementById("<% =HdnTravelOrderId.ClientID %>").value = TOID;
               document.getElementById("<% =BtnDelete.ClientID %>").click();
           }
       }
       function EditTravelAllowance(ID) {
           var fromDate = document.getElementById("<%=txtApproveFrom.ClientID%>").value;
           var toDate = document.getElementById("<%=txtApprovTo.ClientID%>").value;
           var dat1 = new Date(fromDate);
           var dat2 = new Date(toDate);
           var DiffDays = DateDiffInDays(dat1, dat2);
           GB_showCenter('Edit Travel Order', '/EmployeeMovement/TravelOrder/EditAllowance.aspx?TravelOID=' + ID + '&totalDays=' + DiffDays,
             '220', '650', '')
       }

       function DateDifference() {

           var fromDate = document.getElementById("<%=txtApproveFrom.ClientID%>").value;

           var toDate = document.getElementById("<%=txtApprovTo.ClientID%>").value;
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

       function TotalAllowance() {

           var day = document.getElementById("<%=txtDays.ClientID%>").value;
           var rate = document.getElementById("<%=txtPerDay.ClientID%>").value;
           document.getElementById("<%=txtTotal.ClientID%>").value = parseFloat(day.replace(/,/g, '')) * parseFloat(rate.replace(/,/g, ''));
      
       }
  
        
   
   
        </script>
    <style type="text/css">
        .style10
        {
            width: 3px;
        }
        .style11
        {
            height: 49px;
        }
    </style>
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
            <input id="HdnEmpid" name="HdnEmpid"  type="hidden"/>   
            <asp:HiddenField ID="HiddenFieldEmpID" runat="server" />
            <asp:HiddenField ID="HiddenFieldEmpEmail" runat="server" />
            <asp:HiddenField ID="hdnTotal" runat="server" /> 
            <asp:HiddenField ID="hdnRegion" runat="server" /> 
            <asp:HiddenField ID="hdnRateId" runat="server" /> 
                               
           <%-- <asp:HiddenField ID="HdnEmpid" runat="server" />--%>
        </td>
    </tr>
    <tr>

        <td>
            <asp:Panel ID="downPanel" runat="server" GroupingText="Travel Order information" CssClass="">
                    <table cellpadding="" cellspacing="" width="100%">
                        
                        <tr>
                            <td colspan="3">
                                Request By :
                                <br />
                                <asp:TextBox ID="txtReqBy" runat="server" CssClass="inputTextBox" Width="640px"></asp:TextBox>
                            </td>  
                        </tr>
                      
                        <tr>
                         <td>
                                Place of Visit :<br />
                                <asp:TextBox ID="txtPlaceOfVisit" runat="server" CssClass="inputTextBox" ></asp:TextBox>
                            </td> 
                            <td>
                                Region :<br />
                                <asp:TextBox ID="txtRegion" runat="server" CssClass="inputTextBox" ></asp:TextBox>
                            </td>   
                            <td>
                                Transportation : <br />
                                <asp:TextBox ID="txtTransport" runat="server" CssClass="inputTextBox"></asp:TextBox>
                            </td>
                          
                        </tr>
                        <tr>
                            <td>
                                Requested Date :<br />
                                <asp:TextBox ID="txtReqDate" runat="server" CssClass="inputTextBox"></asp:TextBox>
                            </td>
                            <td>
                                From Date :<br />
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="inputTextBox"></asp:TextBox>
                            </td>
                            <td>
                                To Date :<br />
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="inputTextBox"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td colspan="3">
                             Purpose of Visit :<br />
                                <asp:TextBox ID="txtPurposeOfVisit" runat="server" CssClass="inputTextBox" 
                                TextMode="MultiLine" Height="30px" width="640px"></asp:TextBox>
                            
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </td>
    </tr> 

    <tr>
        <td nowrap="nowrap">                
        <asp:Panel ID="ProductListPanel" runat="server" GroupingText="Allowance Info" CssClass="legend">
            <table cellpadding="5" cellspacing="5" border="0">
            <tr>
            <td colspan="3">
             <asp:Label ID="lblAllowanceMsg" runat="server" CssClass="errormsg"></asp:Label>
            </td>
            </tr>
            <tr>
                <td align="left" class="style11">
                 Approved From:<br /> <asp:TextBox ID="txtApproveFrom" runat="server" 
                        CssClass="inputTextBox"></asp:TextBox>
                        <cc1:CalendarExtender ID="ToDateCalendar" runat="server" Enabled="true" EnabledOnClient="true"
                             TargetControlID="txtApproveFrom"></cc1:CalendarExtender>
                </td>
                  <td align="left" class="style11">
                 Approved To:<br /> 
                      <asp:TextBox ID="txtApprovTo" runat="server" 
                        CssClass="inputTextBox"  Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="true" EnabledOnClient="true"
                             TargetControlID="txtApprovTo"></cc1:CalendarExtender>
                </td>
                  <td align="left" class="style11">
                 Approved Advance:<br /> <asp:TextBox ID="txtApproveAdv" runat="server" 
                        CssClass="inputTextBox"  Width="100px"></asp:TextBox>
                </td>
            
            </tr>
            <tr>
                <td align="left">
                    Allowance Type :
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtPerDay" ErrorMessage="Required" ValidationGroup="add"></asp:RequiredFieldValidator>
                    <br />
                    <asp:DropDownList ID="ddlAllowance" runat="server" CssClass="CMBDesign" 
                        ValidationGroup="requisition" Width="150px" 
                        onselectedindexchanged="ddlAllowance_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td>
                    Days :<br />
                    <asp:TextBox ID="txtDays" runat="server" CssClass="inputTextBox" Width="100px"></asp:TextBox>
                </td>
                <td align="left">
                    Per Day :
                    <asp:RequiredFieldValidator ID="RfvQuantity" runat="server" 
                        ControlToValidate="txtPerDay" ErrorMessage="Required" ValidationGroup="add"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="txtPerDay" runat="server"
                        CssClass="inputTextBox" Width="100px" ReadOnly="true" ></asp:TextBox>
                  
                </td>
                  <td>
                    Currency :
                    <br />
                    <asp:TextBox ID="txtCurrency" runat="server" CssClass="inputTextBox" 
                        ReadOnly="true" Width="70px"></asp:TextBox>
                </td>
                <td>
                    Total :
                    <br />
                    <asp:TextBox ID="txtTotal" runat="server" CssClass="inputTextBox" 
                        ReadOnly="true" Width="100px"></asp:TextBox>
                </td>
                <td valign="bottom">
                    <asp:Button ID="BtnAdd" runat="server" CssClass="button" onclick="BtnAdd_Click" 
                        Text="Add" ValidationGroup="add" Width="50" />
                </td>
            
            </tr>
                <tr>
                    <td colspan="5" width="100%">
                        <div id="rpt" runat="server">
                            <asp:Table ID="Table1" runat="server" Width="100%">
                            </asp:Table>
                        </div>
                    </td>
                    <td>&nbsp;</td>
               </tr>
               <tr>
                 <td>
                                Reqested Advance :<br />
                                <asp:TextBox ID="txtReqAdv" runat="server" CssClass="inputTextBox"></asp:TextBox>
                            </td>
               </tr>
               <tr>
               <td colspan="4">
               
                <div id="showcc" runat="server" visible="false">
            <fieldset style="list-style:circle; list-style-type:circle;"><legend>CC:</legend>
            <table>
                <tr>
                    <td class="style10">
                        <iframe id = "notificationList"  src = "../../cc/cc.aspx" height = "100px" width="440px"
                            frameborder="0" scrolling="auto">
                        </iframe>
                    </td>
                </tr>
            </table>
            
            </fieldset>
            </div>  
               
               </td>
               
               </tr>
               <tr>
                    <td colspan="3">
                        Remarks :<br />
                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="inputTextBoxLP" Width="440px"></asp:TextBox>
                    </td>
               </tr>
               <tr>
               <div id ="forwardPanal" runat="server" visible ="false">
                <td colspan="3">
                        <asp:Label ID="lblrequest" runat="server" Text="Forward To Approve :" CssClass="label"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtFinalApprove" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txtFinalApprove" runat="server" CssClass="inputTextBoxLP1" Width="440px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                        runat="server" Enabled="True" TargetControlID="txtFinalApprove" 
                        WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>

                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                        DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                        MinimumPrefixLength="1" 
                        ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                        TargetControlID="txtFinalApprove">
                        </cc1:AutoCompleteExtender>
                        <br />
                    </td> 
                   </div> 
               </tr>
               <tr>
                    <td colspan="3" align="right">
                        <asp:Panel ID="PnDelete" runat="server">
                        <div align="left">
                        <asp:Button ID="BtnRecommend" runat="server" CssClass="button" Text="Recommend" 
                                onclick="BtnRecommend_Click" />
                        

                        

                        </div>
                        </asp:Panel>
                    </td>
                    <td>
                    <td>
                    <asp:Button ID="BtnDelete" runat="server" Text="" onclick="BtnDelete_Click" style="display:none;" />
                    </td>
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
