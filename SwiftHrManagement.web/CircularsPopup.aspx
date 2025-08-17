<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CircularsPopup.aspx.cs" Inherits="SwiftHrManagement.web.CircularsPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <meta name="keywords" content="Swift Hr" />
    <meta name="description" content="" />
    <meta name="author" content="Swifttech" />

    <title>Swift HR</title>

    <!--common-->
    <link href="~/ui/css/style.css" rel="stylesheet" />
    <link href="~/ui/css/style-responsive.css" rel="stylesheet" />
    <link href="~/ui/css/sweetalert.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right" aria-hidden="true"></i>  
                        Circulars And Documents
                    </header>
                    <div class="panel-body" style="overflow:auto;">
                        <div class="form-group">
                            <strong><asp:Label ID="head" runat="server"></asp:Label></strong>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="body" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <div class="table-responsive">
                                <table class="table table-bordered table-striped table-condensed">
                                    <thead>
                                        <tr>
                                            <th>S.No.</th>
                                            <th>File Description</th>
                                            <th>File Type</th>
                                            <th>Upload Date</th>
                                            <th>Uploaded By</th>
                                            <th>File</th>
                                        </tr>
                                    </thead>
                                    <tbody id="circulars" runat="server">

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </form>
</body>
</html>
