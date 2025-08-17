<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Weightage Defination.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.Weightage_Defination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>                        
                    Weightage Defination
                </header>
                <div class="panel-body">
                    <div >
                        <span class="txtlbl">Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                    </div>
                    <div class="form-group">          
                        <div class="col-md-12">                                  
                            <table class="table table1" style="border:1px;" >                                        
                                <tr>
                                    <td></td>
                                    <td>In Percentage</td>                                        
                                </tr>
                                <tr>
                                    <td class="txtlbl">
                                        <div class="form-group">
                                           <label>KRA:</label>
                                        </div>
                                    </td>                                       
                                    <td>            
                                        <asp:TextBox ID="KRAWeightage1" runat="server" CssClass="form-control"></asp:TextBox>                                           
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="KRAWeightage1" Display="None" 
                                            ErrorMessage="Required!" ValidationGroup="Weightage">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="KRAWeightage1"
                                            ValidationGroup="Weightage" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                            ErrorMessage="only numeric values are allowed!" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtlbl">
                                        <div class="form-group">
                                           <label>Competencies:</label>
                                        </div>
                                    </td>                                       
                                    <td>            
                                        <asp:TextBox ID="KRAWeightage2" runat="server" CssClass="form-control"></asp:TextBox>                                           
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="KRAWeightage2" Display="None" 
                                            ErrorMessage="Required!" ValidationGroup="Weightage">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save" Onclick="Btn_Save_Click" ValidationGroup="Weightage" />
                                        <asp:Button ID="Cancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="Cancel_Click" />
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
