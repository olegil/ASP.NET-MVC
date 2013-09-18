$(function () {
    $.fn.centeredForm = function () {
        this.css('position', 'absolute');
        this.css('top', ($(window).height() - this.height()) / 2 + $(window).scrollTop() + 'px');
        this.css('left', ($(window).width() - this.width()) / 2 + $(window).scrollLeft() + 'px');
    }
});

function showWorkForm(data, style) {
    $("#background").show();
    $("#workForm").addClass(style);
    $("#workForm").html(data);
    $("#workForm").centeredForm();
    $("#workForm").delay(100).show(1);
}

function closeForm(box, style) {
    $(box).removeClass(style);
    $(box).hide();
    $("#background").delay(100).hide(1);
}

function closeConfirmForm() {
    $('#confirmForm').hide();
    $("#background").delay(100).hide(1);
}

function showForm(box) {
    $("#background").show();
    $(box).centeredForm();
    $(box).delay(100).show(1);
}

function createAddPhotoForm() {
    $.ajax({
        url: "/ContentWork/ShowAddPhotoForm",
        type: "GET",
        dataType: "html",
        success: function (data) {
            if (data != 0) {
                showWorkForm(data, 'addPhoto-form');
            }
        }
    });
}

function createAddTagForm() {
    $.ajax({
        url: "/ContentWork/ShowAddTagForm",
        type: "GET",
        dataType: "html",
        success: function (data) {
            if (data != 0) {
                showWorkForm(data, 'addTag-form');
            }
        }
    });
}

function createRemovePhotoForm(id) {
    $.ajax({
        url: "/ContentWork/ShowRemovePhotoForm",
        type: "GET",
        data: { ImageId: id },
        dataType: "html",
        success: function (data) {
            if (data != 0) {
                showWorkForm(data, 'confirm-form');
            }
        }
    });
}

function createChangeUserRoleForm(id) {
    $.ajax({
        url: "/Admin/ShowChangeUserRoleForm",
        type: "GET",
        data: { UserId: id },
        dataType: "html",
        success: function (data) {
            if (data != 0) {
                showWorkForm(data, 'changeUserRole-form');
            }
        }
    });
}