<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AreaOfClassification.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.AreasOfClassification.AreaOfClassification" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/listBoxMovement.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">

    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Classification of Areas
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 form-group">
                    <strong>
                         <asp:Label ID="lblMsgDis" runat="server"></asp:Label></strong>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5 form-group">
                    <label>Zone:</label>
                    <asp:DropDownList ID="ddlZone" runat="server" CssClass="form-control"
                        OnSelectedIndexChanged="DdlZone_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                </div>
                <div class="col-md-5">
                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5 form-group">
                    <label>List Of Unassigned Countries</label>
                    <asp:DropDownList ID="DdlUnassigned" runat="server" CssClass="form-control"
                        size="30" multiple="multiple" OnSelectedIndexChanged="DdlUnassigned_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 form-group" style="top:300px;" align="center">
                    <div align="center" class="btn btn-primary" onclick=" return  listbox_moveacross('<%=DdlUnassigned.ClientID %>', '<%=Ddlassigned.ClientID %>');">&gt;&gt;</div>
                </div>
                <div class="col-md-5 form-group">
                    <label>List Of Assigned Countries</label>
                     <asp:DropDownList ID="Ddlassigned" runat="server" CssClass="form-control" size="30" multiple="multiple"
                        OnSelectedIndexChanged="Ddlassigned_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5 form-group">
                    <div align="center" class="btn btn-primary" onclick="listbox_selectall('<%=DdlUnassigned.ClientID %>', true)">Select All </div>
                </div>
                <div class="col-md-2 form-group">

                </div>
                <div class="col-md-5 form-group">
                    <div align="center" class="btn btn-primary" onclick="listbox_selectall('<%=Ddlassigned.ClientID %>', true)" >Select All </div>
                </div>
            </div>
            <div class="row">
                &nbsp;
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <asp:Button ID="BtnSave" runat="server" Width="80" CssClass="btn btn-primary"
                        OnClick="BtnSave_Click" Text="Save" ValidationGroup="areaclassification" />
                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnBack_Click" Text="Back" />
                </div>
            </div>
        </div>
    </div>
            
        </div>
    </div>
</asp:Content>
