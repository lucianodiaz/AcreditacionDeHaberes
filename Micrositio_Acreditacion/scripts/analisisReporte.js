
	$("#acreAnalisis").on('change',  function() {
		$("#formAnalisis").submit();
		
	});


$('#orden').click();
function sortAsDate(cell) {
    var col = cell.cellIndex,
    table = cell.parentNode.parentNode.parentNode,
    tbody = table.tBodies[0],
    formatter = row => row.cells[col].textContent.split(/\D/).reverse().join('');

    Array.from(tbody.rows)
    .sort((a, b) => formatter(a).localeCompare(formatter(b)))
    .reduceRight((acc, row) => tbody.appendChild(row), null);
}