$(function () {
    let appendButtons = $("button[id^='append_job_']");

    appendButtons.each((i, btn) => {
        $(btn).click(() => {
            let appendUrl = 'https://localhost:7265/Work/AppendJob/';
            let id = Number($(btn).attr('id').slice($(btn).attr('id').lastIndexOf("_") + 1));
            window.location.href = appendUrl + "?id=" + id;
        })
    });
});