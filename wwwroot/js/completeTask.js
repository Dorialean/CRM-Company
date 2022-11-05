$(function () {
    let e;
    document.addEventListener("click", function () {
        if ((arguments[0].target.id) === "completeTask"){
            e = arguments[0];
            $.ajax({
                url: '/api/Jobs/complete',
                data: {id: e.target.accessKey},
                success: function (data) {
                    let jobList = document.getElementById("jobList");
                    let completedJob = document.getElementById("job_"+data[0]);
                    jobList.removeChild(completedJob);

                    let completedList = document.getElementById("completedList");
                    console.log(completedList.innerHTML);
                    completedList.innerHTML = completedList.innerHTML
                        + "<div class='row alert-light rounded-1 mb-1 ms-0'>"
                        + "<p class='row'>"+data[1]+"</p>"
                        + "<p class='row'>Описание задания: "+data[2]+"</p>"
                        + "<p class='row'>Должно быть готово к "+data[3]+"</p>"
                        + "</div>";
                },
            });
        }
    });
});