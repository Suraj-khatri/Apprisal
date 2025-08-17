<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ExtendHistory.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Manage Employee Type Extension 
                         <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </header>
                    <div class="panel-body">                        
                        <div class="row">
                            <div class="col-md-2 form-group">
                                <label>Employee Name:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Branch Name:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblBranch" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 form-group">
                                <label>Department Name:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblDept" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Position:</label>
                             </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblPost" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 form-group">
                                <label>Created By:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                 <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Created Date:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                 <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 form-group">
                                <label>Employee Type:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                  <asp:Label ID="lblEmpType" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 form-group">
                                <label>From Date:<span class="required">*</span></label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFromDate" 
                                    Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="cont">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>                                
                                <cc1:CalendarExtender ID="TxtDeductionStartdate_CalendarExtender" runat="server" Enabled="True" 
                                    TargetControlID="txtFromDate">
                                </cc1:CalendarExtender>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>To Date:<span class="required">*</span></label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" 
                                    Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="cont">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>                                
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtToDate">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text=" Update" onclick="btnUpdate_Click"/>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                                ConfirmText="Confirm To Update?" Enabled="True" TargetControlID="btnUpdate">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text=" Delete" onclick="btnDelete_Click"/>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                                ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="btnDelete">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" onclick="btnBack_Click" />
                        </div>
                    </div>
                </section>
            </div>
        </div>
</asp:Content>