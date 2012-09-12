var createModel = function () {
    var priv = {};
    var pub = {};

    priv.role = function (role) {
        switch (role) {
            case 0:
                return { "image": "icon-pencil", "role": "developer" };
                break;
            case 1:
                return { "image": "icon-picture", "role": "designer" };
                break;
            case 2:
                return { "image": "icon-eye-open", "role": "tester" };
                break;
        }
    };

    priv.Helper = function (item, viewModel) {
        var inner = {};
        inner = priv.role(item.Role);

        inner.removeHelper = function () {
            viewModel.helpers.destroy(this);
        };

        return inner;
    };


    pub.viewModel = function () {
        var inner = {};
        inner.helpers = ko.observableArray([]);

        inner.addHelper = function (data, event) {
            inner.helpers.push(new priv.Helper({ "Role": $(event.currentTarget).data("id") }, inner));
        };

        return inner;
    };


    return pub;
};