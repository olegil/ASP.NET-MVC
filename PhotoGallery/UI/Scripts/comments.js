$(function () {
    $('#ImageComments').on('mousedown', '.comment-link', function (e) {
        if (e.button == 0) {
            var Id = $(this).attr("title");
            var AppendBlock = $(Id).clone();
            if ($(this).next().text() != AppendBlock.text()) {
                $(this).parent().append(AppendBlock);
            }
            else {
                var DeleteBlock = $(this).next();
                DeleteBlock.remove();
            }
        }
    });
});

function GetComments(ImageId) {
    var CommentNumber = $('strong').last().text();
    $.ajax({
        cache: false,
        type: "GET",
        data: { ImageId: ImageId, CommentNumber: CommentNumber },
        url: 'ImageView/GetComments',
        dataType: "html",
        success: function (data) {
            if (data != 0) {
                ShowLoadingElement();
                $("#ImageComments").append(data);
            }
        }
    });
}

function PostComment() {
    var CommentText = document.getElementById('CommentText').value;
    var ImageIndex = document.getElementById('ImageIndex').value;
    $.ajax({
        cache: false,
        type: "POST",
        data: { ImageIndex: ImageIndex, CommentText: CommentText },
        url: 'ImageView/PostComment',
        dataType: "html",
        complete: function () {
            $('#CommentText').val('');
            GetComments(GetImageId(document.getElementById('ImageIndex').value));
        }
    });
}

function ShowLoadingElement() {
    $('#LoadingElement').css('display', 'block');
    setTimeout(function () {
        $('#LoadingElement').css('display', 'none').delay('2000');
    }, '2000');
}

function AddParent(ParentNumber) {
    $('#CommentText').val($('#CommentText').val() + '>>' + ParentNumber + '\n');
}

function RemoveComments() {
    $('#ImageComments').empty();
}

function HideCommentArea() {
    clearInterval(window.IntevalId);
    RemoveComments();
    $('#CommentArea').css('display', 'none');
}

function ShowCommentArea() {
    $('#CommentArea').css('display', 'block');
}