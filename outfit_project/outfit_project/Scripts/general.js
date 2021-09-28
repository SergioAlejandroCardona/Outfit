$(document).ready(function () {

    $('.datepicker').datepicker({
        format: 'dd-mm-yyyy',
        i18n: {
            months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
            monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Set", "Oct", "Nov", "Dic"],
            weekdays: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
            weekdaysShort: ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab"],
            weekdaysAbbrev: ["D", "L", "M", "M", "J", "V", "S"],
            cancel: 'Cancelar',
            clear: 'Limpiar',
            done: 'Aceptar',
            previousMonth: '< Anterior',
            nextMonth: 'Siguiente >',
        },
        showDaysInNextAndPreviousMonths: true,
        yearRange: [1900, 2040],
        changeMonth: true,
        changeYear: true,
    });

    $('.slider').slider();

    $('select').formSelect();

    $("#SearchCita").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#appointmentList tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#SearchCustomer").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#customerList tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#SearchProduct").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#productList tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#SearchReserva").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#reservationList tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#SearchVenta").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#saleList tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#SearchSeller").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#sellerList tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#SearchSupplier").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#supplierList tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

});