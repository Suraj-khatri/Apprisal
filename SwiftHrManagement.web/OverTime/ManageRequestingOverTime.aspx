<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageRequestingOverTime.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.ManageRequestingOverTime" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="updatepanel1" runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right" aria-hidden="true"></i>  
                        Over Time Login Entry
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                            <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Request Type:<asp:Label ID="Label5" runat="server" CssClass="required" Text="*" /></label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="DdlReqType" Display="Dynamic" ErrorMessage="*" 
                                SetFocusOnError="True" ValidationGroup="back" />
                            <asp:DropDownList ID="DdlReqType" runat="server" CssClass="form-control" onselectedindexchanged="DdlReqType_SelectedIndexChanged" AutoPostBack="true">   
                                <asp:ListItem Value="">Select</asp:ListItem>   
                                <asp:ListItem Value="650">Over Time </asp:ListItem>
                                <asp:ListItem Value="1453">HardShip Allowance</asp:ListItem>
                            </asp:DropDownList>
                           
                        </div>
                        <div class="form-group" runat="server" id="hardshipHead" visible="false">
                                <label>Hardship Head:<asp:Label ID="Label6" runat="server" CssClass="required" Text="*" /></label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="ddlHardshipHead" Display="Dynamic" ErrorMessage="*" 
                                    SetFocusOnError="True" ValidationGroup="back" />
                                <asp:DropDownList ID="ddlHardshipHead" runat="server" CssClass="form-control">   
                                </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Requisting With:<asp:Label ID="Label1" runat="server" CssClass="required" Text="*"></asp:Label></label>
                            <asp:RequiredFieldValidator ID="rfc" runat="server" 
                                ControlToValidate="DdlApprovedBy" Display="Dynamic" ErrorMessage="*" 
                                SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="DdlApprovedBy" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            
                        </div>
                        <div class="form-group" runat="server" id="oTDate">
                            <label>Requesting Date:<asp:Label ID="Label2" runat="server" CssClass="required" Text="*"></asp:Label></label>
                             <asp:RequiredFieldValidator ID="rfv" runat="server" 
                                ControlToValidate="txtdateIn" Display="Dynamic" ErrorMessage="*" 
                                SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtdateIn" runat="server" CssClass="form-control" 
                                AutoPostBack="True" ontextchanged="txtdateIn_TextChanged"></asp:TextBox>
                            <cc1:calendarextender id="EnteredDate_CalendarExtender" runat="server" 
                                enabled="true" enabledonclient="true" targetcontrolid="txtdateIn" /> 
                           
                        </div>
                        <div runat="server" id="hardShipDates">
                            <div class="form-group">
                                <label>From Date:<asp:Label ID="Label7" runat="server" CssClass="required" Text="*"></asp:Label></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtdateIn" Display="Dynamic" ErrorMessage="*" 
                                    SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" 
                                    AutoPostBack="True" ontextchanged="txtFromDate_TextChanged"></asp:TextBox>
                                <cc1:calendarextender id="Calendarextender1" runat="server" 
                                    enabled="true" enabledonclient="true" targetcontrolid="txtFromDate" /> 
                            </div>
                            <div class="form-group">
                                <label>To Date:<asp:Label ID="Label8" runat="server" CssClass="required" Text="*"></asp:Label></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtdateIn" Display="Dynamic" ErrorMessage="*" 
                                    SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" 
                                    AutoPostBack="True" ontextchanged="txtToDate_TextChanged"></asp:TextBox>
                                <cc1:calendarextender id="Calendarextender2" runat="server" 
                                    enabled="true" enabledonclient="true" targetcontrolid="txtToDate" /> 
                            </div>
                            <div class="form-group">
                                <label>No of Days:<asp:Label ID="LblDateMsg" runat="server" CssClass="errormsg"></asp:Label></label>
                                <asp:TextBox ID="txtNoOfDays" runat="server" CssClass="form-control" 
                                    AutoPostBack="True" Enabled="false" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            &nbsp;
                        </div>
                        <div class="form-group">
                            <strong>Attendance Details</strong>
                            <div id="rptAtt" runat="server"></div>
                        </div>
                        <div runat="server" id="timing">
                            <div class="form-group">
                                <label>From Time:<asp:Label ID="Label3" runat="server" CssClass="required" /></label>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" 
                                    ControlToValidate="ddlhourin" Display="Dynamic" ErrorMessage="*" InitialValue="" 
                                    SetFocusOnError="True"  ValidationGroup="back" />
                                <asp:RequiredFieldValidator ID="rfv3" runat="server" 
                                    ControlToValidate="ddlminutein" Display="Dynamic" ErrorMessage="*" 
                                    InitialValue="" SetFocusOnError="True" ValidationGroup="back" />
                                <div class="row">
                                    <div class="col-md-6">
                                    <asp:DropDownList ID="ddlhourin" runat="server" CssClass="form-control" 
                                        onselectedindexchanged="ddlhourin_SelectedIndexChanged" AutoPostBack="true"/>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlminutein" runat="server" CssClass="form-control" 
                                            onselectedindexchanged="ddlminutein_SelectedIndexChanged" AutoPostBack="true"/>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">    
                            <label>To Time:</label>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlhourout" runat="server" CssClass="form-control" 
                                            onselectedindexchanged="ddlhourout_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlminuteout" runat="server" CssClass="form-control" 
                                            onselectedindexchanged="ddlminuteout_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>Total Hours:</label>
                                <asp:TextBox ID="txtTotalTime" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Remarks:<asp:Label ID="Label4" runat="server" CssClass="required" Text="*"></asp:Label></label>
                            <asp:RequiredFieldValidator ID="rfv5" runat="server" 
                                ControlToValidate="txtRemarks" Display="Dynamic" ErrorMessage="*" 
                                SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSave0" runat="server" CssClass="btn btn-primary" 
                                    Text="Save" ValidationGroup="back" onclick="btnSave0_Click" />
                            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                                    Text="Delete" />
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Are you sure to delete?" Enabled="True" 
                                TargetControlID="BtnDelete">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                Text="Back" onclick="BtnBack_Click" />
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<%-- <script language="javascript" type="text/javascript">

          function AutocompleteOnSelected(sender, e) {
              var customerValueArray = (e._value).split("|");
              document.getElementById("<%=hdnemployeeID.ClientID%>").value = customerValueArray[1];
          }
    </script>--%>
</asp:Content>
