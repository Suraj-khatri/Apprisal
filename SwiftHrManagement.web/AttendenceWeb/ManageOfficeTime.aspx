<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageOfficeTime.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.ManageOfficeTime" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .borderless td, .borderless th {
            border-top: none !important;
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Office Time SetUp
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                        <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-2 form-group">
                            <label>Office Timing:</label><span class="errormsg">*</span>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="ddlOfficeTiming" Display="Dynamic" ErrorMessage="Required" 
                                    SetFocusOnError="True" ValidationGroup="Ot"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlOfficeTiming" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="s">Summer Timing</asp:ListItem>
                                <asp:ListItem Value="w">Winter Timing</asp:ListItem>
                                <asp:ListItem Value="f">Friday Timing</asp:ListItem>
                            </asp:DropDownList>                            
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group table-responsive">
                            <table class="table borderless">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>Date:<span class="errormsg">*</span></td>
                                    <td>Time:<span class="errormsg">*</span></td>
                                    <td> Tolerance:</td>
                                </tr>
                                <tr>
                                    <td><label>From:</label></td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox> <br />
                                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                                            Enabled="True" TargetControlID="txtFromDate">
                                        </cc1:CalendarExtender> 
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromTime" runat="server" CssClass="form-control"></asp:TextBox>  <br />
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromTime"
                                        Mask="99:99:99" MessageValidatorTip="true" MaskType="Time" InputDirection="RightToLeft"
                                        ErrorTooltipEnabled="True" />
                                          
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToleranceStartTime" runat="server" Text="00:00:00" CssClass="form-control"></asp:TextBox>  <br />
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtToleranceStartTime"
                                        Mask="99:99:99" MessageValidatorTip="true" MaskType="Time" InputDirection="RightToLeft"
                                        ErrorTooltipEnabled="True" />                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td><label>To:</label></td>
                                    <td>
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>  <br />
                                        <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                                            Enabled="True" TargetControlID="txtToDate">
                                        </cc1:CalendarExtender>  
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToTime" runat="server" CssClass="form-control"></asp:TextBox>  <br />
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtToTime"
                                        Mask="99:99:99" MessageValidatorTip="true" MaskType="Time" InputDirection="RightToLeft"
                                        ErrorTooltipEnabled="True" />

                                        
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToleranceEndTime" runat="server" Text="00:00:00" CssClass="form-control"></asp:TextBox>  <br />
                                        

                                        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtToleranceEndTime"
                                        Mask="99:99:99" MessageValidatorTip="true" MaskType="Time" InputDirection="RightToLeft"
                                        ErrorTooltipEnabled="True" />

                                        <cc1:MaskedEditValidator ID="MaskedEditValidator4" runat="server" ControlExtender="MaskedEditExtender2"
                                        ControlToValidate="txtToleranceEndTime" IsValidEmpty="false" MaximumValue="23:59:59" MinimumValue="00:00:00"
                                        EmptyValueMessage="Enter Time" MaximumValueMessage="23:59:59" InvalidValueBlurredMessage="Time is Invalid"
                                        MinimumValueMessage="Time must be grater than 00:00:00" EmptyValueBlurredText="*"
                                        SetFocusOnError="true" ForeColor="Red" ValidationGroup="Ot"
                                        ToolTip="Enter time between 00:00:00 to 23:59:59">
                                        </cc1:MaskedEditValidator> 
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">

                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary" 
                         ValidationGroup="Ot" onclick="BtnSave_Click1" />
                        <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>

        <%--                  <asp:Button ID="Btn_delete" runat="server" Text="Delete" CssClass="button" 
                          onclick="Btn_delete_Click" />
                          <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="Btn_delete">
                            </cc1:ConfirmButtonExtender>--%>

                  
                          <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn btn-primary" 
                          onclick="BtnBack_Click"  />

                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>