    <%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true"
    CodeBehind="CompetencyMatrixSetup.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.CompetencyMatrixSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../../ui/js/sweetalert.min.js"></script>
    <script type="text/javascript" src="../../js/functions.js"></script>
    <script type="text/javascript">
        function onDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId1.ClientID%>").value = id;
                document.getElementById("<% =BtnDeleteRecord.ClientID%>").click();
            }
        }
        function onEdit(id) {
            document.getElementById("<% =hdnId2.ClientID%>").value = id;
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
    <div class="panel">
        <header class="panel-heading">
            <a href="CompetancyList.aspx"><i class="fa fa-caret-right"></i></a>
            Competancy Matrix Setup

        </header>
        <div class="panel-body">
            <div class="form-group">
                <%-- <span>Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>--%>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <label>
                        Level Name:
                    </label>
                    <asp:Label runat="server" ID="lblLevelName"></asp:Label>

                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Competancy:
                    </label>
                    <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlCompetancy"
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="matrix"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlCompetancy" runat="server" CssClass="form-control" Width="100%">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>Weight(%): </label>
                    <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtWeight"
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="matrix"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="TxtWeight" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>
                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtWeight"
                        ValidationGroup="matrix" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                        ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                    </asp:RegularExpressionValidator>--%>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Competancy Key:
                    </label>
                    <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlCompetancyKey"
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="matrix"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlCompetancyKey" runat="server" CssClass="form-control" Width="100%">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>Weight(%):</label>
                    <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtWeight1"
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="matrix"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="TxtWeight1" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>
                    <%--                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtWeight1"
                        ValidationGroup="matrix" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                        ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                    </asp:RegularExpressionValidator>--%>
                </div>
                <div class="col-md-4 form-group">
                    <br />
                    <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnAdd_Click" Text="Add" ValidationGroup="matrix" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="form-group col-md-12 table-responsive">
                    <table class="table table1 table-bordered table-striped table-condensed">
                        <thead>
                            <tr>
                                <th>Sn </th>
                                <th>Competency</th>
                                <th>Competency Weight</th>
                                <th>Competency Key</th>
                                <th>Competency Key Weight</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody id="app_grid" runat="server">
                        </tbody>
                    </table>
                </div>
            </div>
            <asp:HiddenField ID="hdnId2" runat="server" />
            <asp:HiddenField ID="hdnCompkeyId" runat="server" />
            <asp:HiddenField ID="hdnId1" runat="server" />
            <asp:Button ID="BtnEditRecord" runat="server" OnClick="BtnEditRecord_Click" Style="display: none;" />
            <asp:Button ID="saveBtn" runat="server" OnClick="saveBtn_Click" Style="display: none;" />
            <asp:Button ID="cancel" runat="server" OnClick="cancel_Click" Style="display: none;" />
            <asp:Button ID="BtnDeleteRecord" runat="server" OnClick="BtnDeleteRecord_Click" Style="display: none;" />
        </div>

        <%--   <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                     <section class="panel">
                    <div class="panel-body">
                        <div id="rpt" runat="server">
                        </div>
                    
                    </div>
                     </section>
                </div>
            </div>
        </div>--%>
    </div>
 
</asp:Content>
