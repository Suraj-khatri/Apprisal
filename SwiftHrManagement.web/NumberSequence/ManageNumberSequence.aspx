<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="ManageNumberSequence.aspx.cs" Inherits="SwiftAssetManagement.NumberSequence.ManageNumberSequence" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12">
                     <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                           Purchase Number Sequence Details
                        </header>
                         <div class="panel-body">
                            <div class="form-group">
                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                            </div>
                        <h5><b>General:</b></h5>
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Company Short Code :</label>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:CheckBox id="ChkCompShortCode" runat="server"></asp:CheckBox>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Use Separator :</label>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:CheckBox id="ChkUseCompShortCodeSep" runat="server"></asp:CheckBox>
                                </div>
                                <div class="col-md-6" align="center">
                                     <div class="form-group form-inline">
                                        <label>Separator :</label>
                                        <asp:DropDownList id="CmbCompShortCodeSep" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Branch Short Code :</label>
                                        
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:CheckBox id="ChkBranchShortCode" runat="server">
                                        </asp:CheckBox>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Use Separator :</label>
                                        
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:CheckBox id="ChkUseBranchShortCodeSep" runat="server">
                                        </asp:CheckBox>
                                </div>
                                <div class="col-md-6" align="center">
                                    <div class="form-group form-inline">
                                        <label>Separator :</label>
                                         <asp:DropDownList id="CmbBranchShortCodeSep" runat="server" CssClass="form-control">
                                         </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Asset Short Code :</label>
                                        
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:CheckBox id="ChkAssetShortCode" runat="server">
                                    </asp:CheckBox>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group ">
                                        <label>Use Separator :</label>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:CheckBox id="ChkUseAssetShortCodeSep" runat="server">
                                    </asp:CheckBox>
                                </div>
                                <div class="col-md-6" align="center">
                                    <div class="form-group form-inline">
                                        <label>Separator :</label>
                                        <asp:DropDownList id="CmbAssetShortCodeSep" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <h5><b>Sequence:</b></h5>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-inline">
                                        <label>Starting Number :</label>
                                        <asp:TextBox id="TxtSequence" runat="server" CssClass="form-control" Width="50%">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Use Separator :</label>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:CheckBox id="ChkUseSequenceSep" runat="server">
                                    </asp:CheckBox>
                                </div>
                                <div class="col-md-4" align="center">
                                    <div class="form-group form-inline">
                                        <label>Separator :</label>
                                        <asp:DropDownList id="CmbSequenceSep" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                             </div>
                            <h5><b>Date:</b></h5>
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Date Code :</label>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:CheckBox id="ChkDateCode" runat="server">
                                    </asp:CheckBox>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-inline">
                                        <label>Date Format :</label>
                                        <asp:DropDownList id="CmbDateFormat" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" onclick="BtnSave_Click" Text="Save" />
                            </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>