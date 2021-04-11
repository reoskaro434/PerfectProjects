var loadFile1 = function loadFile1(event) {
    var image1 = document.getElementById('output1');
    image1.src = URL.createObjectURL(event.target.files[0]);
    image1.width = document.getElementById('textArea').offsetWidth;
};
var loadFile2 = function loadFile2(event) {
    var image2 = document.getElementById('output2');
    image2.src = URL.createObjectURL(event.target.files[0]);
    image2.width = document.getElementById('textArea').offsetWidth;
};
var loadFile3 = function loadFile3(event) {
    var image3 = document.getElementById('output3');
    image3.src = URL.createObjectURL(event.target.files[0]);
    image3.width = document.getElementById('textArea').offsetWidth;
};
var loadFile4 = function loadFile4(event) {
    var image4 = document.getElementById('output4');
    image4.src = URL.createObjectURL(event.target.files[0]);
    image4.width = document.getElementById('textArea').offsetWidth;
};
window.onresize = resizeImg;
window.onload = resizeImg;

function resizeImg() {
    var image1 = document.getElementById('output1');
    var image2 = document.getElementById('output2');
    var image3 = document.getElementById('output3');
    var image4 = document.getElementById('output4');

    if (image1) {
        image1.width = document.getElementById('textArea').offsetWidth;
    }
    if (image2) {
        image1.width = document.getElementById('textArea').offsetWidth;
    }
    if (image3) {
        image1.width = document.getElementById('textArea').offsetWidth;
    }
    if (image4) {
        image1.width = document.getElementById('textArea').offsetWidth;
    }
}


/*function appendImage() {
    var counter = document.getElementById('picCounter').innerHTML;
    var anSource = '<p><input hidden id="photo'+ counter + '" type="file" accept="image/jpeg,image/png" name="file" onchange="loadFile(event)" onstyle="display: none;"></p>';
    var anImage = '<p><img id="output'+counter+'" class="flex-fill" /></p>';
    var description = document.getElementById('description');
    description.innerHTML += anSource;
    description.innerHTML += anImage;
    document.getElementById('photo'+counter).click();
}

function appendTextArea() {
    var anTextArea = '<textarea id="textArea" rows="7" class="form-control"></textarea>';
    var description = document.getElementById('description');
    description.innerHTML += anTextArea;
}
*/
/*var loadFile = function loadFile(event) {
    var counter = document.getElementById('picCounter').innerHTML;
    var image = document.getElementById('output' + counter);
    image.src = URL.createObjectURL(event.target.files[0]);
    counter++;
    document.getElementById('picCounter').innerHTML = counter;
    console.log(typeof (counter));
};*/