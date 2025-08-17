<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.AddSchedule" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript" language="javascript">
            function IsDelete(id) {
                if (confirm("Confirm Delete?")) {
                    document.getElementById("<% =hdnId.ClientID %>").value = id;
                    document.getElementById("<% =btnDeleteRecord.ClientID %>").click();
                }
            }
            </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" onclick="btnDeleteRecord_Click" style="display:none;"/>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                         Add Weekly Schedule
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label> 
                            <label>Weekly Schedule Name:</label>
                            <asp:Label ID="lblWeeklyName" runat="server" CssClass="form-control"></asp:Label> 
                        </div>
                        <div class="form-group">
                            <label>Day:<span class="errormsg">*</span></label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDayName" 
                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="add"> 
                            </asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlDayName" runat="server" CssClass="form-control"></asp:DropDownList>                               
                        </div>    
                        <div class="row">                    
                            <div class="col-md-8 form-group">
                                <label>Login Time:</label>
                            </div>
                            <div class="col-md-6 form-group">
                                <asp:DropDownList ID="ddlHourIn" runat="server" CssClass="form-control" AutoPostBack="true" 
                                    onselectedindexchanged="ddlHourIn_SelectedIndexChanged">              
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <asp:DropDownList ID="ddlMinuteIn" runat="server" CssClass="form-control" AutoPostBack="true" 
                                    onselectedindexchanged="ddlMinuteIn_SelectedIndexChanged">              
                                </asp:DropDownList>                  
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddlHourIn" Display="Dynamic"
                                    ErrorMessage="Required!" InitialValue="" SetFocusOnError="True" ValidationGroup="add">
                                </asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="rfv3" runat="server" 
                                    ControlToValidate="ddlMinuteIn" Display="Dynamic" ErrorMessage="Required!" 
                                    InitialValue="" SetFocusOnError="True" ValidationGroup="add">
                                </asp:RequiredFieldValidator>
                            </div>    
                        </div>
                        <div class="row">                    
                            <div class="col-md-8 form-group">
                                <label> Working Hours (HH:MM):</label>
                            </div>
                            <div class="col-md-6 form-group">
                                <asp:DropDownList ID="ddlWorkingHour" runat="server" CssClass="form-control" AutoPostBack="true" 
                                    onselectedindexchanged="ddlWorkingHour_SelectedIndexChanged">              
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <asp:DropDownList ID="ddlWorkingMinute" runat="server" CssClass="form-control" AutoPostBack="true" 
                                     onselectedindexchanged="ddlWorkingMinute_SelectedIndexChanged">              
                                </asp:DropDownList>                  
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="ddlWorkingHour" Display="Dynamic" ErrorMessage="Required!" InitialValue="" 
                                    SetFocusOnError="True"  ValidationGroup="add"  >
                                </asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="ddlWorkingMinute" Display="Dynamic" ErrorMessage="Required!" 
                                    InitialValue="" SetFocusOnError="True" ValidationGroup="add">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Status:</label>
                            <asp:DropDownList ID="ddlIsActive" runat="server" CssClass="form-control">
                                <asp:ListItem Value="Active">Active</asp:ListItem>
                                <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                            </asp:DropDownList> 
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSave" ValidationGroup="add" runat="server" CssClass="btn btn-primary" Text=" Save " 
                                onclick="btnSave_Click"  />
                            <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="btnSave">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text=" Delete " 
                                onclick="btnDelete_Click" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                                ConfirmText="Confirm to Delete?" Enabled="True" TargetControlID="btnDelete">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" />
                        </div>
                        <div id="rpt" runat="server"></div>
                    </div>
                </section>
            </div>
        </div>
</asp:Content>
