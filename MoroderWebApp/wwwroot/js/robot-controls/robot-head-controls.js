$("#rotate-robot-to-left").click(function () {
    rotateRobotHead(rotateHeadToLeftUrl);
});

$("#rotate-robot-to-right").click(function () {
    rotateRobotHead(rotateHeadToRightUrl);
});

function rotateRobotHead(url) {
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: refreshRotation
    });

    function refreshRotation(data) {
        let isValidMovement = data.isValidMovement;

        if (isValidMovement === true) {
            $("#head-rotation").text(data.description);
        } else {
            alert("Movimento inválido!");
        }
    }
}

$("#robot-tilt-up").click(function () {
    changeInclinationRobotHead(tiltUpHeadUrl);
});

$("#robot-tilt-down").click(function () {
    changeInclinationRobotHead(tiltDownHeadUrl);
});

function changeInclinationRobotHead(url) {
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: refreshInclination
    });

    function refreshInclination(data) {
        let isValidMovement = data.isValidMovement;

        if (isValidMovement === true) {
            $("#head-inclination").text(data.description);
        } else {
            alert("Movimento inválido!");
        }
    }
}