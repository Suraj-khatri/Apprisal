<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.AssetManagement.AssetMaintainenceStatus.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">
        function AutocompleteOnSelected1(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=HdnAssetnumber.ClientID %>").value = customerValueArray[1];
        }
        function VendorOnSelected(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnVendorId.ClientID %>").value = EmpIdArray[1];
       }
        function checkDate(sender, args) {
            if (sender._selectedDate < new Date()) {
                alert("You cannot select a day earlier than today!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }

        }

<%--        $(document).ready(function() {
            $("#<%=txtVendor.ClientID%>").keypress(function(e) {
                if (e.which == 32) {
                    e.preventDefault();
                }
            });
        });--%>
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="upnlwriteoff" runat="server">
        <ContentTemplate>
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
                <img src="/images/big_bullit.gif">&nbsp;Asset Maintenance Details
            </td>
        </tr>
        <tr>
            <td valign="top" bgcolor="#999999" height="1">
                <img src="/images/spacer.gif" width="100%" height="1"></td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" align="center">
                <br>

                <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
                    <tbody>
                        <tr>
                            <td width="1%" class="container_tl">
                                <div></div>
                            </td>
                            <td width="91%" class="container_tmid">
                                <div>Asset Maintenance Details</div>
                            </td>
                            <td width="8%" class="container_tr">
                                <div></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="container_l"></td>
                            <td class="container_content">

                                <!--################ END FORM STYLE-->
                <table border="0" cellspacing="2" cellpadding="2" class="container">
                    <tr>
                        <td>
                            <span class="txtlbl" nowrap="nowrap">Please Enter Valid Data!!! </span>
                            <span class="required">( * are required fields)</span><br />
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            
                            <asp:RegularExpressionValidator ID="RegExp1" runat="server"    
                            ErrorMessage="Special character are not allowed in vendor name" Display="Dynamic"
                            ControlToValidate="txtVendor"    
                            ValidationExpression="^[a-zA-Z0-9\s()\-]*$" />
                            <asp:HiddenField ID="HdnAssetnumber" runat="server" />
                            <asp:HiddenField ID="HdnStatus" runat="server" />
                            <asp:HiddenField ID="hdnVendorId" runat="server" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset style="list-style: circle; list-style-type: circle; width: 90%;">
                                <legend>Asset Maintenance Plan:</legend>
                                <table border="0" cellspacing="5" cellpadding="5" class="container">
                                    <%--<tr>
                                        <div runat="server" id="divAssetName" Visible="False">
                                        <td nowrap="nowrap">
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label runat="server" ID="lblAssetName" Style="text-align: right" CssClass="txtlbl"></asp:Label>
                                            </div>
                                        </td>
                                        </div>
                                    </tr>--%>
                                    <tr>
                                        <td nowrap="nowrap">
                                            <div align="right" class="txtlbl">Asset Number:</div>
                                        </td>
                                        <td align="left" nowrap="nowrap" colspan="3">
                                            <span class="errormsg">
                                                <asp:TextBox ID="TxtAssetNumber" runat="server" CssClass="inputTextBox"
                                                    Width="610px" AutoComplete="off"
                                                    AutoPostBack="True" OnTextChanged="TxtAssetNumber_OnTextChanged"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TxtAssetNumber_TextBoxWatermarkExtender"
                                                    runat="server" Enabled="True" TargetControlID="TxtAssetNumber"
                                                    WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                                </cc1:TextBoxWatermarkExtender>
                                                <cc1:AutoCompleteExtender
                                                    ID="AutoCompleteExtender3" runat="server"
                                                    CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                                    DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                                    MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelected1"
                                                    ServiceMethod="GetAssetNumber" ServicePath="~/Autocomplete.asmx"
                                                    TargetControlID="TxtAssetNumber">
                                                </cc1:AutoCompleteExtender>
                                                *</span>

                                            <asp:RequiredFieldValidator ID="RfvAssetnumber" runat="server"
                                                ControlToValidate="TxtAssetNumber" Display="Dynamic" ErrorMessage="Required!"
                                                SetFocusOnError="True" ValidationGroup="assethist"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap">
                                            <div align="right" class="txtlbl">Book Value :</div>
                                        </td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:TextBox ID="TxtBookValue" runat="server"
                                                CssClass="inputTextBox" Enabled="False" Width="150px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div align="right" class="txtlbl">Purchase Value :</div>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPurchaseValue" runat="server"
                                                CssClass="inputTextBox" Enabled="False" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap">
                                            <div align="right" class="txtlbl">Asset Narration :</div>
                                        </td>
                                        <td align="left" nowrap="nowrap" colspan="3">
                                            <asp:TextBox ID="txtAssetNarration" runat="server"
                                                CssClass="inputTextBox" Width="610px" Height="40px" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                               
                    </tr>
                                    
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="PanelFrom" runat="server" GroupingText="Requested From">
                                                <table cellpadding="3" cellspacing="3" class="container">
                                                    <tr>
                                        <td nowrap="nowrap">
                                            <div align="right" class="txtlbl"> Branch :</div>
                                        </td>
                                        <td colspan="" nowrap="nowrap">
                                            <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="CMBDesign" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                                        </tr>
                                                    <tr>
                                        <td nowrap="nowrap">
                                            <div align="right" class="txtlbl">Department :</div>
                                        </td>
                                        <td nowrap="nowrap">
                                            <asp:DropDownList ID="ddlDepartReq" runat="server" CssClass="CMBDesign" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                                        </tr>
                                   
                                    <tr>
                                        <td nowrap="nowrap">
                                            <div align="right" class="txtlbl">User :</div>
                                        </td>
                                        <td nowrap="nowrap" colspan="3">
                                            <asp:DropDownList ID="ddlReqUser" runat="server" CssClass="CMBDesign" Width="250px">
                                            </asp:DropDownList>
                                            
                                        </td>
                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td colspan="2">
                                            <asp:Panel ID="PanelBranch" runat="server" GroupingText="Forwarded To">
                                                <table cellpadding="3" cellspacing="3" class="container">
                                    <tr>
                                        <td nowrap="nowrap">
                                            <div align="right" class="txtlbl">Branch :</div>
                                        </td>
                                        <td colspan="" nowrap="nowrap">
                                            <asp:DropDownList ID="ddlForwardedTo" runat="server" CssClass="CMBDesign" Width="250px" OnSelectedIndexChanged="ddlForwardedTo_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        </tr>
                                                    <tr>
                                        <td nowrap="nowrap">
                                            <div align="right" class="txtlbl">Department :</div>
                                            </td>
                                        <td nowrap="nowrap">
                                            <asp:DropDownList ID="ddlDept" runat="server" CssClass="CMBDesign" Width="250px" OnSelectedIndexChanged="ddlDept_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                            
                                        </td>
                                                        </tr>
                                    <tr>
                                        <td nowrap="nowrap">
                                            <div align="right" class="txtlbl">User :</div>
                                        </td>
                                        <td nowrap="nowrap" colspan="3">
                                            <asp:DropDownList ID="ddlUser" runat="server" CssClass="CMBDesign" Width="250px" AutoPostBack="True">
                                            </asp:DropDownList>
                                           <%-- <span class="required">*</span>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="ddlUser" Display="Dynamic" ErrorMessage="Required!"
                                                SetFocusOnError="True" ValidationGroup="forward"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                               
                                            <div class="txtlbl" id="vendor" runat="server" >
                                                <tr>
                                                    <td>
                                                        <div align="right" class="txtlbl">Vendor Type:</div>
                                                    </td>
                                                    <td nowrap="nowrap" colspan="3">
                                                        <asp:DropDownList runat="server" ID="ddlVendorType" CssClass="CMBDesign" Width="250px" OnSelectedIndexChanged="ddlVendorType_OnSelectedIndexChanged" AutoPostBack="True">
                                                            <asp:ListItem Value="0"> Select </asp:ListItem>
                                                            <asp:ListItem Value="Existing" > Existing Vendor </asp:ListItem>
                                                            <asp:ListItem Value="New" >Outsider  </asp:ListItem>
                                                        </asp:DropDownList>
                                               
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <div runat="server" Visible="False" id="divVendorName">
                                                    <td nowrap="nowrap">
                                                    </td>
                                                    <td>
                                                        <div>
                                                    <asp:Label runat="server"  ID="lblvendorName" CssClass="txtlbl"></asp:Label>
                                                        </div>
                                                    </td>
                                                    </div>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <div align="right" class="txtlbl">Vendor Name:</div>
                                                    </td>
                                                    <td nowrap="nowrap" align="left">
                                                    <div id="autocomplete" runat="server" >
                                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                            DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetVendor"
                                                            TargetControlID="txtVendorAuto" MinimumPrefixLength="1" CompletionInterval="10"
                                                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="VendorOnSelected">
                                                        </cc1:AutoCompleteExtender>
                                                          <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                                                            runat="server" Enabled="True" TargetControlID="txtVendorAuto"
                                                            WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                                        </cc1:TextBoxWatermarkExtender>
                                                         <asp:TextBox ID="txtVendorAuto" runat="server" Width="300px"
                                                            CssClass="inputTextBox" AutoComplete="off"></asp:TextBox>
                                                 
                                                        </div>

                                                        <div id="textbox" runat="server">
                                                            <asp:TextBox ID="txtVendor" runat="server" Width="300px"
                                                            CssClass="inputTextBox" AutoComplete="off"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                           
                                                    <td nowrap="nowrap">
                                                        <div align="right" class="txtlbl"> Estimated Return Date :</div>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">

                                                        <asp:TextBox ID="TxtReturnDate" runat="server"
                                                            CssClass="inputTextBox" Width="150px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="TxtReturnDate_CalendarExtender" runat="server"
                                                            Enabled="True" TargetControlID="TxtReturnDate" OnClientDateSelectionChanged="checkDate">
                                                        </cc1:CalendarExtender>
                                                        <asp:RangeValidator ID ="rvDate" runat ="server" ControlToValidate="TxtReturnDate" ErrorMessage="Invalid Date"
                                                            Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2100" Display="Dynamic"></asp:RangeValidator>
                                                 
                                                    </td>
                                                    <td>
                                                        <div align="right" class="txtlbl">Repair Cost:</div>
                                                    </td>
                                                    <td align="left" nowrap="nowrap" class="style4">
                                                        <asp:TextBox ID="TxtRepairAmt" runat="server"
                                                            CssClass="inputTextBox" Width="150px"></asp:TextBox>
                                                         <cc1:FilteredTextBoxExtender runat="server" FilterType="Numbers,Custom" TargetControlID="TxtRepairAmt" ValidChars="."/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td nowrap="nowrap">
                                                        <div align="right" class="txtlbl"> Narration :</div>
                                                    </td>
                                                    <td align="left" nowrap="nowrap" colspan="3">
                                                        <asp:TextBox ID="TxtNarrationVendor" runat="server" CssClass="inputTextBox" Width="610px" Height="40px" TextMode="MultiLine" ></asp:TextBox>
                                                
                                                    </td>
                                                </tr>
                                                <div runat="server" Visible="False" id="ActualReceivedDate">
                                                <tr>
                                           
                                                    <td nowrap="nowrap">
                                                        <div align="right" class="txtlbl">Actual Received On :</div>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:TextBox ID="TxtActualRecvDate" runat="server"
                                                            CssClass="inputTextBox" Width="150px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="ReceivedDate_CalenderExtender" runat="server"
                                                            Enabled="True" TargetControlID="TxtActualRecvDate" OnClientDateSelectionChanged="checkDate">
                                                        </cc1:CalendarExtender>
                                                         <asp:RangeValidator ID ="RangeValidator1" runat ="server" ControlToValidate="TxtActualRecvDate" ErrorMessage="Invalid Date"
                                                            Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2100" Display="Dynamic"></asp:RangeValidator>
                                                    </td>
                                                   <%-- <div runat="server" id="chkBox" Visible="False">
                                                    <td nowrap="nowrap">
                                                        <div align="right" class="txtlbl">Approve:</div>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:CheckBox runat="server" ID="chkApprove" />
                                                    </td>
                                                    </div>--%>
                                                </tr>
                                                </div>
                                            </div>
                                
                                </table>
                                <tr>
                                    <td class="txtlbl">
                                        <asp:Button ID="Btn_Save" runat="server" CssClass="button"
                                            OnClick="Btn_Save_Click" Text="Save" ValidationGroup="assethist" />
                                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server"
                                            ConfirmText="Are You Confirm To Save?" Enabled="True"
                                            TargetControlID="Btn_Save">
                                        </cc1:ConfirmButtonExtender>

                                        &nbsp;<asp:Button ID="BtnBack" runat="server" CssClass="button"
                                            Text="&lt;&lt; Back" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>

                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
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
