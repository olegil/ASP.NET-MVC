function ChangeImagePage(Index) {
    var StartIndex = 0;
    if (Index == 'next') {
        document.getElementById('PageIndex').value++;        
        if (document.getElementById('LastPageIndex').value == document.getElementById('PageIndex').value) {
            document.getElementById('PageIndex').value = 0;
        }
        else {
            StartIndex = document.getElementById('PageIndex').value;
        }
    }
    else {
        if (Index == 'prev') {
            if (document.getElementById('PageIndex').value === '0') {
                document.getElementById('PageIndex').value = document.getElementById('LastPageIndex').value - 1;
                StartIndex = document.getElementById('LastPageIndex').value - 1;
            }
            else {
                StartIndex = --document.getElementById('PageIndex').value;
            }
        }
        else {
            StartIndex = Index;
            document.getElementById('PageIndex').value = Index;
        }
    }
    StartIndex *= document.getElementById('ImagesOnPageCount').value;
    if (document.getElementById('ImagePanelTypeId').value == 0) {        
        GetImageReview(StartIndex);
    }
    else {
        if (document.getElementById('ImagePanelTypeId').value === 1) {
            getTagImageReview(StartIndex);
        }
        else {
            if (document.getElementById('ImagePanelTypeId').value === 2) {
                getCommentImageReview(StartInde);
            }
            else {
                if (document.getElementById('ImagePanelTypeId').value === 3) {
                    getItemImageReview(StartIndex);
                }
            }
        }
    }
}

function GetPageButtons() {
    $.ajax({
        cache: false,
        type: "GET",
        url: 'ImageSearch/GetPageButtons',
        dataType: "html",
        success: function (data) {
            $("#PageButtonsPanel").hide().html(data).fadeIn(400);
        }
    });
}

function getPageButtonsByCount(count) {
    $.ajax({
        cache: false,
        type: "GET",
        data: { Count: count },
        url: 'ImageSearch/GetSearchPageButtons',
        dataType: "html",
        success: function (data) {
            $("#PageButtonsPanel").hide().html(data).fadeIn(400);
        }
    });
}

function GetImageReview(StartIndex) {
    document.getElementById('ImagePanelTypeId').value = 0;
    HideCommentArea();
    $.ajax({
        cache: false,
        type: "GET",
        data: { StartIndex: StartIndex },
        url: 'ImageSearch/GetImageReview',
        dataType: "html",
        success: function (data) {
            $("#ImagePanel").hide().html(data).fadeIn(400);
        }
    });
}

function getTagImageReview(startIndex, tagId) {
    document.getElementById('ImagePanelTypeId').value = 1;
    HideCommentArea();
    $.ajax({
        cache: false,
        type: "GET",
        data: { StartIndex: startIndex, Id: tagId },
        url: 'ImageSearch/GetTagImageReview',
        dataType: "html",
        success: function (data) {
            $("#ImagePanel").hide().html(data).fadeIn(400);
        }
    });
}

function getCommentImageReview(startIndex, tagId) {
    document.getElementById('ImagePanelTypeId').value = 2;
    HideCommentArea();
    $.ajax({
        cache: false,
        type: "GET",
        data: { StartIndex: startIndex, Id: tagId },
        url: 'ImageSearch/GetCommentImageReview',
        dataType: "html",
        success: function (data) {
            $("#ImagePanel").hide().html(data).fadeIn(400);
        }
    });
}

function getItemImageReview(startIndex, name) {
    document.getElementById('ImagePanelTypeId').value = 3;
    HideCommentArea();
    $.ajax({
        cache: false,
        type: "GET",
        data: { StartIndex: startIndex, Id: tagId },
        url: 'ImageSearch/GetItemImageReview',
        dataType: "html",
        success: function (data) {
            $("#ImagePanel").hide().html(data).fadeIn(400);
        }
    });
}

function GetImageTable(StartIndex) {
    HideCommentArea();
    $.ajax({
        cache: false,
        type: "GET",
        data: { StartIndex: StartIndex },
        url: 'ImageSearch/GetImageTable',
        dataType: "html",
        success: function (data) {
            $("#ImagePanel").hide().html(data).fadeIn(400);
        }
    });
}