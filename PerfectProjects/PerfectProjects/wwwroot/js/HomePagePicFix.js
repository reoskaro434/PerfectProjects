window.onresize = resizeImg;
window.onload = resizeImg;

function resizeImg() {

    var ctr = document.getElementById('counter');
    var counterNumber = Number(ctr.textContent);
    for (var i = 1; i <= counterNumber;i++)
    {
        console.log('output' + i);
        var image = document.getElementById('output' + i);
        if (image) {
            image.width = document.getElementById('textArea').offsetWidth;
        }
    }
}