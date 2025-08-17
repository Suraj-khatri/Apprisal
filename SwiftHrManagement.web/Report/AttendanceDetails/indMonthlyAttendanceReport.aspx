<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="indMonthlyAttendanceReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AttendanceDetails.indMonthlyAttendanceReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>
                           Individual Monthly Attendace Report
                        </header>
                        <div class="panel-body">
                            
                                
                            <div class="row">
                                <div class="col-md-12 form-group">
                            <div id="searchrpt" runat="server">
                            <div class="form-group autocomplete-form"> 
                            <label>  Employee Name : <span class="errormsg">*</span></label>        
                                                                  
                                <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control"
                                    AutoPostBack="true"></asp:TextBox>
                                <cc1:autocompleteextender id="aceEmpName" runat="server" completioninterval="10"
                                    completionlistcssclass="autocompleteTextBoxLP" delimitercharacters="" enablecaching="true"
                                    enabled="true" minimumprefixlength="1" servicemethod="GetEmployeeList"
                                    servicepath="~/Autocomplete.asmx" targetcontrolid="txtEmpName">
                                        </cc1:autocompleteextender>
                                <cc1:textboxwatermarkextender id="wmeEmpName" runat="server" enabled="True" targetcontrolid="txtEmpName"
                                    watermarkcssclass="form-control" watermarktext="Auto Complete">
                                    </cc1:textboxwatermarkextender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmpName"
                                    Display="Dynamic" ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                            </div>    
                                <div class="form-group">
                                    <label>   Fiscal Year : <span class="errormsg">*</span></label>   
                                <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlYear"
                                    Display="Dynamic" ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
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
                                    <asp:Button ID="Btn_Search" runat="server"  CssClass="btn btn-primary" Text="Search" 
                                        ValidationGroup="payroll" onclick="Btn_Search_Click"/>
                                </div>
                        </div>
                                </div>
                            </div>
                           <div class="row">
                               <div class="col-md-12 form-group">
                                    <div id="showrpt" runat="server">
                                    </div>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-md-12 form-group">
                                   <div id="showrpt1" runat="server">
                                    </div>
                               </div>
                           </div>
                            </div>
                </section>
        </div>
    </div>


</asp:Content>
