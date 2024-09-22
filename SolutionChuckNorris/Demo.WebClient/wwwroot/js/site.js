// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



var requestOptions = {
    method: 'GET',
    redirect: 'follow'
};

var _images;
fetch("http://localhost:5168/api/Images", requestOptions)
    .then(response => response.json())
    .then(result => displayImages(result))
    .catch(error => console.log('error', error));


function displayImages(images) {
    console.log(images);

    _images = images;
    images.forEach(img => {
        var image = new Image();
        image.src = "data:image/jpg;base64,"+img.img;
        document.body.appendChild(image);
    }
    );
}





