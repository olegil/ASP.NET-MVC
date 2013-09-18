$(function () {
    $('#SearchTags').on('mousedown', 'a', function (e) {
        if (e.button == 0) {
            var selectedItem = $(this)[0];
            postSelectedSearchResult(selectedItem.id, selectedItem.innerText, selectedItem.title);
            ClearSearchResult();
        }
    });

    $('#SearchTextBox').on('keyup', function (e) {
        if (e.keyCode === 13) {
            var text = document.getElementById('SearchTextBox').value;
            enterButtonPressed(text);
            ClearSearchResult();
            return;
        }
        if (e.keyCode === 38) {
            buttonUpPressed('SearchTextBox');
            return;
        }
        if (e.keyCode === 40) {
            buttonDownPressed('SearchTextBox');
            return;
        }
        getSearchResults();
    });
});

function buttonUpPressed(box) {
    if (($('.selected-tag')).length === 0) {
        var tag = $('.search-tag').last().addClass('selected-tag');
        document.getElementById(box).value = tag.text();
    }
    else {
        var selectedTag = $('.selected-tag');
        var tag = ($('.search-tag:contains(' + selectedTag.text() + ')')).prev();
        tag.addClass('selected-tag');
        selectedTag.removeClass('selected-tag');
        if (tag.length === 1) {
            document.getElementById(box).value = tag.text();
        }
    }
}

function buttonDownPressed(box) {
    if (($('.selected-tag')).length === 0) {
        var tag = $('.search-tag').first().addClass('selected-tag');
        document.getElementById(box).value = tag.text();
    }
    else {
        var selectedTag = $('.selected-tag');
        var tag = ($('.search-tag:contains(' + selectedTag.text() + ')')).next();
        tag.addClass('selected-tag');
        selectedTag.removeClass('selected-tag');
        if (tag.length === 1) {
            document.getElementById(box).value = tag.text();
        }
    }
}

function getSearchResults() {
    $.ajax({
        url: "/Home/FindTagsAndComments",
        type: "POST",
        dataType: "json",
        data: { SearchText: document.getElementById('SearchTextBox').value },
        success: function (data) {
            ClearSearchResult();
            ShowSearchList(data, '#SearchTags', 'white');
        }
    });
}

function ShowSearchList(data, box, background) {
    $(box).append('<div style="background: ' + background +'; position: relative;">');
    for (var i = 0; i < data.length; i++) {
        $(box + ' div').append('<p class="search-tag"><a id="' + data[i].Id + '" title="' + data[i].SearchResultType + '">' + data[i].SearchResultName + '</a></p>');
    }
    $(box).append('</div>');
}

function ClearSearchResult() {
    $('#SearchTags').empty();
}

function enterButtonPressed(text) {
    var items = $("#SearchTags a:contains(" + text + ")");
    if (items.length == 1) {
        postSelectedSearchResult(items[0].id, items[0].innerText, items[0].title);
    }
    else {
        postSelectedSearchResult(0, text, "");
    }
}

function postSelectedSearchResult(id, name, type) {    
    $.ajax({
        url: "/Home/ShowSearchResult",
        type: "POST",
        data: { Id: id, Name: name, Type: type },
        dataType: "html",
        success: function (data) {
            if (data != 0) {
                showWorkForm(data, 'search-form');
            }
        }
    });
}