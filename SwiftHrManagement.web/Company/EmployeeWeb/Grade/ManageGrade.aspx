<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProjectMaster.Master" CodeBehind="ManageGrade.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.Grade.ManageGrade" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel">
                <header class="panel-heading">
           Grade Setup Form 
        </header>
                  <div id="divMsg" runat="server"></div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                Effective Date:
                            </label>
                            <asp:TextBox ID="txtEffectiveDate" runat="server" MaxLength="50" CssClass="form-control" />
                            <cc1:CalendarExtender ID="ceEffectiveDate" runat="server" TargetControlID="txtEffectiveDate" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Increment Decrement:
                            </label>
                            <asp:DropDownList ID="ddlIncrementDec" runat="server" CssClass="form-control">
                                <asp:ListItem Value="i">Increment</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Grade:
                            </label>
                            <asp:DropDownList ID="ddlGrade" runat="server" CssClass="form-control"
                                OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Amount:
                            </label>
                            <asp:TextBox ID="txtAmount" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary"
                        ValidationGroup="grade" OnClick="BtnSave_Click1" />
                    <asp:Button ID="Btn_delete" runat="server" Text="Delete" CssClass="btn btn-primary"
                        OnClick="Btn_delete_Click" />

                    <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn btn-primary"
                        OnClick="BtnBack_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
