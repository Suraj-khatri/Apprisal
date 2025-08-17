<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="UploadInfo.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.UploadInfo" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Upload Employee Information</h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="form-group">
                        <label>Choose excel file</label>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:FileUpload ID="Emp_uploadFile" runat="server" CssClass="btn btn-default" />
                            </div>
                            <div class="col-md-4">
                               
                                <asp:Button ID="btnUploadEmp" runat="server" CssClass="btn btn-info btn-sm" Text="Upload Employee Record" OnClick="btnUploadEmp_Click" Ispostback="false" />
                                 <asp:Button ID="btnDownloadEmp" runat="server" CssClass="btn btn-warning btn-sm" Text="Download Sample" OnClick="btnDownloadEmp_Click" Ispostback="false" />
                            </div>
                        </div>
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-bold"></asp:Label>
                    </div>
                </div>

            </div>
        </div>
        <div class="col-md-10 col-md-offset-1">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Upload Promotion Record</h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="form-group">
                        <label>Choose excel file</label>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:FileUpload ID="FilePromotionUpload" runat="server" CssClass="btn btn-default" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnUploadPromotion" runat="server" CssClass="btn btn-info btn-sm" Text="Upload Promotion Record"  OnClick="btnUploadPromotion_Click"/>
                             <asp:Button ID="btnDownloadPromotion" runat="server" CssClass="btn btn-warning btn-sm" Text="Download Sample" OnClick="btnDownloadPromotion_Click" />
                            </div>
                        </div>
                        <br />
                        <asp:Label ID="lblPromotion" runat="server" Text="" CssClass="text-bold"></asp:Label>
                    </div>
                </div>
                <!-- /.box-body -->

                <!-- /.box-footer -->
            </div>
        </div>
        <div class="col-md-10 col-md-offset-1">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Upload Transfer Record</h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="form-group">
                        <label>Choose excel file</label>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:FileUpload ID="FileUploadTransfer" runat="server" CssClass="btn btn-default" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnUploadTransfer" runat="server" CssClass="btn btn-info btn-sm" Text="Upload Transfer Record" OnClick="btnUploadTransfer_Click" />
                            <asp:Button ID="btnDownloadTransfer" runat="server" CssClass="btn btn-warning btn-sm" Text="Download Sample" OnClick="btnDownloadTransfer_Click"  />
                                 </div>
                        </div>
                        <br />
                        <asp:Label ID="lblTransfer" runat="server" Text="" CssClass="text-bold"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
