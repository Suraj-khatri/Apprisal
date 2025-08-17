<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOtherDisposalInfo.aspx.cs" Inherits="SwiftHrManagement.web.Voucher.AddOtherDisposalInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
   
    <link href="../ui/css/style.css" rel="stylesheet" />
    
     <style type="text/css">
     
    </style>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <section class="panel">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <header class="panel-heading">
                         <i class="fa fa-caret-right"></i>
                        Disposal other information
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <label>Product Name :</label>
                            <asp:Label ID="lblProductName" runat="server"></asp:Label> Total Qty: 
                            <asp:Label ID="lblqty" runat="server"></asp:Label>
                             <asp:HiddenField ID="hdnQty" runat="server" />
                        </div>
                        <div class="col-md-6">
                            <label>Qty :</label> 
                            <asp:TextBox ID="qty" runat="server" size="15" CssClass="form-control"></asp:TextBox>
                        </div> 
                        <div class="col-md-6">
                            <label>S.N. From :</label> 
                            <asp:TextBox id="sn_from" name="sn_from" size="20" runat="server" CssClass="form-control" 
                                AutoPostBack="True" ontextchanged="sn_from_TextChanged"></asp:TextBox>
                        </div> 
                        <div class="col-md-6">
                            <label>S.N. To :</label> 
                             <asp:TextBox id="sn_to" name="sn_to" size="20" runat="server" CssClass="form-control"></asp:TextBox>
                        </div> 
                        <div class="col-md-6">
                            <label>Batch :</label> 
                            <asp:TextBox ID="batch" runat="server" size="20" CssClass="form-control"></asp:TextBox>
                        </div>   
                        <div class="col-md-12">
                            <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Add" onclick="BtnAdd_Click"/>
                        </div>
                        <div class="col-md-12" style="margin-top:15px;">
                            <div id="rpt" runat="server"></div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="btn btn-primary" 
                                 onclick="BtnDelProduct_Click"/>
                            <cc1:ConfirmButtonExtender ID="BtnDelProduct_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelProduct">
                            </cc1:ConfirmButtonExtender>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" onclick="Button1_Click" Text="Save" />
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
