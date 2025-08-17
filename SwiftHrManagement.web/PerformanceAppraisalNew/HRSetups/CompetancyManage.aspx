<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="CompetancyManage.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.CompetancyManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function EditFunction(id) {
            if (confirm("Do you want to edit?") == true) {
                $("#<%=hdnId.ClientID%>").val(id);
                $("#<%=BtnEdit.ClientID%>").click();
            }
           
        };
        function DeleteFunction(id) {
            if (confirm("Do you want to delete?") == true) {
            $("#<%=hdnId.ClientID%>").val(id);
                $("#<%=BtnDelete.ClientID%>").click();
            }
        };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField runat="server" ID="hdnId" />
    <asp:Button runat="server" ID="BtnDelete" OnClick="BtnDelete_OnClick" Style="display: none" />
    <asp:Button runat="server" ID="BtnEdit" OnClick="BtnEdit_OnClick" Style="display: none" />

    <div class="row">
       
            <section class="panel">
                <header class="panel-heading">
                    <a href="CompetancyList.aspx"><i class="fa fa-caret-right"></i></a>
                    Level Setup Form  <a class="pull-right btn btn-primary btn-xs" href="/PerformanceAppraisalNew/HRSetups/CompetancyList.aspx"> <i class="fa fa-list-alt" ></i> Appraisal Level List</a>
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Plese enter valid data! </span><span class="required">(* Required Fields)</span>
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>
                            Level Name:<span class="errormsg">*</span>
                            <asp:RequiredFieldValidator ID="rfc" runat="server" Display="Dynamic"
                                ControlToValidate="txtComMatrixName" ErrorMessage="Required!"
                                SetFocusOnError="True" ValidationGroup="Competency">
                            </asp:RequiredFieldValidator></label>
                        <asp:TextBox ID="txtComMatrixName" runat="server" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label>
                                Position: <span class="errormsg">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DdlPosition"
                                    Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Competency"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator></label>
                            <asp:DropDownList ID="DdlPosition" runat="server" CssClass="form-control" Width="100%">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 form-group">
                            <label style="color: transparent; width: 100%">Add: </label>
                            <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" OnClick="BtnAdd_OnClick" Text="Add " ValidationGroup="Competency" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>    Is Probation:<span class="errormsg">*</span> </label>
                            <asp:CheckBox runat="server" AutoPostBack="True" ID="chkBoxProbation" />
                        </div>
                      
                        <div class="col-md-6 form-group">
                            <label> Is Active:<span class="errormsg">*</span> </label>
                            <asp:CheckBox runat="server" AutoPostBack="True" ID="chkBoxActive" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:UpdatePanel runat="server" ID="up">
                                <ContentTemplate>
                                    <br />
                                    <div runat="server" id="rptDiv">
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Save" />

                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" OnClick="btnUpdate_Click" Text="Update" />
                    </div>
                </div>
            </section>
      
    </div>

</asp:Content>
