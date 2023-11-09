

function SiparisGonder() {
    let SiparisData = {
        MenuID : $("input[type='radio']:checked").val(),
        Boyut : $("#boyut option:selected").val()
    }
    $.ajax({
        url: "/User/Siparis/SiparisGonder",
        type: "POST",
        dataType: "html",
        data: SiparisData,
        success: function (response) {
            console.log(response);

            $('#siparisListesi').html(response);
        },
        error: function (data) {
            console.log("nbr")
        }
    })
}
$('#boyut').change(function () {
    $.ajax({
        url: "/User/Siparis/BoyutDegistir",
        data: { Boyut: $("#boyut option:selected").val() },
        dataType: "html",
        type: "post",
        success: function (response) {
            $('#menuler').html(response);
        }

    })
}


