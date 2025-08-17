// Defining angularjs Controller and injecting CustomersService
app.directive("select2", function ($timeout, $parse) {
    return {
        restrict: 'AC',
        require: 'ngModel',
        link: function (scope, element, attrs) {
            console.log(attrs);
            $timeout(function () {
                element.select2();
                element.select2Initialized = true;
            });

            var refreshSelect = function () {
                if (!element.select2Initialized) return;
                $timeout(function () {
                    element.trigger('change');
                });
            };

            var recreateSelect = function () {
                if (!element.select2Initialized) return;
                $timeout(function () {
                    element.select2('destroy');
                    element.select2();
                });
            };

            scope.$watch(attrs.ngModel, refreshSelect);

            if (attrs.ngOptions) {
                var list = attrs.ngOptions.match(/ in ([^ ]*)/)[1];
                // watch for option list change
                scope.$watch(list, recreateSelect);
            }

            if (attrs.ngDisabled) {
                scope.$watch(attrs.ngDisabled, refreshSelect);
            }
        }
    };
});

app.controller('ChangeSupervisorCtrl', function ($scope, $http, Journal) {
    $scope.EmpList = [];
    $scope.SuvList = [];
    $scope.RevList = [];
    $scope.BranchList = [];
    $scope.DepartList = [];
    $scope.PositionList = [];
    $scope.error = false;
    $scope.mgs = "";


    $scope.AppraisalList = [];
    $scope.SUV = [];
    $scope.Search = [];
    $scope.FilterRecord = function (Search) {
        debugger
        var Eid=0, Sid=0, Rid = 0;
        if ($scope.Search.EmpId)
        {
            Eid= $scope.Search.EmpId.Value;
        }
        if ($scope.Search.RevId)
        {
            Rid = $scope.Search.RevId.Value;
        }
        if ($scope.Search.SuvId)
        {
            Sid  =$scope.Search.SuvId.Value;
        }
        
        Journal.AppraisalList(0, Eid, Sid, Rid).then(function (d) {
            $scope.AppraisalList = d.data;
        }, function () {
            alert('Unable to Get appraisal  List !!!');
        });
    }
    Journal.AppraisalList(0, 0, 0, 0).then(function (d) {
        $scope.AppraisalList = d.data;
    }, function () {
        alert('Unable to Get appraisal  List !!!');
    });
    $scope.LoadData = function () {
        Journal.DepartmentBranch('B', 0).then(function (d) {

            $scope.BranchList = d.data;
        }, function () {
            alert('Unable to Get Branch List !!!');
        });
        Journal.DepartmentBranch('P', 0).then(function (d) {

            $scope.PositionList = d.data;
        }, function () {
            alert('Unable to Get Position List !!!');
        });
    }
    $scope.LoadDepartment = function (Id) {
      debugger
            if (Id) {
               
                var branchId = Id.Value;
                Journal.DepartmentBranch('D', branchId).then(function (d) {

                    $scope.DepartList = d.data;
                    console.log($scope.DepartList);
                    $scope.error = true;
                }, function () {
                    alert('Unable to Get Department List !!!');
                });
            
        }
       
        
    }
    $scope.UpdateSupervisor = function (appid, supid) {
        $scope.SUV.APPId = appid;
        $scope.SUV.SuvIdOld = supid;
        $scope.error = false;
        $scope.success = false
        $scope.mgs = "";
        Journal.AppInfo($scope.SUV.APPId).then(function (d) {
            for (var i = 0; i < d.data.length; i++) {
                $scope.SUV.reviewer = d.data[i].Reviewer;
                $scope.SUV.Supervisor = d.data[i].Supervisor;
                $scope.SUV.EmpName = d.data[i].AppriseeName;
                $scope.SUV.Department = d.data[i].Department;
                $scope.SUV.Branch = d.data[i].Branch;
                $scope.SUV.Position = d.data[i].Position;
                $scope.SUV.StartDate = d.data[i].StartDate;
                $scope.SUV.EndDate = d.data[i].EndDate;
                console.log(d.data[i]);
            }
        });
        Journal.Emplist('all').then(function (d) {
            $scope.SuvList = d.data;
        });
        $scope.LoadData();

        for (var j = 0; j < $scope.BranchList.length; j++) {
            
            if ($scope.BranchList[j].text == $scope.SUV.Department) {
                console.log($scope.BranchList[j].text);
                $scope.BranchList[j].isSelected = 'selected';
            }
        }
    };
    $scope.UpdateReviewer = function (appid, revid) {
        
        $scope.SUV.APPId = appid;
        $scope.SUV.RevIdOld = revid;
        $scope.error = false;
        $scope.mgs = "";
        Journal.AppInfo($scope.SUV.APPId).then(function (d) {
            for (var i = 0; i < d.data.length; i++) {
                $scope.SUV.reviewer = d.data[i].Reviewer;
                $scope.SUV.Supervisor = d.data[i].Supervisor;
                $scope.SUV.EmpName = d.data[i].AppriseeName;
                $scope.SUV.Department = d.data[i].Department;
                $scope.SUV.Branch = d.data[i].Branch;
                $scope.SUV.Position = d.data[i].Position;
                $scope.SUV.StartDate = d.data[i].StartDate;
                $scope.SUV.EndDate = d.data[i].EndDate;
                console.log(d.data[i]);
            }
        });
        Journal.Emplist('all').then(function (d) {
            $scope.RevList = d.data;
        });
    };
    $scope.ChangeSupervisor = function (SUV) {
        if (!$scope.SUV.ChangeAllSuv) {
            $scope.SUV.ChangeAllSuv = false;
        }
        if (!$scope.SUV.SuvIdNew) {
            $scope.error = true;
            $scope.mgs = "Select new superviso from the list";
            return false;

        } else {

            Journal.UpdateSupervisor($scope.SUV.SuvIdOld, $scope.SUV.SuvIdNew.Value, $scope.SUV.APPId, $scope.SUV.ChangeAllSuv, 'suv').then(function (d) {


                $scope.error = false;
                alert("Supervisor updated successfully");
                $scope.SUV = [];
                Journal.AppraisalList(0,0,0,0).then(function (d) {
                    $scope.AppraisalList = d.data;
                }, function () {
                    alert('Unable to Get appraisal  List !!!');
                });
            });
        }
        
    }
    $scope.ChangeReviewer = function (SUV) {
        if (!$scope.SUV.ChangeAllReviewer) {
            $scope.SUV.ChangeAllReviewer = false;
        }
        if (!$scope.SUV.NewRevId) {
            $scope.error = true;
            $scope.mgs = "Select new Reviewer from the list";
            return false;

        } else {

            Journal.UpdateSupervisor($scope.SUV.RevIdOld, $scope.SUV.NewRevId.Value, $scope.SUV.APPId, $scope.SUV.ChangeAllReviewer, 'rev').then(function (d) {


                $scope.error = false;
                alert("Reviewer updated successfully");
                $scope.SUV = [];
                Journal.AppraisalList(0,0,0,0).then(function (d) {
                    $scope.AppraisalList = d.data;
                }, function () {
                    alert('Unable to Get appraisal  List !!!');
                });
            });
        }

    }
    Journal.Emplist('e').then(function (d) {

        $scope.EmpList = d.data;
    }, function () {
        alert('Unable to Get employee List  List !!!');
    });
    Journal.Emplist('s').then(function (d) {
        $scope.SuvList = d.data;
    }, function () {
        alert('Unable to Get employee List  List !!!');
    });
    Journal.Emplist('s').then(function (d) {
        $scope.RevList = d.data;
    }, function () {
        alert('Unable to Get employee List  List !!!');
    });
   
});
