<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true"  MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="LetterSearch.aspx.cs" Inherits="SwiftHrManagement.web.LetterTemplate.LetterSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/listBoxMovement.js" type="text/javascript"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Letter Generate Form 
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-5 form-group">
                            <label>Letter Template:</label>
                            <asp:DropDownList ID="DdlDocType" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            <asp:Label ID="DocType" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5 form-group">
                            <label>Branch:</label>
                            <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" 
                                onselectedindexchanged="DdlBranch_SelectedIndexChanged1" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 form-group">
                            
                        </div>
                        <div class="col-md-5 form-group">
                            <label>Position:</label>
                            <asp:DropDownList ID="DdlPosition" runat="server" CssClass="form-control" 
                                onselectedindexchanged="DdlPosition_SelectedIndexChanged1" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5 form-group">
                            <label>Employee List:</label>
                            <asp:DropDownList ID="DdlUnassigned" runat="server" CssClass="form-control" size="30" multiple="multiple" >
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 form-group" style="top:280px;" align="center">
                            <div class="btn btn-primary" onclick="return listbox_moveacross('<%=DdlUnassigned.ClientID %>', '<%=Ddlassigned.ClientID %>');">&gt;&gt;</div><br /><br />
                            <div class="btn btn-primary" onclick="return listbox_moveacross('<%=Ddlassigned.ClientID %>', '<%=DdlUnassigned.ClientID %>');">&lt;&lt;</div>
                        </div>
                        <div class="col-md-5 form-group">
                            <label>Selected Employee List:</label>
                            <asp:Label ID="assigned" runat="server" Text=""></asp:Label>
                            <asp:DropDownList ID="Ddlassigned" runat="server" CssClass="form-control" size="30" multiple="multiple">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5 form-group">

                        </div>
                        <div class="col-md-2 form-group">

                        </div>
                        <div class="col-md-5 form-group">

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5 form-group">
                            <div align="center" class="btn btn-primary" onclick="listbox_selectall('<%=DdlUnassigned.ClientID %>', true)" >Select All</div>
                        </div>
                        <div class="col-md-2 form-group">

                        </div>
                        <div class="col-md-5 form-group">
                            <div align="center" class="btn btn-primary" onclick="listbox_selectall('<%=Ddlassigned.ClientID %>', true)">Select All</div>
                        </div>
                    </div>
                    <div class="row">
                        &nbsp;
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnGenerate" runat="server" Text="Generate Letter" CssClass="btn btn-primary" onclick="btnGenerate_Click1" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>


