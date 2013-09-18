function savePhoto() {
    $('#ImgForm').get(0).setAttribute('action', 'ContentWork/SaveImage');
    addTagIdToTagNamesTextBox();
    $('#ImgForm').submit();
    $('#ImgForm').get(0).setAttribute('action', 'ContentWork/UploadImage');
    closeForm('#workForm', 'addPhoto-form');
    document.getElementById('ImageCount').value++;
};

$(function () {
    $('#addPhotoTags').on('mousedown', 'a', function (e) {
        if (e.button == 0) {
            var selectedItem = $(this)[0];
            postSelectedAddPhotoTagSearchResult(selectedItem.id, selectedItem.innerText);
            ClearAddPhotoTagSearchResult();
        }
    });

    $('#addPhotoTagTextBox').on('keyup', function (e) {        
        if (e.keyCode === 13) {
            var text = document.getElementById('addPhotoTagTextBox').value;
            enterAddPhotoTagButtonPressed(text);
            ClearAddPhotoTagSearchResult();
            return;
        }
        if (e.keyCode === 38) {
            buttonUpPressed('addPhotoTagTextBox');
            return;
        }
        if (e.keyCode === 40) {
            buttonDownPressed('addPhotoTagTextBox');
            return;
        }
        getAddPhotoTagSearchResults();
    });
});

function enterAddPhotoTagButtonPressed(text) {
    var items = $("#addPhotoTags a:contains(" + text + ")");
    if (items.length == 1) {
        postSelectedAddPhotoTagSearchResult(items[0].id, items[0].innerText);
    }
}

function ClearAddPhotoTagSearchResult() {
    $('#addPhotoTags').empty();
}

function getAddPhotoTagSearchResults() {
    $.ajax({
        url: "/Home/FindTags",
        type: "POST",
        dataType: "json",
        data: { SearchText: document.getElementById('addPhotoTagTextBox').value },
        success: function (data) {
            ClearAddPhotoTagSearchResult();
            ShowSearchList(data, '#addPhotoTags', 'black');
        }
    });
}

function postSelectedAddPhotoTagSearchResult(id, name) {
    id = -id;
    if (checkSelectedAddPhotoTag(id, name) == true) {
        $('#addPhotoSelectedTags').append('<li><a class="add-photo-tag" id="' + id + '" onclick="removeSelectedAddPhotoTag(' + id + ');">' + name + '</a></li>');
    }
}

function removeSelectedAddPhotoTag(id) {
    var tag = document.getElementById(id);
    tag.remove();
}

function checkSelectedAddPhotoTag(id, name) {
    var tag = document.getElementById(id);
    if (tag != null) {
        if (tag.text == name) {
            return false;
        }
    }
    return true;
}

function addTagIdToTagNamesTextBox() {
    var tags = $('.add-photo-tag');
    if (tags.length != 0) {
        var id = -tags[0].id;
        var result = id + '_' + tags[0].text;;
        for (var i = 1; i < tags.length; i++) {        
            result += '_';
            id = -tags[i].id;
            result += id + '_' + tags[i].text;
        }
        document.getElementById('tagNamesTextBox').value = result;
    }
}