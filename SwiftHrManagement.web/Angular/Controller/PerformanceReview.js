// Defining angularjs Controller and injecting CustomersService

app.controller('PerformanceReviewCtrl', function ($scope, $http, Journal, filterFilter, $location, $window) {

    $scope.Search = [];
    $scope.ErrorMgs = "";
    $scope.FiscalMgs = "";
    $scope.ApprisalList = null;
    $scope.IsAdmin = false;
    $scope.PerformanceReviewList = null;
    $scope.FiscalList = null;
    $scope.loading = false;
    Journal.AppriseeReviewList().then(function (d) {
        
        $scope.PerformanceReviewList = d.data;
        $scope.loading = true;
    }, function () {
        console.log('Unable to Get Apprisal AgreementList  List !!!');
    });
    Journal.FiscalYearList().then(function (d) {
        $scope.FiscalList = d.data;
    }, function () {
        console.log('Unable to Get Fisacal year  List !!!');
    });
    Journal.StatusList(2).then(function (d) {
        $scope.ApprisalList = d.data;
    }, function () {
        console.log('Unable to Get Appraisal Status  List !!!');
    });
    Journal.IsHrAdmin().then(function (d)
    {
        //if (d.data == 1) {
        //    $scope.IsAdmin=true;
        //} else {
        //    $scope.IsAdmin=false;
        //}
        $scope.IsAdmin = d.data; 
    });
    $scope.baseUrl = new $window.URL($location.absUrl()).origin;
    $scope.FilterData = function (Search) {
        var fiscal = 0;
        var Emp = 0;
        var stastus = 0;      
        if (!$scope.Search.FiscalYear)
        {
            $scope.FiscalMgs = "Please select fiscal Year";
        }
        else {

            if ($scope.Search.Status)
            {
                stastus = Search.Status.Value;
            } if ($scope.Search.FiscalYear) {
                fiscal = Search.FiscalYear.Value;
            }
            $scope.loading = false;
            Journal.FilterReviewList(fiscal, 0, stastus).then(function (d) {
                
                $scope.PerformanceReviewList = d.data;
                $scope.ErrorMgs = "";
                $scope.FiscalMgs = "";
                $scope.loading = true;
            }, function () {
                console.log('Unable to Get apprisee  List !!!');
            });

        }
        $scope.showload = false;
    }
    $scope.Reset = function () {
        $scope.Search = [];
        $scope.Search.FiscalYear = null;
        $scope.Search.Status = null;
        $scope.Search.EmpId = null;
    }
    $scope.Discard = function (appid) {
        var isConfirmed = confirm("Are you sure you want to Discard this Appraisal? Once you discard this Appraisal you will not be able to modify it in the future!");
        if (isConfirmed) {
            Journal.DiscarsApp(appid, "PR").then(function (response) {
                alert(response.data); // Show alert after discard response is received

                // Refresh the appraisal list only after successful discard
                Journal.AppriseeReviewList().then(function (listResponse) {
                    $scope.PerformanceReviewList = listResponse.data;
                }, function () {
                    console.error('Unable to get Appraisal Review List!');
                });
            }, function () {
                console.error('Error occurred while discarding the appraisal!');
            });
        }
    };

    $scope.printPdf = function (AppId, EmpId,status) {
        
        var url = $scope.baseUrl+"/PerformanceAppraisalNew/PerformanceReview/ApprisalPrint.aspx?appId=" + AppId + "&empId=" + EmpId + "&status=" + status;
        var iframe = this._printIframe;
        if (!this._printIframe) {
            iframe = this._printIframe = document.createElement('iframe');

            document.body.appendChild(iframe);

            //iframe.style.display = 'none';
            //iframe.onload = function () {
            //    setTimeout(function () {
            //        iframe.focus();
            //        iframe.contentWindow.print();
            //    }, 1);
            //};
        }

        iframe.src = url;
        return false;
    }

});
