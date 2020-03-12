$("#rotate-robot-to-left").click(function () {
    let componentId = "#head-rotation";
    updateComponentText(rotateHeadToLeftUrl, componentId);
});

$("#rotate-robot-to-right").click(function () {
    let componentId = "#head-rotation";
    updateComponentText(rotateHeadToRightUrl, componentId);
});

$("#robot-tilt-up").click(function () {
    let componentId = "#head-inclination";
    updateComponentText(tiltUpHeadUrl, componentId);
});

$("#robot-tilt-down").click(function () {
    let componentId = "#head-inclination";
    updateComponentText(tiltDownHeadUrl, componentId);
});
