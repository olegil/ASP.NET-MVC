function saveTags() {
    addTagsToTagNamesTextBox();
    submitTags();
    closeForm('#workForm', 'changeTag-form');
};

$(function () {
    $('#searchTags').on('mousedown', 'a', function (e) {
        if (e.button == 0) {
            var selectedItem = $(this)[0];
            postSelectedAddTag(selectedItem.innerText);
            clearAddTagTextBox();
        }
    });

    $('#addTagTextBox').on('keyup', function (e) {
        if (e.keyCode === 13) {
            var text = document.getElementById('addTagTextBox').value;
            enterAddTagButtonPressed(text);
            clearAddTagTextBox();
            return;
        }
        if (e.keyCode === 38) {
            buttonUpPressed('addTagTextBox');
            return;
        }
        if (e.keyCode === 40) {
            buttonDownPressed('addTagTextBox');
            return;
        }
        getAddTagSearchResults();
    });
});

function getAddTagSearchResults() {
    $.ajax({
        url: "/Home/FindTags",
        type: "POST",
        dataType: "json",
        data: { SearchText: document.getElementById('addTagTextBox').value },
        success: function (data) {
            clearAddTagTextBox();
            ShowSearchList(data, '#searchTags', 'black');
        }
    });
}

function clearAddTagTextBox() {
    $('#searchTags').empty();
}

function enterAddTagButtonPressed(text) {
    var items = $("#searchTags a:contains(" + text + ")");
    if (items.length == 1) {
        postSelectedAddTag(items[0].innerText);
    }
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
        url: "/ContentWork/ChangeTags",
        type: "POST",
        dataType: "json",
        data: { TagNames: document.getElementById('addTagTagNamesTextBox').value, ImageId: document.getElementById('ImageId').value }
    });
}