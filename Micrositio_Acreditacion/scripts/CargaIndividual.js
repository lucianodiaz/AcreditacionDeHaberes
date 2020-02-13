 $(document).ready(function(){
      //totalizadores
      var table = $('#table1ni tbody tr').length;
      var array = [];
      var sum = 0;
      var ceros  = 0; 

      var focus = true;

     //destruye o conserva el local storage depende si es la primera vez que es visitada
     if (!sessionStorage.getItem('visited')) {
      localStorage.clear();
      sessionStorage.setItem('visited', true);
    }
    else if((sessionStorage.getItem('visited'))) {
     var indicei = localStorage.getItem("indicei");
   }

   var indicei = localStorage.getItem("indicei");
   if (indicei!=null){
       // indice = (parseInt(indice) + 1);
//---------------------------------------------------------------


//---------------------------------------------------------------

if (indicei>=table){
  indicei = 0;
  $('#table1ni tbody tr:eq('+indicei+')').find('.importe').focus().select();
}
else{
       $('#table1ni tbody tr:eq('+indicei+')').find('.importe').focus().select();
     }
     

   }
//------------------------------------------------------------------------------

//----------------------------sumador--------------------

$("#table1ni tbody tr").each(function () {
  if (Number($(this).find(".importe").val()) == 0)
  {
          //chequea cuantos elementos estan con valor cero
          ceros += 1;
        }

        sum += Number($(this).find(".importe").val());

      });

      document.getElementById("TotEmp").innerHTML = table - ceros;//total sin ceros
      document.getElementById("TotImporte").innerHTML = "$ " + sum.toFixed(2);
      
//-----------------------disable siguiente y paso 2---------------------------

if (table == 0 || sum == 0)
{
    $("#btnSiguiente").css("pointer-events", "none");
    $("#paso3").addClass('disabledTab');
    $("#paso3").css('cursor', 'not-allowed');
  $("#paso3").click(function (e) { return false; });
  $("#btnSiguiente").click(function (e) { return false; });

}


    // -------------------------------tabulacion--------------------------

    $(".importe").on('keydown', function(e) { 
      var keyCode = e.keyCode || e.which; 
      if (keyCode == 9) {


       if (focus==true)
       {
        var valor = $(this).closest('td input').val();
      

       var indicei = parseInt($(this).closest('tr').index())+1;
       if (valor<0)
       {
        alert("El valor del importe no puede ser menor a 0");
        return false
      }
      else
      {
       
        localStorage.setItem("indicei", indicei);
        focus = false;
        $(this).closest('td form').submit();


      }
    }

  }
}); 

//-----------------------------------------------------------------




//---------------------------------tecla enter------------
$('.importe').keypress(function(event){
  var keycode = (event.keyCode ? event.keyCode : event.which);
  if(keycode == '13'){

    var valor = $(this).closest('td input').val();
    var indicei = parseInt($(this).closest('tr').index());
    if (valor<0)
    {
      alert("El valor del importe no puede ser menor a 0");
      return false
    }
    else
    {
      localStorage.setItem("indicei", indicei);
      $(this).closest('td form').submit();
    }
  }
});

//-----------------------------------------focus out del campo fecha-------------------------------

 $('#nFecha').on("focusout",function(){
          var e = $('#nFecha').val();
          var days = 1;

          var fechaHoy = new Date();
          fechaHoy.setDate(fechaHoy.getDate() );
          fechaHoy.setMonth(fechaHoy.getMonth() +1);


      // 2019-02-28

      var twoDigitMonth = fechaHoy.getMonth()+"";if(twoDigitMonth.length==1)  twoDigitMonth="0" +twoDigitMonth;
      var twoDigitDate = fechaHoy.getDate()+"";if(twoDigitDate.length==1) twoDigitDate="0" +twoDigitDate;
      var currentDate = fechaHoy.getFullYear() + "-" + twoDigitMonth + "-" + twoDigitDate;
      
      
      

      if (e>=currentDate) {

        $('#fechasForm').submit();
      }
      else {
        alert('Error! la fecha no puede ser menor ni igual a la fecha actual');
        
        return false;
      }
      
      localStorage.clear();
      document.getElementById("fechasForm").submit();
    
  });

    });