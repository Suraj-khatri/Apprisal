<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageReqSettlement.aspx.cs" MasterPageFile="~/SwiftHRManager.Master"Inherits="SwiftHrManagement.web.EmployeeMovement.TravelOrder.Settlement.ManageReqSettlement" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../../Jsfunc.js" type="text/javascript"></script>

  
    <script type="text/javascript">

        function DeleteNotification(TOID) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =HdnTravelOrderId.ClientID %>").value = TOID;
                document.getElementById("<% =BtnDelete.ClientID %>").click();
            }
        }

    function DateDifference() {

        var fromDate = document.getElementById("<%=txtSettlementFromDate.ClientID%>").value;
        var toDate = document.getElementById("<%=txtSettlementToDate.ClientID%>").value;
        var dat1 = new Date(fromDate);
        var dat2 = new Date(toDate);
       if (fromDate == '' || toDate == '') {
            alert('Please Enter From Date and To Date');
        }
        else {
            var DiffDays = DateDiffInDays(dat1, dat2);
            document.getElementById("<%=txtDays.ClientID%>").value = parseInt(DiffDays);
            document.getElementById("<%=hdnDateDiff.ClientID%>").value = parseInt(DiffDays);
        }

    }
    function TotalAllowance() {

        var days = document.getElementById("<%=txtDays.ClientID%>").value;
        var rate = document.getElementById("<%=txtRate.ClientID%>").value;
        var total = days.replace(/,/g, '') * rate.replace(/,/g, '');
        document.getElementById("<%=txtTotal.ClientID%>").value = parseInt(total);
        document.getElementById("<%=HdnTotal.ClientID%>").value = parseInt(total);



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
<img src="../../../Images/big_bullit.gif" />&nbsp;Request Travel Order Settlement
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
   Request Travel Order Settlement Entry</td>
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
            <asp:Label ID="LblMsg" runat="server"></asp:Label>
            <asp:HiddenField ID = "HdnTravelOrderId" runat="server" /> 
            <asp:HiddenField ID="hdnEmployeeId" runat="server" />
            <asp:HiddenField ID="hdnDateDiff" runat="server" />
            <asp:HiddenField ID="HdnTotal" runat="server" />
            <asp:HiddenField ID="hdnRegion" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="downPanel" runat="server" GroupingText="Travel Order information" CssClass="">
            <table cellpadding="2px" cellspacing="2px">
                 
                <tr>
                 <td width="200px">
                        Place of Visit :
                        <span style="font-weight:bold"><asp:Label ID="LblPlaceOfVisit" runat="server" Text=""></asp:Label></span>
                    </td> 
                    <td width="200px">
                        Region :
                        <span style="font-weight:bold"><asp:Label ID="LblRegion" runat="server" Text=""></asp:Label></span>
                        
                    </td>
                   
                </tr>
                <tr>
                    <td colspan="3">
                        Purpose of Visit :
                        <span style="font-weight:bold"> <asp:Label ID="lblPurposeOfVisit" runat="server" CssClass="label" Height="20px" Width="400px">
                            </asp:Label></span>
                    </td>       
                </tr>
                <tr>
                 <td width="200px">
                       Trasportation :
                      <span style="font-size:12px; font-weight:bold"> <asp:Label ID="lblModeOfTrnas" runat="server" Text=""> </asp:Label></span>
                    </td>
                    <td width="200px">
                        Request Date :    <span style="font-size:12px; font-weight:bold"><asp:Label ID="lblReqDate" runat="server" Text=""> </asp:Label></span>
                    </td>
                        <td width="200px">
                        From Date :    <span style="font-size:12px; font-weight:bold"> <asp:Label ID="lblFromDate" runat="server" Text=""> </asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td width="200px">
                       To Date :    <span style="font-size:12px; font-weight:bold"> <asp:Label ID="lblToDate" runat="server" Text=""> </asp:Label></span>
                    </td>
                     <td width="200px">
                       Reqested Advance :    <span style="font-size:12px; font-weight:bold"> <asp:Label ID="lblReqAdv" runat="server" Text=""> </asp:Label></span>
                    </td>
                     <td width="200px">
                       Total Days :     <span style="font-size:12px; font-weight:bold"><asp:Label ID="lblTotal" runat="server" Text=""> </asp:Label></span>
                    </td>
                </tr>
            </table>
            </asp:Panel>
        </td>
    </tr> 
      <tr>
        <td>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Travel Order Allowance" CssClass="">
            <table cellpadding="2px" cellspacing="2px" width="90%">
                <tr>
                    <td colspan="4">
                       <div id="travelAllow" runat="server" width="500px">
                            <asp:Table ID="Table2" runat="server">
                            </asp:Table>
                        </div>
                    </td>
                </tr>    
            </table>
            </asp:Panel>
        </td>
    </tr> 

    <tr>
        <td nowrap="nowrap">                
        <asp:Panel ID="ProductListPanel" runat="server" GroupingText="Settlement Allowance Info" CssClass="legend">
            <table cellpadding="5" cellspacing="5">
            <tr>
            <td>
                <asp:Label ID="lblAllMsg" runat="server" Text=""></asp:Label>
            </td>
            </tr>
            <tr>
             <td align="left">
               Settlement From Date
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtSettlementFromDate" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator>
                <br />
               <asp:TextBox ID="txtSettlementFromDate" runat="server" CssClass="inputTextBox"></asp:TextBox>
               <cc1:CalendarExtender ID="ToDateCalendar" runat="server" Enabled="true" EnabledOnClient="true"
                             TargetControlID="txtSettlementFromDate"></cc1:CalendarExtender>
             
             </td>
                <td align="left">
               Settlement To Date 
               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtSettlementToDate" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator>
               <br />
               <asp:TextBox ID="txtSettlementToDate" runat="server" CssClass="inputTextBox" Width="100px" ></asp:TextBox>
               <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="true" EnabledOnClient="true"
                             TargetControlID="txtSettlementToDate"></cc1:CalendarExtender>
             
             </td>
            
            </tr>
                <tr>
                    <td align="left">
                        Allowance Type :
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="ddlAllowance" ErrorMessage="Required"  
                            ValidationGroup="add"></asp:RequiredFieldValidator>
                            <br />
                        <asp:DropDownList ID="ddlAllowance" runat="server" CssClass="CMBDesign"
                         ValidationGroup="requisition" Width="150px" AutoPostBack ="true"
                            onselectedindexchanged="ddlAllowance_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td align="left">
                         Days :
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtDays" ErrorMessage="Required"  
                            ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                        <asp:TextBox ID="txtDays" runat="server" CssClass="inputTextBoxLP1" Width="100px"> </asp:TextBox>                                
                    </td>
                    <td align="left">
                        Rate :<br />                        
                        <asp:TextBox ID="txtRate" runat="server" CssClass="inputTextBoxLP1" 
                            Width="90px"> </asp:TextBox>                                
                    </td>
                    <td align="left">
                        Currency :<br />
                        <asp:TextBox ID="txtCurrency" runat="server" CssClass="inputTextBoxLP1" Width="70px"></asp:TextBox>
                    </td>
                    <td>
                        Total :<br />
                        <asp:TextBox ID="txtTotal" runat="server" CssClass="inputTextBoxLP1" ReadOnly="true" Width="100px"></asp:TextBox>
                    </td>
                    <td valign="bottom">
                        <asp:Button ID="BtnAdd" runat="server" CssClass="button" Text="Add" 
                        ValidationGroup="add"  Width="50" onclick="BtnAdd_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" width="100%">
                        <div id="rpt" runat="server">
                            <asp:Table ID="Table1" runat="server" Width="100%">
                            </asp:Table>
                        </div>
                    </td>
                    <td class="style11"></td>
               </tr>
               <tr>
                    <td colspan="2">
                        Recommended By :
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="ddlRecommend" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator>
                        <br />
                        <asp:DropDownList ID="ddlRecommend" runat="server" CssClass="CMBDesign" Width="150px" Height="25px"></asp:DropDownList>
                    </td>
               </tr>
               
                  <tr>
                    <td colspan="4">
                        Remarks:
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtRemarks" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator><br />
                             <asp:TextBox ID="txtRemarks" runat="server" CssClass="inputTextBoxLP1"
                         TextMode="MultiLine" Height="30px" Width= "500px" ></asp:TextBox>
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
                    <asp:Button ID="BtnDelete" runat="server" Text="" onclick="BtnDelete_Click1"  style="display:none;" />
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

