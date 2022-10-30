jQuery(function($) {
    $('#register').on('submit', function(event) {
        if ( validateForm() ) { // если есть ошибки возвращает true
            event.preventDefault();
        }
    });

    function validateForm() {
        $(".text-error").remove();

        // Проверка телефона
        var reg1     = /^((\+7|7|8)+([0-9]){10})$/;
        var el_p    = $("#Phone");
        var v_phone = !el_p.val();

        if ( v_phone ) {
            alert("Поле 'Телефон' обязательно к заполнению")
        } else if ( !reg1.test( el_p.val() ) ) {
            v_email = true;
            alert("Вы указали неверный телефонный номер")
        }
        $("#Phone").toggleClass('error', v_email );


        // Проверка e-mail
        var reg     = /^\w+([\.-]?\w+)*@(((([a-z0-9]{2,})|([a-z0-9][-][a-z0-9]+))[\.][a-z0-9])|([a-z0-9]+[-]?))+[a-z0-9]+\.([a-z]{2}|(com|net|org|edu|int|mil|gov|arpa|biz|aero|name|coop|info|pro|museum))$/i;
        var el_e    = $("#Email");
        var v_email = !el_e.val();

        if ( v_email ) {
            alert("Поле e-mail обязательно к заполнению")
        } else if ( !reg.test( el_e.val() ) ) {
            v_email = true;
            alert("Вы указали недопустимый e-mail")
        }
        $("#email").toggleClass('error', v_email );

        // Проверка пароля
        var el_p1  = $("#pass");
        var v_pass = !el_p1.val();

        if ( el_p1.val().length < 6 ) {
            alert("Пароль должен быть не менее 6 символов")
        }
        $("#pass1").toggleClass('error', v_pass );
        return (v_email || v_pass);
    }
});