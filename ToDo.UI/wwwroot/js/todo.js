
var todoid;


$(document).ready(function () {

    

    var dataa = GetToDoList();

    $("#todosTable").DataTable({

        data: dataa,
        "columns": [
            { data: "description", "autoWidth": true },
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
        fail: {     }
    });
    return dataa;
}






$("#AddToDoBtn").click(function () {
    var Description = $("#description").val();

    $.ajax({
        type: "POST",
        url: "https://localhost:44389/todoservice/addtodo",
        dataType: "JSON",
        contentType: "application/json; charset-utf-8",
        data: JSON.stringify({ 'Description': Description }),
        success: function (data) {

            $('#todosTable').dataTable().fnClearTable();
            var _data = GetToDoList();
            if (_data.length != 0) {
                $("#todosTable").dataTable().fnAddData(_data);

            }
        }
    });
});



$("#EditToDoBtn").click(function () {

    var Id = Number(todoid);
    var Description = $("#editdescrptn").val();
    $.ajax({
        type: "POST",
        url: "https://localhost:44389/todoservice/updatetodo",
        dataType: "JSON",
        contentType: "application/json; charset-utf-8",
        data: JSON.stringify({ 'Id': Id, 'Description': Description }),
        success: function (data) {
            $('#todosTable').dataTable().fnClearTable();
            var _data = GetToDoList();
            if (_data.length != 0) {
                $("#todosTable").dataTable().fnAddData(_data);

            }
        }
    });

});



function GettodoInfo(id) {
    todoid = id;

}




function DeleteToDo(id) {

    var todoId = Number(id);
    $.ajax({
        type: "DELETE",
        url: "https://localhost:44389/todoservice/deletetodo",
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'Id': todoId }),
        success: function (data) {
            $('#todosTable').dataTable().fnClearTable();
            var _data = GetToDoList();
            if (_data.length != 0) {
                $("#todosTable").dataTable().fnAddData(_data);

            }
        }
    });
}
