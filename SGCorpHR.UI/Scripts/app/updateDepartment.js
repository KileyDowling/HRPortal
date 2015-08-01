function updateDpt() {
    var id = $(':selected').val();
    var dptName = $(':selected').text();

    $('#updateDepartmentModal').modal('show');

    $('#btnSaveUpdatedDepartment').click(function() {
        var department = {};
        department.DepartmentName = $('#updatedName').val();
        department.DepartmentID = id;

        $.ajax({
            url: uri,
            dataType: "json",
            data: department,
            type: "PUT",
            success: function (data, status, xhr) {
                $('#updateDepartmentModal').modal('hide');
                $('.actionMsg p').remove();
                loadDepartmentNames();
                $(showSuccessMessage(dptName, "updated to " + department.DepartmentName)).appendTo($('.actionMsg'));

            },
            error: function (jqXhr, status, err) {
                $('.actionMsg').text("error");
            }
        });
    });
}

