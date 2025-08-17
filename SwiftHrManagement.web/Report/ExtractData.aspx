<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ExtractData.aspx.cs" Inherits="SwiftHrManagement.web.Report.ExtractData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/functions.js" type="text/javascript"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <title></title>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <style type="text/css">
                .form-inline .form-control {
                    margin-bottom: 3px !important;
                }
            </style>

            <div class="col-md-12">
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
				        Extract Data
                </header>
            </div>
            <div class="row">
                <div class="col-md-5 form-group">
                    <div class="panel panel-default">
                    <header class="panel-heading">
                    Extract Branch 
                    </header>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label>Branch</label>
                            </div>
                            <div class="col-md-8 form-group">
                                <asp:DropDownList ID="branch" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                            </div>
                        </div>
                        <asp:Button ID="btnBranch" runat="server" CssClass="btn btn-primary" Text="View Report"
                            OnClick="btnBranch_Click" />
                    </div>
                </div>
                    </div>

               <div class="col-md-1 form-group"></div>

                 <div class="col-md-5 form-group">
                    <div class="panel panel-default">
                    <header class="panel-heading">
                    Extract Department
                     </header>
                    <div class="panel-body">
                        <div class="row form-inline">
                            <div class="col-md-4 form-group">
                                <label>Branch :</label>
                            </div>
                            <div class="col-md-8 form-group">
                                <asp:DropDownList ID="branchDept" runat="server" CssClass="form-control"
                                   Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:Button ID="btnDept" runat="server" CssClass="btn btn-primary" Text="View Report"
                            OnClick="btnDept_Click" />
                    </div>
                        </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-5 form-group">
                    <div class="panel panel-default">
                    <header class="panel-heading">
                     Extract Asset Type
                    </header>
                    <div class="panel-body">
                        <div class="row form-inline">
                            <div class="col-md-4 form-group">
                                <label>Group</label>
                            </div>
                            <div class="col-md-8 form-group">
                                <asp:DropDownList ID="group" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                            </div>
                        </div>
                        <asp:Button ID="btnAssetType" runat="server" CssClass="btn btn-primary"
                            Text="View Report" OnClick="btnAssetType_Click" />
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                 <div class="col-md-1 form-group"></div>
                <div class="col-md-5 form-group">
                    <div class="panel panel-default">
                    <header class="panel-heading">
           Extract Employee
        </header>
                    <div class="panel-body">
                        <div class="row ">
                            <div class="col-md-4 form-group">
                                <label>Branch</label>
                            </div>
                            <div class="col-md-8 form-group">
                                <asp:DropDownList ID="branchEmp" runat="server" CssClass="form-control"
                                    Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:Button ID="btnEmployee" runat="server" CssClass="btn btn-primary"
                            Text="View Report" OnClick="btnEmployee_Click" />
                        </div>
                    </div>
                </div>
                </div>
                 </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
