var modalWindow = {
    parent: "body",
    windowId: null,
    content: null,
    width: null,
    height: null,
    close: function () {
        $(".modal-window").remove();
        $(".modal-overlay").remove();
    },
    open: function (Heading) {
        var modal = "";

        modal += "<div class=\"modal-overlay\"></div>";
        modal += "<div id=\"" + this.windowId + "\" class=\"modal-window\" style=\"width:" + this.width + "px; height:" + this.height + "px; margin-top:-" + (this.height / 2) + "px; margin-left:-" + (this.width / 2) + "px;\"> <div style=\"height:20px;background-color:#f6f6f6 \"><span id=\"EntityHead\" style=\"font-family:Arial;font-size:10pt;font-weight:bold;\">" + Heading + "</span></div><div style=\"top:20px\">";
        modal += this.content;
        modal += "</div></div>";

        $(this.parent).append(modal);

        $(".modal-window").append("<a class=\"close-window\"></a>");
        $(".close-window").click(function () { modalWindow.close(); });
        $(".modal-overlay").click(function () { modalWindow.close(); });
    }
};


function DisplayWindow(source, p_Heading, p_Height,p_Width) {
    modalWindow.windowId = "myModal";
    modalWindow.width = p_Width;
    modalWindow.height = p_Height;
    modalWindow.content = "<iframe width='" + modalWindow.width + "' height='" + (modalWindow.height - 20) + "' frameborder='0' scrolling='auto' allowtransparency='true' src='" + source + "'></iframe>";
    modalWindow.open(p_Heading);
}
