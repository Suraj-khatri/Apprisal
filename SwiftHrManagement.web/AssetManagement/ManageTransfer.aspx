<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageTransfer.aspx.cs" Inherits="SwiftAssetManagement.AssetManagement.ManageTransfer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
<script language="javascript" type="text/javascript">

    function AutocompleteOnSelected(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=hdnAssetID.ClientID %>").value = customerValueArray[1];
    }
//    function GetEmpID(sender, e) {
//        var customerValueArray = (e._value).split("|");
//        document.getElementById("<%//=hdnEmpId.ClientID%>").value = customerValueArray[1];
//    }
          
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="updatepanel1" runat="server">
    <ContentTemplate>  
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                            Asset Transfer Entry Form
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                            <br />
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnAssetID" runat="server" />
                            <asp:HiddenField ID="hdnAccuDep" runat="server" />
                            <asp:HiddenField ID="hdnFromBranchID" runat="server" />
                            <asp:HiddenField ID="hdnFromDeptID" runat="server" />
                            <asp:HiddenField ID="hdnFromHolderID" runat="server" />  
                        </div>
                       
                            <header class="panel-heading">Asset Information</header> 
                        <div class="row">
                        <div class="form-group col-md-4 autocomplete-form">
                            <label>Asset Number:<span class="errormsg"> *</span></label>
                            <asp:TextBox ID="TxtAssetNumber" runat="server" CssClass="form-control" 
                                AutoComplete="off" AutoPostBack="true" 
                                ontextchanged="TxtAssetNumber_TextChanged">
                            </asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtAssetNumber_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtAssetNumber" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>                          
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAssetNumber"
                                TargetControlID="TxtAssetNumber" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                            </cc1:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" ControlToValidate="TxtAssetNumber" 
                                ErrorMessage="Required" ValidationGroup="Transfer" Display="Dynamic"></asp:RequiredFieldValidator> 
                        </div>
                        <div class="form-group col-md-2">
                            <label>Purchase Value:</label>
                            <asp:TextBox ID="txtPurchaseValue" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <label>Book Value:</label>
                            <asp:TextBox ID="TxtBookValue" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                       
                        <div class="form-group col-md-4">
                            <label>Asset Narration:</label>
                            <asp:TextBox ID="txtAssetNarration" runat="server" CssClass="form-control" Enabled="False" TextMode="MultiLine"></asp:TextBox>     
                        </div>
                             </div>
                        <div class="row ">
                        <div class="form-group col-md-4">
                            <label>Transfer Date:<span class="errormsg">*</span></label>
                            <asp:TextBox ID="TxtTransferDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtTransferDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="TxtTransferDate">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                             runat="server" ControlToValidate="TxtTransferDate" ErrorMessage="Required" 
                                ValidationGroup="Transfer" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-4">
                            <label>Acc Dep.:</label>
                            <asp:TextBox ID="txtAccDep" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <label>Transfer Narration:</label>
                            <asp:TextBox ID="TxtNaration" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                          </div>
                        <div class="row">  
                        <div class="form-group col-md-4">
                            <label>Forwarded To:<span class="errormsg">*</span></label>
                            <asp:DropDownList ID="ddlForwardedTo" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                             runat="server" ControlToValidate="ddlForwardedTo" ErrorMessage="Required" 
                                ValidationGroup="Transfer" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        
                            
                        <div class="form-group col-md-4">
                            <label>Rejection Reason:</label>
                            <asp:TextBox ID="txtRejectionReason" runat="server" 
                                 CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </div>
                            </div>
                        
                            <label>Transfer From</label> 
                       <div class="row">
                        <div class="form-group col-md-4">
                            <label>Branch:</label>
                            <asp:TextBox ID="TxtBranchFrom" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <label>Department:</label>
                            <asp:TextBox ID="TxtDepartmentFrom" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <label>Holder:</label>
                            <asp:TextBox ID="TxtHolderFrom" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                           </div>
                       
                            <label">Transfer To</label> 
                      <div class="row">
                        <div class="form-group col-md-4">
                            <label>Branch:</label>
                            <asp:DropDownList ID="CmbBranchTo" runat="server" CssClass="form-control" onselectedindexchanged="CmbBranchTo_SelectedIndexChanged" 
                                AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                 runat="server" ControlToValidate="CmbBranchTo"
                                 ErrorMessage="Required" ValidationGroup="Transfer" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-4">
                            <label>Department:</label>
                            <asp:DropDownList ID="CmbDepartmentTo" runat="server" CssClass="form-control" onselectedindexchanged="CmbDepartmentTo_SelectedIndexChanged" 
                                AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4">
                            <label>Holder:</label>
                            <asp:DropDownList ID="CmbHolderTo" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                          </div>
                        
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                                onclick="btnSave_Click" Text="Save" ValidationGroup="Transfer" />
                            <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Are You Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" 
                                onclick="btnDelete_Click1" Text="Delete" />
                            <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Are You Sure To Delete?" Enabled="True" 
                                TargetControlID="btnDelete">
                            </cc1:ConfirmButtonExtender>
                       
                    </div>
                </section>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>  
</asp:Content>

