let timer;

$("#searchBox").on("keyup", function () {
    clearTimeout(timer);

    timer = setTimeout(function () {
        const title = $("#searchBox").val();

        $.ajax({
            url: "/Task/Search",
            type: "GET",

            data:
            {
                title: title
            },

            success: function (html) {
                $("#taskTableContainer").html(html);
            },

            error: function () {
                alert("Search failed.");
            }
        });

    }, 300);
});