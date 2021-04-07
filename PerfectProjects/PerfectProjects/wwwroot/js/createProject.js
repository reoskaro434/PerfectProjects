
function appendImage() {
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

var loadFile = function loadFile(event) {
    var counter = document.getElementById('picCounter').innerHTML;
    var image = document.getElementById('output' + counter);
    image.src = URL.createObjectURL(event.target.files[0]);
    counter++;
    document.getElementById('picCounter').innerHTML = counter;
    console.log(typeof (counter));

  //  $("#source").trigger('click');
  //  image.width = document.getElementById('description').offsetWidth;
};