
var set_type, set_url, page_type, proctype;

function InsertData() {

    var set_memberid = $("#userid").val();
    var set_password = $("#password").val();
    var set_name = $("#name").val();
    var set_position = $("#position").val();
    var set_email = $("#email").val();
    var set_date_created = $("#date_created").val();
    var isready = 1;

    if (set_memberid == "") {
        $("#danger_alert").css({ "display": "block" });
        $("#text_alert").text("User ID required!.");
        isready = 0;
    }
    else if (set_password == "") {
        $("#danger_alert").css({ "display": "block" });
        $("#text_alert").text("Password required!.");
        isready = 0;
    }
    else if (set_name == "") {
        $("#danger_alert").css({ "display": "block" });
        $("#text_alert").text("Name required!.");
        isready = 0;
    }
    else if (set_position == "") {
        $("#danger_alert").css({ "display": "block" });
        $("#text_alert").text("Position required!.");
        isready = 0;
    }
    else if (set_date_created == "") {
        $("#danger_alert").css({ "display": "block" });
        $("#text_alert").text("Date required!.");
        isready = 0;
    }

    if (isready == 1) {
        var create_obj = {
            Umt_UserID: set_memberid,
            Umt_Password: set_password,
            Umt_UserName: set_name,
            Umt_UserPosition: set_position,
            Umt_UserEmail: set_email,
            Umt_DateCreated: set_date_created
        }
        var str = "AddRecord";
        SubmitData(create_obj, str);
    }
}

function SubmitData(obj, str) {
    $.ajax({
        url: '/Maintenance/' + str,
        method: "Post",
        data: obj,

        success: function (data) {
            Result(data);
        },
        error: function () {
            console.error(err);
        }
    })
}

function Result(data) {
    if (data == 1) {
        $("#success_alert").css({ "display": "block" });
        $("#text_success_alert").text("New Record Successfully Registered!.");
    }
}



