<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.TrainingRpt.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
<ContentTemplate>
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel">     
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                   Training Report
                </header>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Training Report
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>From Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="datewiserpt" 
                        ControlToValidate ="txtFrmDate" ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFrmDate" runat="server"  CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate1_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFrmDate"></cc1:CalendarExtender>                        
                    </div>
                    <div class="form-group">
                        <label>To Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="datewiserpt"
                             ControlToValidate ="txtToDate" ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtToDate" runat="server"  CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtToDate"></cc1:CalendarExtender>                        
                    </div>
                    <div class="form-group">
                        <label>Training Category:</label>
                        <asp:DropDownList ID="ddlCategory" runat="server"  CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Training Type:</label>
                        <asp:DropDownList ID="ddlTrainingType" runat="server"  CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Status:</label>
                        <asp:DropDownList ID="ddlStatus" runat="server"  CssClass="form-control">
                             <asp:ListItem Value="">All</asp:ListItem>
                             <asp:ListItem Value="Requested">Requested</asp:ListItem>
                             <asp:ListItem Value="Forwarded">Forwarded</asp:ListItem>
                             <asp:ListItem Value="Approved">Approved</asp:ListItem>
                             <asp:ListItem Value="Final Approved">Final Approved</asp:ListItem>
                             <asp:ListItem Value="Recorded">Recorded</asp:ListItem>
                             <asp:ListItem Value="Closed">Closed</asp:ListItem>                 
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnViewReport" runat="server" onclick="btnViewReport_Click" CssClass="btn btn-primary" 
                            ValidationGroup="datewiserpt" Text="Summary Rpt" />
                        <asp:Button ID="btnExportSummary" runat="server" onclick="btnExportSummary_Click" CssClass="btn btn-primary" 
                            ValidationGroup="datewiserpt" Text="Export Summary Rpt" />  
                        <asp:Button ID="btnDetail" runat="server" onclick="btnDetail_Click" CssClass="btn btn-primary" 
                            ValidationGroup="datewiserpt" Text="View Detail Rpt" />
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Participant Wise Report
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>Branch:</label>
                        <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" AutoPostBack="True" 
                                onselectedindexchanged="DdlBranchName_SelectedIndexChanged"></asp:DropDownList> 
                    </div>
                    <div class="form-group">
                        <label>Department:</label>
                        <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control" AutoPostBack="True" 
                              onselectedindexchanged="DdlDeptName_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Employee Name:</label>
                         <asp:DropDownList ID="ddlEmpName" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>From Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Pdatewiserpt" 
                            ControlToValidate ="txtPFromDate" ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPFromDate" runat="server"  CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" TargetControlID="txtPFromDate"></cc1:CalendarExtender>                        
                    </div>
                    <div class="form-group">
                        <label">To Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPToDate" 
                            ErrorMessage="Required Field!!" ValidationGroup="Pdatewiserpt"> </asp:RequiredFieldValidator>
                         <asp:TextBox ID="txtPToDate" runat="server" CssClass="form-control"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" TargetControlID="txtPToDate">
                        </cc1:CalendarExtender>                        
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnPSummary" runat="server" CssClass="btn btn-primary" Text="Summary Rpt" ValidationGroup="Pdatewiserpt"
                                onclick="btnPSummary_Click"  />
                        <asp:Button ID="btnPExport" runat="server" CssClass="btn btn-primary" Text="Export Summary Rpt" ValidationGroup="Pdatewiserpt" 
                            onclick="btnPExport_Click" />
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Cost & Resource Person Wise Report
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>Choose Report:</label>
                        <asp:RadioButtonList ID="rdbRptType" runat="server" RepeatDirection="Horizontal"
                            onselectedindexchanged="rdbRptType_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="r" Selected="True" Text="Resource Person Wise"></asp:ListItem>
                            <asp:ListItem Value="c" Text="Cost Wise Report"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="rptResourcePersonWise" runat="server" visible="true">
                            <div class="form-group">
                                <label>From Date:<span class="errormsg">*</span></label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="other" 
                                    ControlToValidate ="fromDate1" ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                                <asp:TextBox ID="fromDate1" runat="server"  CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="fromDate1">
                                </cc1:CalendarExtender>                               
                            </div>
                            <div class="form-group">
                                <label>To Date:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="other" 
                                    ControlToValidate ="toDate1" ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                                <asp:TextBox ID="toDate1" runat="server"  CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="toDate1">
                                </cc1:CalendarExtender>                                
                             </div>
                             <div class="form-group">
                                <label>Trainer :</label>
                                <asp:TextBox ID="txtTrainer" CssClass="form-control" runat="server"></asp:TextBox>&nbsp;</td>
                             </div>
                            <div class="form-group">
                                <asp:Button ID="btnResourcePerson" runat="server" onclick="btnResourcePerson_Click" CssClass="btn btn-primary" 
                                    ValidationGroup="other" Text="Resource Person Wise" />
                                <asp:Button ID="btnResourcePersonExport" runat="server" onclick="btnResourcePersonExport_Click" 
                                    CssClass="btn btn-primary" ValidationGroup="other" Text="Export Resource Person" />
                            </div>
                        </div>

                     <div id="rptCostWise" runat="server" visible="false">
                         <div class="form-group">
                            <label>From Date:<span class="errormsg">*</span></label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="cost" ControlToValidate ="fromDate2" 
                                 ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                            <asp:TextBox ID="fromDate2" runat="server"  CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" TargetControlID="fromDate2">
                            </cc1:CalendarExtender>                            
                         </div>
                         <div class="form-group">
                            <label>To Date:<span class="errormsg">*</span></strong></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="cost" 
                                ControlToValidate ="toDate2" ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                            <asp:TextBox ID="toDate2" runat="server"  CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" TargetControlID="toDate2">
                            </cc1:CalendarExtender>                           
                         </div>
                         <div class="form-group">
                            <label>Cost Range From :</label>
                            <asp:TextBox ID="txtRangeFrom" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>Cost Range To :</label>
                            <asp:TextBox ID="txtRangeTo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                         <div class="form-group">
                             <asp:Button ID="btnCostWise" runat="server" onclick="btnCostWise_Click" CssClass="btn btn-primary" ValidationGroup="cost"
                                  Text="Training Cost Wise Rpt" />
                            <asp:Button ID="btnCostWiseExport" runat="server" onclick="btnCostWiseExport_Click" CssClass="btn btn-primary"
                                 ValidationGroup ="other" Text="Export Cost Wise" />
                         </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>









