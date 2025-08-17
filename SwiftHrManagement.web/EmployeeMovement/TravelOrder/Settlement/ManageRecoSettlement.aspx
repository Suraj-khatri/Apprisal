<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageRecoSettlement.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TravelOrder.Settlement.ManageRecoSettlement" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Css/style.css" rel="stylesheet" type="text/css" />
    
    <script language ="javascript">
        var GB_ROOT_DIR = "/greybox/";
        </script>


    
    
     <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../../Jsfunc.js" type="text/javascript"></script>
    
  <script type="text/javascript">
      function AutocompleteOnSelected(sender, e) {
          var customerValueArray = (e._value).split("|");
          document.getElementById("<%=hdnEmployeeId.ClientID %>").value = customerValueArray[1];
        
      }
      function GetId() {
          var notificationList = document.getElementById("notificationList");
          var ids = notificationList.contentWindow.GetIdListForNotification();
          var HiddenFieldempEmail = document.getElementById("<%=HiddenFieldEmpEmail.ClientID %>");
          alert(HiddenFieldempEmail)
          HiddenFieldempEmail.value = ids;
          return false;
      }

      function DeleteNotification(TOID) {
          if (confirm("Are you sure to delete this message?")) {
              document.getElementById("<% =HdnTravelOrderId.ClientID %>").value = TOID;
              document.getElementById("<% =BtnDelete.ClientID %>").click();
          }
      }
        function EditTravelAllowance(ID) {

            GB_showCenter('Edit Travel Order', '/EmployeeMovement/TravelOrder/Settlement/EditOldAllowance.aspx?TravelOID=' + ID ,
             '220', '650', '')
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
            <asp:Label ID="LblMsg" runat="server" CssClass="errormsg"></asp:Label>
            <asp:HiddenField ID = "HdnTravelOrderId" runat="server" /> 
            <asp:HiddenField ID="hdnEmployeeId" runat="server" />
            <asp:HiddenField ID="hdnDateDiff" runat="server" />
            <asp:HiddenField ID="HiddenFieldEmpEmail" runat="server" />
            <asp:HiddenField ID="HdnTotal" runat="server" />
             <asp:HiddenField ID="hdnregion" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="downPanel" runat="server" GroupingText="Travel Order information" CssClass="">
            <table cellpadding="2px" cellspacing="2px">
                <tr>
                    <td colspan="3">
                        Requested By :<b><asp:Label ID="lblReqBy" runat="server" Width="300px"></asp:Label></b>
                    </td>
                </tr> 
                <tr>
                    <td colspan="3">
                         Purpose of Visit :
                        <span style="font-size:12px; font-weight:bold">
                        <asp:Label ID="lblPurpose" runat="server" CssClass="label" Height="20px" Width="300px"></asp:Label></span>
                         
                    </td>      
                </tr>   
                <tr>
                    <td width="200px">
                        Region :<b><asp:Label ID="LblRegion" runat="server"></asp:Label></b>
                    </td> 
                    <td width="200px">
                        Place of Visit :<b><asp:Label ID="LblPlaceOfVisit" runat="server" Text=""></asp:Label></b>
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
        <td nowrap="nowrap">                
        <asp:Panel ID="ProductListPanel" runat="server" GroupingText="Settlement Allowance Info" CssClass="legend">
            <table cellpadding="5" cellspacing="5">
            <tr>
                <td>
                    <asp:Label ID="lblDMsg" runat="server" ForeColor="Red" CssClass="label"></asp:Label>
                </td>
            </tr>
            <tr>
             <td align="left">
               Settlement From Date <br />
               <asp:TextBox ID="txtSettlementFromDate" runat="server" CssClass="inputTextBox"></asp:TextBox>
               <cc1:CalendarExtender ID="ToDateCalendar" runat="server" Enabled="true" EnabledOnClient="true"
                             TargetControlID="txtSettlementFromDate"></cc1:CalendarExtender>
             
             </td>
                <td align="left">
               Settlement To Date <br />
               <asp:TextBox ID="txtSettlementToDate" runat="server" CssClass="inputTextBox" Width="100px"></asp:TextBox>
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
                         ValidationGroup="requisition" Width="150px" AutoPostBack="true" 
                            onselectedindexchanged="ddlAllowance_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td align="left">
                         Days :
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtDays" ErrorMessage="Required"  
                            ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                        <asp:TextBox ID="txtDays" runat="server" CssClass="inputTextBoxLP1" Width="100px"> </asp:TextBox>                                
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtDays">
                        </cc1:FilteredTextBoxExtender>                            
                    </td>
                    <td align="left">
                        Rate :
                        <asp:RequiredFieldValidator ID="RfvQuantity" runat="server" 
                            ControlToValidate="txtRate" ErrorMessage="Required"  
                            ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                        <asp:TextBox ID="txtRate" runat="server" CssClass="inputTextBoxLP1" 
                            Width="100px"> </asp:TextBox>                                
                    </td>
                    <td>
                        Currency : <br />
                        <asp:TextBox ID="txtCurrency" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox>
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
                            <asp:Table ID="tblAllowance" runat="server" Width="100%">
                            </asp:Table>
                        </div>
                    </td>
                    <td class="style11"></td>
               </tr>
            <tr>
            <div id="divApprove" runat="server" visible="false">
            
             
                  <td colspan="2">
                  <asp:Label ID="lblforward" runat="server" Text="Forward To Approve :" CssClass="label"></asp:Label>
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="ddlRecommend" ErrorMessage="Required"  
                            ValidationGroup="save"></asp:RequiredFieldValidator>
                        <br />
                        <asp:DropDownList ID="ddlRecommend" runat="server" CssClass="CMBDesign" Width="150px" Height="25px"></asp:DropDownList>
                    </td>
              </div>
               </tr>
               <tr>
                   <td colspan="4">
                        <div id="showcc" runat="server" visible="false">
                            <fieldset style="list-style:circle; list-style-type:circle;"><legend>CC:</legend>
                                <table>
                                    <tr>
                                        <td class="style10">
                                         <iframe id = "notificationList"  src = "../../../cc/cc.aspx" height = "90px" width="450px"
                                            frameborder="0" scrolling="auto">
                                            </iframe>
                                        </td>
                                    </tr>
                             
                                </table>
                            </fieldset>
                                   <tr>
                                       <td colspan="3">
                        <asp:Label ID="lblrequest" runat="server" Text="Forward To Approve :" CssClass="label"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
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
                        MinimumPrefixLength="1"  OnClientItemSelected="AutocompleteOnSelected"
                        ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                        TargetControlID="txtFinalApprove">
                        </cc1:AutoCompleteExtender>
                        <br />
                    </td> 
                                    </tr>
                        </div>  
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
                    <asp:Button ID="BtnDelete" runat="server" Text=""  style="display:none;" 
                            onclick="BtnDelete_Click" />
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
