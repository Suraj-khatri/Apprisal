<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.Manage" Title="Swift HRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .btn-primary {
            margin-top: 5px !important;
            margin-bottom: 5px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
    <div class="row">  
        <div class="col-lg-6 col-md-offset-3"> 
            <section class="panel">    
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Salary Sheet Report
                </header>
            </section>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel panel-default">
                <header class="panel-heading">
                    Salary Report
                </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <label>Year: <span class="errormsg">*</span></label> 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                    runat="server" ControlToValidate="DdlYear" Display="Dynamic" 
                                    ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True"></asp:RequiredFieldValidator>                  
                                <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control" />
                                
                         </div>
                         <div class="form-group">
                            <label>Month: <span class="errormsg">*</span></label>   
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                runat="server" ControlToValidate="DdlMonth" Display="Dynamic" 
                                ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True" />
                                <asp:DropDownList ID="DdlMonth" runat="server" CssClass="form-control" />
                               
                         </div>
                         <div class="form-group">
                             <label>Branch:</label>   
                                <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" 
                                AutoPostBack="True"  onselectedindexchanged="DdlBranchName_SelectedIndexChanged" />
                        </div>
                        <div class="form-group">
                            <label>Department: </label> 
                                 <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control" 
                                     AutoPostBack="True" onselectedindexchanged="DdlDeptName_SelectedIndexChanged"/>
                        </div>
                         <div class="form-group">
                                <label>Employee Name: </label>
                                <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="form-control"/>
                         </div>
                         <div class="row">
                            <div class="col-md-4">
                                <asp:Button ID="BtnSalary" runat="server" CssClass="btn btn-primary" Text="Salary Sheet Live" 
                                    ValidationGroup="payroll" onclick="BtnSalary_Click"/>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="BtnSalaryTrail" runat="server" CssClass="btn btn-primary" Text="Salary Sheet Trail" 
                                    ValidationGroup="payroll" onclick="BtnSalaryTrail_Click" />&nbsp;
                     
                           </div>
                            <div class="col-md-4">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Search" 
                                  onclick="Btn_Search_Click" />
                            </div>
                              </div>
                         <div class="row">
                           <div class="col-md-4">
                                <asp:Button ID="ExpertToExcel" runat="server" CssClass="btn btn-primary" 
                                    onclick="ExpertToExcel_Click" Text="Trial Export To Excel" 
                                    ValidationGroup="payroll" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="Export_Live" runat="server" CssClass="btn btn-primary" 
                                                            onclick="Export_Live_Click" Text="Live Export To Excel" 
                                                            ValidationGroup="payroll" />&nbsp;
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="Tax_Report" runat="server" CssClass="btn btn-primary" Text="Tax Report" 
                                                            ValidationGroup="payroll" onclick="Tax_Report_Click" />

                            </div>                 

                            </div>               

                            </div>
                </div>
            </section>
        </div>
    </div>
    <div class="row">  
        <div class="col-lg-6 col-md-offset-3"> 
            <section class="panel panel-default">    
                <header class="panel-heading">
                    Salary Advice
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6">
                                <label>Year: <span class="errormsg">*</span></label>   
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" ControlToValidate="DdlYear1" Display="Dynamic" 
                                ErrorMessage="Required!" ValidationGroup="report" SetFocusOnError="True" />  
                                <asp:DropDownList ID="DdlYear1" runat="server" CssClass="form-control" />
                                
                        </div>
                        <div class="col-md-6">
                            <label>Month: <span class="errormsg">*</span></label>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                    runat="server" ControlToValidate="DdlMonthName" Display="Dynamic" 
                                    ErrorMessage="Required!" ValidationGroup="report" SetFocusOnError="True" />
                            <asp:DropDownList ID="DdlMonthName" runat="server" CssClass="form-control" />
                            
                        </div>
                        <div class="col-md-6">
                                <asp:Button ID="ButtonSearch" runat="server" CssClass="btn btn-primary" Text="Search" 
                                onclick="ButtonSearch_Click" ValidationGroup="report" />&nbsp;
                        </div>  
                        <div class="col-md-6">
                            <asp:Button ID="ButtonSearchTrial" runat="server" CssClass="btn btn-primary" Text="Search Trial" 
                            ValidationGroup="report" onclick="ButtonSearchTrial_Click" />
                    </div>
                    </div>
                </div>
                
            </section>
        </div>
    </div>
    <div class="row">  
        <div class="col-lg-6 col-md-offset-3"> 
        <section class="panel panel-default">         
            <header class="panel-heading">
                Tax Calculation REPORT
            </header>
             <div class="panel-body">
                <div class="form-group">
                    <div class="col-md-6">
                        <label>Year: <span class="errormsg">*</span></label>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                            runat="server" ControlToValidate="calFYear" Display="Dynamic" 
                            ErrorMessage="Required!" ValidationGroup="calRpt" SetFocusOnError="True" />
                            <asp:DropDownList ID="calFYear" runat="server" CssClass="form-control" />
                            
                    </div>
                    <div class="col-md-6">
                        <label>Month: <span class="errormsg">*</span></label> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                            runat="server" ControlToValidate="calMonth" Display="Dynamic" 
                            ErrorMessage="Required!" ValidationGroup="calRpt" SetFocusOnError="True" /> 
                            <asp:DropDownList ID="calMonth" runat="server" CssClass="form-control" />
                            
                    </div>
                    <div class="col-md-6">
                                          
                            <asp:Button ID="calSearchRpt" runat="server" CssClass="btn btn-primary" Text="Search Live" 
                                onclick="calSearchRpt_Click" ValidationGroup="calRpt" />&nbsp;
                        </div>
                    <div class="col-md-6">
                            <asp:Button ID="calSearchRptTrail" runat="server" CssClass="btn btn-primary" Text="Search Trial" 
                                onclick="calSearchRptTrail_Click" ValidationGroup="calRpt" />
                    </div>
                </div>
            </div>
        </section>
    </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-offset-3"> 
            <section class="panel panel-default">         
                <header class="panel-heading">
                    GL Upload File
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>Year: <span class="errormsg">*</span></label> 
                            <asp:RequiredFieldValidator ID="rfvYearGL" 
                            runat="server" ControlToValidate="yearGL" Display="Dynamic" 
                            ErrorMessage="Required!" ValidationGroup="GL" SetFocusOnError="True" />
                            <asp:DropDownList ID="yearGL" runat="server" CssClass="form-control" />
                            
                        </div> 
                        <div class="col-md-6">
                            <label>Month: <span class="errormsg">*</span></label> 
                            <asp:RequiredFieldValidator ID="rfvMonthGL" 
                            runat="server" ControlToValidate="monthGL" Display="Dynamic" 
                            ErrorMessage="Required!" ValidationGroup="GL" SetFocusOnError="True" />
                            <asp:DropDownList ID="monthGL" runat="server" CssClass="form-control" />
                            
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="btnUploadGL" runat="server" CssClass="btn btn-primary" Text="Upload GL" 
                            onclick="btnUploadGL_Click" ValidationGroup="GL" />&nbsp;
                                                          
                        </div> 
                        <div class="col-md-6">
                        <asp:Button ID="btnUploadGLTrail" runat="server" CssClass="btn btn-primary" Text="Upload GL Trial" 
                        ValidationGroup="GL" onclick="btnUploadGLTrail_Click" /> 
                        </div> 
                    </div>
                </div>
            </section>
        </div>
    </div>
<div class="row">       
    <div class="col-lg-6 col-md-offset-3"> 
        <section class="panel panel-default">    
            <header class="panel-heading">
                Voucher
            </header>
            <div class="panel-body">
                <div class="form-group">
                    <div class="col-md-6">
                        <label>Branch: <span class="errormsg">*</span></label> 
                                    <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" />
                    </div>
                                      
                    <div class="col-md-6">
                        <label>Year: <span class="errormsg">*</span></label> 
                            <asp:RequiredFieldValidator ID="rfvVoucherYr" runat="server" ControlToValidate="ddlVoucherYr" Display="Dynamic" 
                                        ErrorMessage="Required!" ValidationGroup="voucher" SetFocusOnError="True" />             
                        <asp:DropDownList ID="ddlVoucherYr" runat="server" CssClass="form-control" />
                        
                    </div>
                    <div class="col-md-12">
                        <label>Month: <span class="errormsg">*</span></label> 
                        <asp:RequiredFieldValidator ID="rfvVoucherMOnth" runat="server" ControlToValidate="ddlVoucherMonth" Display="Dynamic" 
                                        ErrorMessage="Required!" ValidationGroup="voucher" SetFocusOnError="True" />
                        <asp:DropDownList ID="ddlVoucherMonth" runat="server" CssClass="form-control" />
                        
                    </div>
                    <%--    <div class="col-md-6">
                            <asp:Button ID="Live_exportExcel" runat="server" CssClass="btn btn-primary   " Text="Live_Export To Excel" 
                                        onclick="Live_exportExcel_Click" ValidationGroup="calRpt" />&nbsp;
                                        <asp:Button ID="Trial_exportExcel" runat="server" CssClass="button" Text="Trial_Export To Excel" 
                                        onclick="Trial_exportExcel_Click" ValidationGroup="calRpt" />
                            </div>--%>
                                          
                    <div class="col-md-6">
                        <asp:Button ID="btnVoucherLive" runat="server" CssClass="btn btn-primary" Text="Upload Voucher" 
                                        ValidationGroup="voucher" onclick="btnVoucherLive_Click" />&nbsp;
                                                      
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="btnVoucherTrial" runat="server" CssClass="btn btn-primary" Text="Upload Voucher Trial" 
                                        ValidationGroup="voucher" onclick="btnVoucherTrial_Click" /> 
                    </div>
                </div>
            </div>
        </section>
    </div>   
</div>   
</ContentTemplate>
</asp:UpdatePanel>


</asp:Content>
