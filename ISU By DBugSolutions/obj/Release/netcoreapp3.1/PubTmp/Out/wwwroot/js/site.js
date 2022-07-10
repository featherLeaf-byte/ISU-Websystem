function hideContent() {

    document.getElementById("#item-1").style.display = "none";
    document.getElementById("#item-2").style.display = "none";
    document.getElementById("#item-3").style.display = "none";
    document.getElementById("#item-4").style.display = "none";
    document.getElementById("#item-5").style.display = "none";
    document.getElementById("#item-6").style.display = "none";
    document.getElementById("#item-7").style.display = "none";
    document.getElementById("#item-8").style.display = "none";
    document.getElementById("#item-9").style.display = "none";
    document.getElementById("#item-10").style.display = "none";
    document.getElementById("#item-11").style.display = "none";

    document.getElementById("#menuIcon").style.display = 'block';
    document.getElementById("#closeIcon").style.display = "none";

}

function displayContent() {

    document.getElementById("#item-1").style.display = "block";
    document.getElementById("#item-2").style.display = "block";
    document.getElementById("#item-3").style.display = "block";
    document.getElementById("#item-4").style.display = "block";
    document.getElementById("#item-5").style.display = "block";
    document.getElementById("#item-6").style.display = "block";
    document.getElementById("#item-7").style.display = "block";
    document.getElementById("#item-8").style.display = "block";
    document.getElementById("#item-9").style.display = "block";
    document.getElementById("#item-10").style.display = "block";
    document.getElementById("#item-11").style.display = "block";


    document.getElementById("#menuIcon").style.display = 'none';
    document.getElementById("#closeIcon").style.display = "block";



}

$(document).ready(function () {
    $('input[type="file"]').change(function (e) {
        var attachment = e.target.files[0].name;
        attachment = jQuery.trim(attachment).substring(0, 20).trim(this) + "...";
        $(".custom-file-label").text(attachment);

    });
});