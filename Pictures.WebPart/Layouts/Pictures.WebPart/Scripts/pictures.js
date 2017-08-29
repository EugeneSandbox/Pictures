
$(document).ready(function() {
    $("img.image-source").each(function () {
        var id = $(this).get(0).id;
        //var url = serviceUrl + "/" + id.split("-")[1];
        var url = $(this).data("imagesource");

        $.ajax({
            type: "GET",
            url: url,
            async: false,
            success: function(data) {
                $("#" + id + ".image-source").attr("src", "data:image/jpg;base64," + unzip(data.Image));
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(XMLHttpRequest);
            }
        });
    });
});

function unzip(base64String) {
    var stringData = atob(base64String);
    var charData = stringData.split("").map(function (e) { return e.charCodeAt(0); });
    var binArray = new Uint8Array(charData);
    var data = pako.inflate(binArray);

    var strings = [], chunksize = 0xffff;
    var uintArray = new Uint16Array(data);
    var len = uintArray.length;
    for (var i = 0; i * chunksize < len; i++)
        strings.push(String.fromCharCode.apply(null, uintArray.subarray(i * chunksize, (i + 1) * chunksize)));
    
    return btoa(strings.join(""));
}