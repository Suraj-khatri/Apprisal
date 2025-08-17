// Defining angularjs Controller and injecting CustomersService

app.controller('ReviewInitationCtrl', function ($scope, $http, Journal, filterFilter) {

    $scope.Search = [];
    $scope.ErrorMgs = "";
    $scope.FiscalMgs = "";
    $scope.ApprisalList = null;
    $scope.ReviewinitiationcList = null;
    $scope.FiscalList = null;
    Journal.ReviewinitiationcList().then(function (d) {
        $scope.ReviewinitiationcList = d.data;
    }, function () {
        alert('Unable to Get Apprisal AgreementList  List !!!');
    });
    Journal.FiscalYearList().then(function (d) {
        $scope.FiscalList = d.data;
    }, function () {
        alert('Unable to Get Fisacal  List !!!');
    });
    $scope.FilterData = function (Search) {
        debugger
        var fiscal = 0;
        var Emp = 0;
        var ststus = 0;
        if (!$scope.Search.FiscalYear) {

            $scope.FiscalMgs = "Please select fiscal Year";

            if (!$scope.Search.FiscalYear && !$scope.Search.EmpId && !$scope.Search.Status) {

                $scope.ErrorMgs = "Please select at least a parameter";
            }
        }


        else {
            debugger
            if ($scope.Search.EmpId) {
                Emp = Search.EmpId.Value;
            }
            if ($scope.Search.Status) {
                ststus = Search.Status.Value;
            }
            if ($scope.Search.FiscalYear) {
                fiscal = Search.FiscalYear.Value;
            }
            Journal.FilterReviewinitiationcList(fiscal, Emp).then(function (d) {
                $scope.ReviewinitiationcList = d.data;
                $scope.ErrorMgs = "";
                $scope.FiscalMgs = "";

            }, function () {
                alert('Unable to Get apprisee  List !!!');
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

});
