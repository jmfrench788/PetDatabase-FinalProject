var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Pet/GetPets"
        },
        "columns": [
            { "data": "id", "width": "25%" },
            { "data": "name", "width": "25%" },
            { "data": "petType.name", "width": "25%" },
            { "data": "currentService.name", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                     <div class="w-75 btn-group" role="group">

                        <a href="Pet/Details/${data}"
                            class="btn btn-info btn-sm mx-1">Details</a>
                        <a href="Pet/Edit/${data}"
                            class="btn btn-warning btn-sm mx-1">Edit</a>
                        <a href="Pet/Delete/${data}"
                            class="btn btn-info btn-sm mx-1">Delete</a>
                        </div>
                    `
                },
                "width": "25%"
            }
        ]
    });
}