var BookFinder = (function () {
    $(document).ajaxSend(function (event, request, settings) {
        $('#loading-indicator').show();
    });

    $(document).ajaxComplete(function (event, request, settings) {
        $('#loading-indicator').hide();
    });
    //Public functions
    return {
        baseUrl: "",
        GetBookByIds: function (isbnNumbers) {
            $('#indicator').show();
            $('#loading-indicator').show();
            $.ajax({
                url: BookFinder.baseUrl + "?isbnNumbers=" + isbnNumbers
            }).done(function (data) {
                $('#loading-indicator').hide();
                $("#divResult").show();
                $("#imgBookResult").attr("src", data.imageurl);
                $("#bookLink").attr("href", data.url);
                $("#spanTitle").html(data.title);
                $("#spanAuthor").html(data.label);
            });
        }
    };

    
})();