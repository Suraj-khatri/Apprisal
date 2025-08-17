<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Performance Rating Reference.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.Performance_Rating_Reference" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>                        
                    Performance Rating Reference
                </header>
                <div class="panel-body">
                    <div >
                        <span class="txtlbl">Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                    </div>                                 
                    <div class="form-group col-md-8">
                        <label>KRA Achivement Score:</label>
                        <asp:TextBox ID="KRARatings1" runat="server" CssClass="form-control"></asp:TextBox>                                           
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="KRARatings1" Display="None" 
                            ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-8">
                        <label>Performance Level Rating:</label>
                        <asp:TextBox ID="KRARatings2" runat="server" CssClass="form-control"></asp:TextBox>                                           
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="KRARatings2" Display="None" 
                            ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-8">
                        <label>Percenatge of Increment:</label>
                        <asp:TextBox ID="KRARatings3" runat="server" CssClass="form-control"></asp:TextBox>                                           
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="KRARatings3" Display="None" 
                            ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                        </asp:RequiredFieldValidator>    
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="KRAQuestions1"
                            ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                            ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                        </asp:RegularExpressionValidator>                    
                    </div>
                    <div class="form-group col-md-2">
                        <label>&nbsp;</label>
                       <asp:Button ID="Btn_Add" runat="server" CssClass="btn btn-primary" Text="Add" Onclick="Btn_Add_Click" ValidationGroup="PerformanceRating" />
                    </div>
                    <div>

                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
