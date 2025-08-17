<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="LetterReport.aspx.cs" Inherits="SwiftHrManagement.web.LetterTemplate.LetterReport" %>

<%

    Response.ContentType = "application/msword";

%>
<html>
<head>
    <STYLE TYPE='text/css'>
        P.pagebreakhere {page-break-before: always}
    </STYLE>
</head>
<body>
    <div runat="server" id="rptDiv"> </div>
    
</body>
</html>
