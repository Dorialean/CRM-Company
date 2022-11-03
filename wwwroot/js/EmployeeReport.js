$(function () {
    let employeeButton = $("#job_report");

    employeeButton.click(function () {
        fetch('https://localhost:7265/api/employees')
            .then(resp => resp.blob())
            .then(blob => {
                const url = window.URL.createObjectURL(blob);
                const a = document.createElement('a');
                a.style.display = 'none';
                a.href = url;
                a.download = 'jobs.json';
                document.body.appendChild(a);
                a.click();
                window.URL.revokeObjectURL(url);
                alert('your file.jobs has downloaded!');
            })
            .catch(() => alert('oh no!'))
    });
});