function saveRoles() {
    addRolesToRoleNamesTextBox();
    submitRoles();
    closeForm('#workForm', 'addRole-form');
    window.location.reload(true);
};

function clearAddRoleTextBox() {
    $('#addRoleTextBox').empty();
}

function addRoleNameToEnteredRoleList() {
    postSelectedAddRole($('#addRoleNameDropdownList').val());
}

function postSelectedAddRole(name) {
    if (checkSelectedAddRole(name) == true) {
        $('#addEnteredRole').append('<li><a class="add-role" onclick="removeSelectedAddRole(\'' + name + '\');">' + name + '</a></li>');
    }
}

function removeSelectedAddRole(text) {
    var roles = $('.add-role');
    for (var i = 0; i < roles.length; i++) {
        if (roles[i].text == text) {
            roles[i].remove();
            return;
        }
    }
}

function checkSelectedAddRole(text) {
    var roles = $('.add-role');
    for (var i = 0; i < roles.length; i++) {
        if (roles[i].text == text) {
            return false;
        }
    }
    return true;
}

function addRolesToRoleNamesTextBox() {
    var roles = $('.add-role');
    if (roles.length != 0) {
        var result = roles[0].text;;
        for (var i = 1; i < roles.length; i++) {
            result += '_' + roles[i].text;
        }
        document.getElementById('addRoleRoleNamesTextBox').value = result;
    }
}

function submitRoles() {
    $.ajax({
        url: "/Admin/SaveRoles",
        type: "POST",
        dataType: "json",
        data: { RoleNames: document.getElementById('addRoleRoleNamesTextBox').value, UserId: document.getElementById('UserId').value }
    });
}