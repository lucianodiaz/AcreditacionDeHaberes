function exportReportToExcel() {
    let table = document.getElementsByTagName("table"); // you can use document.getElementById('tableId') as well by providing id to the table tag
    alert(table.length);
    TableToExcel.convert(table[0], { // html code may contain multiple tables so here we are refering to 1st table tag
        name: `export.xls`, // fileName you could use any name
        sheet: {
            name: 'Sheet 1' // sheetName
        }
    });
}
