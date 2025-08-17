<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageSupervisor.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.SuperVisorAssignment.ManageSupervisor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../js/listBoxMovement.js" type="text/javascript"></script>
    <link href="../../../ui/css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                   <i class="fa fa-caret-right" aria-hidden="true"></i> Manage Supervisor
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="lblMsgDis" runat="server" CssClass="txtlbl"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-5">
                            <div class="form-group">
                                <label>Supervisor Type:</label>
                                <asp:DropDownList ID="ddlSupType1" runat="server" CssClass="form-control" 
                                    onselectedindexchanged="ddlSupType1_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="i">Immediate SuperVisor</asp:ListItem>
                                <asp:ListItem Value="s">SuperVisor</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>Supervisor Name:</label>
                                <asp:DropDownList ID="lstFirst" runat="server" CssClass="form-control" 
                                onselectedindexchanged="lstFirst_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="DdlFirstList" runat="server" CssClass="form-control" size="30" multiple="multiple" 
                                     onselectedindexchanged="lstFirst_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <div align="center"  class="button" onclick="listbox_selectall('<%=DdlFirstList.ClientID %>', true)" style="width:65px;">Select All </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="bttntype">
                                <div class="form-group">
                                    <div align="center" class="btn btn-primary" onclick="return  listbox_moveacross('<%=DdlFirstList.ClientID %>', '<%=DdlSecondList.ClientID %>');"><i class="fa fa-arrow-right" aria-hidden="true"></i>
</div>
	                                <div align="center"  class="btn btn-primary" onclick="return listbox_moveacross('<%=DdlSecondList.ClientID %>', '<%=DdlFirstList.ClientID %>');"><i class="fa fa-arrow-left" aria-hidden="true"></i>
</div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <label>Supervisor Type:</label>
                                <asp:DropDownList ID="ddlSupType2" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="i">Immediate SuperVisor</asp:ListItem>
                                <asp:ListItem Value="s">SuperVisor</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>Supervisor Name:</label>
                                <asp:DropDownList ID="lstSecond" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="DdlSecondList" runat="server" CssClass="form-control" size="30" multiple="multiple" 
                                     onselectedindexchanged="lstFirst_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <div align="center"  class="button" onclick="listbox_selectall('<%=DdlSecondList.ClientID %>', true)" style="width:65px;">Select All </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Button ID="btnMoveSupervisor" runat="server" CssClass="btn btn-primary btn-block" 
                                    Text="Move Supervisor" onclick="btnMoveSupervisor_Click1"/>
                            </div>
                        </div>
                        <div class="form-group">
                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
