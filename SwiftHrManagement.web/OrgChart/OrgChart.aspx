<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgChart.aspx.cs" Inherits="SwiftHrManagement.web.OrgChart.OrgChart1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript" src="http://www.google.com/jsapi"></script>
    <script src="js/jquery-3.0.0.min.js" type="text/javascript"></script>
     <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        google.charts.load('current', { packages: ["orgchart"] });
        $(document).ready(function () {
        });
        $(function () {
            $('#btnOrgChart').click(function (e) {
                var dataToSend = { MethodName: 'data' };
                var options =
                            {
                                url: '<%=ResolveUrl("OrgChart.aspx") %>?x=' + new Date().getTime(),
                                data: dataToSend,
                                dataType: 'JSON',
                                type: 'POST',
                                success: function (response) {
                                    OnSuccess_getOrgData(response);
                                }
                            };
                $.ajax(options);

                return true;
            });

            function OnSuccess_getOrgData(repo) {
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Name');
                data.addColumn('string', 'Manager');
                data.addColumn('string', 'ToolTip');

                var response = eval(repo);
                for (var i = 0; i < response.length; i++) {
                    var empName = response[i].Employee;
                    var empId = response[i].empID;
                    var mgrId = response[i].mgrID;
                    var designation = response[i].designation;
                    
                    data.addRows([[{
                        v: empId,
                        f: empName
                    }, mgrId, designation]]);
                }
                
                
                var chart = new google.visualization.OrgChart(document.getElementById('chart_div'));
                chart.draw(data, { allowHtml: true });
            }

            function OnErrorCall_getOrgData() {
                console.log("Whoops something went wrong :( ");
            }
        });
</script>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
    <input type="button" name="btnOrgChart" id="btnOrgChart" value="Org Chart" />
   <div id="chart_div"></div>

    </div>
    </form>
</body>
</html>
