var ProjectModel = function () {
    var priv = {};
    var pub = {};

    priv.Commit = function (item) {
        var inner = {};
        inner.message = item.commit.message;
        return inner;
    }

    pub.viewModel = function (config) {
        var inner = {}

        inner.commits = ko.observableArray([]);
        inner.showAllCommits = ko.observable(false);


        inner.following = ko.observable(false);

        inner.toggleFollow = function () {
            inner.following(!inner.following());
            $.ajax({
                type: 'POST',
                url: "/project/follow",
                data: { id: config.projectId },
                error: function () {
                    inner.following(!inner.following());
                }
            });
        };

        inner.init = function () {
            inner.checkIfIFollow();
            inner.getCommits()
        }


        inner.checkIfIFollow = function () {
            $.ajax({
                type: 'POST',
                url: "/project/CheckFollowing",
                data: { id: config.projectId },
                success: function (response) {
                    inner.following(response);
                }
            });
        };

        inner.getCommits = function () {
            $.ajax({
                url: "https://api.github.com/repos/" + config.user + "/" + config.repository + "/commits",
                data: "",
                success: function (response) {
                    var i = 0;
                    $.each(response, function () {
                        inner.commits.push(new priv.Commit(this));
                    });
                },
                error: function () {
                    $(".github").hide();
                },
                dataType: "json"
            });
        }

        inner.toggleShowAllCommits = function () {
            inner.showAllCommits = !inner.showAllCommits();
        }


        inner.init();

        return inner;
    }

    return pub;
};