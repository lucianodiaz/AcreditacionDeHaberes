   $("#uploadNew").on("click", function () {
            //Reference the FileUpload element.
            var fileUpload = $("#fileUploadNew")[0];
            document.getElementById("uploadNew").name = "nuevo";

            //Validate whether File is valid Excel file.
            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$/;
            if (regex.test(fileUpload.value.toLowerCase())) {
              if (typeof (FileReader) != "undefined") {
                var reader = new FileReader();

                    //For Browsers other than IE.
                    if (reader.readAsBinaryString) {
                      reader.onload = function (e) {
                        ProcessExcel(e.target.result);
                    };
                    reader.readAsBinaryString(fileUpload.files[0]);
                } else {
                        //For IE Browser.
                        reader.onload = function (e) {
                          var data = "";
                          var bytes = new Uint8Array(e.target.result);
                          for (var i = 0; i < bytes.byteLength; i++) {
                            data += String.fromCharCode(bytes[i]);
                        }
                        ProcessExcel(data);
                    };
                    reader.readAsArrayBuffer(fileUpload.files[0]);
                }
            } else {
              alert("This browser does not support HTML5.");
          }
      } else {
        alert("Por favor cargue un archivo de excel valido.");
        return false;
    }
});
   $(".uploadedit").on("click", function () {
            //Reference the FileUpload element.
            var fileUpload = $(".fileUploadedit")[0];
            document.getElementById("uploadedit").name = "editar";
            //Validate whether File is valid Excel file.
            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$/;
            if (regex.test(fileUpload.value.toLowerCase())) {
              if (typeof (FileReader) != "undefined") {
                var reader = new FileReader();

                    //For Browsers other than IE.
                    if (reader.readAsBinaryString) {
                      reader.onload = function (e) {
                        ProcessExcel(e.target.result);
                    };
                    reader.readAsBinaryString(fileUpload.files[0]);
                } else {
                        //For IE Browser.
                        reader.onload = function (e) {
                          var data = "";
                          var bytes = new Uint8Array(e.target.result);
                          for (var i = 0; i < bytes.byteLength; i++) {
                            data += String.fromCharCode(bytes[i]);
                        }
                        ProcessExcel(data);
                    };
                    reader.readAsArrayBuffer(fileUpload.files[0]);
                }
            } else {
              alert("This browser does not support HTML5.");
          }
      } else {
        alert("Por favor cargue un archivo de excel valido.");
        return false;
    }
});
   function ProcessExcel(data ) {
            //Read the Excel File data.
            var workbook = XLSX.read(data, {
              type: 'binary'
          });

            //Fetch the name of First Sheet.
            var firstSheet = workbook.SheetNames[0];

            //Read all rows from First Sheet into an JSON array.
            var excelRows = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[firstSheet]);
            var tablaCant = excelRows.length;


            // alert (document.getElementById("uploadNew").name);
            // alert (document.getElementById("uploadedit").name);
            // alert (tablaCant);
            

            //armar las tablas para la vista previa (2 funciones colisionan)
            if ((tablaCant == 9) && (document.getElementById("uploadNew").name =="nuevo"))
            {
                document.getElementById("uploadNew").name="";
                var table = $("<table class='table table-responsive table-striped' />");
                table[0].border = "1";

            //Add the header row.
            var row = $(table[0].insertRow(-1));

            //Add the header cells.
            var headerCell = $("<th />");
            headerCell.html("NOMBRE");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("DNI");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("CUIL");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("SUCURSAL");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("CUENTA");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("FECHAACREDITACION");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("IMPORTE");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("TIPOCUENTA");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("TIPOACREDITACION");
            row.append(headerCell);

            //Add the data rows from Excel file.
            for (var i = 0; i < excelRows.length; i++) {
                //Add the data row.
                var row = $(table[0].insertRow(-1));

                //Add the data cells.
                var cell = $("<td />");
                var arr1 = [];
                cell.html(excelRows[i].NOMBRE);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].DNI);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].CUIL);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].SUCURSAL);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].CUENTA);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].FECHAACREDITACION);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].IMPORTE);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].TIPOCUENTA);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].TIPOACREDITACION);
                row.append(cell);
            }

            var dvExcel = $(".dvExcelNew");
            dvExcel.html("");
            dvExcel.append(table);
        }
        else if ((tablaCant == 3) && (document.getElementById("uploadedit").name =="editar"))
        {
            document.getElementById("uploadedit").name="";
            //Create a HTML Table element.
            var table = $("<table class='table table-responsive table-striped' />");


            //Add the header row.
            var row = $(table[0].insertRow(-1));
            
            //Add the header cells.
            var headerCell = $("<th />");
            headerCell.html("FECHAACREDITACION");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("DNI");
            row.append(headerCell);

            var headerCell = $("<th />");
            headerCell.html("IMPORTE");
            row.append(headerCell);



            //Add the data rows from Excel file.
            for (var i = 0; i < excelRows.length; i++) {
                //Add the data row.
                var row = $(table[0].insertRow(-1));

                //Add the data cells.
                var cell = $("<td />");
                cell.html(excelRows[i].FECHAACREDITACION);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].DNI);
                row.append(cell);

                cell = $("<td />");
                cell.html(excelRows[i].IMPORTE);
                row.append(cell);


            }

            var dvExcel = $(".dvExcelNew");
            dvExcel.html("");
            dvExcel.append(table);
        }
        else
        {
            alert("El archivo excel posee un formato incorrecto");
            
        }

            //Create a HTML Table element.

        };


        // function ProcessExcelEdit(data) {
        //     //Read the Excel File data.
        //     var workbook = XLSX.read(data, {
        //       type: 'binary'
        //   });

        //     //Fetch the name of First Sheet.
        //     var firstSheet = workbook.SheetNames[0];

        //     //Read all rows from First Sheet into an JSON array.
        //     var excelRows = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[firstSheet]);

        //     //Create a HTML Table element.
        //     var table = $("<table class='table table-responsive table-striped' />");


        //     //Add the header row.
        //     var row = $(table[0].insertRow(-1));
        //     alert("tabla2");
        //     //Add the header cells.
        //     var headerCell = $("<th />");
        //     headerCell.html("FECHAACREDITACION");
        //     row.append(headerCell);

        //     var headerCell = $("<th />");
        //     headerCell.html("DNI");
        //     row.append(headerCell);

        //     var headerCell = $("<th />");
        //     headerCell.html("IMPORTE");
        //     row.append(headerCell);



        //     //Add the data rows from Excel file.
        //     for (var i = 0; i < excelRows.length; i++) {
        //         //Add the data row.
        //         var row = $(table[0].insertRow(-1));

        //         //Add the data cells.
        //         var cell = $("<td />");
        //         cell.html(excelRows[i].FECHAACREDITACION);
        //         row.append(cell);

        //         cell = $("<td />");
        //         cell.html(excelRows[i].DNI);
        //         row.append(cell);

        //         cell = $("<td />");
        //         cell.html(excelRows[i].IMPORTE);
        //         row.append(cell);


        //     }

        //     var dvExcel = $(".dvExceledit");
        //     dvExcel.html("");
        //     dvExcel.append(table);
        // };