<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageBill.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.BillDetail.ManageBill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">
        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");

            document.getElementById("<%=HdnVendor.ClientID %>").value = customerValueArray[1];
        }
    </script>
    <style type="text/css">
        .form-inline{
           margin-top:5px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                     Purchase Bill Information</header>
                <div class="panel-body">
                <div class="form-group">
                    <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                    <br />
                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    <asp:HiddenField ID="HdnVendor" runat="server" />
                </div>
                     <fieldset>
                         <label>Bill Information:</label>
                         <div class="row form-inline">
                         <div class="col-md-4 form-group autocomplete-form">
                            <label>Vendor Name:</label><span class="errormsg">*</span>
                            <asp:TextBox ID="TxtVendor" runat="server" CssClass="form-control"  AutoComplete="off" width="100%"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtVendor_TextBoxWatermarkExtender" 
                                 runat="server" Enabled="True" TargetControlID="TxtVendor" 
                                 WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                             </cc1:TextBoxWatermarkExtender>
                            <cc1:AutoCompleteExtender 
                                ID="AutoCompleteExtender3" runat="server" 
                                CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelected" 
                                ServiceMethod="GetVendor" ServicePath="~/Autocomplete.asmx" 
                                TargetControlID="TxtVendor">
                            </cc1:AutoCompleteExtender>
                                                    
                             <asp:RequiredFieldValidator ID="rfv" runat="server" 
                                 ControlToValidate="TxtVendor" Display="Dynamic" ErrorMessage="Required!" 
                                 SetFocusOnError="True" ValidationGroup="bill"></asp:RequiredFieldValidator>
                        </div>
                         
                            <div class="col-md-4">
                                <div class="form-group">
                    
                                <label>IBranch Name:</label><span class="errormsg">*</span>
                                <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ControlToValidate="DdlBranch" Display="Dynamic" ErrorMessage="Required!" 
                                 SetFocusOnError="True" ValidationGroup="bill"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <div class="form-group">
                    
                                    <label>Bill Amount:</label><span class="errormsg">*</span>
                                    <asp:TextBox ID="TxtBillAmount" runat="server" CssClass="form-control" width="100%"></asp:TextBox> 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                     ControlToValidate="TxtBillAmount" Display="Dynamic" ErrorMessage="Required!" 
                                     SetFocusOnError="True" ValidationGroup="bill"></asp:RequiredFieldValidator>   
                                    <asp:CompareValidator ID="CV" runat="server" 
                                    ControlToValidate="TxtBillAmount" Display="Dynamic" 
                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                    ValidationGroup="bill"></asp:CompareValidator>
                                </div>
                            </div>
                    </div>
                        <div class="row form-inline">
                            <div class="col-md-4">
                                <div class="form-group">
                    
                                <label>Billing Date:</label>
                                <asp:TextBox ID="TxtBillDate" runat="server" CssClass="form-control" width="100%"></asp:TextBox>         
                                <cc1:CalendarExtender ID="TxtBillDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtBillDate">
                                </cc1:CalendarExtender>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <div class="form-group">
                                    <label>Bill Number:</label>
                                   <asp:TextBox ID="TxtBillno" runat="server" CssClass="form-control" width="100%"></asp:TextBox>    
                                </div>
                            </div>
                         </div>
                         <div class="row">
                         <div class="col-md-12 form-group">
                            <label>Narration:</label>
                             <asp:TextBox ID="TxtNarration" runat="server" CssClass="form-control" width="100%" TextMode="MultiLine"></asp:TextBox>         
                        </div>
                         </div>  
                </fieldset>
                    
             
                    <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" onclick="Btn_Save_Click" Text="Save" ValidationGroup="bill" />
                  <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" onclick="BtnDelete_Click" Text="Delete"  />
                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"  Text="Back" />   
               
            </div>
            </section>
        </div>
    </div>
</asp:Content>



