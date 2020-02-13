 
$(document).ready(function() {
  // validador excel
  var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$/;
//si no funciona validar que el archivo enviado sea un xls o xlsx


var table2 = $("#tableResult tbody tr").length;

if (!sessionStorage.getItem('visited')) {
   
  sessionStorage.setItem('visited', true);
}
else if ((table2 > 0) && (sessionStorage.getItem('visited'))) {
 
   
  $(".boton1").click();
}








//evento de fileupload
$(".excel").on('change', function(event) {
  var fileUpload = $(".excel")[0];

    //proceso de validacion de archivo excel
    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$/;
    if (regex.test(fileUpload.value.toLowerCase())) {
     document.getElementById("boton2").click();
   } else {
    alert("Por favor cargue un archivo de excel valido.");
    
    return false
  }
  return true;

});

    // funcion modal dismiss
$("#previewedit-modal-grid").on('hide.bs.modal', function () {
    
    document.getElementById("cancel").click();

});

$(".fechaMasiva").on("focusout", function () {
    var e = $('#fechaMasiva').val();
    var days = 1;
    

    var fechaHoy = new Date();
    fechaHoy.setDate(fechaHoy.getDate());
    fechaHoy.setMonth(fechaHoy.getMonth() + 1);


    // 2019-02-28

    var twoDigitMonth = fechaHoy.getMonth() + ""; if (twoDigitMonth.length == 1) twoDigitMonth = "0" + twoDigitMonth;
    var twoDigitDate = fechaHoy.getDate() + ""; if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;
    var currentDate = fechaHoy.getFullYear() + "-" + twoDigitMonth + "-" + twoDigitDate;




    if (e >= currentDate) {

        $('.fechaMasivaForm').submit();
    }
    else {
        alert('Error! la fecha no puede ser menor ni igual a la fecha actual');
        $("#excel").val("");
        return false;
    }

   
});




});

function VerificarMasiva(){
  var e = $('#fechaMasiva').val();
  var days = 1;
 

  var fechaHoy = new Date();
  fechaHoy.setDate(fechaHoy.getDate() );
  fechaHoy.setMonth(fechaHoy.getMonth() +1);


      // 2019-02-28

      var twoDigitMonth = fechaHoy.getMonth()+"";if(twoDigitMonth.length==1)  twoDigitMonth="0" +twoDigitMonth;
      var twoDigitDate = fechaHoy.getDate()+"";if(twoDigitDate.length==1) twoDigitDate="0" +twoDigitDate;
      var currentDate = fechaHoy.getFullYear() + "-" + twoDigitMonth + "-" + twoDigitDate;
      
      
      

      if (e>=currentDate) {
          return true;
       
      }
      else {
        alert('Error! la fecha no puede ser menor ni igual a la fecha actual');
        $("#excel").val("");
        return false;
      }
      
      return true;
    }
