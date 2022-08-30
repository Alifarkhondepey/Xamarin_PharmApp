
function OnlineSearchResult(json) {
    //txtsearch.value = json;
    //$('#txtsearch').val(json);
    ////alert(json)

    var drugs = JSON.parse(json);
    //divdrugslist.innerHTML = drugs.length;
    var html = "";
    for (var i in drugs) {
        html +=
            '<div onclick= "IndexInterFace.ShowDetails(' + drugs[i].Id + ')" class="live-search-list" >' +
            '<div class="decoration"></div>' +
            '<div class="one-half">' +
            '<p>' +
            '<h2>' + drugs[i].EnglishName + '</h2><br>' +
            drugs[i].CommercialNAme +
            '</p>' +
            '</div>' +
            '<div class="two-half last-column">' +
            '<p>' +
            '<h3>' + drugs[i].PersianName + '</h3><br>' +
            '</p>' +
            '</div>' +
            '</div>' +
            '<hr />'
    }
    divdrugslist.innerHTML = html;
    //txtsearch.value = html;
    //list1.innerHTML = html;

    //$(drugs).each(function (idx, drug) {
    //})
}

//$(function  () {
//    $("#btnGet").click(function () {
//            alert("call ajax");
//            $.ajax({
//                type: "POST",
//                url: "/IndexRazorInterFace/SearchByName",
//                data: '{name: "' + $("#Search").val() + '" }',
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function (response) {
//                    alert("Hello: ");
//                },
//                failure: function (response) {
//                    alert(response.responseText);
//                },
//                error: function (response) {
//                    alert(response.responseText);
//                }
//            });
//        });
//    });
