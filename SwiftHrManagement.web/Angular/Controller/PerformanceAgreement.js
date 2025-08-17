// Defining angularjs Controller and injecting CustomersService

app.controller('PerformanceAgreemnetCtrl', function ($scope, $http, Journal, filterFilter, $location, $window) {

    $scope.Search = [];
    $scope.ErrorMgs = "";
    $scope.FiscalMgs = "";
    $scope.ApprisalList = null;
    $scope.ApprisalAgreementList = null;
    $scope.FiscalList = null;
    $scope.loading = false;
    $scope.IsAdmin = false;
    Journal.AppriseeAgreementList().then(function (d) {
        
        $scope.ApprisalAgreementList = d.data;
        $scope.loading = true;
    }, function () {
        alert('Unable to Get Apprisal AgreementList  List !!!');
    });
    Journal.IsHrAdmin().then(function (d)
    {
        debugger
        if (d.data == 1) {
            $scope.IsAdmin = true;
        } else {
            $scope.IsAdmin = false;
        }
    });
    Journal.StatusList(1).then(function (d) {
        $scope.ApprisalList = d.data;
    }, function () {        alert('Unable to Get Apprisal Status  List !!!');
    });
    Journal.FiscalYearList().then(function (d) {
        $scope.FiscalList = d.data;
    }, function () {
        alert('Unable to Get Fisacal  List !!!');
    });
  
    $scope.Discard = function (appid) {
        
        var isConfirmed = confirm("Are you sure you want to Discard this Appraisal?  Once you discard this Appraisal you will not be able to modify  now onwards  in future !");
        if (isConfirmed) {
            debugger
            Journal.DiscarsApp(appid,"PA").then(function (d) {
                Journal.AppriseeAgreementList().then(function (d) {
                    $scope.ApprisalAgreementList = d.data;
                }, function () {
                    alert('Unable to Get Apprisal AgreementList  List !!!');
                });
                alert(d.data);
            });
        } else {
            return false;
        }
    }
    $scope.FilterData = function (Search) {
        $scope.loading = false;
        var fiscal = 0;
        var Emp = 0;
        var ststus = 0;
        debugger
        if (!$scope.Search.FiscalYear)
        {
            $scope.FiscalMgs = "Please select fiscal Year";
        }  else  {
            if ($scope.Search.Status) {
                ststus = Search.Status.Value;
            }
            if ($scope.Search.FiscalYear) {
                fiscal = Search.FiscalYear.Value;
            }

            if (ststus == 999)
            {
                Journal.FilterReviewList(fiscal, 0, 0).then(function (d) {
                    $scope.ApprisalAgreementList = d.data;
                    $scope.ErrorMgs = "";
                    $scope.FiscalMgs = "";
                    $scope.loading = true;
                }, function () {
                    console.log('Unable to Get apprisee  List !!!');
                });
            } else {
                debugger
                Journal.FilterList(fiscal, 0, ststus).then(function (d) {
                    console.log(d);
                    $scope.ApprisalAgreementList = d.data;
                    $scope.ErrorMgs = "";
                    $scope.FiscalMgs = "";
                    $scope.loading = true;
                }, function () {
                    alert('Unable to Get apprisee  List !!!');
                });
            }

          

        }
    }
    $scope.Reset = function () {
        $scope.Search = [];
        $scope.Search.FiscalYear = null;
        $scope.Search.Status = null;
        $scope.Search.EmpId = null;
    }
    $scope.baseUrl = new $window.URL($location.absUrl()).origin;
    $scope.printPdf = function (AppId, EmpId, status) {
        var url = $scope.baseUrl + "/PerformanceAppraisalNew/PerformanceAgreement/PrintAgreement.aspx?appId=" + AppId + "&empId=" + EmpId + "&status=" + status;
        var iframe = this._printIframe;
        if (!this._printIframe) {
            iframe = this._printIframe = document.createElement('iframe');
            document.body.appendChild(iframe);

            iframe.style.display = 'none';
            iframe.onload = function () {
                setTimeout(function () {
                    iframe.focus();
                    iframe.contentWindow.print();
                }, 1);
            };
        }

        iframe.src = url;
     
        return false;
    }
    $scope.notvalid = function () {
        alert("KRA, KPI for this user has not been created yet")
    }
});
