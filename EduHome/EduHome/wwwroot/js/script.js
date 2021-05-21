

$(document).ready(function () {

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




    let inputVal;
    $('#search').keyup(function () {
       // $('#result').html('');
        inputVal = $(this).val().toLowerCase();
        
        $.ajax({
            type: "POST",
            url: "/Courses?Search=" + inputVal,
            
            //data: {
            //    "Search": inputVal

            //},
            data: {},
            success: function (res) {
                console.log(res)
            }
        });

    })

});
