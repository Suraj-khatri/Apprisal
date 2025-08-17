<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/Projectmaster.Master" AutoEventWireup="true" CodeBehind="ManageBenefitsOnlyForTaxSettings.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageBenefitsOnlyForTaxSettings" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel id="upatepanel" runat = "server">
<ContentTemplate>
<div class="panel">
        <header class="panel-heading">
             <i class="fa fa-caret-right"></i>  <a href="ListBenefitsOnlyForTaxSettings.aspx?Id=<%=GetEmpId().ToString()%>">List Interest Benefit  </a> &raquo; Manage Interest Benefit						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
             Plese enter valid data!
                <span class="required" >(* Required fields)</span><br />
                <div>
                <asp:Label ID="lblTransactionMessage" runat="server" ></asp:Label>
                <asp:HiddenField ID="hdnEmployeeId" runat="server" />
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                          Benefit Name: <span class="errormsg">*</span> 
                    </label>
                   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                    runat="server" ControlToValidate="ddlBenefitName" Display="None" 
                    ErrorMessage="*" SetFocusOnError="True" ValidationGroup="Benifits"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="ddlBenefitName" runat="server" CssClass="form-control">
                </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Fiscal Year: <span class ="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RfvFy" runat="server" 
                    ControlToValidate="DDLFY" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="Benifits"></asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="DDLFY" runat="server" CssClass="form-control">
                </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Actual Interest Paid: <span class="errormsg">*</span>
                    </label>
                    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TxtIntAmt" ErrorMessage="*" 
                    SetFocusOnError="True" Display="None" ValidationGroup="Benifits"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="TxtIntAmt" 
                    Display="Dynamic" ErrorMessage="Invalid Amount!" SetFocusOnError="True" 
                    Type="Double" ValidationGroup="Benifits"></asp:CompareValidator>
                <br />
                <asp:TextBox ID="TxtIntAmt" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
                    <div class="row">
                <div class="col-md-4 form-group">
                    <label>
Applied Interest Rate: <span class ="errormsg">*</span>
                    </label>
                    
                <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtAppIntRate" 
                    Display="None" ErrorMessage="*" SetFocusOnError="True" 
                    ValidationGroup="Benifits"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv2" runat="server" ControlToValidate="TxtAppIntRate" 
                    Display="Dynamic" ErrorMessage="Invalid Amount!" SetFocusOnError="True" 
                    Type="Double" ValidationGroup="Benifits"></asp:CompareValidator>
                <br />
                <asp:TextBox ID="TxtAppIntRate" runat="server" CssClass="form-control" 
                    ValidationGroup="Benifits"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Market Interest Rate: <span class="errormsg">*</span>
                    </label>
                     
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TxtMarketIntRate" ErrorMessage="*" 
                    SetFocusOnError="True" Display="None" ValidationGroup="Benifits"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv3" runat="server" 
                    ControlToValidate="TxtMarketIntRate" Display="Dynamic" 
                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                    ValidationGroup="Benifits"></asp:CompareValidator>
                <br />

                <asp:TextBox ID="TxtMarketIntRate" runat="server" CssClass="form-control" 
                    AutoPostBack="True" ontextchanged="TxtMarketIntRate_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
 Taxable Interest Amount: <span class="errormsg">*</span>
                    </label>
                   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="TxttaxableIntAmount" Display="None" 
                    ErrorMessage="*" SetFocusOnError="True" 
                    ValidationGroup="Benifits"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv4" runat="server" 
                    ControlToValidate="TxttaxableIntAmount" Display="Dynamic" 
                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                    ValidationGroup="Benifits"></asp:CompareValidator>
                <br />
                <asp:TextBox ID="TxttaxableIntAmount" runat="server" CssClass="form-control" 
                    Enabled="False"></asp:TextBox>       
                </div>
                        <div class="col-md-6 form-group">
                            <label>Narration:</label> 
                <asp:TextBox ID="TxtNaration" runat="server" CssClass="form-control" 
                    Height="58px" TextMode="MultiLine" ></asp:TextBox>
                        </div>
            </div>
                    <br/>
 <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                    onclick="BtnSave_Click" ValidationGroup="Benifits" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                    Text="Delete" onclick="BtnDelete_Click" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" />
        </div>
    </div>


</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

