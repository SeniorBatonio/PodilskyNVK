$('#inputPhotos').on('change', function () {

    var inputEl = document.getElementById("inputPhotos")
    var files = inputEl.files;
    for (var i = 0; i < files.length; i++) {
        photoToBase64(files[i]);
    };
});

$('#photos').bind("DOMSubtreeModified", function () {
    namePhotos();
})

function photoToBase64(file) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        var addedHTML1 = "<img  onclick='removeNewImg(this)' class='new-photo' src=\""
            + reader.result + "\" />";
        var data = reader.result.replace(/^data:image\/(png|jpeg|jpg);base64,/, "");
        var addedHTML2 = "<input type='radio' class='added-photos' value=" + data + " hidden checked='checked'/>"
        $('#added').append(addedHTML2);
        $('#photos').append(addedHTML1);
        j++;
    };
}

function namePhotos() {
    var photos = document.getElementsByClassName('new-photo');
    for (var i = 0; i < photos.length; ++i) {
        photos.item(i).setAttribute("name", "addedImages[" + i + "]")
    }
    var radios = document.getElementsByClassName('added-photos');
    for (var i = 0; i < radios.length; ++i) {
        radios.item(i).setAttribute("name", "addedImages[" + i + "]")
    }
}

var k = 0;
var j = 0;

function removeImg(img) {
    var addedHTML = "<input type='radio' name='deletedPhotos[" + k + "]' value=" + img.getAttribute('id') + " hidden checked='checked'/>";
    k++;
    img.remove();
    $('#deleted').append(addedHTML);
}

function removeNewImg(img) {
    var radios = document.getElementsByClassName('added-photos');
    for (var i = 0; i < radios.length; ++i) {
        if (radios.item(i).getAttribute('name') == img.getAttribute('name')) {
            radios.item(i).remove();
        }
    }
    img.remove();
}