function removePhoto(id) {
    $.ajax({
        url: "/ContentWork/RemoveImage",
        type: "POST",
        data: { Id: id },
        datatype: "JSON",
        success: function () {
            closeForm('#workForm', 'confirm-form');
            ChangeImageIndex(true);
            document.getElementById('ImageCount').value--;
        }
    });
}

function changeUserStatus(userId, element) {
    $.ajax({
        url: "/Admin/ChangeUserStatus",
        type: "POST",
        data: { UserId: userId },
        datatype: "JSON",
        success: function () {
            if (element.innerText == "Active") {
                element.innerText = 'Unactive';
            }
            else {
                if (element.innerText == "Unactive") {
                    element.innerText = 'Active';
                }
                else {
                    if (element.innerText == "Активирован") {
                        element.innerText = "Не активирован";
                    }
                    else {
                        if (element.innerText == "Не активирован") {
                            element.innerText = "Активирован"
                        }
                    }
                }
            }
        }
    });
}