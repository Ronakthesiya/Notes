$(function () {
    $("#buttonContainer").dxButton({
        text: "Click me!",
        onClick: function () {
            alert("Hello world!");
            console.log($("#buttonContainer").dxButton("instance").option());
            $("#buttonContainer").dxButton("option","text","clicked");
        }
    });
});



