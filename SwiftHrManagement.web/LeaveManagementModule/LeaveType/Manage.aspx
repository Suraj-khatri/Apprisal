<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveType.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <script type="text/javascript" language="javascript">

        function showHelp(val) {
            var msg;
            if (val == "LeaveDetails")
                msg = "Leave Details"
                        + "\nCashable: The unused Leave days gets cashed at the end of the Year/ Tenure."
                        + "\nHalf Day: The Leave Request can be applied as a half day."
                        + "\nSaturday: If applied leave has a saturday in between the leave start date and the leave end date,"
                        + "\n\t\tYes- includes saturday as a leave day."
                        + "\n\t\tNo - excludes Saturday from the leave."
                        + "\nHoliday: If applied leave has a holiday in between the leave start date and the leave end date,"
                        + "\n\t\tYes- Includes holiday as a leave day."
                        + "\n\t\tNo - Excludes holiday from the leave."
                        + "\nUnlimited: Allows to apply leave for any no. of days."
                        + "\nSubstitute: Allows to apply leave for the day(Saturday/holiday), the employee worked";

            alert(msg);
        }

    </script>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div class="col-md-8 col-md-offset-2">
                <div class="panel">
                    <header class="panel-heading">
                     <i class="fa fa-caret-right"></i>
                       Leave Type Entry Details
                    </header>
                    <div class="col-md-12">
                        Please enter valid data!
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12">&nbsp;</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Leave Details:</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                <label>Leave type:<span class="required">*</span></label>
                                <asp:DropDownList ID="DdlLeaveName" runat="server" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Rfd1" runat="server"
                                    ControlToValidate="DdlLeaveName" Display="Dynamic" ErrorMessage="Required!"
                                    ValidationGroup="LeaveType" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Is Active:</label>
                                <asp:DropDownList ID="DdlIsActive" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 form-group">
                                    <label>Description:</label>
                                    <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label><strong>Days:</strong> </label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Default Days: </label>
                                    <asp:TextBox ID="TxtDefaultDays" runat="server" CssClass="form-control"
                                        OnTextChanged="TxtDefaultDays_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="Rgexp1" runat="server" Display="Dynamic"
                                        ErrorMessage="Invalid Days" ControlToValidate="TxtDefaultDays" ValidationGroup="LeaveType"
                                        ValidationExpression="^([0-9]*)(.([0,5]))?$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Max Accumulation:</label>
                                    <asp:TextBox ID="TxtMaxAccumulation" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="Regexp2" runat="server" Display="Dynamic"
                                        ErrorMessage="Invalid Days" ControlToValidate="TxtMaxAccumulation" ValidationGroup="LeaveType"
                                        ValidationExpression="^([0-9]*)(.([0,5]))?$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Occurrence:</label>
                                    <asp:DropDownList ID="DdlOccurrence" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Yearly">Yearly</asp:ListItem>
                                        <asp:ListItem Value="Tenure">Tenure</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Maximum Days in a Year : </label>
                                    <asp:TextBox ID="TxtMaxDays" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                        ErrorMessage="Invalid Days" ControlToValidate="TxtMaxDays" ValidationGroup="LeaveType"
                                        ValidationExpression="^([0-9]*)(.([0,5]))?$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>LFA :</label>
                                    <asp:DropDownList ID="DdlLfaDays" runat="server" CssClass="form-control"
                                        OnSelectedIndexChanged="DdlLfaDays_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:Panel ID="PnlLfaDays" runat="server" Visible="false">
                                        <div align="left">
                                            <label>LFA Days: </label>
                                            <asp:TextBox ID="TxtNoofLfadays" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="Regexp3" runat="server" Display="Dynamic"
                                                ErrorMessage="Invalid Days" ControlToValidate="TxtNoofLfadays" ValidationGroup="LeaveType"
                                                ValidationExpression="^([0-9]*)(.([0,5]))?$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Maximum Days per Request :</label>
                                    <asp:TextBox ID="TxtMaxReqDays" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegExp" runat="server" Display="Dynamic"
                                        ErrorMessage="Invalid Days" ControlToValidate="TxtMaxReqDays" ValidationGroup="LeaveType"
                                        ValidationExpression="^([0-9]*)(.([0,5]))?$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Minimum Days per Request :</label>
                                    <asp:TextBox ID="txtMinReqDays" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                        ErrorMessage="Invalid Days" ControlToValidate="txtMinReqDays" ValidationGroup="LeaveType"
                                        ValidationExpression="^([0-9]*)(.([0,5]))?$" SetFocusOnError="True">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                        <label><strong>Leave Details:</strong></label>
                                        <label><a title='Click to see help' onclick="showHelp('LeaveDetails');"  style="text-decoration:none;">&nbsp;&nbsp;<i class="fa fa-question-circle" style="font-size:18px; text-decoration:none; cursor:pointer;"></i></a></strong></label></a>
                                    </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Cashable:</label>
                                    <asp:DropDownList ID="DdlCashable" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Half Day:</label>
                                    <asp:DropDownList ID="DdlHalfDay" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Saturday :</label>
                                    <asp:DropDownList ID="DdlSaturday" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Holiday:</label>
                                    <asp:DropDownList ID="DdlHoliday" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Unlimited :</label>
                                    <asp:DropDownList ID="DdlUnlimited" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Substitute:</label>
                                    <asp:DropDownList ID="DdlSubstitute" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Relieving Arrangement:</label>
                                    <asp:DropDownList ID="DdlRelieving" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row col-md-12">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    ValidationGroup="LeaveType" OnClick="BtnSave_Click" />
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                                    Text="Delete" OnClick="BtnDelete_Click" />
                                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                                </cc1:ConfirmButtonExtender>
                                &nbsp;<asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    Text="Back" OnClick="BtnBack_Click" />
                            </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
