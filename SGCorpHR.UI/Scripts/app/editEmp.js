function editEmp() {
    var uri = 'api/EmployeeManagement/';

   
    var id = $(':selected').val();
    var empName = $(':selected').text();

    function loadSingleEmp(id) {
        $.getJSON(uri + id)
            .success(function (data) {
                $("#updatedFirstName").val(data.FirstName);
                $("#updatedLastName").val(data.LastName);
                $('#updatedLocationID').val(data.LocationID);
                $('#updatedStatus').val(data.Status);
                $('#updatedDepartmentID').val(data.Department.DepartmentID);
            });
    }

    $('#updateEmptModal').modal('show');
    loadSingleEmp(id);

    $('#btnSaveUpdatedEmp').click(function () {
        var employee = {};
        employee.FirstName = $('#updatedFirstName').val();
        employee.LastName = $('#updatedLastName').val();
        employee.LocationID = $('#updatedLocationID').val();
        employee.Status = $('#updatedStatus').val();
        employee.Department.DepartmentID = $('#updatedDepartmentID').val();
        employee.EmpID = id;

        $.ajax({
            url: uri,
            dataType: "json",
            data: employee,
            type: "PUT",
            success: function (data, status, xhr) {
                $('#updateEmptModal').modal('hide');
                $('.actionMsg p').remove();
                loadEmployeeNames();
                $(showSuccessMessage(empName, "updated to " + employee.FirstName + ' ' + employee.LastName)).appendTo($('.actionMsg'));

            },
            error: function (jqXhr, status, err) {
                $('.actionMsg').text("error");
            }
        });
    });
}

