$(function () {   
    let clientSearchButton = $("#client_searchb");
    let clientSerachBox = $("#client_search_info");
    let clientSearchRes = $("#client_search_res");

    clientSearchButton.click(() => {
        let info = clientSerachBox.val();
        console.log(allClients);
        clientSearchRes.html("");
        allClients.forEach((client) => {
            let addInfo = () => {
                clientSearchRes.append("<div class='row alert alert-warning mt-1 mb-1'>"
                    + "<p class='row'>Название организации: " + client.organisationName + "</p>"
                    + "<p class='row'>Номер контракта: " + client.contractId + "</p>"
                    + "<p class='row'>Имя: " + client.firstName + "</p>"
                    + "<p class='row'>Фамилия: " + client.secondName + "</p>"
                    + "<p class='row'>Почта: " + client.email + "</p>"
                    + "<p class='row'>Телефон: " + client.phone + "</p>"
                    + "<p class='row'>Адрес: " + client.address + "</p>" + "</div>")
            };
            if (!info) {
                info = null;
            }

            if (client.clientId == info) {
                addInfo();
            }
            else if (client.organisationName.includes(info)) {
                addInfo();
            }
        })
    });
});