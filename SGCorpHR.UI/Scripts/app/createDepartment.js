function createDpt() {
        $('#createDepartmentModal').modal('show');

        $('#btnSaveDepartment').click(function() {
            var name = $('#name').val();
            var department = {};
            department.DepartmentName = name;


            $.post(uri, department)
                .success(function() {
                    loadDepartmentNames();
                    $('#createDepartmentModal').modal('hide');
                    $(showSuccessMessage(name, "created")).appendTo($('.actionMsg'));

                })
                .fail(function(jqXhr, status, err) {
                    alert(status + ' - ' + err);
                });
        });
    }
