<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="ManageInsurance.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.InsuranceDetail.ManageInsurance" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Insurance Information</header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <br />
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        <asp:HiddenField ID="HdnVendor" runat="server" />
                    </div>
                    <fieldset style="list-style:circle; list-style-type:circle;">
                        <label>Insurance Information:</label>
                         <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Insurer Company:</label><span class="errormsg">*</span>
                                    <asp:DropDownList ID="DdlInsurer" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" 
                                    ControlToValidate="DdlInsurer" Display="Dynamic" ErrorMessage="Required!" 
                                    SetFocusOnError="True" ValidationGroup="insurance"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Insured Amount: </label><span class="errormsg">*</span>
                                    <asp:TextBox ID="TxtInsuredAmount" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="TxtInsuredAmount" Display="Dynamic" ErrorMessage="Required!" 
                                        SetFocusOnError="True" ValidationGroup="insurance"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                       
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Branch Name:</label><span class="errormsg">*</span>
                                    <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="DdlBranch" Display="Dynamic" ErrorMessage="Required!" 
                                    SetFocusOnError="True" ValidationGroup="insurance"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                             
                         
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Insured Date: </label><span class="errormsg">*</span>
                                    <asp:TextBox ID="TxtInsuredDate" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtInsuredDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtInsuredDate">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="TxtInsuredDate" Display="Dynamic" ErrorMessage="Required!" 
                                        SetFocusOnError="True" ValidationGroup="insurance"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                       
                     
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Expiry Date: </label>
                                    <asp:TextBox ID="TxtExpiredDate" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtExpiredDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtExpiredDate">
                                    </cc1:CalendarExtender>
                                    
                                </div>
                            </div>
                        </div>
                      
                        <div class="form-group">
                            <label>Narration: </label>
                            <asp:TextBox ID="TxtNarration" runat="server" CssClass="form-control"  TextMode="MultiLine">
                            
                            </asp:TextBox>
                                    
                        </div>

                    </fieldset>
                  
                        <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" 
                        onclick="Btn_Save_Click" Text="Save" ValidationGroup="insurance" />
                        
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" onclick="BtnDelete_Click" Text="Delete"/>
                        
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                        Text="Back" onclick="BtnBack_Click"  />
                                    
                   
                    
                </div>
            </section>
        </div>

    </div>


</asp:Content>
