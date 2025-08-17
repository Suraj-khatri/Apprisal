<%@ Page Title="" Language="C#" EnableEventValidation="false"   MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ClassificationOfStaff.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.StaffClassification.ClassificationOfStaff" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script src="/js/listBoxMovement.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <asp:UpdatePanel ID="UPDATE1" runat="server">
        <ContentTemplate>
                 <div class="row">
                        <div class="col-md-8 col-md-offset-2">
                            <section class="panel">
                                <header class="panel-heading">
                                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                                        Classification of Staff
                                </header>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="form-group">
                                            <strong><asp:Label ID="lblMsgDis" runat="server"></asp:Label><br/>
                                            <asp:Label ID="lblmsg" runat="server" ></asp:Label></strong> 
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5 form-group">
                                            <div class="form-group">
                                                <label>Category For:</label>
                                                <asp:DropDownList ID="ddlCategoryFor" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True"> 
                                                </asp:DropDownList>
                                        
                                            </div>
                                        </div>
                                        <div class="col-md-2 form-group">
                                        </div>
                                        <div class="col-md-5 form-group">
                                            <div class="form-group">
                                                <label>Category:</label>
                                                <asp:DropDownList ID="ddlCatagory" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlCatagory_SelectedIndexChanged" > 
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                            
                                    <div class="row">
                                        <div class="col-md-5 ">
                                            <div class="form-group">
                                                <label>List Of Unassigned Position:</label>
                                                <asp:DropDownList ID="DdlUnassigned" runat="server" CssClass="form-control" 
                                                    size="30" multiple="multiple"  Width="100%"  onselectedindexchanged="DdlUnassigned_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                <div class="btn btn-primary text-center" onclick="listbox_selectall('<%=DdlUnassigned.ClientID %>', true)">Select All </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2 text-center" style="margin-top:320px">
                                            <div class="form-group">
                                                <div  class="btn btn-primary text-center" onclick=" return  listbox_moveacross('<%=DdlUnassigned.ClientID %>', '<%=Ddlassigned.ClientID %>');">&gt;&gt;</div><br><br>
                                       
                                            </div>
                                        </div>
                                
                                        <div class="col-md-5 ">
                                            <div class="form-group">
                                                <label>List Of Assigned Position:</label>
                                                <asp:DropDownList ID="Ddlassigned" runat="server" CssClass="form-control" size="30" multiple="multiple" 
                                                    Width="100%" onselectedindexchanged="Ddlassigned_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <div  class="btn btn-primary text-center" onclick="listbox_selectall('<%=Ddlassigned.ClientID %>', true)">Select All </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                                OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="user"
                                                Width="75px" />
                                             <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                            </cc1:ConfirmButtonExtender>
                                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                                OnClick="BtnBack_Click" Text=" Back" />
                                        </div>
                                </div>
                            </section>
                        </div>
                </div>
            </ContentTemplate>
         </asp:UpdatePanel>

</asp:Content>