function submitForm(gridName) {
    var btnHdd = document.getElementById(gridName + "_submitButton");
    if (btnHdd != null) btnHdd.click();
}

function nav(page, gridName) {
    var pageNumberHdd = document.getElementById(gridName + "_pageNumber");
    if (pageNumberHdd != null) pageNumberHdd.value = page;

    submitForm(gridName);
}

function newTableToggle(idTD, idImg, gridName) {
    var td = document.getElementById(gridName + "_" + idTD);
    var img = document.getElementById(gridName + "_" + idImg);

    if (td != null && img != null) {
        var isHidden = td.style.display == "none" ? true : false;
        img.src = isHidden ? "/images/icon_hide.gif" : "/images/icon_show.gif";
        img.alt = isHidden ? "Hide" : "Show";
        td.style.display = isHidden ? "" : "none";
    }
}
function sortGrid(gridName, sortBy, sortOrder) {
    var sortByHdd = document.getElementById(gridName + "_sortBy");
    if (sortByHdd != null) sortByHdd.value = sortBy;
    var sortOrderHdd = document.getElementById(gridName + "_sortOrder");
    if (sortOrderHdd != null) sortOrderHdd.value = sortOrder;
    submitForm(gridName);
}

