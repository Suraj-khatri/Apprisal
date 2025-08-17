<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true"
    CodeBehind="LevelCriticalJobs.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.LevelCriticalJobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //Criticle Job
        function onDeleteCJ(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId1CJ.ClientID%>").value = id;
                document.getElementById("<% =BtnDeleteRecordCJ.ClientID%>").click();
            }
        }
        function onEditCJ(id) {
            document.getElementById("<% =hdnId2CJ.ClientID%>").value = id;
            document.getElementById("<% =BtnEditRecordCJ.ClientID%>").click();
        }
        function EditDataCJ(id) {
            if (confirm("Are you sure, you want to save?")) {
                document.getElementById("<% =hdnId2CJ.ClientID%>").value = id;
                document.getElementById("<% =saveBtnCJ.ClientID%>").click();
            }
        }
        function CancelCJ() {
            //if (confirm("Are you sure, you want to cancel?")) {
            document.getElementById("<% =cancelCJ.ClientID%>").click();
            //}
        }
        //function isNumber(evt) {
        //    evt = (evt) ? evt : window.event;
        //    var charCode = (evt.which) ? evt.which : evt.keyCode;
        //    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        //        return false;
        //    }
        //    return true;
        //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="col-md-10 col-md-offset-1">
        <div class="panel">
            <header class="panel-heading">
                   <a href="CompetancyList.aspx"><i class="fa fa-caret-right"></i></a>
             Critical Jobs

                </header>
            <div id="criticalJobs" runat="server">
                <section class="panel">               
                  <div><div class="container"><div style="padding:10px;position:relative;"> <span style="position:absolute;left:-5px;top:10px">B.</span> Following critical jobs are expected to be completed on a regular basis failure in completion will <br />  reduce the overall performance score of the appraisee </div></div>
                </div>
                <div class="panel-body">
                    <div class="form-group row">
                         <div class="col-md-12 form-group">
                    <label>
                        Level Name:
                    </label>
                    <asp:Label runat="server" ID="lblLevelName"></asp:Label>

                </div>
                        <div class="col-md-6">
                            <label>Objectives:</label>
                            <span class="errormsg">*</span>
                            <asp:RequiredFieldValidator
                                ID="RFV1" runat="server" ControlToValidate="txtObjectives"
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="user"
                                SetFocusOnError="True" CssClass="danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                             <asp:HiddenField ID="hdnEmpName" runat="server" />
                            <label>Deduction Score:</label>
                            <span class="errormsg">*</span>
                            <asp:RequiredFieldValidator
                                ID="RFV2" runat="server" ControlToValidate="txtDeductionScore"
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="user"
                                SetFocusOnError="True" CssClass="danger"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-md-6">
                            <asp:TextBox ID="txtObjectives" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDeductionScore" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add"
                                Font-Strikeout="False" ValidationGroup="user" OnClick="BtnSaveCJ_Click"
                                Width="75px" />
                        </div>
                    </div>

                    <div class="clearfix"></div>

                    <table class="table table-bordered mtop10">
                        <thead>
                            <tr>
                                <th>SNO</th>
                                <th>Objectives</th>
                                <th>Deduction Score</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody id="criticalJobs_grid" runat="server">
                        </tbody>
                    </table>

                    <%--<p>Note:Total sum of “Deduction points of all allocated critical jobs” should not be more than 5. </p>--%>
                </div>
                </section>
            </div>

            <asp:HiddenField ID="hdnId2CJ" runat="server" />
            <asp:HiddenField ID="hdnId1CJ" runat="server" />
            <asp:Button ID="BtnEditRecordCJ" runat="server" OnClick="BtnEditRecordCJ_Click" Style="display: none;" />
            <asp:Button ID="saveBtnCJ" runat="server" OnClick="saveBtnCJ_Click" Style="display: none;" />
            <asp:Button ID="cancelCJ" runat="server" OnClick="cancelCJ_Click" Style="display: none;" />
            <asp:Button ID="LoadCJGrid" runat="server" OnClick="LoadCJGrid_Click" Style="display: none;" />
            <asp:Button ID="BtnDeleteRecordCJ" runat="server" OnClick="BtnDeleteRecordCJ_Click"
                Style="display: none;" />
            <%--CRITICAL JOB END --%>
        </div>
    </div>
    <script src="../../js/functions.js"></script>
</asp:Content>
