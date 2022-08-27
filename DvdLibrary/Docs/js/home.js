$(document).ready(function () {
    loadDvds();
    searchDvds();
});

function clearDvdTable() {
    $('#dvdRows').empty();
}

function clearDvdBody() {
    $('#dvdBody').empty();
}

function loadDvds() {
    clearDvdTable();
    $('#errorMessages').empty();
    var dvdRows = $('#dvdRows');

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44345/dvds',
        success: function (dvdArray) {
            $.each(dvdArray, function (index, dvd) {
                var title = dvd.Title;
                var releaseYear = dvd.ReleaseYear;
                var director = dvd.Director;
                var rating = dvd.Rating;
                var id = dvd.DvdId;

                var row = '<tr>';
                row += '<td><button type="button" class="btn btn-link" onclick="showDvdDetails(' + id + ')">' + title + '</button>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + id + ')">Edit</button> | <button type="button" class="btn btn-link" onclick="showDeleteForm(' + id + ')">Delete</button></td>';
                row += '</tr>';

                dvdRows.append(row);
            })

        },
        error: function () {
            $('#searchErrorMessage')
                .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling web service. Please try again later.')
                );
        }
    });
}

function searchDvds() {
    $('#searchButton').click(function (event) {
        $('#errorMessages').empty();

        var haveValidationErrors = checkAndDisplayValidationErrors($('#toolbarDiv').find('input'));

        if (haveValidationErrors) {
            return false;
        }

        clearDvdTable();
        var category = $('select[name=searchMenu] option').filter(':selected').val();
        var term = $('#searchBar').val();
        var dvdRows = $('#dvdRows');

        if (category == 'searchCategory') {
            loadDvds();
        }

        if (category == 'title') {
            $.ajax({
                type: 'GET',
                url: 'https://localhost:44345/dvds/title/' + term,
                success: function (dvdArray) {
                    $.each(dvdArray, function (index, dvd) {
                        var title = dvd.Title;
                        var releaseYear = dvd.ReleaseYear;
                        var director = dvd.Director;
                        var rating = dvd.Rating;
                        var id = dvd.DvdId;

                        var row = '<tr>';
                        row += '<td><button type="button" class="btn btn-link" onclick="showDvdDetails(' + id + ')">' + title + '</button>';
                        row += '<td>' + releaseYear + '</td>';
                        row += '<td>' + director + '</td>';
                        row += '<td>' + rating + '</td>';
                        row += '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + id + ')">Edit</button> | <button type="button" class="btn btn-link" onclick="showDeleteForm(' + id + ')">Delete</button></td>';
                        row += '</tr>';

                        dvdRows.append(row);
                    })
                },
                error: function () {
                    $('#errorMessages')
                        .append($('<li>')
                            .attr({ class: 'list-group-item list-group-item-danger' })
                            .text('Error calling web service. Please try again later.'));
                }
            });
        }

        if (category == 'releaseYear') {
            $.ajax({
                type: 'GET',
                url: 'https://localhost:44345/dvds/year/' + term,
                success: function (dvdArray) {
                    $.each(dvdArray, function (index, dvd) {
                        var title = dvd.Title;
                        var releaseYear = dvd.ReleaseYear;
                        var director = dvd.Director;
                        var rating = dvd.Rating;
                        var id = dvd.DvdId;

                        var row = '<tr>';
                        row += '<td><button type="button" class="btn btn-link" onclick="showDvdDetails(' + id + ')">' + title + '</button>';
                        row += '<td>' + releaseYear + '</td>';
                        row += '<td>' + director + '</td>';
                        row += '<td>' + rating + '</td>';
                        row += '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + id + ')">Edit</button> | <button type="button" class="btn btn-link" onclick="showDeleteForm(' + id + ')">Delete</button></td>';
                        row += '</tr>';

                        dvdRows.append(row);
                    })
                },
                error: function () {
                    $('#errorMessages')
                        .append($('<li>')
                            .attr({ class: 'list-group-item list-group-item-danger' })
                            .text('Error calling web service. Please try again later.'));
                }
            });
        }

        if (category == 'director') {
            $.ajax({
                type: 'GET',
                url: 'https://localhost:44345/dvds/director/' + term,
                success: function (dvdArray) {
                    $.each(dvdArray, function (index, dvd) {
                        var title = dvd.Title;
                        var releaseYear = dvd.ReleaseYear;
                        var director = dvd.Director;
                        var rating = dvd.Rating;
                        var id = dvd.DvdId;

                        var row = '<tr>';
                        row += '<td><button type="button" class="btn btn-link" onclick="showDvdDetails(' + id + ')">' + title + '</button>';
                        row += '<td>' + releaseYear + '</td>';
                        row += '<td>' + director + '</td>';
                        row += '<td>' + rating + '</td>';
                        row += '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + id + ')">Edit</button> | <button type="button" class="btn btn-link" onclick="showDeleteForm(' + id + ')">Delete</button></td>';
                        row += '</tr>';

                        dvdRows.append(row);
                    })
                },
                error: function () {
                    $('#errorMessages')
                        .append($('<li>')
                            .attr({ class: 'list-group-item list-group-item-danger' })
                            .text('Error calling web service. Please try again later.'));
                }
            });
        }

        if (category == 'rating') {
            $.ajax({
                type: 'GET',
                url: 'https://localhost:44345/dvds/rating/' + term,
                success: function (dvdArray) {
                    $.each(dvdArray, function (index, dvd) {
                        var title = dvd.Title;
                        var releaseYear = dvd.ReleaseYear;
                        var director = dvd.Director;
                        var rating = dvd.Rating;
                        var id = dvd.DvdId;

                        var row = '<tr>';
                        row += '<td><button type="button" class="btn btn-link" onclick="showDvdDetails(' + id + ')">' + title + '</button>';
                        row += '<td>' + releaseYear + '</td>';
                        row += '<td>' + director + '</td>';
                        row += '<td>' + rating + '</td>';
                        row += '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + id + ')">Edit</button> | <button type="button" class="btn btn-link" onclick="showDeleteForm(' + id + ')">Delete</button></td>';
                        row += '</tr>';

                        dvdRows.append(row);
                    })
                },
                error: function () {
                    $('#errorMessages')
                        .append($('<li>')
                            .attr({ class: 'list-group-item list-group-item-danger' })
                            .text('Error calling web service. Please try again later.'));
                }
            });
        }
    })

    $('#errorMessages').empty();
}

