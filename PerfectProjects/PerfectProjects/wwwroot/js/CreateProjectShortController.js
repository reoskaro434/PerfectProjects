var loadFile = function (event) {
    var image = document.getElementById('output');
    image.src = URL.createObjectURL(event.target.files[0]);
    image.width = document.getElementById('textArea').offsetWidth;
};

window.onresize = resizeImg;

function resizeImg() {
    var image = document.getElementById('output');
    if (image) {
        image.width = document.getElementById('textArea').offsetWidth;
    }
}