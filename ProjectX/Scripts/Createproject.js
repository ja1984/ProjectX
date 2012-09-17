var createModel = function () {
    var priv = {};
    var pub = {};

    priv.role = function (role) {
        switch (role) {
            case 0:
                return { "image": "icon-pencil", "displayRole": "developer", "role": 0 };
                break;
            case 1:
                return { "image": "icon-picture", "displayRole": "designer", "role": 1 };
                break;
            case 2:
                return { "image": "icon-eye-open", "displayRole": "tester", "role": 2 };
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

            console.log(inner.helpers());
            return helpers;
        });

        return inner;
    };




    return pub;
};