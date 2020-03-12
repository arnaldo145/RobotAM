$(".btn-delete-robot").click(function () {
    let robotId = $(this).attr('robot-id');

    $("#robot-to-delete-id").text(robotId);
    $("#confirm-delete-robot").attr('robot-id', robotId);

    $('#delete-robot-modal').modal("show");
});

$("#confirm-delete-robot").click(function () {
    let robotId = $(this).attr('robot-id');

    $('#delete-robot-modal').modal("hide");
    $(this).attr('robot-id', '');

    $.ajax({
        url: `${deleteRobotUrl}/${robotId}`,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: robotDeletedActions
    });

    function robotDeletedActions(data) {
        if (data.isRobotDeleted) {
            location.reload();
        }
    }
});

function updateComponentText(url, componentId) {
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: refreshComponent
    });

    function refreshComponent(data) {
        let isValidMovement = data.isValidMovement;

        if (isValidMovement === true) {
            $(componentId).text(data.description);
        } else {
            alert("Movimento inválido!");
        }
    }
}