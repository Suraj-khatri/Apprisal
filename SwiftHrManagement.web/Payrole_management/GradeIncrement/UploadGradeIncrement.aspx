<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="UploadGradeIncrement.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.GradeIncrement.UploadGradeIncrement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
              <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                           Grade Increment
                        </header>
            <div class="panel-body">
                <div align="center">
                    <asp:Label ID="lblMsgDis" runat="server"></asp:Label></div>
                <div class="form-group">
                    <label>Fiscal Year: <span class="required">*</span>  </label>
                     <asp:RequiredFieldValidator ID="RFVGrade" runat="server"
                        ControlToValidate="fiscalYear" ErrorMessage="Required" SetFocusOnError="True"
                        Display="dynamic" ValidationGroup="GRADE"> </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="fiscalYear" runat="server" CssClass="form-control"></asp:DropDownList>
                   
                </div>
                <div class="form-group">
                    <label>Appraisal Rating: <span class="required">*</span>  </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="appraisalRating" ErrorMessage="Required" SetFocusOnError="True"
                        Display="dynamic" ValidationGroup="GRADE"> </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="appraisalRating" runat="server" CssClass="form-control"></asp:DropDownList>
                    
                </div>
                <div class="form-group">
                    <label>Effective From: <span class="required">*</span>  </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="effectiveDate" ErrorMessage="Required" SetFocusOnError="True"
                        Display="dynamic" ValidationGroup="GRADE"> </asp:RequiredFieldValidator>
                    <asp:TextBox ID="effectiveDate" runat="server" CssClass="form-control"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                        TargetControlID="effectiveDate">
                    </cc1:CalendarExtender>
                    
                </div>
                <div class="form-group">
                    <label>Apply Date: <span class="required">*</span>  </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="applyDate" ErrorMessage="Required" SetFocusOnError="True"
                        Display="dynamic" ValidationGroup="GRADE"> </asp:RequiredFieldValidator>
                    <asp:TextBox ID="applyDate" runat="server" CssClass="form-control"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                        TargetControlID="applyDate">
                    </cc1:CalendarExtender>
                    
                </div>
                <div class="form-group">
                    <label>Select File  </label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                    
                    <input id="fileUpload" runat="server" name="fileUpload" type="file" size="30"
                        class="inputTextBoxLP" />
                </div>
                <br/>
                <div class="form-group">
                    <asp:Button ID="BtnUpload" runat="server" Text="Upload To Server" CssClass="btn btn-primary"
                        OnClick="BtnUpload_Click" ValidationGroup="adhoc" />
                    <cc1:ConfirmButtonExtender ID="BtnUpload_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUpload">
                    </cc1:ConfirmButtonExtender>
                     <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnSave_Click" Text=" Search Detail" ValidationGroup="GRADE" />
                    <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary"
                        OnClick="btnExportToExcel_Click" Text=" Export To Excel " ValidationGroup="GRADE" />

                </div>
            </div>
            </section>
        </div>
    </div>

</asp:Content>
