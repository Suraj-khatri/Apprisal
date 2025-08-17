<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="AppraisalCommitteeReviewMembers.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppprialCommitteeReview.AppprialCommitteeReviewMembers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">

        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").Value = EmpIdArray[1];
        }           
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Appraisal Review Committee
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required">&nbsp; (* Required fields)</span>
                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnRowid" runat="server" />
                    </div>
                    <div id="info" runat="server">
                    <div class="form-group ">
                        <label>Review Type:<span class="errormsg">*</span></label>
                        <asp:TextBox ID="reviewType" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div runat="server" visible="false">
                        <div class="form-group ">
                            <label>Member Position:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="reviewDdlType"
                                Display="dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="reviewDdlType" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group autocomplete-form">
                        <label>Member Name:<span class="errormsg">*</span></label>
                        <asp:Label ID="lblEmpName" runat="server" Font-Bold="True"></asp:Label>
                        <asp:HiddenField ID="hdnEmpName" runat="server" />
                        <asp:HiddenField ID="hddempId" runat="server" />
                        <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="on" AutoPostBack="true"
                            OnTextChanged="txtEmployee_TextChanged" CssClass="form-control"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                            CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true"
                            Enabled="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee" OnClientItemSelected="GetEmpName">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtEmployee" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                    <div class="form-group">
                        <label>From Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtFromDate"
                            Display="dynamic" ErrorMessage="Required" ValidationGroup="rating"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="TxtFromDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <label>To Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="frv" runat="server" ControlToValidate="txtToDate"
                            Display="dynamic" ErrorMessage="Required" ValidationGroup="rating"></asp:RequiredFieldValidator><br />
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtToDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <label>Is First Rater:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlRater"
                            Display="dynamic" ErrorMessage="Required" ValidationGroup="rating"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlRater" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Members" CssClass="btn btn-primary" ValidationGroup="rating"
                            OnClick="btnAdd_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" ValidationGroup="rating"
                            OnClick="btnUpdate_Click" Visible="false" />
                    </div>
                    <div id="rptComments" runat="server"></div>
                </div>
            </div>
        </section>
    </div>
</div>                                                                               
</asp:Content>
