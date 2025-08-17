
var app = angular.module("ReviewModule", ['angularUtils.directives.dirPagination']);

app.config(function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
});