<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DeptwiseExtrpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeDetails.DeptwiseExtrpt" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <div class="panel">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="form-group" align="center">
                                <strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                </font></strong>
                                <font size="-1"><strong>
                                    <asp:Label ID="lbldesc"  Text="Employee Extension List" runat="server"></asp:Label><br />  
                                </font>
                                <font><strong>
                                    <asp:Label ID="lblbranch" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbldept" runat="server"></asp:Label></font>
                            </div>
                            <div id="rptDiv" runat="server">
                            </div>
                        </div>
                    </section>
                </div>
            </div>
            <asp:HiddenField ID="Hdnflag" runat="server" />
        </div>
    </div>
</body>
</html>
</asp:Content>