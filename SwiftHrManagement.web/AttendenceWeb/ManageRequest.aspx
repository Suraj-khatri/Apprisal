<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageRequest.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.ManageRequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<div class="row">
    <div class="col-md-8 col-md-offset-2">
        <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right" aria-hidden="true"></i>  
                Attendance Login & Logout Request
            </header>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12 form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 form-group">
                        <label>Employee Name:<asp:Label ID="Label1" runat="server" CssClass="required" Text="*"></asp:Label></label>
                        <asp:RequiredFieldValidator ID="rfc" runat="server" 
                            ControlToValidate="txtEmpId" Display="None" ErrorMessage="*" 
                            SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmpId" runat="server" CssClass="form-control" 
                            AutoComplete="Off"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtEmpId_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtEmpId" 
                            WatermarkText="Auto Complete" WatermarkCssClass="form-control">
                        </cc1:TextBoxWatermarkExtender>
        
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                                TargetControlID="txtEmpId" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" >
                        </cc1:AutoCompleteExtender>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 form-group">
                        <label>Login Date Time:<asp:Label ID="Label3" runat="server" CssClass="required" Text="*"></asp:Label></label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:TextBox ID="txtLoginDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtLoginDate_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtLoginDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="col-md-4 form-group">
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" 
                            ControlToValidate="ddlhourin" Display="None" ErrorMessage="*" InitialValue="" 
                            SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlhourin" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <asp:RequiredFieldValidator ID="rfv3" runat="server" 
                            ControlToValidate="ddlminutein" Display="None" ErrorMessage="*" 
                            InitialValue="" SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlminutein" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 form-group">
                        <label>Logout Date Time:</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:TextBox ID="txtLogoutDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                            Enabled="True" TargetControlID="txtLogoutDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="col-md-4 form-group">
                        <asp:DropDownList ID="ddlhourout" runat="server" CssClass="form-control" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlhourout_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <asp:DropDownList ID="ddlminuteout" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 form-group">
                        <label>Approved By:<span class="required">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="ddlApprovedBy" Display="Dynamic" ErrorMessage="Required!" 
                            SetFocusOnError="True" ValidationGroup="back">
                        </asp:RequiredFieldValidator><br />

                        <asp:DropDownList ID="ddlApprovedBy" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 form-group">
                        <label>Remarks:<asp:Label ID="Label4" runat="server" CssClass="required" Text="*"></asp:Label></label>
                        <asp:RequiredFieldValidator ID="rfv5" runat="server" 
                            ControlToValidate="txtRemarks" Display="None" ErrorMessage="*" 
                            SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" 
                            TextMode="MultiLine" ></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 form-group">
                        <asp:Button ID="btnSave0" runat="server" CssClass="btn btn-primary" 
                            onclick="btnSave_Click" Text="Save" ValidationGroup="back" />
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnDelete_Click" Text="Delete" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Are you sure to delete?" Enabled="True" 
                            TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnBack_Click" Text="Back" />
                    </div>
                </div>
            </div>
        </section>
    </div>
</div>
</asp:Content>