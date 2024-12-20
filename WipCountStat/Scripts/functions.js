function getVirtDir() {
    var Path = location.host;
    var VirtualDirectory;
    if (Path.indexOf("localhost") >= 0 && Path.indexOf(":") >= 0) {
        VirtualDirectory = "";

    }
    else {
        var pathname = window.location.pathname;
        var VirtualDir = pathname.split('/');
        VirtualDirectory = VirtualDir[1];
        VirtualDirectory = '/' + VirtualDirectory;
    }
    return VirtualDirectory;
}
function getDetailCountAssy() {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getDetailCountAssy.ashx",
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#smtDiv").html(r.html);
                new DataTable('#tableSerialsDet', {
                    info: false,
                    searching: false,
                    ordering: false,
                    paging: false
                });
            }
            else
                alert(r.messageError);
            return false;
        },
        error: function () { }
    });
}

function getDetailCountAKBattery() {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getDetailCountAKBattery.ashx",
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#assyDiv").html(r.html);
                new DataTable('#tableSerialsDetAk', {
                    info: false,
                    searching: false,
                    ordering: false,
                    paging: false
                });
            }
            else
                alert(r.messageError);
            return false;
        },
        error: function () { }
    });
}
function getDetailAreaAssy(idArea) {
    //alert(idArea);
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getDetailNotQAValAssy.ashx",
        data: {idarea: idArea},
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                //$("#smtDiv").html(r.html);
                $("#modalBody").html(r.html);
                new DataTable('#tableDetQANonVal', {
                    info: false,
                    searching: false,
                    ordering: true,
                    paging: true
                });
            }
            else
                alert(r.messageError);
            return false;
        },
        error: function () { }
    });
   
}
function getDetailAreaSMT(idArea) {
    //alert(idArea);
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getDetailNotQAValSMT.ashx",
        data: { idarea: idArea },
        success: function (data) {
            data = data.trim();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                //$("#smtDiv").html(r.html);
                $("#modalBody").html(r.html);
                new DataTable('#tableDetQANonValSMT', {
                    info: false,
                    searching: false,
                    ordering: true,
                    paging: true
                });
            }
            else
                alert(r.messageError);
            return false;
        },
        error: function () { }
    });

}

