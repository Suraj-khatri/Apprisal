// Defining angularjs Controller and injecting CustomersService

app.controller('JdCtrl', function ($scope, $http, Journal, filterFilter, $window, $location) {

    $scope.Search = [];
    $scope.ErrorMgs = "";
    $scope.FiscalMgs = "";
    $scope.IsAdmin = false;
    $scope.JobDescriptionList = null;
    $scope.FiscalList = null;
    $scope.JdHrdList = null;
    $scope.loading = false;
    Journal.AdminJDList('').then(function (d) {
        $scope.JdHrdList = d.data;
        $scope.loading = true;
    }, function () {
        console.log('Unable to Get JD  List !!!');
    });
    Journal.IsHrAdmin(null).then(function (d) {
        if (d.data == 1) {
            $scope.IsAdmin = true;
        } else {
            $scope.IsAdmin = false;
        }

    });

    Journal.JodDescList('').then(function (d) {
        $scope.JobDescriptionList = d.data;
    }, function () {
         console.log('Unable to Get JD  List !!!');
    });

    Journal.FiscalYearList().then(function (d) {
        $scope.FiscalList = d.data;
    }, function () {
         console.log('Unable to Get Fisacal  List !!!');
    });
    $scope.FilterData = function (Search) {
        var fiscal = 0;
        var Emp = 0;
        if (!$scope.Search.FiscalYear) {

            $scope.FiscalMgs = "Please select fiscal Year";

            if (!$scope.Search.FiscalYear && !$scope.Search.EmpId && !$scope.Search.Status) {

                $scope.ErrorMgs = "Please select at least a parameter";
            }
        }
        else {
            if ($scope.Search.EmpId) {
                Emp = Search.EmpId.Value;
            }
            if ($scope.Search.FiscalYear) {
                fiscal = Search.FiscalYear.Value;
            }
            Journal.FilterJodDescList(fiscal, Emp, 't').then(function (d) {
                $scope.JobDescriptionList = d.data;
                $scope.ErrorMgs = "";
                $scope.FiscalMgs = "";


            }, function () {
                 console.log('Unable to Get Job Description  List !!!');
            });

        }
        
    }
    $scope.baseUrl = new $window.URL($location.absUrl()).origin;
    $scope.printPdf = function (Id) {
        debugger
        var url = $scope.baseUrl + "/Company/EmployeeWeb/JobDescription/PrintJd.aspx?Id="+Id;
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
});
app.controller('JdListCtrl', function ($scope, $http, Journal, filterFilter, $window, $location) {

    $scope.Search = [];
    $scope.ErrorMgs = "";
    $scope.FiscalMgs = "";
    $scope.JobDescriptionList = null;
    $scope.FiscalList = null;
    Journal.JodDescList('List').then(function (d) {
        $scope.JobDescriptionList = d.data;
    }, function () {
         console.log('Unable to Get Apprisal AgreementList  List !!!');
    });
    Journal.FiscalYearList().then(function (d) {
        $scope.FiscalList = d.data;
    }, function () {
         console.log('Unable to Get Fisacal  List !!!');
    });
    $scope.FilterData = function (Search) {
        var fiscal = 0;
        var Emp = 0;
        if (!$scope.Search.FiscalYear) {

            $scope.FiscalMgs = "Please select fiscal Year";

            if (!$scope.Search.FiscalYear && !$scope.Search.EmpId) {

                $scope.ErrorMgs = "Please select at least a parameter";
            }
        }


        else {
            if ($scope.Search.EmpId) {
                Emp = Search.EmpId.Value;
            }
            if ($scope.Search.FiscalYear) {
                fiscal = Search.FiscalYear.Value;
            }
            Journal.FilterJodDescList(fiscal, Emp, 'List').then(function (d) {
                $scope.JobDescriptionList = d.data;
                $scope.ErrorMgs = "";
                $scope.FiscalMgs = "";

            }, function () {
                 console.log('Unable to Get Job Description  List !!!');
            });

        }

    }
    $scope.baseUrl = new $window.URL($location.absUrl()).origin;
    $scope.printPdf = function (Id) {
        debugger
        var url = $scope.baseUrl + "/Company/EmployeeWeb/JobDescription/PrintJd.aspx?Id=" + Id;
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
});