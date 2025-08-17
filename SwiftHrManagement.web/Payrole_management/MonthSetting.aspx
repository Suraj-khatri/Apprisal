<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="MonthSetting.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.MonthSetting" Title="Swift HRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script language="javascript" type="text/javascript">   
    function Update(monthId,ctl) {
        var btn = document.getElementById("<%=btnUpdate.ClientID%>");
        var txtMonthId = document.getElementById("<%=hddMonthId.ClientID%>");
        var txtMonthName = document.getElementById("<%=hddMonthName.ClientID%>");        
        txtMonthId.value = monthId;
        txtMonthName.value = document.getElementById(ctl).value;
        btn.click();
        
    }
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hddMonthId" runat="server" Value="" />
    <asp:HiddenField ID="hddMonthName" runat="server" Value="" />
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                <section class="panel">
                    <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                                Nepali Month Setup Details
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-3">
                                <label>Month Number</label>
                                <strong><asp:Label ID="Label13" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-6 text-center">
                                <label>Month Name</label>
                                <strong><asp:Label ID="Label14" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label1" runat="server" Text="1"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth1" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(1,'<%=txtMonth1.ClientID%>');" >Update</a>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label2" runat="server" Text="2"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth2" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(2,'<%=txtMonth2.ClientID%>');" >Update</a>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label3" runat="server" Text="3"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth3" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(3,'<%=txtMonth3.ClientID%>');" >Update</a>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label4" runat="server" Text="4"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth4" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(4,'<%=txtMonth4.ClientID%>');" >Update</a>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label5" runat="server" Text="5"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth5" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(5,'<%=txtMonth5.ClientID%>');" >Update</a>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label6" runat="server" Text="6"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth6" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(6,'<%=txtMonth6.ClientID%>');" >Update</a>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label7" runat="server" Text="7"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth7" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(7,'<%=txtMonth7.ClientID%>');" >Update</a>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label8" runat="server" Text="8"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth8" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(8,'<%=txtMonth8.ClientID%>');" >Update</a>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label9" runat="server" Text="9"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth9" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(9,'<%=txtMonth9.ClientID%>');" >Update</a>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label10" runat="server" Text="10"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth10" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(10,'<%=txtMonth10.ClientID%>');" >Update</a>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label11" runat="server" Text="11"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth11" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(11,'<%=txtMonth11.ClientID%>');" >Update</a>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-3 text-center form-group">
                                <asp:Label ID="Label12" runat="server" Text="12"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                               <asp:TextBox ID="txtMonth12" runat="server" Text="" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <a href="javascript:Update(12,'<%=txtMonth12.ClientID%>');" >Update</a>
                            </div>
                        </div>
                    </div>
                </section>
                </div>
            </div>
    <asp:UpdatePanel ID="updPanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" RenderMode="Inline">
        <ContentTemplate>
            <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" style="display:none" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="click" />
        </Triggers>        
    </asp:UpdatePanel>
    
</asp:Content>
