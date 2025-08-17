<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="AppraisalSearch.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalSearch" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">     
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            Appraisal Rating Search
                        </header>
                        <div class="panel-body">
                            <div class="form-group">  
                                 <span class="txtlbl" >Please enter valid data!</span><span class="required" > (* Required fields!) </span><br />     
                                 <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                 <asp:HiddenField ID="hdnRowid" runat="server" />
                                
                            </div>
                            <div id="info" runat="server">
                                <div class="form-group">
                                    <label>From Date: <span class="required">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                                        ControlToValidate="txtFromDate" Display="dynamic" ErrorMessage="Required" 
                                        ValidationGroup="rating"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="TxtFromDate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="form-group">
                                     <label>To Date: <span class="required">*</span></label>
                                     <asp:RequiredFieldValidator ID="frv" runat="server" 
                                        ControlToValidate="txtToDate" Display="dynamic" ErrorMessage="Required" 
                                        ValidationGroup="rating"></asp:RequiredFieldValidator><br />
                                     <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Enabled="True" TargetControlID="txtToDate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="form-group">
                                     <label>Rating Roles: <span class="required">*</span></label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="DdlRatingRoles" Display="dynamic" ErrorMessage="Required" 
                                        ValidationGroup="rating"></asp:RequiredFieldValidator><br />
                                     <asp:DropDownList ID="DdlRatingRoles" runat="server" CssClass="form-control" ></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary" 
                                        ValidationGroup="rating" onclick="BtnSearch_Click" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div id="rptComments" runat="server"></div>
                            </div>
                        </div>
                     </section>
                   </div>
                </div>
</asp:Content>
