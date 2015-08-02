function deleteEmp() {
    var id = $(':selected').val();
    var empName = $(':selected').text();
    


    $.ajax({
        url: uri + id,
        dataType: "json",
        type: "DELETE",
        data: JSON.stringify({ id: 20 }),
        async: true,
        processData: false,
        cache: false,
        success: function (data, status, xhr) {
            $('.actionMsg p').remove();
            loadEmployeeNames();
            $(showEmpSuccessMessage(empName, "deleted")).appendTo($('.actionMsg'));

        },
        error: function (xhr) {
            $('.actionMsg').text("error");
        }
    });
}