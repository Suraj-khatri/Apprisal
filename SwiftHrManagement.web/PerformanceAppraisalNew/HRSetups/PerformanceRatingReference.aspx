<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="PerformanceRatingReference.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.PerformanceRatingReference" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<asp:UpdatePanel ID="up1" runat="server">
    <ContentTemplate>
         <div class="row">
           
             <section class="panel">
                 <header class="panel-heading">
                     <i class="fa fa-caret-right" aria-hidden="true"></i>
                     Performance Rating Reference
                 </header>
                 <div class="panel-body">
                     <div>
                         <span class="txtlbl">Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                     </div>
                     <div class="row">
                         <div class="form-group col-md-6">
                             <label>KRA Achivement Score:<span class="errormsg">*</span></label>
                             <asp:TextBox ID="KRARatings1" runat="server" CssClass="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="KRARatings1" Display="Dynamic"
                                 ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                             </asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="row">
                         <div class="form-group col-md-6">
                             <label>Performance Level Rating:<span class="errormsg">*</span></label>
                             <asp:TextBox ID="KRARatings2" runat="server" CssClass="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="KRARatings2" Display="Dynamic"
                                 ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                             </asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="row">
                         <div class="form-group col-md-6">
                             <label>Percenatge of Increment:<span class="errormsg">*</span></label>
                             <asp:TextBox ID="KRARatings3" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="KRARatings3" Display="Dynamic"
                                 ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                             </asp:RequiredFieldValidator>
                         </div>
                         <div class="form-group col-md-2">
                             <label>&nbsp;</label><br />
                             <asp:Button ID="Btn_Add" runat="server" CssClass="btn btn-primary" Text="Add" OnClick="Btn_Add_Click" ValidationGroup="PerformanceRating" />
                         </div>
                     </div>
                     <br />
                     <div class="row">
                         <div class="form-group col-md-12 table-responsive">
                             <table class="table table-bordered table-striped table-condensed">
                                 <thead>
                                     <tr>
                                         <th>KRA Achivement Score</th>
                                         <th>Performance Level Rating</th>
                                         <th>Percenatge of Increment</th>
                                         <th>Actions</th>
                                     </tr>
                                 </thead>
                                 <tbody id="app_grid" runat="server">
                                 </tbody>
                             </table>
                         </div>
                         <asp:HiddenField ID="hdnId2" runat="server" />
                         <asp:HiddenField ID="hdnId1" runat="server" />
                         <asp:Button ID="BtnEditRecord" runat="server" OnClick="BtnEditRecord_Click" Style="display: none;" />
                         <asp:Button ID="saveBtn" runat="server" OnClick="saveBtn_Click" Style="display: none;" />
                         <asp:Button ID="cancel" runat="server" OnClick="cancel_Click" Style="display: none;" />
                         <asp:Button ID="BtnDeleteRecord" runat="server" OnClick="BtnDeleteRecord_Click" Style="display: none;" />
                     </div>
                 </div>
             </section>
           
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<script src="../../js/functions.js"></script>
</asp:Content>

