<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="RequisitionPlaceManual.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.Requisition.RequisitionPlaceManual" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function AutocompleteOnSelected(sender, e) {

            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnProductId.ClientID%>").Value = EmpIdArray[1];

        }
        function AutocompleteOnSelected(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=HdnEmpid.ClientID%>").Value = EmpIdArray[1];
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UPDPANEL" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel"> 
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Place Requisition-Manual
                    </header>
                    <div class="panel-body">
                            <span class="txtlbl">Please enter valid data! <span class="errormsg">(* are required fields!)</span>
                                
                                <asp:HiddenField ID="hdnProductId" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                       
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Branch Name:<span class="errormsg">*</span></label>
                                    <asp:DropDownList ID="branch" runat="server" CssClass="form-control" Width="100%"
                                        AutoPostBack="True" OnSelectedIndexChanged="branch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="branch" ErrorMessage="Required!"
                                        SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>  
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>Department Name:<span class="errormsg">*</span><br /></label>
                                    <asp:DropDownList ID="DEPT" CssClass="form-control" runat="server" Width="100%"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="DEPT" ErrorMessage="Required!"
                                        SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>  
                            </div>
                            
                       </div>
                        <br />
                        <div class="row">
                            <div class="col-md-5 autocomplete-form">
                                <div class="form-group">
                                    <label>Product Name:</label>
                                    <asp:TextBox ID="product" CssClass="form-control" runat="server" ValidationGroup="requistion" AutoComplete="off"
                                        OnTextChanged="product_TextChanged" AutoPostBack="True" ></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="product_TextBoxWatermarkExtender"
                                        runat="server" Enabled="True" TargetControlID="product"
                                        WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                        DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductList"
                                        TargetControlID="product" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="form-control" OnClientItemSelected="AutocompleteOnSelected">
                                    </cc1:AutoCompleteExtender>
                                     <asp:RequiredFieldValidator ID="Rfvproduct" runat="server"
                                        ControlToValidate="product" ErrorMessage="Required"
                                        SetFocusOnError="True" ValidationGroup="add" Width="100%"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Unit of Measurement:</label><br />
                                    <asp:TextBox ID="txtUnit" CssClass="form-control" runat="server"
                                        ValidationGroup="requistion" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Qty :</label><asp:RequiredFieldValidator ID="RfvQuantity" runat="server"
                                        ControlToValidate="quantity" ErrorMessage="Required"
                                        ValidationGroup="add" ></asp:RequiredFieldValidator ><br />
                                    <asp:TextBox ID="quantity" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="quantity_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="quantity">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                 <label>&nbsp;</label><br />
                                <asp:Button ID="BtnAdd" CssClass="btn btn-primary" style="float:right" runat="server" Text="Add"
                                    ValidationGroup="add" OnClick="BtnAdd_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div id="rpt" runat="server">
                                    <asp:Table ID="Table1" runat="server">
                                    </asp:Table>
                                </div>
                            </div>
                            <div class="col-md-12">
                                        <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete" CssClass="btn btn-primary" style="float:right" />
                                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                            ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                                        </cc1:ConfirmButtonExtender>
                            </div>
                        </div>
                    <label>Other Information:</label>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Requisition Message:<span class="required">*</span></label>
                                <asp:TextBox ID="TxtMessage" runat="server" CssClass="form-control"
                                    TextMode="MultiLine" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="TxtMessage" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>
                                    Request With Branch:
                                 <span class="errormsg">
                                </label>
                                <asp:DropDownList ID="DdlBranchRqe" runat="server" CssClass="form-control">
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="rfvDdlForward" runat="server"
                                    ControlToValidate="DdlBranchRqe" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group autocomplete-form">
                                <label>Recommend With:<span class="required">*</span></label>
                                <asp:TextBox ID="TxtEmpname" runat="server" CssClass="form-control"
                                    AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmpid" runat="server"
                                    ControlToValidate="TxtEmpname" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>
                                <cc1:TextBoxWatermarkExtender ID="TxtEmpname_TextBoxWatermarkExtender"
                                    runat="server" Enabled="True" TargetControlID="TxtEmpname"
                                    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                    CompletionInterval="10" CompletionListCssClass="form-control"
                                    DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                    MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelected"
                                    ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx"
                                    TargetControlID="TxtEmpname">
                                </cc1:AutoCompleteExtender>
                                <br />
                                <asp:HiddenField ID="HdnEmpid" runat="server" />
                            </div>
                        </div>
                     </div>
                            <div class="form-group">
                                <label>Priority:<span class="required">*</span></label>
                                <asp:DropDownList ID="Ddlpriority" runat="server" CssClass="form-control" Width="20%">
                                    <asp:ListItem Value="N">Normal</asp:ListItem>
                                    <asp:ListItem Value="L">Low</asp:ListItem>
                                    <asp:ListItem Value="H">High</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary"
                                    Text="Save" OnClick="btnSave_Click" ValidationGroup="req" />
                                <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="btnSave">
                                </cc1:ConfirmButtonExtender>
                               <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary"
                                    Text="Back" ValidationGroup="chart" />
                            </div>
                            <asp:Label ID="LblMsg" runat="server" CssClass="errormsg"></asp:Label>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    </div>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

