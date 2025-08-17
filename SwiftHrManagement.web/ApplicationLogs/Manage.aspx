<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.ApplicationLogs.Manage"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">    
    <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
			            <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                             Log Details
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group text-left">
                                        <label>Date:</label>
                                        <asp:Label ID = "created_date" runat="server" ></asp:Label>
                                        <br/>
                                        <label>Data Id:</label>
                                        <asp:Label ID = "data_id" runat="server" ></asp:Label>
                                        <br/>
                                        <label>Log Type:</label>
                                        <asp:Label ID = "log_type" runat="server" ></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 form-group text-right">
                                    <label>Table:</label>
                                    <asp:Label ID ="table_name" runat="server"></asp:Label>
                                    <br/>
                                    <label>User:</label>
                                    <asp:Label ID ="created_by" runat="server"></asp:Label>
                                </div>
                                </div>                           
                            <div class="row">
                                <div class="col-md-12 form-group">
                                    <div id = "changeDetails" align="left" runat ="server"><label>Changes Details:</label></div> 
                                    <div id="rpt_grid" runat="server"></div>
                                </div>                                
                            </div>
                            <div class="form-group">
                                 <input id="Button1" type="button" value=" Back" class="btn btn-primary" onclick="javascript: history.back(1); return false;" />
                            </div>
                    </section>
                </div>
            </div>
</asp:Content>
