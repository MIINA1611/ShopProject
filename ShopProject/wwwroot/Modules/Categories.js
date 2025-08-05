function Delete(id) {
    Swal.fire({
        title: "Are You Sure",
        text: "You can't undo this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/Admin/Category/Delete?id=${id}`,
                type: 'POST',
                success: function (response) {
                    Swal.fire(
                        'Deleted!',
                        'Your category has been deleted.',
                        'success'
                    ).then(() => {
                        location.reload(); // Reload table after delete
                    });
                },
                error: function () {
                    Swal.fire(
                        'Error!',
                        'There was a problem deleting the category.',
                        'error'
                    );
                }
            });
        }
    });
}


function DeleteLog(id) {
    Swal.fire({
        title: "هل أنت متأكد؟",
        text: "لن تتمكن من التراجع عن هذا!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Admin/Categories/DeleteLog?id=${id}`;
            Swal.fire({
                title: "تم الحذف!",
                text: "لقد تم حذف ملفك.",
                icon: "success"
            });
        }
    });
}



function openCity(evt, cityName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}
document.getElementById("defaultOpen").click();
