function showTagSearchResults(count, id) {    
    clearElementsData();
    getPageButtonsByCount(count);
    getTagImageReview(0, 8, id);
}

function showCommentSearchResults(count, id) {
    clearElementsData();
    getPageButtonsByCount(count);
    getCommentImageReview(0, 8, id);
}

function showItemSearchResults(count, name) {
    clearElementsData();
    getPageButtonsByCount(count);
    getItemImageReview(0, 8, name);
}

function clearElementsData() {
    closeForm('#workForm', 'search-form');
    document.getElementById('PageIndex').value = 0;
    document.getElementById('LastPageIndex').value = 0;
    document.getElementById('ImageIndex').value = 0;
    document.getElementById('ImageCount').value = 0;
    document.getElementById('IntervalId').value = 0;
    $('#ImagePanel').empty();
    $('#PageButtonsPanel').empty();
    $('#ImageComments').empty();
}