var GitModel = function () {
    var priv = {};
    var pub = {};

    priv.Commit = function (item) {
        var inner = {};
        inner.message = item.commit.message;
        return inner;
    };

    pub.viewModel = function(config) {
        var inner = { };

        inner.commits = ko.observableArray([]);
        inner.showAllCommits = ko.observable(false);

        inner.getCommits = function() {
            $.ajax({
                url: "https://api.github.com/repos/" + config.user + "/" + config.repository + "/commits",
                data: "",
                success: function(response) {
                    var i = 0;
                    $.each(response, function() {
                        inner.commits.push(new priv.Commit(this));
                    });
                },
                error: function() {
                    $(".github").hide();
                },
                dataType: "json"
            });
        };
        inner.toggleShowAllCommits = function() {
            inner.showAllCommits = !inner.showAllCommits();
        };


        inner.getCommits();

        return inner;
    };

    return pub;
};