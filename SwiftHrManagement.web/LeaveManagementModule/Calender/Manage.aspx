<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.Calender.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <script language = "javascript">

        function CheckAll(obj) {

            var cBoxes = document.getElementsByName("chkId");

            for (var i = 0; i < cBoxes.length; i++) {

                cBoxes[i].checked = true;
            }
            }
        function UncheckAll(obj) {
            var cBoxes = document.getElementsByName("chkId");

            for (var i = 0; i < cBoxes.length; i++) {
                cBoxes[i].checked = false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Holiday Calendar Entry
                </header>
                <div class="panel-body">
                    <div class="col-md-12">
                        <label>Please enter valid data!</label><span class="required" >&nbsp;(* Required fields)<br />
                        </span><br />               
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    <//div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:Panel id="branchPnl" runat="server" Visible="false">
                                <label>Branch Name:</label>
                                <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="form-control"></asp:DropDownList>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="row"> 
                        <div class="col-md-5 form-group">
                            <label>Holiday Title:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" ControlToValidate="txtholidayTitle" Display="Dynamic" 
                                ErrorMessage="Required!" ValidationGroup="holiday"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="txtholidayTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-5 form-group">
                            <label>Date:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" ControlToValidate="TxtDate" Display="Dynamic" 
                                ErrorMessage="Required!" ValidationGroup="holiday"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="TxtDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtDate">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="col-md-2 form-group">
                             <label>Female Only:</label>
                             <asp:CheckBox ID="ChkFemaleOnly" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label>Branch Group:</label>
                            <asp:DropDownList ID="DdlBranchGroup" runat="server" CssClass="form-control" AutoPostBack="true"
                                  onselectedindexchanged="DdlBranchGroup_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label>Description:</label>
                            <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>Select Branches for Holiday</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:Panel ID="showAllBranch" runat="server">
                                
                                <div id="rptDiv" runat="server"></div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                                onclick="BtnSave_Click" ValidationGroup="holiday" Width="75px" />
                            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" 
                                onclick="btnDelete_Click" Text="Delete" Width="75px" />
                            <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                BehaviorID="btnDelete_Cm onfirmButtonExtender" ConfirmText="Confirm To Delete?" 
                                Enabled="True" TargetControlID="btnDelete">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                onclick="BtnBack_Click" Text="Back" Width="75px" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
