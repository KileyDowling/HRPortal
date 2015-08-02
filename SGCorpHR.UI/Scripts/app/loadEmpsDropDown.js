var uri = '/api/EmployeeManagement/';

$(document).ready(function () {
    loadEmployeeNames();
});

function loadEmployeeNames() {
    $.getJSON(uri)
       .done(function (data) {
           $('#listAllEmps select option').remove();
           $('#listAllEmps select').append('<option disabled selected> -- Select an Employee -- </option>');
           $.each(data, function (index, department) {
               $(createEmpDropdown(department)).appendTo($('#listAllEmps select'));
           });
       });
}

function createEmpDropdown(employee) {
    return '<option value="' + employee.EmpID + '">' + employee.FirstName + ' ' + employee.LastName + '</option>';
}

function showEmpSuccessMessage(empName, action) {
    var msg = "<p>" + empName + " has been successfully " + action + "!</p>";
    return msg;
}