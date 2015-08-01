function createDpt() {
        $('#createDepartmentModal').modal('show');

        $('#btnSaveDepartment').click(function() {
            var name = $('#name').val();

            $.post(uri, name)
                .success(function() {
                    loadDepartmentNames();
                    $('#createDepartmentModal').modal('hide');
                })
                .fail(function(jqXhr, status, err) {
                    alert(status + ' - ' + err);
                });
        });
    }
