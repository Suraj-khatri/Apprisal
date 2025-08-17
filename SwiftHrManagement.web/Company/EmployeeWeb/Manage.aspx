<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Jsfunc.js"></script>

    <style type="text/css">
        .ajax__calendar_container {
            z-index: 2 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="UPDATE1" runat="server">
        <ContentTemplate>
            <div class="employee-info">
                <div class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right" aria-hidden="true"></i> 
                        Employee Information Entry  
                        <span class="subheading">
                        <asp:Label ID="LblEmpName" runat="server"></asp:Label
                            ></span>
                    </header>
                </div>
                <div class="panel">
                    <div class="panel-body">
                        <div class="col-md-10">
                            <div class="empinfo">
                                <span class="txtlbl">Please enter valid data! </b></span><span class="required">(* Required fields)</span>
                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label><br />

                                <div id="showHide" runat="server" visible="false">
                                    Allow to update individual profile&nbsp;
                                    <asp:CheckBox ID="ChkInvProfileUpdate" runat="server" CssClass="saroj" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div align="right">

                                <%
                                    string imagename = GetProfileImages();
                                    string empid = GetEmployeeId().ToString();
                                    if (imagename == "")
                                    {
                                %>
                                <img src="../../Images/profile_icon.png" class="img-responsive img-thumbnail" style="height: 100px" />
                                <%
                                    }
                                    else
                                    {
                                %>
                                <img src="../../doc/<%=empid %>/<%=imagename%>" class="img-responsive img-thumbnail" />
                                <%
                                    }
                                %>
                            </div>
                        </div>

                    </div>
                </div>
                <form class="form-horizontal" role="form">
                    <div class="panel panel-default">
                        <header class="panel-heading">
                            Personal Information
                        </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Salutation:
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DdlSalutation"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="employee"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DdlSalutation" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Employee Code: 
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpCode"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="employee"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtEmpCode" runat="server"
                                        ValidationGroup="employee" MaxLength="30"
                                        AutoPostBack="True" OnTextChanged="txtEmpCode_TextChanged" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        First Name:
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        runat="server" ErrorMessage="Required!"
                                        ControlToValidate="txtfname" Display="Dynamic" ValidationGroup="employee"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtfname" runat="server" CssClass="form-control"
                                        ValidationGroup="employee" MaxLength="50" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Middle Name:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtmname" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Last Name:
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                        runat="server" ControlToValidate="txtlname" Display="Dynamic"
                                        ErrorMessage="Required!" ValidationGroup="employee" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtlname" runat="server" MaxLength="50" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 form-group ">
                                    <label>
                                        Gender:
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="ddlGender" Display="Dynamic"
                                        ErrorMessage="Required!" ValidationGroup="employee" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Date Of Birth:
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="txtdob" Display="Dynamic" ErrorMessage="Required!"
                                        ValidationGroup="employee" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtdob" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                        TargetControlID="txtdob">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Marital Status:
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                        ControlToValidate="ddlmeritalstatus" Display="Dynamic"
                                        ErrorMessage="Required!" ValidationGroup="employee" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlmeritalstatus" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Branch Name: 
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                        ControlToValidate="DdlBranchName" Display="Dynamic"
                                        ErrorMessage="Required!" ValidationGroup="employee" InitialValue="0" SetFocusOnError="True" />
                                    <asp:DropDownList ID="DdlBranchName" runat="server" EnableViewState="true"
                                        AutoPostBack="True" OnSelectedIndexChanged="DdlBranchName_SelectedIndexChanged" CssClass="form-control" Width="100%" />
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Department: 
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                        ControlToValidate="ddldepartment" Display="Dynamic"
                                        ErrorMessage="Required!" ValidationGroup="employee"
                                        InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddldepartment" runat="server" CssClass="form-control" Width="100%"
                                        OnSelectedIndexChanged="ddldepartment_OnSelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Sub Category/Department1:
                                    </label>
                                    <asp:DropDownList ID="subDeptDDL1" runat="server" CssClass="form-control" Width="100%" OnSelectedIndexChanged="subDeptDDL1_OnSelectedIndexChanged" AutoPostBack="True" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Sub Category/Department2:
                                    </label>
                                    <asp:DropDownList ID="subDeptDDL2" runat="server" CssClass="form-control" Width="100%" OnSelectedIndexChanged="subDeptDDL2_OnSelectedIndexChanged" AutoPostBack="True"/>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Position:
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                        ControlToValidate="ddlposition" Display="Dynamic"
                                        ErrorMessage="Required!" ValidationGroup="employee" SetFocusOnError="True" />
                                    <asp:DropDownList ID="ddlposition" runat="server" CssClass="form-control" Width="100%" />
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Salary Title:
                                    </label>
                                    <br />
                                    <asp:DropDownList ID="ddlSalaryTitle" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                </div>
                               
                                
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Functional Title:
                                    </label>
                                    <br />
                                    <asp:DropDownList ID="ddlFunTitle" runat="server" CssClass="form-control" Width="100%" />
                                </div>
                                <div class=" col-md-4 form-group ">
                                    <label>
                                        Attendance Card Number:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" Width="100%" />
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Date of Appointment: 
                                    </label>
                                    <span class="errormsg">*</span>
                                  <%--  <asp:RequiredFieldValidator
                                        ID="rfv" runat="server" ControlToValidate="txtAppointmentDate"
                                        Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True"
                                        ValidationGroup="employee"></asp:RequiredFieldValidator>--%>

                                    <asp:TextBox ID="txtAppointmentDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtAppointmentDate">
                                    </cc1:CalendarExtender>
                                </div>
                              
                                
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Date of Joining: 
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator
                                        ID="rfv1" runat="server" ControlToValidate="txtdoj" Display="Dynamic"
                                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="employee" />

                                    <asp:TextBox ID="txtdoj" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                        TargetControlID="txtdoj" />
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Gratuity Start Date:
                                    </label>
                                   
                                    <asp:TextBox ID="txtGratuityStartDate" runat="server" CssClass="form-control" Width="100%" />
                                    <cc1:CalendarExtender ID="ceGratuityStartDate" runat="server"
                                        TargetControlID="txtGratuityStartDate" />
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Employee Status:
                                    </label>
                                    <span class="errormsg">*</span>
                                    <asp:RequiredFieldValidator
                                        ID="rfv12" runat="server" ControlToValidate="DdlEmpStatus" Display="Dynamic"
                                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="employee" />
                                    <asp:DropDownList ID="DdlEmpStatus" runat="server" CssClass="form-control" Width="100%" />
                                </div>
                            
                                
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Blood Group:</label>
                                    <asp:DropDownList ID="ddlbloodgroup" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        PAN Number:
                                    </label>
                                   
                                    <asp:TextBox ID="txtpannumber" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtpannumber_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="txtpannumber">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Employee Type: 
                                    </label>
                                    <span class="errormsg">*</span><asp:RequiredFieldValidator
                                        ID="rfv21" runat="server" ControlToValidate="DdlEmpType" Display="Dynamic"
                                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="employee" />
                                    <asp:DropDownList ID="DdlEmpType" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DdlEmpType_SelectedIndexChanged" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div id="div_Contract_detail" runat="server" align="left" visible="false">
                                    <div class="col-md-4 form-group">
                                        From Date:<span class="errormsg">*
                                            <%--<asp:RequiredFieldValidator ID="Rffd1"
                                            runat="server" ControlToValidate="txtContractFrm" Display="None"
                                            ErrorMessage="Requierd!" SetFocusOnError="True" ValidationGroup="employee" Width="100%"></asp:RequiredFieldValidator>--%>
                                        </span>
                                        <asp:TextBox ID="txtContractFrm" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server"
                                            TargetControlID="txtContractFrm">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div class="col-md-4 form-group" >
                                        To Date:<span class="errormsg">*<%--<asp:RequiredFieldValidator ID="Rftd1"
                                            runat="server" ControlToValidate="txtContractTo" Display="None"
                                            ErrorMessage="Requierd!" SetFocusOnError="True" ValidationGroup="employee" CssClass="form-control"></asp:RequiredFieldValidator>--%></span><asp:CompareValidator ID="Cmv" runat="server" ControlToCompare="txtContractFrm"
                                            ControlToValidate="txtContractTo" Display="Dynamic"
                                            ErrorMessage="Invalid Date!" Operator="GreaterThanEqual" SetFocusOnError="True"
                                            Type="Date" ValidationGroup="employee"></asp:CompareValidator>

                                        <asp:TextBox ID="txtContractTo" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server"
                                            TargetControlID="txtContractTo">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div id="div_permamanent_date" runat="server" align="left" visible="false">
                                    <div class="col-md-4 form-group">
                                      <label>  Permanent Date:<span class="errormsg">*</label><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator10" runat="server"
                                            ControlToValidate="txtPermanentDate" Display="Dynamic" ErrorMessage="Requierd!"
                                            SetFocusOnError="True" ValidationGroup="employee" CssClass="form-control"></asp:RequiredFieldValidator>
                                        </span>
                                        <asp:TextBox ID="txtPermanentDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server"
                                            TargetControlID="txtPermanentDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Grade Year:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtGradeYear" runat="server" CssClass="form-control" Width="100%">        
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Last Promoted:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtlastpromoted" runat="server" CssClass="form-control" Width="100%">        
                                    </asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server"
                                        TargetControlID="txtlastpromoted" CssClass="form-control" />
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Last Transfer:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtlasttransfer" runat="server" CssClass="form-control" Width="100%">        
                                    </asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server"
                                        TargetControlID="txtlasttransfer" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <header class="panel-heading">
                            Permanent Address 
                        </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Country:
                                    </label>
                                    <br />
                                    <asp:DropDownList ID="DdlPerCountry" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Zone:
                                    </label>
                                    <br />
                                    <asp:DropDownList ID="DdlPerZone" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="DdlPerZone_SelectedIndexChanged" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        District:
                                    </label>
                                    <br />
                                    <asp:DropDownList ID="DdlPerDistrict" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Municipality/VDC:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="TxtPerMVDC" runat="server" Width="100%"
                                        MaxLength="100" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Ward No:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="TxtPerWardno" runat="server" Width="100%"
                                        MaxLength="10" CssClass="form-control"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="TxtPerWardno_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="TxtPerWardno">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        House No:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="TxtPerHouseno" runat="server" Width="100%"
                                        MaxLength="10" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Street Name:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="TxtPerStreetName" runat="server" Width="100%"
                                        MaxLength="100" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row form-inline">
                                <div class="col-md-12 form-group">
                                    <label>
                                        <a href="">
                                            <asp:LinkButton ID="btnLink" runat="server" OnClick="btnLink_Click"
                                                Text="Copy Permanent To Temporary"></asp:LinkButton></a>
                                    </label>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="panel panel-default">
                        <header class="panel-heading">
                    Temporary Address 
              </header>
                        <div class="panel-body">




                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Country:
                                    </label>
                                    <br />
                                    <asp:DropDownList ID="DdlTempCountry" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Zone:
                                    </label>
                                    <br />
                                    <asp:DropDownList ID="DdlTempZone" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="DdlTempZone_SelectedIndexChanged" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        District:
                                    </label>
                                    <br />
                                    <asp:DropDownList ID="DdlTempDistrict" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Municipality/VDC:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="TxtTempMVDC" runat="server"
                                        MaxLength="100" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Ward No:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="TxtTempWardno" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="TxtTempWardno_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="TxtTempWardno">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        House No:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="TxtTempHouseno" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Street Name:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="TxtTempStreetName" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <header class="panel-heading">
                    Contact Information 
              </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Phone (Office):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtphonoff" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtphonoff_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtphonoff">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Phone (Res):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtphonres" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtphonres_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtphonres">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Mobile (Office):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtmoboff" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtmoboff_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtmoboff">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Mobile (Personal):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtmobpersonal" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtmobpersonal_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="txtmobpersonal">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class=" col-md-4 form-group">
                                    <label>
                                        Fax (Office):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtfaxoffice" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtfaxoffice_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="txtfaxoffice">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class=" col-md-4 form-group">
                                    <label>
                                        Fax (Personal):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtfaxpersonal" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtfaxpersonal_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="txtfaxpersonal">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Extension No:</label><br />
                                    <asp:TextBox ID="txtExtensionNO" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtExtensionNO">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Email (Office):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtemailoffice" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="txtemailoffice" ErrorMessage="Invalid Email!"
                                        SetFocusOnError="True"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Email (Personal):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtemailoffpersonal" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                        ControlToValidate="txtemailoffpersonal" ErrorMessage="Invalid Email!"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <header class="panel-heading">
                  Emergency Contact Information 
              </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Contact Person Name
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtEmName" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Address:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtEmAddress" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Relationship:
                                    </label>
                                    <br />
                                    <asp:DropDownList ID="ddlRelationship" runat="server" Width="100%" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Contact No(1):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtFristContactNumber" runat="server" Width="100%"
                                        CssClass="form-control"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                        runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="txtFristContactNumber">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Contact No(2):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtSecondContactNumber" runat="server" Width="100%"
                                        CssClass="form-control"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                        runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="txtSecondContactNumber">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        Contact No(3):
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtThirdContactNumber" runat="server" Width="100%"
                                        CssClass="form-control"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                        runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="txtThirdContactNumber">
                                    </cc1:FilteredTextBoxExtender>
                                </div>
                            </div>

                            <div class="row ">

                                <div class="col-md-4 form-group">
                                    <label>
                                        Email:
                                    </label>
                                    <br />
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                        ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Invalid Email!"
                                        SetFocusOnError="True"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="row form-inline">
                                <div class="col-md-12 form-group">
                                    <div id="showHideSaveBtn" runat="server">
                                        <asp:Button ID="btnSave" runat="server"
                                            OnClick="btnSave_Click" Text="Save" ValidationGroup="employee" CssClass="btn btn-md btn-primary" />
                                         <asp:Label ID="LblMsg1" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div id="showHideDeleteBtn" runat="server">
                                        <asp:Button ID="BtnDelete" runat="server"
                                            OnClick="BtnDelete_Click" Text="Delete" CssClass="btn btn-md btn-primary" />
                                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                                        </cc1:ConfirmButtonExtender>
                                        <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server"
                                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                                        </cc1:ConfirmButtonExtender>
                                        <%--<asp:Button ID="BtnBack" runat="server" CssClass="button" 
                                    Text="&lt;&lt; Back" onclick="BtnBack_Click" Width="75px" />--%>
                                   
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
