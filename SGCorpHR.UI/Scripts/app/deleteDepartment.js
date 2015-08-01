var uri = '/api/Departments/';
$(document).ready(function() {
    loadDepartmentNames();
});

function loadDepartmentNames() {
    $.getJSON(uri)
       .done(function (data) {
           $('#listAllDpts select option').remove();
            $('#listAllDpts select').append('<option disabled selected> -- Select a Department -- </option>');
           $.each(data, function (index, department) {
               $(createDropdown(department)).appendTo($('#listAllDpts select'));
            });
        });
}

function createDropdown(department) {
    return '<option value="' + department.DepartmentID + '">' + department.DepartmentName + '</option>';
}

function deleteDpt() {
    var id = $(':selected').val();
    var dptName = $(':selected').text();

    $.ajax({
        url: uri+id,
        dataType: "json",
        type: "DELETE",
        data: JSON.stringify({ id: 20 }),
        async: true,
        processData: false,
        cache: false,
        success: function (data, status, xhr) {
            $('.actionMsg p').remove();
            loadDepartmentNames();
            $(showSuccessMessage(dptName,"deleted")).appendTo($('.actionMsg'));

        },
        error: function (xhr) {
            $('.actionMsg').text("error");
        }
    });
}


function showSuccessMessage(dptName, action) {
    var msg = "<p> The "+dptName+" department has been successfully " + action+"!</p>";
    return msg;
}