function addPhoto() {

    var inputEl = document.getElementById("inputPhoto")
    var files = inputEl.files;
    photoToBase64(files[0]);
}

function photoToBase64(file) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        var addedHTML1 = "<img  onclick='removeNewImg(this)' class='new-photo' src=\""
            + reader.result + "\" />";
        var data = reader.result.replace(/^data:image\/(png|jpeg|jpg);base64,/, "");
        var addedHTML2 = "<input type='radio' name='addedPhoto' class='added-photo' value=" + data + " hidden checked='checked'/>"
        $('#added').append(addedHTML2);
        document.getElementById('photo').innerHTML = addedHTML1;
    };
}

function removeImg(img) {
    var addedHTML = "<input type='radio' name='isDeleted hidden checked='checked'/>";
    img.remove();
    $('#deleted').append(addedHTML);
}

function removeNewImg(img) {
    var radios = document.getElementsByClassName('added-photo');
    radios.item(0).remove();
    img.remove();
    var addedHTML = "<label class='custom-input'>" +
        "<input id='inputPhoto' onchange='addPhoto()' type='image' name='Image' class='form-control-file' />" +
        "<img style='width: 30px;height: 30px;' src='/Content/AddPhoto.png' /></label>";
    document.getElementById('photo').innerHTML = addedHTML;
}