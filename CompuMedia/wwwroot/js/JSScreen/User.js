let DataTable;
let FormType = 1;
let ID= 0;
function Save() {
    var Form = $("#Frm");
    Form.validate();
    if (Form.valid()) {
        var UserViewModel = {
            FormType: FormType,
            Name: $("#Name").val(),
            Email: $("#Email").val(),
            Password: $('#Password').val(),
        };
        var data = { UserViewModel };
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            datatype: 'json',
            contenttype: 'application/json; charset=utf-8',
            url: '/User/Save',
            data: data,
            success: function (data) {
                if (data === 1) {
                  //  swal("Good job!", "Done", "success");
                

                    swal("Good job!", "Done", "success")
                        .then((value) => {
                            window.location.reload();
                        });
                    New();
                }
                else {
                    swal("Error", "Error", "error");
                    window.location.reload();
                }
            },
            error: function (data) { }
        })
    }
}

function New() {
    FormType = 1;
    $("#Name").val('');
    $("#Email").val('');
    $("#Password").val('');
    $("#ConfirmPassword").val('');

}
function Edit(Element) {
    FormType = 2;
    $("#Name").val($(Element).parents('td').prev().prev().text());
    $("#Email").val($(Element).parents('td').prev().text()).attr('readonly', 'readonly');
}
function Delete(Element) {

    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this imaginary User!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                var email = $(Element).parents('td').prev().prev().text();
                $.ajax({
                    type: "POST",
                    cache: false,
                    async: true,
                    datatype: 'json',
                    contenttype: 'application/json; charset=utf-8',
                    url: '/User/Delete',
                    data: { Email: email },
                    success: function (data) {
                        if (data === 1) {
                            swal("Good job!", "Done", "success")
                                .then((value) => {
                                    window.location.reload();
                                });
                            New();
                        }
                        else {
                            swal("Error", "Error", "error");
                            window.location.reload();
                        }
                    },
                    error: function (data) { }
                })
            } else {
                swal("User is safe!");
            }
        });




}
function MarkDone(element) {
    $(element).parents('tr').css('background-color', 'green');
    $(element).hide();
}
function Drow(UserLst) {
    for (var i = 0; i < UserLst.length; i++) {
        DataTable.row.add([
            UserLst[i].name, UserLst[i].email, "<input type='button' class='btn btn-info' value='Edit' onclick='Edit(this)'/>", "<input type='button' class='btn btn-info' value='Delete' onclick='Delete(this)'/>", "<input type='button' class='btn btn-info' value='Mark Done' onclick='MarkDone(this)'/>"
        ]).draw(false);
    }
}
$(function () {

    //swal("Good job!", "You clicked the button!", "success");
    DataTable = $("#tb").DataTable();
    Drow(Users);
    $("#btnsave").click(function () {
        Save();
    })
    $("#New").click(function () {
        New();
    })
})