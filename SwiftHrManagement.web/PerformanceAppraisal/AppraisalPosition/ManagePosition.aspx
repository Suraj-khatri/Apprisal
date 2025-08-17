<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManagePosition.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalPosition.ManagePosition" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>        
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function DeleteNotification(ID) {
            if (confirm("Are you sure to delete this record?")) {
                document.getElementById("<% =hdnRowid.ClientID %>").value = ID;
                document.getElementById("<% =BtnDelete.ClientID %>").click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Position Assignment Form
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label><br />
                        <asp:HiddenField ID="hdnRowid" runat="server" />
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label>Template Name:</label>
                            <strong><asp:Label ID="lblTemplateName" runat="server"></asp:Label></strong>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Position:</label>
                            <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control" ValidationGroup="Add"></asp:DropDownList>
                        </div>
                        <div class="col-md-6 form-group" style="margin-top:3px;">
                            <br />
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" 
                                ValidationGroup="Add" onclick="btnAdd_Click" />
                        </div>
                    </div>
                    <div class="row">
                        &nbsp;
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <div id="rptPosition" runat="server"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" onclick="BtnSave_Click" />
                            <cc1:confirmbuttonextender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                            </cc1:confirmbuttonextender>
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Text="Back" onclick="BtnBack_Click" />
                            <asp:Button ID="BtnDelete" runat="server" style="display:none" onclick="BtnDelete_Click" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
