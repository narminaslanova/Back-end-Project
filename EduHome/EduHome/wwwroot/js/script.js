$(document).ready(function () {

    //****************Subscribe starts**************//
    let subInput;
    function Subscribe(Page) {
        $(`#${Page}-subscribe`).click(function () {
            subInput = $(`#${Page}-EMAIL`).val();
            $(`#${Page}-span`).empty();
            $.ajax({
                type: "POST",
                url: `/Account/SendNotification`,
                data: {
                    "Email": subInput,
                },
                success: function (res) {
                    $(`#${Page}-span`).append(res);
                }
            });
        });
    }
    Subscribe("Home")
    Subscribe("About")
    Subscribe("Courses")
    Subscribe("Teacher")
    Subscribe("Event")
    Subscribe("Blog")
    Subscribe("Contact")

    //****************Subscribe ends**************//


    //****************Search starts**************//
    let inputVal;
    let newProducts ;
    let oldProducts;
        function Search(Page) {
           
        $(`#${Page}-search-input`).keyup(function () {
            oldProducts = $(`#Old-${Page}s`);
            newProducts = $(`#New-${Page}s`);
            inputVal = $(this).val().toLowerCase();
            oldProducts.css("display", "none")
            newProducts.empty();
            if ($(this).val().length > 0) {
                $.ajax({
                    type: "POST",
                    url: `/Home/Search`,
                    data: {
                        "name": inputVal,
                        "page": Page,
                    },
                    success: function (res) {
                        oldProducts.css("display", "none")
                        newProducts.append(res)
                    }
                });
            }
            else {
                oldProducts.css("display", "block")
            }

        })
    }
    Search("Course")
    Search("Event")
    Search("Blog")
    Search("Teacher")
    //****************Search ends**************//

    //****************GlobalSearch starts**************//

    let gInput;
   // $('#global-input').val("");
    $('#global-input').keyup(function () {
        gInput = $(this).val().trim();
        $('#globals-list #global-list').remove();
        $('#globals-list').empty();
        if (gInput.length > 0) {
            $.ajax({
                url: `/Home/GlobalSearch/`,
                data: {
                    "search": gInput
                },
                type: "Get",
                success: function (res) {
                    $('#globals-list').append(res);
                }
            });
        }
    })
});
