function Save() {
    var Form = $("#Frm");
    Form.validate();
    if (Form.valid()) {
        var LoginViewModel = {
            Email: $("#Email").val(),
            Password: $('#Password').val(),
        };
        var data = { LoginViewModel };
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            datatype: 'json',
            contenttype: 'application/json; charset=utf-8',
            url: '/Login/Login',
            data: data,
            success: function (data) {
                if (data === 1) {
                    swal("Good job!", "Done", "success")
                        .then((value) => {
                            window.location.href="/Todo/index";
                        });
                }
                else {
                    swal("Error", "Wrong with in Password or E-mail", "error");
                }
            },
            error: function (data) { }
        })
    }
}
$(function () {
    $("#btnsave").click(function () {
        Save();
    })
    $("#btnRegister").click(function () {
        window.location.href = "/Login/Register";
    })
})