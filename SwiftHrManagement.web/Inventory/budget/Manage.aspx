<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.Budget.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function AutocompleteOnSelected(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnProductId.ClientID%>").Value = EmpIdArray[1];           
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnProductId" runat="server" />
    
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading"> 
                    <i class="fa fa-caret-right"></i>
                    Budget Entry Details</header>
                <div class="panel-body">
                   
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <br />
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                   <div class="row">
                        <div class=" col-md-6 form-group autocomplete-form">
                        <label>Product Name:</label>
                        <span class="errormsg">*</span>
                        <asp:TextBox ID="product" runat="server" CssClass="form-control" ValidationGroup="budget"
                                AutoComplete="on" AutoPostBack="True" OnTextChanged="product_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV2" runat="server" ControlToValidate="product" ErrorMessage="Required"
                            SetFocusOnError="True" ValidationGroup="budget"></asp:RequiredFieldValidator>
                        <cc1:TextBoxWatermarkExtender ID="product_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="product" WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                            Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductList1"
                            TargetControlID="product" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true"
                            ContextKey="" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                        </cc1:AutoCompleteExtender>
                    </div>
                   </div>
                    <div class="row">
                        <div class="col-md-3 form-group">
                        <label>Fiscal Year: </label>
                       <span class="errormsg">*</span>
                        <asp:DropDownList ID="DdlFY" runat="server" CssClass="form-control" AutoPostBack="True">
                        </asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RV3" runat="server" ControlToValidate="DdlFY" ErrorMessage="Required"
                        ValidationGroup="budget" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                        <div class="col-md-3 form-group">
                        <label>Branch: </label>
                       <span class="errormsg">*</span>
                        <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="form-control" AutoPostBack="True">
                        </asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RV4" runat="server" ControlToValidate="DdlBranchType" ErrorMessage="Required"
                        ValidationGroup="budget" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                        <div class="col-md-3 form-group">
                        <label>Budget Quantity: </label>
                        <span class="errormsg">*</span>
                        <asp:TextBox ID="TxtTelNo" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="TxtTelNo_FilteredTextBoxExtender" runat="server"
                        Enabled="True" FilterType="Numbers,Custom" TargetControlID="TxtTelNo" ValidChars=".">
                        </cc1:FilteredTextBoxExtender>
                    </div>
                        <div class="col-md-3 form-group">
                        <label>Unit Price: </label>
                        <asp:TextBox ID="TxtFaxNo" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                        Enabled="True" FilterType="Numbers,Custom" TargetControlID="TxtFaxNo" ValidChars=".">
                        </cc1:FilteredTextBoxExtender>
                    </div>
                    
                    </div>
                   
                    <div class="row">
                        <div class="col-md-12 form-group">
                        <label> Business Details: </label>
                        <asp:TextBox ID="TxtBusinessDetails" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    </div>
                    
                    
                    
                     <div class="form-group">
                        <label> Is Active: </label>
                        <asp:CheckBox ID="ChkIsActive" runat="server" CssClass="" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" OnClick="Btn_Save_Click"
                        Text="Save" ValidationGroup="budget" />
                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?"
                        Enabled="True" TargetControlID="Btn_Save">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" OnClick="BtnDelete_Click"
                        Text="Delete" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Delete?"
                        Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="BtnBack_Click" />
                    </div>
                </div>
            </section>
        </div>
    </div>

</asp:Content>
