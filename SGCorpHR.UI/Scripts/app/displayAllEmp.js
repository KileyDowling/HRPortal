var uri = '/api/EmployeeDirectory/';

$(document).ready(function() {
    loadEmployees();
});

function loadEmployees() {
    $.getJSON(uri)
        .done(function(data) {
            $('#employees tbody tr').remove();

            $.each(data, function(index, employee) {
                $(createRow(employee)).appendTo($('#employees tbody'));
            });
        });
}

function createRow(employee) {
    return '<tr data-departmentID=' + employee.Department.DepartmentID+'><td>' + employee.LastName + '</td> <td>' + employee.FirstName + '</td> <td>' + employee.FormattedHireDate + '</td> <td>' + employee.ManagerName + '</td> <td>' + employee.Department.DepartmentName + '</td> <td>' + employee.State + '</td> <td>' + employee.Status + '</td> </tr>';
}

function find() {
    var id = $('#departmentID').val();

    $.getJSON(uri + id)
        .done(function (data) {
            $('#employees tbody tr').remove();

            $.each(data, function (index, employee) {
                $(createRow(employee)).appendTo($('#employees tbody'));
            });
        })

.fail(function (jqXhr, status, err) {
    $('#dptEmp').text('Error: ' + err);
});
}
