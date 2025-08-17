<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductSetup.aspx.cs" Inherits="SwiftAssetManagement.AssetParameters.Item.ProductSetup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../ui/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>
        <div class="panel panel-default">
             <asp:Label ID="LblMsg" runat="server" class="required"></asp:Label>
             <asp:HiddenField ID = "hdnitem" runat="server" />
             <asp:HiddenField ID="ParentID" runat="server" />
            <header class="panel-heading">
                 Asset Type Setup 
            </header>
            <div class="panel-body">
                <div class="row form inline">
                    <div class="col-md-4">
                        <label>Group Name:</label>
                   
                 <asp:Label ID="LblProduct" runat="server"></asp:Label></span>
                    </div>
                </div>
                <div class="row form inline">
                    <div class="col-md-4">
                        <label>Asset Code: *</label>
                   
                        <span class="errormsg">
                         <asp:TextBox ID="TxtAssetCode" runat="server" CssClass="form-control"  MaxLength="30"></asp:TextBox>
                          </span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                               ControlToValidate="TxtAssetCode" ErrorMessage="Required" 
                               SetFocusOnError="True" ValidationGroup="product" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row form inline">
                    <div class="col-md-4">
                       <lable>Asset Type:*</lable>
                    
                         <span class="errormsg">
                          <asp:TextBox ID="TxtProductCode" runat="server" CssClass="form-control" 
                              MaxLength="30"></asp:TextBox></span>
                          <asp:RequiredFieldValidator 
                              ID="Rfvnewitem" runat="server" ControlToValidate="TxtProductCode"  
                              ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="product" 
                                          Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            Description : *
                        </label>
                  
                        <asp:TextBox ID="TxtProductDesc" runat="server" CssClass="form-control" ></asp:TextBox>
                                     </span>                                                                    
                          <asp:RequiredFieldValidator ID="Rfvitem" runat="server" 
                              ControlToValidate="TxtProductDesc" ErrorMessage="Required" 
                              SetFocusOnError="True" ValidationGroup="product" Display="Dynamic"></asp:RequiredFieldValidator> 
                    </div>
                </div>
                <br />
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                       onclick="btnSave_Click" Text="Save" ValidationGroup="product" /> 
                   <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                       ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                   </cc1:ConfirmButtonExtender>                                                                           
                   &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                       onclick="BtnDelete_Click" Text="Delete" ValidationGroup="chart" 
                       Visible="False" />
                   <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                       ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                   </cc1:ConfirmButtonExtender>
                   &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" 
                       Text="Back" ValidationGroup="chart" onclick="BtnCancel_Click" />
            </div>

    
 
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>