// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showConfirmAcctionEdit(e,id) {
    e.preventDefault();
    //'Sure you want to delete the record?'
    Swal.fire({
        title: 'Sure you want to edit the record?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Yes'
    }).then((resultado) => {
        if (resultado.isConfirmed) {
            window.location.href = `/Products/Edit/${id}`;
        }
    })
}

function showConfirmAcctionDelete(e, id) {
    e.preventDefault();
    //'Sure you want to delete the record?'
    Swal.fire({
        title: 'Sure you want to delete the record?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Yes'
    }).then((resultado) => {
        if (resultado.isConfirmed) {
            window.location.href = `/Products/Delete/${id}`;
        }
    })
}
