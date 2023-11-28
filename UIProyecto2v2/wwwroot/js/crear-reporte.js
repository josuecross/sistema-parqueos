$(document).ready(function () {
    $("#mes").show();
    const mes = document.getElementsByName("mes")[0]
    const dia = document.getElementsByName("dia")[0]
    const range_dia = document.getElementsByName("range_dia")[0]
    const range_from = document.getElementsByName("range_from")[0]
    const range_to = document.getElementsByName("range_to")[0]
    mes.required = true;

    $('#purpose').on('change', function () {
        if (this.value == '1') {
            $("#mes").show();
            mes.required = true;
        }
        else {
            $("#mes").hide();
            mes.value = "";
            mes.required = false;
        }
        if (this.value == '2') {
            $("#dia").show();
            dia.required = true;
        }
        else {
            $("#dia").hide();
            dia.value = "";
            dia.required = false;
        }
        if (this.value == '3') {
            $("#rango").show();
            range_dia.required = true;
            range_from.required = true;
            range_to.required = true;

        }
        else {
            $("#rango").hide();
            range_dia.value = "";
            range_from.value = "";
            range_to.value = "";
            range_dia.required = false;
            range_from.required = false;
            range_to.required = false;
        }
    });
});