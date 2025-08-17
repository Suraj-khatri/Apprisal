<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftAssetManagement.AssetParameters.Item.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../ui/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>
        <div class="panel panel-default">
            <header class="panel-heading">
                Asset Group Details
            </header>
            <div class="panel-body">
             <asp:Label ID="LblMsg" runat="server" class="required"></asp:Label>
            <div class="form-group">
                    <label>
                        Parent Group:<span class="errormsg">*</span>
                    </label>
                     <asp:DropDownList ID="DdlItems" runat="server" CssClass="form-control"  >
                    </asp:DropDownList>                                              
                    <asp:RequiredFieldValidator 
                    ID="Rfvnewitem" runat="server" ControlToValidate="DdlItems" 
                    ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="itemsetup" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            
            <div class="form-group">
                    <label>
                    Asset Group:<span class="errormsg">*</span>
                    </label>
                <asp:TextBox ID="TxtNewItems" runat="server" CssClass="form-control" 
                    MaxLength="30"></asp:TextBox>                                                                   
                <asp:RequiredFieldValidator ID="Rfvitem" runat="server" 
                    ControlToValidate="TxtNewItems" ErrorMessage="Required" 
                    SetFocusOnError="True" ValidationGroup="itemsetup"></asp:RequiredFieldValidator>
                </div>
         
            <div class="form-group">
                    <label>
                        Description:<span class="errormsg">*</span>
                    </label>
                        <asp:TextBox ID="TxtDecs" runat="server" CssClass="form-control" MaxLength="30">
                </asp:TextBox>                                                                    
                <asp:RequiredFieldValidator 
                    ID="RfvDEsc" runat="server" ControlToValidate="TxtDecs" 
                    ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="itemsetup"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="LblDepreciation" runat="server" Text="Depreciation Pct:"></asp:Label>
                    <asp:TextBox ID="TxtDeprPct" runat="server" CssClass="form-control"></asp:TextBox>                                                                    
                <asp:RangeValidator ID="RvPct" runat="server" ControlToValidate="TxtDeprPct" 
                    Display="Dynamic" ErrorMessage="Invalid Range" MaximumValue="100" 
                    MinimumValue="0" SetFocusOnError="True" Type="Double" 
                    ValidationGroup="itemsetup"></asp:RangeValidator>
                </div>
           <br />
             <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                    onclick="btnSave_Click" Text="Save" ValidationGroup="itemsetup" />                                                                        
                <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                </cc1:ConfirmButtonExtender>                                                                                                                                                                                                            
               <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                    Text="Delete" onclick="BtnDelete_Click1" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
               
                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                    Text="Back" ValidationGroup="chart" onclick="BtnCancel_Click" />  
        </div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>
