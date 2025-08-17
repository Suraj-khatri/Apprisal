<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="AssignReviewCommittee.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.AssignReviewCommittee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../ui/js/sweetalert.min.js"></script>
    <script type="text/javascript">
        function DeleteFunction(id) {
            if (confirm("Do you want to delete?") == true) {
                $("#<%=hdnId.ClientID%>").val(id);
                $("#<%=BtnDelete.ClientID%>").click();
            }
        };
        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpId.ClientID%>").value = EmpIdArray[1];
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField runat="server" ID="hdnId" />
    <asp:Button runat="server" ID="BtnDelete" OnClick="BtnDelete_OnClick" Style="display: none" />
    <%--<asp:Button runat="server" ID="BtnEdit" OnClick="BtnEdit_OnClick" Style="display: none" />--%>
    
        <section class="panel">
            <header class="panel-heading">
                <a href="CompetancyList.aspx"><i class="fa fa-caret-right"></i></a>
                Assign Review Committee
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
                </div>
                <div class="row">
                    <div class="col-md-10 form-group">
                        <asp:HiddenField runat="server" ID="hdnEmpId" />
                        <label>Employee Name: </label>
                        <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control" AutoPostBack="True" AutoComplete="Off">
                         
                        </asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                            CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" Enabled="true"
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListAppraisal" ServicePath="~/Autocomplete.asmx"
                            TargetControlID="txtEmpName" OnClientItemSelected="GetEmpName" ContextKey="" UseContextKey="True">
                        </cc1:AutoCompleteExtender>
                        <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,Custom" TargetControlID="txtEmpName" ValidChars=""/>--%>

                        <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender" runat="server" Enabled="True"
                            TargetControlID="txtEmpName" WatermarkCssClass="form-control" WatermarkText="All Employee">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                    <%--  <div class="col-md-2 form-group">
                          <label style="color:transparent; width:100%"> Add: </label>
                    <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnAdd_Click" Text="Add" ValidationGroup="Company" />
                </div>--%>
                </div>
                <div class="row">
                    <div class="col-md-6 form-group">
                        <label>
                            Is Active:<span class="errormsg">*</span>
                        </label>
                        <asp:CheckBox runat="server" AutoPostBack="True" ID="chkBoxActive" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group">
                        <br />
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                            OnClick="btnSave_Click" Text="Save" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 form-group">
                        <div id="rpt" runat="server">
                        </div>
                    </div>
                </div>

            </div>
        </section>
      
</asp:Content>
