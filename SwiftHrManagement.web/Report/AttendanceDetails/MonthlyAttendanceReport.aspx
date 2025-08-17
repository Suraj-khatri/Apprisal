<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="MonthlyAttendanceReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AttendanceDetails.MonthlyAttendanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel">
                <section>
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                          Monthly Attendace Report
                        </header>
                        <div class="panel-body">
                            
                            <div  id="searchrpt" runat="server">
                       <div class="form-group"> 
                                                                  <label>  Fiscal Year : <span class="errormsg">*</span></label>   
                        
                                                                    <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                               </div>
                                                                 <div class="form-group">
                                                                       <label>   Month : <span class="errormsg">*</span></label>  
                                                                    <asp:DropDownList ID="DdlMonth" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlMonth"
                                                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True">
                                                                    </asp:RequiredFieldValidator>
                                                                     </div>
                                <div class="form-group">
                                                                        <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Search" 
                                                                            ValidationGroup="payroll" onclick="Btn_Search_Click" />
                                                                  </div>
                                </div>

                                                         
                                                     
                                              
                    
                            <div id="showrpt" runat="server"></div>
                       
                            <div id="showrpt1" runat="server"></div>
                        </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
