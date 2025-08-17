<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="SalarySetAssignment.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.SalarySetAssignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">

        function CheckAll(obj) {

            var cBoxes = document.getElementsByName("chkId");
            for (var i = 0; i < cBoxes.length; i++) {

                cBoxes[i].checked = true;
            }
        }
        function UncheckAll(obj) {
            var cBoxes = document.getElementsByName("chkId");

            for (var i = 0; i < cBoxes.length; i++) {
                cBoxes[i].checked = false;
            }
        }

        function Calculate() {
            document.getElementById("<%=btnCalcGrade.ClientID %>").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            Salary Set Assignment
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <span class="txtlbl" >Please enter valid data! </span><span class="required" >&nbsp;(* Required fields)<br />
                                </span><br />               
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            </div>   
                            <div class="row">        
                                <div class="col-md-6 form-group">
                                    <label>Branch:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required!" 
                                        ControlToValidate="ddlBranchName" AutoComplete="Off" Display="Dynamic" ValidationGroup="search" 
                                        BorderColor="#FFFF66" SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="form-control" AutoPostBack="true" 
                                    onselectedindexchanged="ddlBranchName_SelectedIndexChanged" />
                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Department:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ErrorMessage="Required!" ControlToValidate="ddlDeptName" AutoComplete="Off"
                                                Display="Dynamic" ValidationGroup="search" BorderColor="#FFFF66"
                                                SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlDeptName" runat="server" CssClass="form-control"/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label>Salary Title:<span class="errormsg">*</span></label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required!" 
                                         ControlToValidate="ddlSalaryTitle" AutoComplete="Off" Display="Dynamic" ValidationGroup="search" 
                                         BorderColor="#FFFF66" SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlSalaryTitle" runat="server" CssClass="form-control"/>
                                </div>
                            </div>
                
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" onclick="btnSearch_Click" ValidationGroup="search" />
               
                            <div class="form-group">
                                <br/>
                                <div id="rpt" runat="server"></div>
                            </div>
                            <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>New Salary Set:<span class="errormsg">*</span></label> 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="ddlNewSalarySet" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="save" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="ddlNewSalarySet" runat="server" CssClass="form-control" AutoPostBack="true" onselectedindexchanged="ddlNewSalarySet_SelectedIndexChanged"/>
                                    </div>
                                </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                <label>No of Grade: <span class="errormsg">*</span></label> 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                ErrorMessage="Required!" ControlToValidate="txtGradeNo" AutoComplete="Off"
                                                Display="Dynamic" ValidationGroup="save" BorderColor="#FFFF66"
                                                SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtGradeNo" runat="server" CssClass="form-control" />
                                <asp:Button ID="btnCalcGrade" runat="server" onclick="btnCalcGrade_Click" style="display:none;" />
                                </div> 
                            </div>
                            </div>
                            <div class="form-group">
                                <label>Grade Amount: </label>  
                                <asp:TextBox ID="txtGradeAmt" runat="server" CssClass="form-control"   ReadOnly="True" />
                            </div>
                            <div id="rpt1" runat="server"></div>
                        <div class="row">
                        <div class="col-md-6">
                        <div class="form-group">
                        <label>Effective Date:<span class="errormsg">*</span></label> 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="txtEffectiveDate" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="save" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="form-control" />
                        <cc1:CalendarExtender ID="txtEffectiveDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtEffectiveDate">
                        </cc1:CalendarExtender>

                        </div>
                        </div>
                        <div class="col-md-6">
                        <div class="form-group">
                        <label>Applicable Date:<span class="errormsg">*</span></label> 
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="txtApplicableDate" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="save" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtApplicableDate" runat="server" CssClass="form-control" 
                         />
                        <cc1:CalendarExtender ID="txtApplicableDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtApplicableDate">
                        </cc1:CalendarExtender>
                        </div>
                        </div>
                        </div>
                        <div>
                                
                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary" 
                        ValidationGroup="save" onclick="BtnSave_Click"/>
                     
                        <cc1:confirmbuttonextender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:confirmbuttonextender>
                        <asp:Button ID="BtnDelete" runat="server" Text="" style="display:none"/>
            
                        <%--<asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                        Text="Back"  />--%>
                        </div>
                        </div>  

                        </div>
                    </section>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

