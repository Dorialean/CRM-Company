$(function () {
    let loginTextBox = $("#login");
    let passwordBox = $("#pass");


    $("#auth").hover(() =>  {
        if (!(loginTextBox.val() && passwordBox.val())) {
            if (!loginTextBox.val()) {
                loginTextBox.addClass("border-2 border-danger");
            }
            if (!passwordBox.val()) {
                passwordBox.addClass("border-2 border-danger");
            }
        }
    }, function () {
        if (loginTextBox.val()) {
            loginTextBox.removeClass("border-2 border-danger");
        }
        if (passwordBox.val()) {
            passwordBox.removeClass("border-2 border-danger");
        }
    });
    console.log($("#reg"));
});