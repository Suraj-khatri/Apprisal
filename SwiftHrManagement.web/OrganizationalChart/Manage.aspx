<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.OrganizationalChart.Manage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Organization Chart</title>     
    <script src="../js/jquery/jquery-1.4.1.js"></script>
    <script src="jsplugin.js" type="text/javascript"></script>
    <script src="orgChartJs.js" type="text/javascript"></script>
    <link href="popupStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        google.charts.load('current', { packages: ["orgchart"] });
        $(document).ready(function () {
            var chart = new orgChart({ url: '<%=ResolveUrl("Manage.aspx") %>',popupHeadText:'Manage Organization Chart'});            
            $("#btnOrgChart").click(function () {
                chart.drawChart();
            });

            setTimeout(function () {
                chart.drawChart();
            }, 1000);
        });

        function ShowDetail(obj) {
            window.open('<%=ResolveUrl("NodeDetail.aspx") %>?nodeId=' + obj[0].NodeId, '_blank', 'height=500,width=1000');        
            return false;
        }

    </script>
</head>
<body>
    
     <form id="form1" runat="server">
        <div>
            <div id="chart_div">
            </div>
            <input type="button" name="btnOrgChart" id="btnOrgChart" value="Org Chart" style="display:none" />            
        </div>
    </form>
</body>
</html>
