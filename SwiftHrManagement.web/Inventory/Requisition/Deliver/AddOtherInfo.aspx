<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="AddOtherInfo.aspx.cs" Inherits="SwiftAutomobile.Inventory.Requisition.Deliver.AddOtherInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../ui/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../ui/js/jquery-1.10.2.min.js"></script>
    <script src="../../../ui/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
product other information
        </header>
        <div class="panel-body">
             <asp:Label ID="LblMsg" runat="server"></asp:Label>
            Product Name:
               <asp:Label ID="lblProductName" runat="server" CssClass="lblText"></asp:Label>
               &nbsp;&nbsp;&nbsp;Total Qty:
               <asp:Label ID="lblqty" runat="server" CssClass="lblText"></asp:Label>
               <asp:HiddenField ID="hdnQty" runat="server" />
        </div>
        <div class="panel-body">
            <header class="panel-heading">
                Other Information:
            </header>
            <div class="form-group">
               <div>
                     <table class="table table-responsive table-bordered table-condensed table-striped">
                               <tr>
                                   <td nowrap="nowrap" valign="middle" width="52">Qty:</td>
                                   <td nowrap="nowrap" valign="middle" width="1">S.N. From:</td>
                                   <td nowrap="nowrap" valign="middle" width="27">S.N. To:</td>
                                   <td nowrap="nowrap" valign="middle" width="32">Batch:</td>
                                   <td nowrap="nowrap" width="70">&nbsp;</td>
                               </tr>
                               <tr>
                                   <td nowrap="nowrap">
                                       <asp:TextBox ID="qty" runat="server" size="15" CssClass="form-control"></asp:TextBox></td>
                                   <td nowrap="nowrap">
                                       <asp:TextBox ID="sn_from" name="sn_from" size="20" runat="server"
                                           CssClass="form-control" AutoPostBack="True"
                                           OnTextChanged="sn_from_TextChanged"></asp:TextBox></td>
                                   <td nowrap="nowrap">
                                       <asp:TextBox ID="sn_to" name="sn_to" size="20" runat="server"
                                           CssClass="form-control"></asp:TextBox></td>
                                   <td nowrap="nowrap">
                                       <asp:TextBox ID="batch" runat="server" size="20" CssClass="form-control"></asp:TextBox></td>

                                   <td nowrap="nowrap" align="right">
                                       <label>
                                           <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Add" OnClick="BtnAdd_Click" />

                                       </label>
                                   </td>

                               </tr>
                               <tr>
                                   <td colspan="6">
                                       <div id="rpt" runat="server"></div>
                                   </td>
                               </tr>
                               <tr>
                                   <td colspan="6">
                                       <div align="right">
                                           <p>
                                               <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="btn btn-primary"
                                                   OnClick="BtnDelProduct_Click"  />
                                           </p>
                                       </div>
                                   </td>
                               </tr>
                           </table>
                       </div>
            </div>
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Save"  />
        </div>
    </div>
   
</asp:Content>
