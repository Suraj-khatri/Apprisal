
app.filter('propsFilter', function () {
    return function (items, props) {
        var out = [];
        if (angular.isArray(items)) {
            items.forEach(function (item) {
                var keys = Object.keys(props);
                var prop = keys[0];
                var text = props[prop].toLowerCase();
                if (item[prop].toString().toLowerCase().indexOf(text) === 0) {
                    out.push(item);
                }
            });
        } else {
            out = items;
        }
        return out;
    };
});