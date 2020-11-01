let DataTable;
let FormType = 1;
let ID = 0;
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
                            window.location.href="/login/login";
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
$(function () {
    $("#btnsave").click(function () {
        Save();
    })
    $("#New").click(function () {
        New();
    })
})