<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageTest.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement.Manage" %>

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
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>           
                    Performance Agreement Question Count Setup
                </header>
                <div class="panel-body">
                    <div >
                        <span class="txtlbl">Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                    </div>
                    <div class="form-group">          
                            <div class="col-md-12">                                  
                                <table class="table table1" style="border:0!important;" >                                        
                                    <tr>
                                        <td></td>
                                        <td>Number of Questions<span class="errormsg">*</span></td>
                                        <td>Total Weightage</td>
                                        <td>Rating Ceiling</td>
                                    </tr>
                                    <tr>
                                        <td class="txtlbl">
                                            <div class="form-group">
                                                <div align="right"><label>KRA:</label></div>
                                            </div>
                                        </td>                                       
                                        <td>            
                                            <asp:TextBox ID="kraNoOfQuestions" runat="server" CssClass="form-control" ></asp:TextBox>                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="kraNoOfQuestions"
                                               ErrorMessage="Required!" ValidationGroup="QuestionCount">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="kraNoOfQuestions"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="kraTotalWeightage" runat="server" CssClass="form-control"></asp:TextBox>                                            
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="kraTotalWeightage"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="kraRatingCeiling" runat="server" CssClass="form-control"></asp:TextBox>                                            
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="kraRatingCeiling"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td>                                           
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="form-group">
                                                <div align="right"><label>KPI Per KRA:</label></div>
                                            </div>
                                        </td>
                                        <td>            
                                            <asp:TextBox ID="kpiPerKraQuestionNo" runat="server" CssClass="form-control"></asp:TextBox>                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="kpiPerKraQuestionNo" 
                                               ErrorMessage="Required!" ValidationGroup="QuestionCount">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="kpiPerKraQuestionNo"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="kpiPerKraTotalWeightAge" runat="server" CssClass="form-control"></asp:TextBox>       
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="kpiPerKraTotalWeightAge"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="kpiPerKraRatingCeiling" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="kpiPerKraRatingCeiling"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td> 
                                    </tr>
                                     <tr>
                                        <td>
                                            <div class="form-group">
                                                <div align="right"><label>Critical Jobs:</label></div>
                                            </div>
                                        </td>
                                        <td>            
                                            <asp:TextBox ID="criticalJobsQuestionNo" runat="server" CssClass="form-control"></asp:TextBox>                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="criticalJobsQuestionNo"
                                               ErrorMessage="Required!" ValidationGroup="QuestionCount">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="CriticalJobsQuestionNo"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="criticalJobsTotalWeightAge" runat="server" CssClass="form-control"></asp:TextBox> 
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="criticalJobsTotalWeightAge"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="criticalJobsRatingCeiling" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="criticalJobsRatingCeiling"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td> 
                                    </tr>
                                     <tr>
                                        <td>
                                            <div class="form-group">
                                                <div align="right"><label>Training Assessment:</label></div>
                                            </div>
                                        </td>
                                        <td>            
                                            <asp:TextBox ID="trainingAssesQuestionNo" runat="server" CssClass="form-control"></asp:TextBox>                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="trainingAssesQuestionNo"
                                               ErrorMessage="Required!" ValidationGroup="QuestionCount">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="trainingAssesQuestionNo"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="trainingAssesTotalWeightAge" runat="server" CssClass="form-control"></asp:TextBox> 
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="trainingAssesTotalWeightAge"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="trainingAssesRatingCeiling" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="trainingAssesRatingCeiling"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td> 
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save" Onclick="Btn_Save_Click"
                                                 ValidationGroup="QuestionCount" />
                                        </td>                        
                                    </tr>
                                    </table>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
</asp:Content>
