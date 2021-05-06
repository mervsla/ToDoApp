
var todoid;

$(document).ready(function () {



    var dataa = GetToDoList();

    $("#todosTable").DataTable({

        
        data: dataa,
        "columns": [
            { data: "description", "autoWidth": true },
            { data: "timetoFinish", "autoWidth": true },
            {
                "render": function (data, type, row) {
                    debugger;
                    if (row.isCompleted == true) {
                        return "<span class='badge badge-secondary' disabled>Completed</span>";
                    }
                    else {
                        debugger;
                        return "<a href='#' class='btn btn-success complete'   onclick=Completed('" + row.id + "')>Complete</a>";
                    }
                }
            },
            { data: "createdDate", "autoWidth": true },
            { data: "updatedDate", "autoWidth": true },

            {
                "render": function (data, type, row) {
                    return "<a class='btn btn-danger' onclick=GettodoInfo('" + row.id + "')  data-toggle='modal' data-target='#edittodoModal'>Edit</a>";
                }
            }
            ,

            {
                "render": function (data, type, row) {
                    return "<a  class='btn btn-primary' onclick=DeleteToDo('" + row.id + "')>Delete</a > ";
                }
            }

        ]

    });




});


function GetToDoList() {
    var dataa;
    $.ajax({

        type: "GET",
        url: "https://localhost:44389/todoservice/getalltodos",
        datatype: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            dataa = data;
        },
        fail: {}
    });
    return dataa;
}


function ReloadTable() {
    $('#todosTable').dataTable().fnClearTable();
    var _data = GetToDoList();
    if (_data.length != 0) {
        $("#todosTable").dataTable().fnAddData(_data);

    }
}



function GettodoInfo(id) {
    todoid = Number(id);
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44389/todoservice/gettodoinfo",
        dataType: "JSON",
        contentType: "application/json; charset-utf-8",
        data: JSON.stringify({ 'Id': todoid }),
        success: function (data) {
            $('#editdescrptn').val(data.description);
            $('#editdatetimepicker').val(data.timetoFinish);
        }
    });

}



$("#AddToDoBtn").click(function () {
    var Description = $("#description").val();
    var TimetoFinish = $("#adddatetimepicker").val();
    debugger;

    $.ajax({
        type: "POST",
        url: "https://localhost:44389/todoservice/addtodo",
        dataType: "JSON",
        contentType: "application/json; charset-utf-8",
        data: JSON.stringify({ 'Description': Description, 'TimetoFinish': TimetoFinish}),
        success: function (data) {
            $("#description").val("");
            $("#adddatetimepicker").val("");
            ReloadTable();
        }
    });
});



$("#EditToDoBtn").click(function () {

    var Id = todoid;
    var Description = $("#editdescrptn").val();
    var TimetoFinish = $("#editdatetimepicker").val();
    $.ajax({
        type: "POST",
        url: "https://localhost:44389/todoservice/updatetodo",
        dataType: "JSON",
        contentType: "application/json; charset-utf-8",
        data: JSON.stringify({ 'Id': Id, 'Description': Description, 'TimetoFinish': TimetoFinish }),
        success: function (data) {
            $("#editdescrptn").val("");
            $("#editdatetimepicker").val("");
            ReloadTable();
        }
    });

});




function DeleteToDo(id) {

    var todoId = Number(id);
    $.ajax({
        type: "DELETE",
        url: "https://localhost:44389/todoservice/deletetodo",
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'Id': todoId }),
        success: function (data) {
            ReloadTable();
        }
    });
}


//function isTimeClose() {

//}
//setTnter,100


function Completed(id) {
    var Id = Number(id);
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44389/todoservice/todocompleted",
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'Id': Id }),
        success: function (data) {
            debugger;
                ReloadTable();
        }
    });
}