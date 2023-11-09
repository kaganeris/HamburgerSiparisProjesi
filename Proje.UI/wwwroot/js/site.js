

function SiparisGonder() {
    let SiparisData = {
        MenuID : $("input[type='radio']:checked").val(),
        Boyut: $("#boyut option:selected").val(),
        Adet: $('#adet').val(),
        UserID: $('#userID').val()

    }
    $.ajax({
        url: "/User/Siparis/SiparisGonder",
        type: "POST",
        dataType: "html",
        data: SiparisData,
        success: function (response) {
            console.log(response)
            $('#siparisListesi').html(response);
        },
        error: function (data) {
            console.log("Hata Oluştu")
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
            $('#menuler').html(response)
        }

    });
});
function SepettenSil(siparisID) {
    let sepetData={
        sepetID : siparisID
    }
    $.ajax({
        url: "/User/Siparis/SepettenSil",
        type: "POST",
        dataType: "html",
        data: sepetData,
        success: function (response) {
            console.log(response)
            $('#siparisListesi').html(response);
        },
        error: function (data) {
            console.log("Hata Oluştu")
        }
    })
}


