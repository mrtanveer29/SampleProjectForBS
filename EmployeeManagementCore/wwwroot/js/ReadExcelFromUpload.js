function uploadExcel(file, controller, action,data) {
    if (!controller) {
        controller = "Bug";
    }
    if (!action) {
        action = "ImportFromExcel";
    }
    var fileExtension = ['xls', 'xlsx'];
    var filename = file.val();
    //--- Validation for excel file---  
    if (filename.length == 0) {
        alert("Please select a file.");
        return false;
    }
    else {
        var extension = filename.replace(/^.*\./, '');
        if ($.inArray(extension, fileExtension) == -1) {
            alert("Please select only excel files.");
            return false;
        }
    }
    var filedata = new FormData();
    // file uploads
    var fileUpload = file.get(0);
    var files = fileUpload.files;
    filedata.append(files[0].name, files[0]);
    // extra data
    for (var key in data) {
        if (data.hasOwnProperty(key)) {
            filedata.append(key, data[key])
        }
    }
    $('#divData').html("..Please Wait");
    $.ajax({
        type: "POST",
        url: "/" + controller + "/"+action,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: filedata,
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.length == 0)
                alert('Error occurred while uploading the excel file');
            else {
                $('#divData').html(response);
            }
        },
        error: function (e) {
            $('#divData').html(e.responseText);
        }
    });

}