function showEditForm(id) {
    $('#errorMessages').empty();

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44345/dvd/' + id,
        success: function (data, status) {
            $('#editDvdTitle').val(data.Title);
            $('#editReleaseYear').val(data.ReleaseYear);
            $('#editDirector').val(data.Director);
            $('#editRating').val(data.Rating); 
            $('#editNotes').val(data.Notes);
            $('#dvdId').val(id)
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling web service. Please try again later.'));
        }
    })

    $('#toolbarDiv').hide();
    $('#dvdTableDiv').hide();
    $('#editDvdDiv').show();
}

function hideEditForm() {
    $('#errorMessages').empty();

    $('#toolbarDiv').show();
    $('#dvdTableDiv').show();
    $('#editDvdDiv').hide();
}

function editDVD() {
    var haveValidationErrors = checkAndDisplayValidationErrors($('#editDvdDiv').find('input'));

    if (haveValidationErrors) {
        return false;
    }

    var id = $('#dvdId').val()

    $.ajax({
        type: 'PUT',
        url: 'https://localhost:44345/dvd/' + id,
        data: JSON.stringify({
            DvdId: id,
            Title: $('#editDvdTitle').val(),
            ReleaseYear: $('#editReleaseYear').val(),
            Director: $('#editDirector').val(),
            Rating: $('#editRating').val(), 
            Notes: $('#editNotes').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function () {
            $('#errorMessages').empty();
            hideEditForm();
            loadDvds();
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling web service. Please try again later.'));
        }
    })
}

function showDvdDetails(id) {
    clearDvdBody();
    var dvdBody = $('#dvdBody');

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44345/dvd/' + id,
        success: function (dvd) {
            var title = dvd.Title;
            var releaseYear = dvd.ReleaseYear;
            var director = dvd.Director;
            var rating = dvd.Rating;
            var notes = dvd.Notes;

            var row = '<h2>' + title + '</h2><br>';
            row += '<hr />';
            row += '<div class="form-group row">';
            row += '<h4 class="col-md-1">Release Year: </h4><h4 class="col-md-4">' + releaseYear + '</h4><br>';
            row += '</div>';
            row += '<div class="form-group row">';
            row += '<h4 class="col-md-1">Director: </h4><h4 class="col-md-4">' + director + '</h4><br>';
            row += '</div>';
            row += '<div class="form-group row">';
            row += '<h4 class="col-md-1">Rating: </h4><h4 class="col-md-4">' + rating + '</h4><br>';
            row += '</div>';
            row += '<div class="form-group row">';
            row += '<h4 class="col-md-1">Notes: </h4><h4 class="col-md-4">' + notes + '</h4><br>';
            row += '</div>';
            row += '<br>';

            dvdBody.append(row);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    })

    $('#toolbarDiv').hide();
    $('#dvdTableDiv').hide();
    $('#dvdDetailsForm').show();
}

function hideDvdDetails() {
    $('#toolbarDiv').show();
    $('#dvdTableDiv').show();
    $('#dvdDetailsForm').hide();
}

function createDVD() {
    var haveValidationErrors = checkAndDisplayValidationErrors($('#createDvdDiv').find('input'));

    if (haveValidationErrors) {
        return false;
    }

    $.ajax({
        type: 'POST',
        url: 'https://localhost:44345/dvd',
        data: JSON.stringify({
            title: $('#createDvdTitle').val(),
            releaseYear: $('#createReleaseYear').val(),
            director: $('#createDirector').val(),
            rating: $('#createRating').val(),
            notes: $('#createNotes').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'success': function () {
            $('#errorMessages').empty();
            hideCreateForm();
            loadDvds();
        },
        'error': function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    })

    hideCreateForm();
}

function showCreateForm() {
    $('#errorMessages').empty();

    $('#toolbarDiv').hide();
    $('#dvdTableDiv').hide();
    $('#createDvdDiv').show();
}

function hideCreateForm() {
    $('#errorMessages').empty();

    $('#toolbarDiv').show();
    $('#dvdTableDiv').show();
    $('#createDvdDiv').hide();
}

function showDeleteForm(id) {
    if (confirm('Are you sure you want to this DVD from your collection?') == true) {
        deleteDVD(id);
    }
}

function deleteDVD(id) {
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44345/dvd/' + id,
        success: function () {
            loadDvds();
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    });
}

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });

        return true;
    } else {
        return false;
    }
}