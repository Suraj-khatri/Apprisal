<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="EditRequisition.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Requisition.EditRequisition" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                     Add Requisition
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                                <br />
                                <asp:Label ID="LblMsg" runat="server" CssClass="txtlbl"></asp:Label>
                                <asp:HiddenField ID = "hdnProductId" runat="server" />
                                <asp:HiddenField ID = "HdnEmpid" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 autocomplete-form">
                            <label>Product Name:</label>
                            <asp:TextBox ID="product" runat="server" CssClass="form-control" 
                               ValidationGroup="requistion" AutoComplete="off"></asp:TextBox>                                                              
                             <cc1:TextBoxWatermarkExtender ID="product_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="product" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>                            
                             <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductList"
                                TargetControlID="product" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected" >
                             </cc1:AutoCompleteExtender>     
                            <asp:RequiredFieldValidator ID="Rfvproduct" runat="server" 
                                ControlToValidate="product" ErrorMessage="Required" 
                                SetFocusOnError="True" ValidationGroup="add"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Qty:</label>
                                <asp:TextBox ID="quantity" runat="server" CssClass="form-control" 
                                    ></asp:TextBox>                                
                                <asp:RequiredFieldValidator ID="RfvQuantity" runat="server" 
                                    ControlToValidate="quantity" ErrorMessage="Required"  
                                    ValidationGroup="add"></asp:RequiredFieldValidator>                        
                                <cc1:FilteredTextBoxExtender ID="quantity_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="quantity">
                                </cc1:FilteredTextBoxExtender>  
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>&nbsp;</label><br />
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Add" 
                                    ValidationGroup="add" onclick="BtnAdd_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div id="rpt" runat="server">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Panel ID="PnDelete" runat="server">
                                    <div align="right">
                                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                                            onclick="BtnDelete_Click" Text="Delete" />
                                        
                                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                            ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                                        </cc1:ConfirmButtonExtender>
                                
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Message:<span class="required">*</span></label>
                                <asp:TextBox ID="TxtMessage" runat="server" CssClass="form-control" 
                                    TextMode="MultiLine" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="TxtMessage" ErrorMessage="Required!" 
                                    SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 form-group">
                                <label>Request With Branch:<span class="errormsg">*</span></label>
                                <asp:DropDownList ID="DdlBranchRqe" runat="server" CssClass="form-control" 
                                    onselectedindexchanged="DdlBranchRqe_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvDdlForward" runat="server" 
                                    ControlToValidate="DdlBranchRqe" ErrorMessage="Required!" 
                                    SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3 form-group">
                                <label>Recommend With:</label>
                                <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="form-control">
                                </asp:DropDownList>   
                            </div>
                            <div class="col-md-3 form-group">
                                <label>Priority:</label>
                                <asp:DropDownList ID="Ddlpriority" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="N">Normal</asp:ListItem>
                                    <asp:ListItem Value="L">Low</asp:ListItem>
                                    <asp:ListItem Value="H">High</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 form-group">
                                <asp:Panel id="unschPnl" runat="server" Visible="false">
                                    <label>Unschedule Req. Reason:</label>
                                    <asp:TextBox ID="txtUnschReqMsg" runat="server" CssClass="form-control" 
                                        TextMode="MultiLine"></asp:TextBox>
                                </asp:Panel>
                            </div>
                            <div class="col-md-3 form-group">
                                <div id="RejectionDetails" runat="server" visible="false">
                                    <label>Rejected By:</label>
                                    <asp:Label ID="rejectedBy" runat="server" CssClass="txtlbl"></asp:Label>
                                    Rejected Date: <asp:Label ID="rejectedDate" runat="server" CssClass="txtlbl"></asp:Label>
                                    Rejected Message:<asp:Label ID="rejectedMsg" runat="server" CssClass="txtlbl"></asp:Label>
                                </div>
                            </div>
                        </div>
                   
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary"
                                    Text="Save" onclick="btnSave_Click" ValidationGroup="req" />
                                <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="btnSave">
                                </cc1:ConfirmButtonExtender>
                                  &nbsp;&nbsp;<asp:Button ID="BtnDeleted" runat="server" CssClass="btn btn-primary" 
                                    onclick="BtnDeleted_Click" Text="Delete" />
                                <cc1:ConfirmButtonExtender ID="BtnDeleted_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Are you sure to delete?" Enabled="True" 
                                    TargetControlID="BtnDeleted">
                                </cc1:ConfirmButtonExtender>
                            </div>
                    
            </section>
        </div>
    </div>
</asp:Content>
