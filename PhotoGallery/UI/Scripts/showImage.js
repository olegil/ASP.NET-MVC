function ChangeImageIndex(Direction) {
    var ImageCount = document.getElementById('ImageCount').value;    
    var ImageIndex = 0;
    if (Direction == true) {
        if (ImageCount == document.getElementById('ImageIndex').value) {
            document.getElementById('ImageIndex').value = 0;
            GetImageId(0);
            return;
        }
        ImageIndex = ++document.getElementById('ImageIndex').value;
    }
    else {
        if (document.getElementById('ImageIndex').value === '0') {
            document.getElementById('ImageIndex').value = ImageCount;
            GetImageId(ImageCount);
            return;
        }
        ImageIndex = --document.getElementById('ImageIndex').value;
    }
    GetImageId(ImageIndex);
}

function GetImageId(ImageIndex) {
    $.post("/ImageView/GetImageId", { ImageIndex: ImageIndex }, function (data) { ShowImage(data); });
}

function ShowImage(ImageId) {
    $.ajax({
        cache: false,
        type: "GET",
        data: { ImageId: ImageId },
        url: 'ImageView/GetImage',
        dataType: "html",
        complete: function () {
            RemoveComments();
            clearInterval(window.IntevalId);
            GetComments(ImageId);
            window.IntevalId = setInterval(function () {
                GetComments(ImageId);
            }, 10000);
        },
        success: function (data) {            
            $("#ImagePanel").hide().html(data).fadeIn(400);
            ShowCommentArea();
        }
    });
}

function OpenImage(ImageId, ImageIndex) {
    document.getElementById('ImageIndex').value = ImageIndex;
    ShowImage(ImageId);
}

function setImageIndexByImageId(ImageId) {
    $.ajax({
        cache: false,
        type: "POST",
        data: { ImageId: ImageId },
        url: 'ImageView/SetImageIndexByImageId',
        dataType: "JSON",
        success: function (data) {
            document.getElementById('ImageIndex').value = data;
        }
    });
}