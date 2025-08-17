<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageJD.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageJD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> <a href="ListJD.aspx?Id=<%=GetEmpId().ToString()%>">List Job Description  </a> &raquo;Manage Job Description
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
                      
        </header>
        <div class="panel-body">
            <span class="txtlbl">Please enter valid data!</span>
            <span class="required">(* Required fields)</span>
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Branch Name
                    </label>

                    <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="form-control"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlBranchName_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Department Name
                    </label>

                    <asp:DropDownList ID="ddlDeptName" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Position
                    </label>

                    <asp:DropDownList ID="ddlPositionName" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Supervisor Name
                    </label>

                    <asp:DropDownList ID="ddlSupervisorName" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Effective From <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ControlToValidate="txtFromDate" Display="Dynamic"
                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="jd" >
                    </asp:RequiredFieldValidator><br />
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>

                    <cc1:CalendarExtender ID="CalendarExtender12"
                        runat="server" Enabled="True" TargetControlID="txtFromDate">
                    </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Effective To <span class="errormsg">*</span>
                    </label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        runat="server" ControlToValidate="txtToDate" Display="Dynamic"
                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="jd">
                    </asp:RequiredFieldValidator><br />
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>

                    <cc1:CalendarExtender ID="CalendarExtender1"
                        runat="server" Enabled="True" TargetControlID="txtToDate">
                    </cc1:CalendarExtender>
                </div>
            </div>
            <div id="fileUploadForm" runat="server">
                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>
                            File Description <span class="errormsg">*</span>
                        </label>
                        <asp:RequiredFieldValidator ID="rfv3"
                            runat="server" ControlToValidate="TxtFileDescription" Display="None"
                            ErrorMessage="*" SetFocusOnError="True" ValidationGroup="jd">
                        </asp:RequiredFieldValidator><br />

                        <asp:TextBox ID="TxtFileDescription" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>
                            Select File
                        </label>
                        <span class="errormsg">*</span>
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="RequiredFieldValidator"
                            ValidationGroup="jd" ControlToValidate="fileUpload" Display="None"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <input id="fileUpload" runat="server" name="fileUpload" type="file" size="20" cssclass="form-control" />

                    </div>
                </div>
            </div>
            <asp:Panel ID="pnlDisplayFile" runat="server" Visible="false">
                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>
                            File Desc.:
                        </label>
                        <asp:Label ID="lblFileDesc" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>
                            File Type:
                        </label>
                        <asp:Label ID="lblFileType" runat="server" CssClass="form-control"></asp:Label>
                        <asp:Label ID="lblLink" runat="server" CssClass="form-control"></asp:Label>
                        </t
                    </div>
                </div>
            </asp:Panel>
            <asp:Button ID="BtnSave" runat="server" Text=" Save " CssClass="btn btn-primary"
                ValidationGroup="jd" OnClick="BtnSave_Click" />
            <cc1:ConfirmButtonExtender ID="btnSave123" runat="server"
                ConfirmText="Confirm To Save?" TargetControlID="BtnSave">
            </cc1:ConfirmButtonExtender>
            &nbsp;
                    
                     <asp:Button ID="btnDelete" runat="server" Text=" Delete " CssClass="btn btn-primary" OnClick="btnDelete_Click" />
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                ConfirmText="Confirm To Delete?" TargetControlID="btnDelete">
            </cc1:ConfirmButtonExtender>
            &nbsp;
                    
                    <asp:Button ID="BtnBack" runat="server" Text="Back " CssClass="btn btn-primary" OnClick="BtnBack_Click" />
            <div id="rpt" runat="server"></div>
        </div>
    </div>

</asp:Content>
