

function SiparisGonder() {
    let SiparisData = {
        MenuID = $("input[type='radio']:checked").val(),
        Boyut = $("#boyut option:selected").val()
    }
    $.ajax({
        url: "/Siparis/SiparisOlustur",
        type: "POST",
        dataType: "json",
        data: SiparisData,
        success: function (data) {
            console.log(SiparisData)
        }
    })
}

function Deneme() {
    $.ajax({
        url: "/Siparis/deneme",
        type: "GET",
        success: function (response) {
            $(#siparisListesi).html(response);
        }
    })
}
