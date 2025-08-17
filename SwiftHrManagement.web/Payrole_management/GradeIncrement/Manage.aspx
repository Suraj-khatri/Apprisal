<%@ Page Title="" Language="C#"  EnableEventValidation="false" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.GradeIncrement.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/js/listBoxMovement.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i> 
                            Grade Increment  
                            <span class="subheading">
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label></span>
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                               
                                <asp:Label ID="lblMsgDis" runat="server"></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Fiscal Year:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="fiscalYear" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="grade" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="fiscalYear" runat="server" CssClass="form-control" Width="100%"> 
                                        </asp:DropDownList>
                                         
                                    </div>
                                </div>
                                
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Appraisal Rating:<span class="errormsg">*</span></label>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="appraisalRating" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="grade" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="appraisalRating" runat="server" CssClass="form-control" Width="100%"> 
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Effective From:<span class="errormsg">*</span></label>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="effectiveDate" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="grade" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:TextBox ID="effectiveDate" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="effectiveDate"></cc1:CalendarExtender>
                                        
                                    </div>
                                </div>
                                
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Apply Date:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="applyDate" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="grade" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                         <asp:TextBox ID="applyDate" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  TargetControlID="applyDate"></cc1:CalendarExtender>
                                         
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <span>Search By</span>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label> Branch:</label>
                                        <asp:DropDownList ID="branch" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" onselectedindexchanged="branch_SelectedIndexChanged"> 
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label> Department:</label>
                                        <asp:DropDownList ID="department" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" onselectedindexchanged="department_SelectedIndexChanged"> 
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            <div class="col-md-6 form-group">
                                <div class="form-group">
                                    <label> Position:</label>
                                    <asp:DropDownList ID="position" runat="server" CssClass="form-control" Width="100%" > 
                                    </asp:DropDownList>
                                </div>
                            </div>
                                
                            <div class="col-md-6 form-group">
                                <div class="form-group">
                                    <label> Salary Title:</label>
                                    <asp:DropDownList ID="salaryTitle" runat="server" CssClass="form-control" Width="100%" > 
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                            <div class="form-group">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search"
                                    OnClick="btnSearch_Click" Font-Strikeout="False" ValidationGroup="grade"
                                    Width="75px" />
                            </div>
                        </div>
                    </section>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-5 ">
                                    <div class="form-group">
                                        <span>Unassigned Employee List</span>
                                        <asp:DropDownList ID="DdlUnassigned" runat="server" CssClass="form-control" size="30" 
                                            multiple="multiple" Width="100%" onselectedindexchanged="DdlUnassigned_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <div class="form-group" style="margin-top: 300px;">
                                        <div class="text-center btn btn-primary"  onclick=" return  listbox_moveacross('<%=DdlUnassigned.ClientID %>', '<%=Ddlassigned.ClientID %>');">&gt;&gt;</div>
                                    </div>
                                </div>
                                <div class="col-md-5 ">
                                    <div class="form-group">
                                        <span>Employee To Be Assigned List</span>
                                        <asp:DropDownList ID="Ddlassigned" runat="server" CssClass="form-control" size="30" 
                                            multiple="multiple" Width="100%" onselectedindexchanged="Ddlassigned_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 ">
                                    <div class="form-group">
                                        <div  class="text-center btn btn-primary" onclick="listbox_selectall('<%=DdlUnassigned.ClientID %>', true)">Select All </div>
                                    </div>
                                </div>
                                <div class="col-md-6 ">
                                    <div class="form-group">
                                        <div  class="text-center btn btn-primary" onclick="listbox_selectall('<%=Ddlassigned.ClientID %>', true)">Select All </div>
                                    </div>
                                </div>
                                
                            </div>
                            
                            <div class="form-group ">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="grade"
                                    Width="75px" />
                                <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary" 
                                        onclick="btnExportToExcel_Click" Text=" Export To Excel " ValidationGroup="grade" />
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnBack_Click" Text=" Back" />
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
