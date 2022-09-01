
var set_type, set_url, page_type, proctype;

function InsertData() {

    VerifyID();

}

function DisplayAlert(text_alert) {
    $("#danger_alert").css({ "display": "block" });
    $("#text_alert").text(text_alert);
}

function AddNewRecord() {

    var set_memberid = $("#userid").val();
    var set_password = $("#password").val();
    var set_name = $("#name").val();
    var set_position = $("#position").val();
    var set_email = $("#email").val();
    var set_date_created = $("#date_created").val();
    var isready = 1;

    if (set_memberid == "") {
        DisplayAlert("User ID required!.")
        isready = 0;
    }
    else if (set_password == "") {
        DisplayAlert("Password required!.")
        isready = 0;
    }
    else if (set_name == "") {
        DisplayAlert("Name required!.")
        isready = 0;
    }
    else if (set_position == "") {
        DisplayAlert("Position required!.")
        isready = 0;
    }
    else if (set_date_created == "") {
        DisplayAlert("Date required!.")
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

function VerifyID() {

    var str = "VerifyID";
    var set_memberid = $("#userid").val();
    var isready = 1;

    if (set_memberid == "") {
        DisplayAlert("User ID required!.")
        isready = 0;
    }

    if (isready == 1) {
        var obj = {
            Umt_UserID: set_memberid,
        }

        $.ajax({
            url: '/Maintenance/' + str,
            method: "Get",
            data: obj,
            success: function (data) {
                if (data == 1) {
                    DisplayAlert("User ID already Exist!. Try again..");
                }
                else {
                    AddNewRecord();
                }
            },
            error: function () {
                alert(err);
            }
        })
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
        $("#userid").val('');
        $("#password").val('');
        $("#name").val('');
        $("#position").val('');
        $("#email").val('');
    }
}

function deleteRecord() {

    var table = document.getElementById("UserTable"), rIndex;

    for (var i = 0; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            rIndex = this.rowIndex;

            var id = this.cells[1].innerHTML;

            var obj = {
                userid: id
            }

            if (confirm("Are you sure you want to delete this User?")) {
                Deleterecord(obj);
            }
        };
    }

}

function Deleterecord(id) {
    $.ajax({
        url: '/Maintenance/DeleteRecord',
        method: "Post",
        data: id,
        success: function (data) {
            if (data == 1) {
                alert("Record successfuly deleted..");
            }
        },
        error: function () {
            alert(err);
        }
    })

    $("#UserTable").on('click', '.btnDelete', function () {
        $(this).closest('tr').remove();
    });
}