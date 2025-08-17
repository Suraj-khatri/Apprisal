<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true"
    CodeBehind="LevelAppraisalMatrixKRA.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.LevelCompetencyMatrixSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <%--   <div id="class" KRAKPIDiv="tab-pane active" runat="server">
        
        <section class="panel">            
                        <div class="panel-heading">Agreed KRAs and KPIs for performance measurement</div>           
                     <div class="panel-body">   --%>


    <div class="panel">
        <header class="panel-heading">
            <a href="CompetancyList.aspx"><i class="fa fa-caret-right"></i></a>
            Agreed KRAs and KPIs for performance measurement

        </header>
        <div class="panel-body">

            <div class="form-group row">
                <div class="col-md-12 form-group">
                    <label>
                        Level Name:
                    </label>
                    <asp:Label runat="server" ID="lblLevelName"></asp:Label>

                </div>
                <div class="col-md-4">
                    <label>
                        KRA Topic:
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="kraTopic"
                                     Display="Dynamic"
                                     ErrorMessage="Required!" ValidationGroup="PerformanceMeasurement">
                                 </asp:RequiredFieldValidator></label>
                </div>
                <div class="col-md-4">
                    <label>
                        Weight(%): 100
                                  <asp:RequiredFieldValidator ID="RFVkraWeight" runat="server" ControlToValidate="kraWeight"
                                      Display="Dynamic"
                                      ErrorMessage="Required!" ValidationGroup="PerformanceMeasurement"> </asp:RequiredFieldValidator></label>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-4">
                    <asp:TextBox ID="kraTopic" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="kraWeight" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>
                </div>

            </div>
            <div class="form-group row">
                <div class="col-md-4">
                    <label>
                        KPI Topic:
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="kpiTopic"
                                     Display="Dynamic"
                                     ErrorMessage="Required!" ValidationGroup="PerformanceMeasurement"></asp:RequiredFieldValidator></label>
                </div>
                <div class="col-md-4">
                    <label>
                        Weight(%): 
                                  <asp:RequiredFieldValidator ID="RFVkpiWeight" runat="server" ControlToValidate="kpiWeight"
                                      Display="Dynamic"
                                      ErrorMessage="Required!" ValidationGroup="PerformanceMeasurement"></asp:RequiredFieldValidator></label>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-4">
                    <asp:TextBox ID="kpiTopic" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="kpiWeight" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>
                    <%-- <cc1:FilteredTextBoxExtender runat="server" FilterType="Numbers,Custom" TargetControlID="kpiWeight"
                            ValidChars="." FilterMode="ValidChars" />--%>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Add"
                        Font-Strikeout="False" ValidationGroup="PerformanceMeasurement"
                        Width="75px" OnClick="BtnSave_Click" />
                </div>
            </div>

            <hr />
            <div class="row">
                <div class="form-group col-md-12 table-responsive">
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>SNO</th>
                                <th>KRA</th>
                                <th>Weightage (%)</th>
                                <th>KPI</th>
                                <th>Weightage (%)</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody id="kra_grid" runat="server">
                        </tbody>
                    </table>
                </div>
                <asp:HiddenField ID="hdnCount" runat="server" />
                <asp:HiddenField ID="hdnId2" runat="server" />
                <asp:HiddenField ID="hdnId1" runat="server" />
                <asp:Button ID="BtnEditRecord" runat="server" OnClick="BtnEditRecord_Click" Style="display: none;" />
                <asp:Button ID="saveBtn" runat="server" OnClick="saveBtn_Click" Style="display: none;" />
                <asp:Button ID="cancel" runat="server" OnClick="cancel_Click" Style="display: none;" />
                <asp:Button ID="BtnDeleteRecord" runat="server" OnClick="BtnDeleteRecord_Click" Style="display: none;" />
            </div>
            <div class="form-group row">
                <div class="col-md-4">
                    <p>Note:</p>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-12">
                    <p>
                        1. KRAs for performance measurement should not be more than 10 with specific KPIs
                            for each KRA.
                    </p>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-12">
                    <p>
                        2. Total weight of all KRAs should be 100, weight of each KRA depends upon its importance
                            and accordingly higher weight should be given to prime KRA.
                    </p>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-12">
                    <p>
                        3. All Achievements will be capped at 150%. Hence the maximum score possible on the
                            scorecard will be 150.
                    </p>
                </div>
            </div>
        </div>
    </div>

    <asp:Button ID="LoadKRAKPIGrid" runat="server" OnClick="LoadKRAKPIGrid_Click" Style="display: none;" />
    <script type="text/javascript">
        function CheckDecimal(evt) {
            var element = evt.currentTarget.id;
            var val = document.getElementById(element).value;
            if (isNaN(val)) {
                val = val.replace(/[^0-9\.]/g, '');
                if (val.split('.').length > 2)
                    val = val.replace(/\.+$/, "");
            }
            var split = val.split('.');
            if (split.length > 1)
                if (split[1].length > 2) {
                    split[1] = split[1].substring(0, 2);
                    val = split[0] + '.' + split[1];
                }
            document.getElementById(element).value = val;
        }
        function onDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId1.ClientID%>").value = id;
                document.getElementById("<% =BtnDeleteRecord.ClientID%>").click();
            }
        }
        function onEdit(id, count) {
            document.getElementById("<% =hdnId2.ClientID%>").value = id;
            document.getElementById("<% =hdnCount.ClientID%>").value = count;
            document.getElementById("<% =BtnEditRecord.ClientID%>").click();
        }
        function EditData(id) {
            if (confirm("Are you sure, you want to save?")) {
                document.getElementById("<% =hdnId2.ClientID%>").value = id;
                document.getElementById("<% =saveBtn.ClientID%>").click();
            }
        }
        function Cancel() {
            //if (confirm("Are you sure, you want to cancel?")) {
            document.getElementById("<% =cancel.ClientID%>").click();
               //}
           }
    </script>

</asp:Content>
