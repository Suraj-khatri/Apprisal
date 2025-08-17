<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageBidFor.aspx.cs" Inherits="SwiftHrManagement.web.Vendor.ManageBidFor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            //                document.getElementById("hdnProductId").value = customerValueArray[1];
            document.getElementById("<%=hdnProductId.ClientID%>").Value = customerValueArray[1];
            //alert(document.getElementById("<%=hdnProductId.ClientID%>").Value);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">Vendor Bid For Product Details</header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <br />
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnProductId" runat="server" />
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">   
                        <label>Vendor Name :</label>
                        <asp:TextBox ID="txtVendor" runat="server" CssClass="form-control" width="100%"></asp:TextBox>                                  
                    </div>
                        <div class="col-md-4 form-group  autocomplete-form">

                        <label>Product Name :</label><span class="required">*</span>
                                 <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Required!"
                            ControlToValidate="txtProduct" Display="Dynamic" SetFocusOnError="True"
                            ValidationGroup="bid"></asp:RequiredFieldValidator>                              
                        <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control" AutoComplete="off" width="100%"></asp:TextBox>
                        

                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                            DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductList1"
                            TargetControlID="txtProduct" MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                        </cc1:AutoCompleteExtender>


                        <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtProduct"
                            WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>     
                    </div>
                         <div class="col-md-4 form-group">
                        <label>Unit Price (Rate) :</label>     
                         <span class="required">*<asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtPrice" Display="Dynamic"
                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="bid"></asp:RequiredFieldValidator></span>                               
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" width="100%"></asp:TextBox>
                       
                    </div>
                    </div>
                    
                    
                   
                    <div class="form-group">
                        <label>Is Active :</label>     
                        <asp:CheckBox ID="ChkIsActive" runat="server"/>
                                                                                    
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary"
                            OnClick="BtnSave_Click" ValidationGroup="bid" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm to save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-primary"
                             OnClick="BtnDelete_Click" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm to delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn btn-primary"
                             OnClick="BtnBack_Click" />
                                                                                    
                    </div>
                </div>
            
            </section>
        </div>
    </div>

    
</asp:Content>
