function deleteBugs(params) {
    $.ajax({
        url: "/Bug/Delete",
        type: "POST",
        data: { "source": params.bugSource },
        success: function (data) {
            alert(data.msg);
            $('#bugs').DataTable().clear();
            $('#bugs').DataTable().ajax.reload();
        }

    });
}

    function getBugList(status) {
     $("#bugs").DataTable({
        // Design Assets
        stateSave: true,
        autoWidth: true,
        // ServerSide Setups
        processing: false,
        serverSide: false,
        // Paging Setups
        paging: true,
        // Searching Setups
        searching: { regex: true },
        // Ajax Filter
        ajax: {
            url: "/Bug/GetBugs",
            type: "POST",
            data: { status: status },
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            "dataSrc": ""
        },
        // Columns Setups
        columns: [

            { data: "id" },
            { data: "productName" },
            { data: "componentName" },

            {
                data: "severity",
                render: function (data, type, dataItem) {
                    // data in this case is developerId
                    // type can be display, filter etc
                    // dataItem is the current row
                    switch (data) {
                        case 1: return "Blocker";
                        case 2: return "Critical";
                        case 3: return "Major";
                        case 4: return "Normal";
                        case 5: return "Minor";
                        case 6: return "Trivial";
                        case 7: return "Enhancement";

                    }

                    return "N/A";
                }
            },
            {
                data: "priority",
                render: function (data, type, dataItem) {
                    // data in this case is developerId
                    // type can be display, filter etc
                    // dataItem is the current row
                    switch (data) {
                        case 0: return "Not Defined";
                        case 1: return "P1";
                        case 2: return "P2";
                        case 3: return "P3";
                        case 4: return "P4";
                        case 5: return "P5";
                        case 6: return "P6";
                      

                    }

                    return "N/A";
                }
            },
            {
                data: "bugId",
                render: function (data, type, dataItem) {
                    // data in this case is developerId
                    // type can be display, filter etc
                    // dataItem is the current row
                    var html = "<a  class='btn btn-default' href='/Bug/Details/" + data + "' >View Profile</a>"
                    return html;
                }
            },
        ],
        // Column Definitions
        columnDefs: [
            { targets: "no-sort", orderable: false },
            { targets: "no-search", searchable: false },
            { "orderable": false, "targets": -1 },
            {
                targets: "trim",
                render: function (data, type, full, meta) {
                    if (type === "display") {
                        data = strtrunc(data, 10);
                    }

                    return data;
                }
            },
            { targets: "date-type", type: "date-eu" }
        ]
    });
    }


