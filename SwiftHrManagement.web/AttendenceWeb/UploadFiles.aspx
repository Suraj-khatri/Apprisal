<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="UploadFiles.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.UploadFiles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <script language="javascript">

        function checkAll(me) {
            var checkBoxes = document.forms[0].chkTran;
            var boolChecked = me.checked;

            for (i = 0; i < checkBoxes.length; i++) {
                checkBoxes[i].checked = boolChecked;
            }
        }

        function fileUpload_onclick() {

        }

    </script>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Upload File Details
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                    <label>    From Date:</label>
                        <asp:TextBox ID="txtDate" runat="server"  CssClass="form-control"  ></asp:TextBox>   
                        <cc1:calendarextender id="txtDate_CalendarExtender" runat="server" 
                                enabled="true" enabledonclient="true" targetcontrolid="txtDate" />   
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnImportData" runat="server" CssClass="btn btn-primary" 
                                Text="ImportAttendanceData" onclick="BtnImportData_Click" />
                            <cc1:ConfirmButtonExtender ID="BtnImportData_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Are you sure to Import Data?" Enabled="True" 
                                TargetControlID="BtnImportData">
                            </cc1:ConfirmButtonExtender>           
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

