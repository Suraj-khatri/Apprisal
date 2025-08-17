<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageRequest.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TransferRequest.ManageRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
        <div class="col-md-10 col-md-offset-1">
    
    <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> Transfer Request
        </header>
        <asp:UpdatePanel ID="ext" runat="server">
            <ContentTemplate>
                <div class="panel-body">
                    <span class="txtlbl">Please enter valid data!</span>
                    <span class="required">(* Required fields)</span><br />
                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                From Branch: <span class="errormsg">*</span>
                            </label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                ControlToValidate="DdlFromBranch"
                                ErrorMessage="Required!" SetFocusOnError="True"
                                ValidationGroup="External">
                            </asp:RequiredFieldValidator>

                            <asp:DropDownList ID="DdlFromBranch" runat="server" AutoPostBack="True"
                                class="form-control">
                            </asp:DropDownList>
                        </div>
                          
                        <div class="col-md-4 form-group">
                            <label>
                                From Department: <span class="errormsg">*</span>
                            </label>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator11" runat="server" ControlToValidate="DdlFromDept"
                                ErrorMessage="Required!"
                                SetFocusOnError="True" ValidationGroup="External"> 
                            </asp:RequiredFieldValidator>
                            <asp:DropDownList ID="DdlFromDept" runat="server" AutoPostBack="True"
                                class="form-control">
                            </asp:DropDownList>
                        </div>
                          <div id="deptsub" runat="server" class="col-md-4 form-group" visible="false">
                            <label>
                                From Sub-Department: <span class="errormsg">*</span>
                            </label>
                            <asp:DropDownList ID="ddlSubdept" runat="server" AutoPostBack="True"
                                class="form-control">
                            </asp:DropDownList>
                        </div>
                        </div>
                        <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                To Branch: <span class="errormsg">*</span>
                            </label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                runat="server" ControlToValidate="DdlToBranch"
                                ErrorMessage="Required!" ValidationGroup="External"
                                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                            <asp:DropDownList ID="DdlToBranch" runat="server" AutoPostBack="True"
                                class="form-control"
                                OnSelectedIndexChanged="DdlToBranch_SelectedIndexChanged1">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                To Department: <span class="errormsg">*</span>
                            </label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                runat="server" ControlToValidate="DdlToDept"
                                ErrorMessage="Required!" ValidationGroup="External"
                                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                            <asp:DropDownList ID="DdlToDept" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                          <div class="col-md-4 form-group">
                            <label>
                                To Sub-Department: <span class="errormsg">*</span>
                            </label>
                            <asp:DropDownList ID="DdlToSubDept" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                         </div>

                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>
                                Recommend By : 
                            </label>
                            <asp:Label ID="lblRecommendBy" runat="server" class="form-control" Width="100%"></asp:Label>
                         
                        </div>
                        <div class="col-md-6 autocomplete-form">
                            <label>
                                &nbsp;
                            </label>
                               <asp:TextBox ID="txtRecommendBy" runat="server" CssClass="form-control"
                                OnTextChanged="txtRecommendBy_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                ServicePath="~/Autocomplete.asmx" TargetControlID="txtRecommendBy">
                            </cc1:AutoCompleteExtender>

                            <cc1:TextBoxWatermarkExtender ID="txtVendor_TextBoxWatermarkExtender"
                                runat="server" Enabled="True" TargetControlID="txtRecommendBy"
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                <span>Effective Date:</span>
                            </label>

                            <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtEffectiveDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="txtEffectiveDate">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                <span>Actual Reported Date: </span>
                            </label>
                            <asp:TextBox ID="txtReportedDate" runat="server" CssClass="form-control" Width="100%">
                            </asp:TextBox>
                            <cc1:CalendarExtender ID="txtReportedDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="txtReportedDate">
                            </cc1:CalendarExtender>
                        </div>
                        </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>
                                Transfer Description: <span class="errormsg">*</span>
                            </label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                runat="server" ControlToValidate="txtTransferDesc"
                                ErrorMessage="Required!" ValidationGroup="External"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtTransferDesc" runat="server" Width="100%"
                                CssClass="inputTextBoxMultiLine" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                     <br />
                           
                    <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary"
                        OnClick="Btn_Save_Click" Text="Save" ValidationGroup="External" />
                    <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="Btn_Save">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                        OnClick="BtnDelete_Click" />
                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                        Text=" Back" OnClick="BtnBack_Click" />
                </div>
                </div>
                </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
