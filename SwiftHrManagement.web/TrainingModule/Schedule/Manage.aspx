<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingModule.Schedule.Manage" %>
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
                    Manage Schedule
                    <asp:Label ID="LblEmpName" runat="server" Text=""></asp:Label>
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl" >Please enter valid  data!</span><span class="required" > (* Required fields)</span>         
                        <asp:Label ID="LblMsg" runat="server"></asp:Label> 
                    </div>
                    <div class="form-group">
                        <label>Training Program Name:<span class="errormsg">*</span></label>
                        <asp:Label ID="lblProgramName" runat="server" ></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Date:<span class="errormsg">*</span></label>
                         <asp:TextBox ID="txtDate" runat="server" CssClass="form-control"></asp:TextBox>               
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                             runat="server" ControlToValidate="txtDate" Display="dynamic" 
                             ErrorMessage="Required!" ValidationGroup="sch" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>                
                        <cc1:CalendarExtender ID="EndDate_CalendarExtender" runat="server" 
                             Enabled="True" TargetControlID="txtDate">
                         </cc1:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <label>From Time:<span class="errormsg">*</span></label>
                         <asp:TextBox ID="txtFromTime" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                             runat="server" ControlToValidate="txtFromTime" Display="dynamic" 
                             ErrorMessage="Required!" ValidationGroup="sch" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>To Time:<span class="errormsg">*</span></label>
                        <asp:TextBox ID="txtToTime" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" ControlToValidate="txtToTime" Display="dynamic" 
                                ErrorMessage="Required!" ValidationGroup="sch" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Topic:<span class="errormsg">*</span></label>
                        <asp:TextBox ID="txtTopic" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                             runat="server" ControlToValidate="txtTopic" Display="dynamic" 
                             ErrorMessage="Required!" ValidationGroup="sch" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Trainer:<span class="errormsg">*</span></label>
                        <asp:TextBox ID="txtTrainer" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                             runat="server" ControlToValidate="txtTrainer" Display="dynamic" 
                             ErrorMessage="Required!" ValidationGroup="sch" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" onclick="btnSave_Click" Text=" Save " 
                            ValidationGroup="sch"/>                    
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>                
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" onclick="btnBack_Click" Text="Back" />                
                    </div>
                    <div class="form-group">
                        &nbsp;
                    </div>
                    <div id="rpt" runat="server"></div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
