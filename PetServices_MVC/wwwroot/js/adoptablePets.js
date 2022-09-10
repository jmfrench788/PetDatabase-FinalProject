var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "AdoptablePet/GetAdoptablePets"
        },
        "columns": [
            { "data": "id", "width": "25%" },
            { "data": "name", "width": "25%" },
            { "data": "petType.name", "width": "25%" },
            { "data": "adoptionStatus", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                     <div class="w-75 btn-group" role="group">

                        <a href="AdoptablePet/Details/${data}"
                            class="btn btn-info btn-sm mx-1">Details</a>
                        <a href="AdoptablePet/Edit/${data}"
                            class="btn btn-warning btn-sm mx-1">Edit</a>
                        <a href="AdoptablePet/Delete/${data}"
                            class="btn btn-info btn-sm mx-1">Delete</a>
                        </div>
                    `
                },
                "width": "25%"
            }
        ]
    });
}