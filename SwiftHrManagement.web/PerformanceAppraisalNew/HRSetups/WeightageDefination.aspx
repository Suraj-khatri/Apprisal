<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="WeightageDefination.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.WeightageDefination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table > thead > tr > th,
        .table > tbody > tr > th,
        .table > tfoot > tr > th,
        .table > thead > tr > td,
        .table > tbody > tr > td,
        .table > tfoot > tr > td {
            border-top: 1px solid #ffffff !important;
            line-height: 1.42857;
            padding: 8px;
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
       
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>
                    Weightage Defination
                </header>
                <div class="panel-body">
                    <div>
                        <span class="txtlbl">Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            <table class="table table1" style="border: 1px;">
                                <tr>
                                    <td></td>
                                    <td>In Percentage</td>
                                </tr>
                                <tr>
                                    <td class="txtlbl">
                                        <div class="form-group">
                                            <div align="right">
                                                <label>Level Name:</label></div>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLevelName" runat="server" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtlbl">
                                        <div class="form-group">
                                            <div align="right">
                                                <label>KRA:</label></div>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KRAWeightage1" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="KRAWeightage1" Display="Dynamic"
                                            ErrorMessage="Required!" ValidationGroup="Weightage">
                                        </asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="KRAWeightage1"
                                            ValidationGroup="Weightage" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                            ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                        </asp:RegularExpressionValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtlbl">
                                        <div class="form-group">
                                            <div align="right">
                                                <label>Competencies:</label></div>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KRAWeightage2" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="KRAWeightage2" Display="Dynamic"
                                            ErrorMessage="Required!" ValidationGroup="Weightage">
                                        </asp:RequiredFieldValidator>
                                        <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="KRAWeightage2"
                                            ValidationGroup="Weightage" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                            ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                        </asp:RegularExpressionValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="Btn_Save_Click" ValidationGroup="Weightage" />
                                        <asp:Button ID="Cancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="Cancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </section>
    </div>
    <script src="../../js/functions.js"></script>
</asp:Content>