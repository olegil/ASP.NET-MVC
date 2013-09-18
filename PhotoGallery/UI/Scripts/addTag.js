function saveTags() {
    addTagsToTagNamesTextBox();
    submitTags();
    closeForm('#workForm', 'addTag-form');
};

$(function () {
    $('#addTagTextBox').on('keyup', function (e) {
        if (e.keyCode === 13) {
            var text = document.getElementById('addTagTextBox').value;
            postSelectedAddTag(text);
            clearAddTagTextBox();
            return;
        }
    });
});

function clearAddTagTextBox() {
    $('#addTagTextBox').empty();
}

function postSelectedAddTag(name) {
    if (checkSelectedAddTag(name) == true) {
        $('#addEnteredTag').append('<li><a class="add-tag" onclick="removeSelectedAddTag(\'' + name + '\');">' + name + '</a></li>');
    }
}

function removeSelectedAddTag(text) {
    var tags = $('.add-tag');
    for (var i = 0; i < tags.length; i++) {
        if (tags[i].text == text) {
            tags[i].remove();
            return;
        }
    }
}

function checkSelectedAddTag(text) {
    var tags = $('.add-tag');
    for (var i = 0; i < tags.length; i++) {
        if (tags[i].text == text) {
            return false;
        }
    }
    return true;
}

function addTagsToTagNamesTextBox() {
    var tags = $('.add-tag');
    if (tags.length != 0) {
        var result = tags[0].text;;
        for (var i = 1; i < tags.length; i++) {
            result += '_' + tags[i].text;
        }
        document.getElementById('addTagTagNamesTextBox').value = result;
    }
}

function submitTags() {
    $.ajax({
        url: "/ContentWork/SaveTags",
        type: "POST",
        dataType: "json",
        data: { TagNames: document.getElementById('addTagTagNamesTextBox').value }
    });
}