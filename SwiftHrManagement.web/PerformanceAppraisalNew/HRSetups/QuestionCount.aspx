<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="QuestionCount.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.QuestionCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table > thead > tr > th,
        .table > tbody > tr > th,
        .table > tfoot > tr > th,
        .table > thead > tr > td,
        .table > tbody > tr > td,
        .table > tfoot > tr > td {
            border-top: 1px solid #ffffff !important;
            line-height: 1.42857;
            padding: 8px;
            vertical-align: top;
        }
        .table1 thead > tr > th {
           border-top: 1px solid #DDDDDD !important;  
        }
    </style>
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
    <div class="row">
      
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>           
                    Performance Agreement Question Count Setup
                </header>
                <div class="panel-body">
                    <div >
                        <span class="txtlbl">Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                    </div>

                    <div class="row">          
                            <div class="col-md-12">                                  
                                <table class="table">                                        
                                    <tr>
                                        <td>Question Type<span class="errormsg">*</span></td>
                                        <td>Number of Questions<span class="errormsg">*</span></td>
                                        <td>Total Weightage<span class="errormsg">*</span></td>
                                        <td>Rating Ceiling Percentage%</td>
                                    </tr>
                                    <tr>
                                        <td class="txtlbl">
                                            <%--<div class="form-group">--%>
                                               <%-- <div align="right"><label>KRA:</label></div>--%>
                                                 <asp:DropDownList ID="ddlQuestionGroup" runat="server" Width="200px" CssClass="form-control" >
                                                </asp:DropDownList> 
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlQuestionGroup"
                                                   ErrorMessage="Required!" ValidationGroup="QuestionCount">
                                                </asp:RequiredFieldValidator> 
                                            <%--</div>--%>
                                        </td>                                       
                                        <td>            
                                            <asp:TextBox ID="txtNoOfQstn" runat="server" CssClass="form-control"></asp:TextBox>                                           
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoOfQstn"
                                               ErrorMessage="Required!" ValidationGroup="QuestionCount">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNoOfQstn"
                                                ValidationGroup="QuestionCount" SetFocusOnError="true" ValidationExpression="[0-9]*\.?[0-9]*"
                                                ErrorMessage="only numeric values are allowed!" ForeColor="Red">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalWeight" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>   
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTotalWeight"
                                               ErrorMessage="Required!" ValidationGroup="QuestionCount">
                                            </asp:RequiredFieldValidator>                                         
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRatingCeiling" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>                                            
                                        </td>                                           
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save" Onclick="Btn_Save_Click"
                                                 ValidationGroup="QuestionCount" />
                                        </td>                        
                                    </tr>
                                    </table>
                                </div>
                        </div>
                          <br/>
                    <div class="row">
                            <div class="form-group col-md-12 table-responsive" >
                                <table class="table table1 table-bordered table-striped table-condensed">
                                    <thead>
                                        <tr>
                                            <th>Question Type</th>
                                            <th>Number of Questions</th>
                                            <th>Total Weightage</th>
                                            <th>Rating Ceiling</th>
                                             <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody id="app_grid" runat="server">

                                    </tbody>
                                </table>
                            </div>
                         </div>
                            <asp:HiddenField ID="hdnId2" runat="server" />
                            <asp:HiddenField ID="hdnId1" runat="server" />
                            <asp:Button ID="BtnEditRecord" runat="server" onclick="BtnEditRecord_Click" style="display:none;" />
                            <asp:Button ID="saveBtn" runat="server" onclick="saveBtn_Click" style="display:none;" />
                            <asp:Button ID="cancel" runat="server" onclick="cancel_Click" style="display:none;" />
                            <asp:Button ID="BtnDeleteRecord" runat="server" onclick="BtnDeleteRecord_Click" style="display:none;" />
                       
                 </div>
                </section>
            
        </div>
    <script src="../../js/functions.js"></script>
</asp:Content>


