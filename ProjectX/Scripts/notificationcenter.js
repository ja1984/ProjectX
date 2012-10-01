var loggedInModel = function () {
    var priv = {};
    var pub = {};

    pub.viewModel = function (config) {
        var inner = {}

        inner.messageNotifications = ko.observable(0);
        inner.projectNotifications = ko.observable(0);

        inner.totalNotifications = ko.computed(function () {
            return inner.messageNotifications() + inner.projectNotifications();
        });

        inner.updateNotifications = function () {
            $.ajax({
                type: 'POST',
                url: '/user/GetNotifications',
                data: {},
                dataType: 'json',
                success: function (response) {
                    inner.messageNotifications(response.MessageNotifications);
                    inner.projectNotifications(response.ProjectNotifications);
                }
            });
        };

        inner.updateNotifications();
        return inner;
    };



    return pub;
};