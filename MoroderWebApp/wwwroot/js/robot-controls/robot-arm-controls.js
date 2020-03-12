$("#increase-left-elbow").click(function () {
    let componentId = "#left-elbow";
    updateComponentText(stretchLeftElbowUrl, componentId);
});

$("#decrease-left-elbow").click(function () {
    let componentId = "#left-elbow";
    updateComponentText(relaxLeftElbowUrl, componentId);
});

$("#rotate-to-left-left-wrist").click(function () {
    let componentId = "#left-wrist";
    updateComponentText(rotateToLeftLeftWristUrl, componentId);
});

$("#rotate-to-right-left-wrist").click(function () {
    let componentId = "#left-wrist";
    updateComponentText(rotateToRightLeftWristUrl, componentId);
});

$("#increase-right-elbow").click(function () {
    let componentId = "#right-elbow";
    updateComponentText(stretchRightElbowUrl, componentId);
});

$("#decrease-right-elbow").click(function () {
    let componentId = "#right-elbow";
    updateComponentText(relaxRightElbowUrl, componentId);
});

$("#rotate-to-left-right-wrist").click(function () {
    let componentId = "#right-wrist";
    updateComponentText(rotateToLeftRightWristUrl, componentId);
});

$("#rotate-to-right-right-wrist").click(function () {
    let componentId = "#right-wrist";
    updateComponentText(rotateToRightRightWrist, componentId);
});

