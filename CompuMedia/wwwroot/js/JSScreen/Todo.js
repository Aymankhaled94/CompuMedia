let DataTable;
let FormType = 1;
let ID = 0;
function Save() {
    var Form = $("#Frm");
    Form.validate();
    if (Form.valid()) {
        var TodoViewModel = {
            FormType: FormType,
            Title: $("#Title").val(),
            Action: $("#Action").val(),
            DueTime: $('#DueTime').val(),
            UserId: $('#UserId').val(),
        };
        var data = { TodoViewModel };
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            datatype: 'json',
            contenttype: 'application/json; charset=utf-8',
            url: '/Todo/Save',
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
    $("#Title").val('');
    $("#Action").val('');
    $("#DueTime").val('');
    $("#UserId").val('');

}
function Edit(Element) {
    FormType = 2;
    $("#Title").val($(Element).parents('td').prev().prev().text()).attr('readonly', 'readonly');
    $("#Action").val($(Element).parents('td').prev().text());
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
                var Title = $(Element).parents('td').prev().prev().prev().text();
                $.ajax({
                    type: "POST",
                    cache: false,
                    async: true,
                    datatype: 'json',
                    contenttype: 'application/json; charset=utf-8',
                    url: '/Todo/Delete',
                    data: { Title: Title },
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
            UserLst[i].title, UserLst[i].action, "<input type='button' class='btn btn-info' value='Edit' onclick='Edit(this)'/>", "<input type='button' class='btn btn-info' value='Delete' onclick='Delete(this)'/>", "<input type='button' class='btn btn-info' value='Mark Done' onclick='MarkDone(this)'/>"
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