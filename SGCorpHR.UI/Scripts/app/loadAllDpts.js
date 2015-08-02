var uri = '/api/Department/';
$(document).ready(function () {
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

function showSuccessMessage(dptName, action) {
    var msg = "<p> The " + dptName + " department has been successfully " + action + "!</p>";
    return msg;
}