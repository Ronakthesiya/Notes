$("#pan").dxTextBox({
    label: "pan"
})

$("#state").dxTextBox({
    label: "state"
})

$("#gst").dxTextBox({
    label: "gst"
}).dxValidator({
    validationRules: [
        {
            type: "compare",
            comparisonTarget: function () {
                let pan = $("#pan").dxTextBox("instance").option("value");
                let state = $("#state").dxTextBox("instance").option("value");
                let gst = $("#gst").dxTextBox("instance").option("value");

                console.log(gst)

                if (gst.length==15 && gst.startsWith(state + pan) && gst[13] == "Z") {
                    return gst;
                }

                return gst+"1";
            },
            message: "enter valid GST"
        }
    ]
})