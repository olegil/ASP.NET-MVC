function createLogOnForm() {
    $.ajax({
        url: "/Account/LogOn",
        type: "GET",
        dataType: "html",
        success: function (data) {
            if (data != 0) {
                showWorkForm(data, 'logOn-form');
            }
        }
    });
}

function createRegisterForm() {
    $.ajax({
        url: "/Account/Register",
        type: "GET",
        dataType: "html",
        success: function (data) {
            if (data != 0) {
                showWorkForm(data, 'register-form');
            }
        }
    });
}
