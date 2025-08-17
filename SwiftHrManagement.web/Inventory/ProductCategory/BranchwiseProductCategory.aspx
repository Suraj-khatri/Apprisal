<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="BranchwiseProductCategory.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.ProductCategory.BranchwiseProductCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">

        function AutocompleteOnSelected_Depreciation(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=TxtPurchaseAcNo.ClientID%>").Value = EmpIdArray[1];
        }

        function AutocompleteOnSelected_Accumulated(sender, e) {

            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=TxtInventoryAcNo.ClientID%>").Value = EmpIdArray[1];
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="col-md-12">
        <div class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                 Product Assignment With Branch</header>
            <div class="panel-body">
                <div class="form-group">
                    <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Group Name:</label>
                        <asp:DropDownList ID="DdlGroup" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Branch Name: </label>
                        <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Inventory/Stock A/C:</label>
                        <asp:TextBox ID="TxtInventoryAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4 form-group autocomplete-form">
                        <label>&nbsp;</label><br />
                        <asp:TextBox ID="TxtInventoryAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
                            DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                            TargetControlID="TxtInventoryAc" MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Accumulated">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2"
                            runat="server" Enabled="True" TargetControlID="TxtInventoryAc"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Expenses A/C: </label>
                        <asp:TextBox ID="TxtPurchaseAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4 form-group autocomplete-form">
                        <label>&nbsp;</label><br />
                        <asp:TextBox ID="TxtPurchaseAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                            DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                            TargetControlID="TxtPurchaseAc" MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Depreciation">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                            runat="server" Enabled="True" TargetControlID="TxtPurchaseAc"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 form-group">
                        <label>Is Active:</label><span class="errormsg">*</span>
                        <asp:DropDownList ID="DdlIsActive" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required!" ControlToValidate="DdlIsActive" Display="Dynamic"
                            SetFocusOnError="True" ValidationGroup="Branch"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="Branch" OnClick="BtnAdd_Click" />

                <div class="form-group">
                    <div id="rpt" runat="server" nowrap="nowrap"></div>
                </div>
                <div class="form-group">
                    <asp:Panel ID="PnDelete" runat="server">
                        <div align="right"></div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <script type="text/javascript">


            function AutocompleteOnSelected_Depreciation(sender, e) {
                var EmpIdArray = (e._value).split("|");
                document.getElementById("<%=TxtPurchaseAcNo.ClientID%>").Value = EmpIdArray[1];
            }

            function AutocompleteOnSelected_Accumulated(sender, e) {

                var EmpIdArray = (e._value).split("|");
                document.getElementById("<%=TxtInventoryAcNo.ClientID%>").Value = EmpIdArray[1];

            }
        </script>
    </div>
</asp:Content>
