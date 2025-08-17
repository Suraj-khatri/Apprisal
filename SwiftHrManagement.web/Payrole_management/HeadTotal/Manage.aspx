<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.HeadTotal.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
            <header class="panel-heading">
                 <i class="fa fa-caret-right" aria-hidden="true"></i> 
                         Head Total
                        </header>
            <div class="panel-body">
                <div id="form" runat="server">
                    <strong>
                        <div align="center">
                            <asp:Label ID="lblMsgDis" runat="server" ></asp:Label></div>
                    </strong>
                    <div class="form-group">
                        <label>Fiscal Year:<span class="required">*</span>  </label>
                        <asp:RequiredFieldValidator ID="RFVGrade" runat="server"
                            ControlToValidate="fiscalYear" ErrorMessage="Required" SetFocusOnError="True"
                            Display="dynamic" ValidationGroup="GRADE"> </asp:RequiredFieldValidator>
                        <asp:DropDownList ID="fiscalYear" runat="server" CssClass="form-control"></asp:DropDownList>
                        
                    </div>
                    <div class="form-group">
                        <label>Month Name:<span class="required">*</span>  </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="month" ErrorMessage="Required" SetFocusOnError="True"
                            Display="dynamic" ValidationGroup="GRADE"> </asp:RequiredFieldValidator>
                        <asp:DropDownList ID="month" runat="server" CssClass="form-control"></asp:DropDownList>
                        
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                            OnClick="BtnSave_Click" Text=" Search Live " ValidationGroup="GRADE" />
                        &nbsp;
                <asp:Button ID="BtnSearchTrial" runat="server" CssClass="btn btn-primary"
                    Text=" Search Trial " ValidationGroup="GRADE"
                    OnClick="BtnSearchTrial_Click" />
                     
                    </div>
                </div>
            </div>
            </section>
        </div>
    </div>
     <div class="row" id="report" runat="server" Visible="False">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
            <div class="panel-body">
                <div id="rpt" runat="server"></div>
            </div>
            </section>
        </div>
        
    </div>

</asp:Content>
