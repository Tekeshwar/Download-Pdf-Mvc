var trueCookie = "filedownload=true";
var falseCookie = "filedownload=false";

function initiateDownload(fileUrl, successCallbak, failCallBack) {
    var ifrm = document.createElement("iframe");
    ifrm.setAttribute("src", fileUrl);
    ifrm.setAttribute("id", "__iframe__hidden__");
    ifrm.setAttribute("style", "display: none");
    document.body.appendChild(ifrm);
    retry(successCallbak, failCallBack);
}

function retry(successCallbak, failCallBack) {
    setTimeout(function () { checkFileDownloadComplete(successCallbak, failCallBack); }, 100);
}

function checkFileDownloadComplete(successCallbak, failCallBack) {
    if (hasDownloadCookie()) {
        if (isSuccessDownloadCookie()) {
            if (successCallbak) { successCallbak(); }
        } else {
            if (failCallBack) { failCallBack(); }
        }
        cleanUp();
    } else {
        retry(successCallbak, failCallBack);
    }
}

function cleanUp() {
    var element = document.getElementById("__iframe__hidden__");
    element.parentElement.removeChild(element);
    deleteDownloadCookie();
}

function hasDownloadCookie() {
    return isSuccessDownloadCookie() ||
        (document.cookie.toLowerCase().indexOf(falseCookie) > -1);
}

function isSuccessDownloadCookie() {
    return (document.cookie.toLowerCase().indexOf(trueCookie) > -1);
}
function deleteDownloadCookie() {
    document.cookie = 'fileDownload=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
}