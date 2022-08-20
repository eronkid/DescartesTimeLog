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

var timeLog = {
    html: function (id, first, middle, last, time, isTimeIn) {
        var htmlStr = "<tr>";        
        htmlStr += "<td class=\"hidden\"><span class=\"id\">" + id + "</span></td>";
        htmlStr += "<td><span class=\"firstName\">" + first + "</span></td>";
        htmlStr += "<td><span class=\"middleName\">" + middle + "</span></td>";
        htmlStr += "<td><span class=\"lastName\">" + last + "</span></td>";
        htmlStr += "<td><span class=\"time\">" + time + "</span></td>";
        if (isTimeIn) {
            htmlStr += "<td><button id=\"time-out-btn\" class=\"btn btn-warning\">Time out</button></td>";
        } else {
            htmlStr += "<td><button id=\"time-in-btn\" class=\"btn btn-success\">Time in</button></td>";
        }
        
        htmlStr += "</tr>";
        return htmlStr;
    }
}

$(document).on('click', 'button#time-in-btn', function (e) {
    let tr = $(this).closest('tr');
    let id = tr.find('.id').text();
    let firstName = tr.find('.firstName').text();
    let middleName = tr.find('.middleName').text();
    let lastName = tr.find('.lastName').text();
    
    $.post("TimeLog/Edit", {
        EmployeeId: id,
        IsTimeIn: true
    }).done(function (result) {
        if (result.success) {
            $('#active-employees tbody').append(timeLog.html(id, firstName, middleName, lastName, result.dateTime, true));
            tr.remove();
        }
    });
});

$(document).on('click', 'button#time-out-btn', function (e) {
    let tr = $(this).closest('tr');
    let id = tr.find('.id').text();
    let firstName = tr.find('.firstName').text();
    let middleName = tr.find('.middleName').text();
    let lastName = tr.find('.lastName').text();

    $.post("TimeLog/Edit", {
        EmployeeId: id,
        IsTimeIn: false
    }).done(function (result) {
        if (result.success) {
            $('#absent-employees tbody').append(timeLog.html(id, firstName, middleName, lastName, result.dateTime, false));
            tr.remove();
        }
    });
});