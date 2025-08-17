<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"
    CodeBehind="ManageLoanAndAdvance.aspx.cs" Inherits="SwiftHrManagement.web.Report.Loan_and_Advance_Report.ManageLoanAndAdvance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                             <i class="fa fa-caret-right" aria-hidden="true"></i> 
                            Loan and Advance  Summary Report
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <label style="color:red"> Employee Name Mandatory For Detail Report!!! </label><br />
                            </div>
                            <label>Loan Report</label>
                            <div class="form-group">
                                <label>Loan Type:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="DdlLoanType" 
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="loan" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator> 
                                <asp:DropDownList ID="DdlLoanType" runat="server" CssClass="form-control" ></asp:DropDownList>                                  
                            </div>
                            <div class="form-group">
                                <label>Branch:</label>
                                <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" 
                                AutoPostBack="True" onselectedindexchanged="DdlBranchName_SelectedIndexChanged" ></asp:DropDownList> 
                            </div>
                            <div class="form-group">
                                <label>Department:</label>
                                <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control" 
                                AutoPostBack="True" onselectedindexchanged="DdlDeptName_SelectedIndexChanged"></asp:DropDownList> 
                            </div>
                            <div class="form-group">
                                <label>Employee:</label>
                                <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="form-control" ></asp:DropDownList>  
                            </div>
                            <div class="form-group">
                                <label>From Date:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFrom" 
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="loan" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>  
                                <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control"></asp:TextBox>   
                                         
                                <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtFrom">
                                </cc1:CalendarExtender>
                            </div>
                            <div class="form-group">
                                <label>To Date:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTo" 
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="loan" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtTo" runat="server" CssClass="form-control"></asp:TextBox> 
                                   
                             
                                <cc1:CalendarExtender ID="txtTo_CalendarExtender" runat="server" Enabled="True" 
                                TargetControlID="txtTo">
                                </cc1:CalendarExtender>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="BtnSummery" runat="server" CssClass="btn btn-primary" Text="Summary" 
                                onclick="BtnSummery_Click" ValidationGroup="loan" />
                                <asp:Button ID="BtnViewDetails" runat="server" CssClass="btn btn-primary" Text="View Details" 
                                ValidationGroup="loan" onclick="BtnViewDetails_Click"  />
                                &nbsp;
                            </div>
                            <br/>
                            <label> Advance Report</label>
                            <div class="form-group">
                                <label>Advance Type:  <span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="DdlAdvanceType" 
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Advancetype" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>  
                                <asp:DropDownList ID="DdlAdvanceType" runat="server" CssClass="form-control" ></asp:DropDownList> 
                     
                                
                            </div>
                            <div class="form-group">
                                <label>Branch:  </label>
                                <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="form-control" 
                                AutoPostBack="True" onselectedindexchanged="DdlBranchType_SelectedIndexChanged"></asp:DropDownList> 
                            </div>
                            <div class="form-group">
                                <label>Department:  </label>
                                <asp:DropDownList ID="DdlDepartmentType" runat="server" CssClass="form-control" 
                                AutoPostBack="True"    onselectedindexchanged="DdlDepartmentType_SelectedIndexChanged"></asp:DropDownList> 
                            </div>  
                            <div class="form-group">
                                <label>Employee:  </label> 
                                <asp:DropDownList ID="DdlEmployeeType" runat="server" CssClass="form-control" ></asp:DropDownList>    
                            </div>   
                            <div class="form-group">
                                <label>From Date  :  <span class="errormsg">*</span></label> 
                                <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFormDate" 
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Advancetype" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator> 
                                <asp:TextBox ID="txtFormDate" runat="server" CssClass="form-control"></asp:TextBox> 
                      
                                
                              
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                Enabled="True" TargetControlID="txtFormDate">
                                </cc1:CalendarExtender>  
                            </div>  
                            <div class="form-group">
                                <label>To Date:  <span class="errormsg">*</span></label> 
                                <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTodate" 
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Advancetype" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator> 
                                <asp:TextBox ID="txtTodate" runat="server" CssClass="form-control"></asp:TextBox> 
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                Enabled="True" TargetControlID="txtTodate">
                                </cc1:CalendarExtender>  
                            </div> 
                                <asp:Button ID="BtnAdvanceSummery" runat="server" CssClass="btn btn-primary" Text="Summary" 
                                ValidationGroup="Advancetype" onclick="BtnAdvanceSummery_Click"  />
                                &nbsp;
                                <asp:Button ID="Btn_view_details" runat="server" CssClass="btn btn-primary" Text="View Details" 
                                ValidationGroup="Advancetype" onclick="Btn_view_details_Click"  />
                        </div>
                </div>
                </section>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


