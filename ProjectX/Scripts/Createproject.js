var createModel = function () {
    var priv = {};
    var pub = {};

    priv.role = function (role) {
        switch (role) {
            case 101:
                return { "image": "icon-pencil", "displayRole": "developer", "role": 101 };
                break;
            case 102:
                return { "image": "icon-picture", "displayRole": "designer", "role": 102 };
                break;
            case 103:
                return { "image": "icon-eye-open", "displayRole": "tester", "role": 103 };
                break;
        }
    };

    priv.Helper = function (item, viewModel) {
        var inner = {};
        inner = priv.role(item.Role);

        inner.removeHelper = function () {
            viewModel.helpers.remove(this);
        };

        return inner;
    };


    pub.viewModel = function () {
        var inner = {};
        inner.helpers = ko.observableArray([]);

        inner.addHelper = function (data, event) {
            inner.helpers.push(new priv.Helper({ "Role": $(event.currentTarget).data("id") }, inner));
        };

        inner.getHelpers = function () {
            return ko.toJSON(inner.helpers);
        };

        inner.requestedHelpers = ko.computed(function () {
            if (inner.helpers().length == 0)
                return;

            var helpers="";
            $.each(inner.helpers(), function () {
                helpers += this.role + ",";
            });
            return helpers;
        });

        return inner;
    };




    return pub;
};