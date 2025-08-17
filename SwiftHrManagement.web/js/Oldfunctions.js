

function readData(id, singleQuote, focusIfNull) {
    var obj = document.getElementById(id);
    if (obj) return (singleQuote ? "'" + obj.value + "'" : obj.value);
    return "null";
}

function isCSVFile(fileName) { 
    var file_parts = fileName.split(".");

    if (file_parts[file_parts.length - 1].toUpperCase() == "CSV")
        return true;
    return false;

}

