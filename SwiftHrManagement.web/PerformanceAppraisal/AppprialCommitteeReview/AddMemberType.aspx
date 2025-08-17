<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AddMemberType.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppprialCommitteeReview.AddMemberType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">

    function deletePos(_obj) {       
        document.getElementById("ctl00_MainPlaceHolder_HiddenField2").value = _obj;
        document.getElementById("ctl00_MainPlaceHolder_btnDelete").click();   
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:Button ID="btnDelete" runat="server" Text="Button" style="display:none" onclick="btnDelete_Click" />

<div id="addType" runat="server">
     <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Appraisal Type Setting
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields)</span>
                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label><br />
                        <asp:HiddenField ID="hdnRowid" runat="server" />
                    </div>
                    <div class="form-group">
                         <label>Review Committee for: <span class="errormsg">*</span></label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="reviewType"
                                Display="dynamic" ErrorMessage="Required" ValidationGroup="rating">
                         </asp:RequiredFieldValidator><br />                                                                                    
                        <asp:TextBox ID="reviewType" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Review Committee Description:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="reviewDesc"
                                Display="dynamic" ErrorMessage="Required" ValidationGroup="rating"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="reviewDesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Is Active: <span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlActive" 
                            Display="dynamic" ErrorMessage="Required" ValidationGroup="rating"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlActive" runat="server" CssClass="form-control" ValidationGroup="rating">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Type" CssClass="btn btn-primary" ValidationGroup="rating" 
                            onclick="btnAdd_Click"/>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update Type" CssClass="btn btn-primary" ValidationGroup="rating" 
                            Visible="false" onclick="btnUpdate_Click"/>
                    </div>                    
                    <div class="form-group">
                        <div id="rptComments" runat="server"></div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</div>
<div id="addReviewPos" runat="server" visible="false">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Appraisal Review Position Setting
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required">&nbsp; (* Required fields)</span>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                    <div id="Div1" runat="server">
                        <div class="form-group">
                            <label>Review Type:</label>
                            <asp:TextBox ID="txtReview" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Position:</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPosition" 
                                    Display="dynamic" ErrorMessage="Required" ValidationGroup="rating"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    <div class="form-group">
                            <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary" ValidationGroup="rating" 
                                onclick="Button1_Click"/>
                    </div>
                    <div class="form-group">
                        <label>&nbsp;</label>
                    </div>
                    <div class="form-group">
                            <div runat="server" id="rptPosition"></div>
                    </div>
                </div>
                </div>
            </section>
        </div>
    </div>
</div>
</asp:Content>
