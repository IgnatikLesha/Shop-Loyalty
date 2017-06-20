
    function processData(data) {
        var target = $("#tableBody");
        target.empty();
        for (var i = 0; i < data.length; i++) {
            var task = data[i];
            target.append("<tr><td>" + task.Name + "</td><td>"
                + task.Description + "</td><td>" + task.Checked
                + "</td></tr>");
        }
    }


    (function() {
        $("#smt").click(function() {
            var actionUrl = '@Url.Action("ShowMyTasksJson", "Home")';
            $.getJSON(actionUrl, displayData);
        });
    });

    function displayData(response) {
        if (response != null) {
            for (var i = 0; i < response.length; i++) {
                $("#tableBody").append("<tr><td>" + response.Name + "</td><td>"
                    + response.Description + "</td><td>" + response.Checked
                    + "</td></tr>");
            }
        }
    }




(function () {
    var $id = $(".TaskId").text();
    var $thisBtn = $("#btnDone");
    $thisBtn.on("click", done($thisBtn));
    var passTask = $(".btn-primary").css("cursor");
    if (passTask === "pointer") {
        $.ajax({
            url: "/api/home/SETDONE/" + $id
        });
    }

});

function done(btn) {

    btn.off("click");
    btn.css({ "color": "red", "cursor": "default" });

}


