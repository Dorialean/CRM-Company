$(function () {

    let organisationNameBox = $("#orgName");
    let endDateBox = $("#endDate");

    $("#orderSub").hover(() => {
        if (!organisationNameBox.val()) {
            organisationNameBox.addClass("border-2 border-danger");
        }
        if (!endDateBox.val()) {
            endDateBox.addClass("border-2 border-danger");
        }
    }, () => {
        if (organisationNameBox.val()) {
            organisationNameBox.removeClass("border-2 border-danger").addClass("border-2 border-success");
            
        }
        if (endDateBox.val()) {
            endDateBox.removeClass("border-2 border-danger").addClass("border-2 border-success");
        }
    });
});