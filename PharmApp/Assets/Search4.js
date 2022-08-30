
function OnlineSearchResult(json) {
    //txtsearch.value = json;
    //$('#txtsearch').val(json);
    ////alert(json)

    var drugs = JSON.parse(json);
    //divdrugslist.innerHTML = drugs.length;
    var html = "";
    for (var i in drugs) {
        html +=
            '<div class="paddingtop searchpadding" onclick= "AboutUsRazorInterFace.ShowDetails(' + drugs[i].Id + ')" class="live-search-list" >' +
        '<div class="decoration marginsearch"></div>' +
            '<div class="one-half">' +
            '<p>' +
            '<h4 dir="ltr">' + drugs[i].EnglishName + '</h4><br>' +
            drugs[i].CommercialName +
            '</p>' +
            '</div>' +
            '<div class="two-half last-column">' +
            '<p>' +
            '<h5 dir="rtl">' + drugs[i].PersianName + '</h5><br>' +
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
