// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('span#delete').click(function () {
    let row = $(this).closest('tr');
    let employeeId = $(this).parent().siblings('.id').find('span').text();

    if (confirm("Delete this employee?")) {
        $.post("Employee/Delete", {
            id: employeeId
        }).done(function (result) {
            if (result) {
                row.remove();
            }
        });
    }
});