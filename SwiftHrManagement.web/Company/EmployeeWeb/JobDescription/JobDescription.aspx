<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="JobDescription.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.JobDescription.JobDescription" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style >
        .ajax__calendar .ajax__calendar_container {
    border: 1px solid #646464;
    background-color: #ffffff;
    color: #000000;
    z-index: 99999999;
}
    </style>
    <script type="text/javascript" language="javascript">
        function Delete() {
            if (confirm("Please Confirm to Delete")) {
                document.getElementById("<%=hdnDel.ClientID%>").value = id;
                document.getElementById("<%=hdnBtn.ClientID%>").click();
            }
        }
    </script>
    <script  src="<%=ResolveUrl("/Theme/bower_components/jquery/dist/jquery.js") %>" ></script>
     <script src="<%=ResolveUrl("/Theme/bower_components/dist/js/bootstrap-datepicker.js")%>" ></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="Panel1" runat="server">
        <ContentTemplate>
            <div class="row autocomplete-form" onload="myFunction()">
                <div class="col-md-8 col-md-offset-2">
                    <asp:HiddenField ID="hdnJobHold" runat="server" />
                    <asp:HiddenField ID="hdbBranch" runat="server" />
                    <asp:HiddenField ID="hdnFuncTitle" runat="server" />
                    <asp:HiddenField ID="hdnPosition" runat="server" />
                    <asp:HiddenField ID="hdnRptTo" runat="server" />
                    <asp:HiddenField ID="hdnSuperVis" runat="server" />
                    <asp:HiddenField ID="HdnEmpType" runat="server" />
                    <asp:HiddenField ID="hdnDel" runat="server" />
                    <div class="panel">
                        <header class="panel-heading">
                         <i class="fa fa-caret-right"></i>Job Description
                        </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <span class="txtlbl">Please enter valid data! </b></span>
                                    <span class="required">(* Required fields)</span><br />

                                </div>
                                <div class="col-md-12 form-group">
                                    <label>Job Holder:</label>
                                    <asp:TextBox ID="txtJobHolder" runat="server" AutoComplete="Off"
                                        AutoPostBack="true" CssClass="form-control" OnTextChanged="txtJobHolder_OnTextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Rfd1" runat="server"
                                        ControlToValidate="txtJobHolder" Display="Dynamic" ErrorMessage="*"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                        DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeListJD"
                                        ServicePath="~/Autocomplete.asmx" TargetControlID="txtJobHolder"  UseContextKey="true">
                                    </cc1:AutoCompleteExtender>

                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Branch:</label>
                                    <asp:Label ID="lblBranch" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Functional Title:</label>
                                    <asp:Label ID="lblFuncTitle" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Corporate Title:</label>
                                    <asp:Label ID="lblCorpTitle" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="col-md-12 form-group">
                                    <label>Supervisor:<span class="errormsg">*</span></label>
                                    <asp:TextBox ID="txtSuperVis" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                                </div>
                                <%--StartEndDate Start--%>
                                <div class="col-md-4 form-group">
                                    <label>Start Date:</label>

                                    <!-- TextBox for date input with placeholder in MM/DD/YYYY format -->
                                    <asp:TextBox ID="startDate" runat="server" CssClass="form-control" placeholder="MM/DD/YYYY" AutoPostBack="false"></asp:TextBox>

                                    <!-- CalendarExtender using MM/dd/yyyy format -->
                                    <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" Enabled="True" 
                                        TargetControlID="startDate" Format="MM/dd/yyyy"></cc1:CalendarExtender>

                                    <!-- RangeValidator for validating the date range in MM/dd/yyyy format -->
                                    <asp:RangeValidator ID="rvDate" runat="server" ControlToValidate="startDate" 
                                        ErrorMessage="Invalid Date" Type="Date" 
                                        MinimumValue="01/01/2000" MaximumValue="01/01/2100" Display="Dynamic">
                                    </asp:RangeValidator>

                                    <!-- RequiredFieldValidator to ensure date is entered -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="startDate" Display="Dynamic" ErrorMessage="*" 
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-4 form-group">
                                    <label>End Date:</label>
    
                                    <!-- TextBox for end date input with placeholder in MM/DD/YYYY format -->
                                    <asp:TextBox ID="endDate" runat="server" CssClass="form-control" OnTextChanged="endDate_OnTextChanged" AutoPostBack="false" placeholder="MM/DD/YYYY"></asp:TextBox>

                                    <!-- CalendarExtender using MM/dd/yyyy format -->
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="endDate" Format="MM/dd/yyyy"></cc1:CalendarExtender>

                                    <!-- Label to display error messages -->
                                    <asp:Label ID="LblDate" runat="server"></asp:Label>

                                    <!-- RangeValidator for validating the date range in MM/dd/yyyy format -->
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="endDate" 
                                        ErrorMessage="Invalid Date" Type="Date" 
                                        MinimumValue="01/01/1900" MaximumValue="01/01/2100" Display="Dynamic"></asp:RangeValidator>

                                    <!-- RequiredFieldValidator to ensure date is entered -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="endDate" Display="Dynamic" ErrorMessage="*" 
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>

                                <%--StartEndDate End--%>
                                <div class="col-md-10 form-group">
                                    <label>Staffs Reporting to Appraisee: <span class="errormsg"><%--*--%></span></label>
                                    <asp:TextBox ID="staffRptto" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="staffRptto" Display="Dynamic" ErrorMessage="*"
                                        ValidationGroup="Req" SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                        DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                        ServicePath="~/Autocomplete.asmx" TargetControlID="staffRptto">
                                    </cc1:AutoCompleteExtender>
                                </div>
                                <div class="col-md-2 form-group" align="right">
                                    <br />
                                    <asp:Button ID="btnAdd" CssClass="btn btn-primary" Text="Add" OnClick="btnAdd_OnClick" ValidationGroup="Req" runat="server" />
                                </div>
                                <div class="col-md-12 form-group">
                                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                                    <ContentTemplate>--%>
                                    <div id="rptDiv" runat="server"></div>
                                    <%--</ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="hdnBtn" EventName="Click" />
                                        </Triggers>
                                        </asp:UpdatePanel>--%>
                                </div>
                                <div class="col-md-12 form-group">
                                    <label>Key Competencies:</label>
                                    <asp:TextBox ID="txtKeyComp" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                        ControlToValidate="txtKeyComp" Display="Dynamic" ErrorMessage="*"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12 form-group">
                                    <label>Functional Objectives:</label>
                                    <asp:TextBox ID="txtObj" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txtObj" Display="Dynamic" ErrorMessage="*"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    <label>Detail Job Description:</label>
                                </div>
                                <div class="col-md-12 form-group">
                                    <asp:TextBox ID="txtGeneralJd" runat="server" TextMode="MultiLine" CssClass="form-control" Height="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="txtGeneralJd" Display="Dynamic" ErrorMessage="*"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>

                                 <div class="col-md-12">
                                     <asp:Label ID="lblDisagree"  runat="server"> Reason of Disagree:</asp:Label>
                                    
                                </div>
                                <div class="col-md-12 form-group">
                                    <asp:TextBox ID="txtDisagree" TextMode="MultiLine"  runat="server" CssClass="form-control" Height="200px"></asp:TextBox>
                                    
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_OnClick" CssClass="btn btn-primary" Text="Save"
                                        ValidationGroup="Request" OnClientClick=" return confirm('are you sure you want to cintinue?');" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="BtnSave"
                                        ConfirmText="Please Confirm!" runat="server">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="btnAccept" runat="server" CssClass="btn btn-primary" OnClick="btnAccept_OnClick" Text="Accept"
                                        Visible="False" OnClientClick=" return confirm('are you sure you want to cintinue?');" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" TargetControlID="btnAccept"
                                        ConfirmText="Please Confirm!" runat="server">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="btnAssign" runat="server" CssClass="btn btn-primary" OnClick="btnAssign_OnClick" Text="Approve"
                                        Visible="False" OnClientClick=" return confirm('are you sure you want to Assign?');"/>
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" OnClick="btnUpdate_OnClick" Text="Update"
                                        Visible="False" OnClientClick=" return confirm('are you sure you want to Update?');"/>
                                    <asp:Button ID="btnDisagree" runat="server" CssClass="btn btn-primary" OnClick="btnDisagree_OnClick" Text="Disagree"
                                        Visible="False" OnClientClick=" return confirm('are you sure you want to Disagree this JD?');"/>
                                    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" OnClick="BtnDelete_OnClick" Text="Delete"  Visible="False" OnClientClick="return confirm('are you sure you want to Delete this JD?');" />

                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" TargetControlID="btnAssign"
                                        ConfirmText="Please Confirm!" runat="server">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_OnClick" CssClass="btn btn-primary"
                                        Text="Back" />
                                    &nbsp;  
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                </div>
                                <div>&nbsp;</div>
                                <div class="col-md-12" id="label" visible="False" runat="server">
                                    <div class="col-md-6" align="left">
                                        Name of the Job Holder<br />
                                        <asp:Label ID="lblJobHold" runat="server"></asp:Label><br />
                                        <asp:Label runat="server" ID="date"></asp:Label>

                                    </div>
                                    <div class="col-md-6" align="right">
                                        Name of the Supervisor
                                        <br />
                                        <asp:Label ID="lblSupvis" runat="server"></asp:Label><br />
                                        <asp:Label runat="server" ID="date1"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>

    </asp:UpdatePanel>
    <asp:Button ID="hdnBtn" runat="server" Style="display: none;" OnClick="hdnBtn_OnClick"></asp:Button>
</asp:Content>
