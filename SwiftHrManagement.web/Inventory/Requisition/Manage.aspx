<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Requisition.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function AutocompleteOnSelected(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnProductId.ClientID%>").Value = EmpIdArray[1];
        }
        function AutocompleteOnSelectedEmp(sender, e) {
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
                        Place Requition Details
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                        <div class="col-md-12">
                            <span class="txtlbl">Please enter valid data! <span class="errormsg">(* are required fields!)</span>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="LblMsg" runat="server" CssClass="errormsg"></asp:Label>
                            <asp:HiddenField ID = "hdnitem" runat="server" />                         
                            <asp:HiddenField ID="hdnProductId" runat="server" />
                            <asp:HiddenField ID="HdnEmpid" runat="server" />
                        </div>
                            <div class="row">
                        <div class="col-md-6 autocomplete-form">
                            <label>Product Name:</label>
                            <asp:TextBox ID="product" runat="server" CssClass="form-control" ValidationGroup="requistion" AutoComplete="off" 
                                ontextchanged="product_TextChanged" AutoPostBack="True" ></asp:TextBox>    
                            <asp:RequiredFieldValidator ID="Rfvproduct" runat="server" ControlToValidate="product" ErrorMessage="Required" 
                                SetFocusOnError="True" ValidationGroup="add"></asp:RequiredFieldValidator>
                            <cc1:TextBoxWatermarkExtender ID="product_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="product" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender> 
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductList"
                                TargetControlID="product" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected" >
                             </cc1:AutoCompleteExtender>                   
                        </div>
                        <div class="col-md-3">
                            <label>Unit of Measurement:</label>
                            <asp:TextBox ID="txtUnit" runat="server" CssClass="form-control" ValidationGroup="requistion"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label>Quantity:</label>
                            <asp:RequiredFieldValidator ID="RfvQuantity" runat="server" 
                                ControlToValidate="quantity" ErrorMessage="Required"  
                                ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                            <asp:TextBox ID="quantity" runat="server" CssClass="form-control"></asp:TextBox>                                
                            <cc1:FilteredTextBoxExtender ID="quantity_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="quantity">
                            </cc1:FilteredTextBoxExtender>      
                        </div>
                        <div class="col-md-1">
                            <label>&nbsp;</label><br />
                            <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="add" onclick="BtnAdd_Click" align="right"/>
                        </div>
                                </div>
                            <div class="row">
                        <div class="col-md-12">
                            <div id="rpt" runat="server"></div>
                        </div>
                                </div>
                        <div  align="right">
                            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                                        onclick="BtnDelete_Click" Text="Delete" />  
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                            </cc1:ConfirmButtonExtender>
                        </div>
                        <div class="col-md-12">
                            <h4>Other Information</h4>
                        </div>
                            <div class="row">
                        <div class="col-md-12">
                            <label>Message:<span class="required">*</span></label>
                            <asp:TextBox ID="TxtMessage" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TxtMessage" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="req"></asp:RequiredFieldValidator>   
                        </div>
                                </div>
                            <div class="row">
                        <div class="col-md-3">
                            <label>Request With Branch:<span class="required">*</span></label>
                            <asp:DropDownList ID="DdlBranchRqe" runat="server" CssClass="form-control" onselectedindexchanged="DdlBranchRqe_SelectedIndexChanged" 
                                AutoPostBack="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDdlForward" runat="server" ControlToValidate="DdlBranchRqe" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <label>Recommend with:<span class="required">*</span></label>
                            <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="form-control"></asp:DropDownList> 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="DdlEmpName" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <label>Priority:</label>
                            <asp:DropDownList ID="Ddlpriority" runat="server" CssClass="form-control">
                                <asp:ListItem Value="N">Normal</asp:ListItem>
                                <asp:ListItem Value="L">Low</asp:ListItem>
                                <asp:ListItem Value="H">High</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3" id="unschPnl" runat="server" visible="false">
                            <label>Unschedule Req. Reason:</label>
                            <asp:TextBox ID="txtUnschReqMsg" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox></td>
                        </div>
                                </div>
                       <br />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                                onclick="btnSave_Click" ValidationGroup="req"/>
                            <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="btnSave">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" 
                                Text="Back" ValidationGroup="chart"/>
                       
                    </div>
                        </div>
                </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
