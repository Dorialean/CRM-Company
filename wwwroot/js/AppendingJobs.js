$(function () {
    let appendButtons = $("button[id^='append_job_']");
    //Почему-то redirect не видит
    appendButtons.each(() => {
        $(this).click(() => {
            redirect($(this).attr('id').slice($(this).attr('id').lastIndexOf("_")));
        })
    });
});