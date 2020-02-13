 $(document).ready(function(){
      //totalizadores
      var tablemasiva = $('#table1m tbody tr').length;
      var summ = 0;
      var ceros = 0;
      var focus = true;
    


//destruye o conserva el local storage depende si es la primera vez que es visitada
if (!sessionStorage.getItem('visited')) {
  localStorage.clear();
  sessionStorage.setItem('visited', true);
}
else if((sessionStorage.getItem('visited'))) {
 var indice = localStorage.getItem("indice");
}

var indice = localStorage.getItem("indice");
if (indice!=null){
//---------------------------------------------------------------

if (indice>=tablemasiva){
  indice = 0;
  $('#table1m tbody tr:eq('+indice+')').find('.importem').focus();
}
else{
       $('#table1m tbody tr:eq('+indice+')').find('.importem').focus();
     }
     

   }
//------------------------------------------------------------------------------



   // -------------------------------tabulacion--------------------------

   $(".importem").on('keydown', function(e) { 
    var keyCode = e.keyCode || e.which; 
    if (keyCode == 9) {

     
     if (focus==true)
     {
      var valor = $(this).closest('td input').val();
     

       var indice = parseInt($(this).closest('tr').index())+1;
       if (valor<0)
       {
        alert("El valor del importe no puede ser menor a 0");
        return false
      }
      else
      {
        
        localStorage.setItem("indice", indice);
        focus = false;
        $(this).closest('td form').submit();


      }
    }

  }
}); 

//---------------- sumador-------------------------------------------------


   $("#table1m tbody tr").each(function () {

      
  if (Number($(this).find(".importem").val()) == 0)
  {
      //chequea cuantos elementos estan con valor cero
      $("#table1m tbody tr").find(".mostrar").addClass("display-none");
          ceros += 1;
        }
        summ += Number($(this).find(".importem").val());

      });



document.getElementById("TotEmpm").innerHTML = tablemasiva - ceros;
document.getElementById("TotImportem").innerHTML = "$ " + summ.toFixed(2);

//-----------------------disable siguiente y paso 2---------------------------

if (tablemasiva == 0 || summ == 0 )
{
    $("#btnSiguientem").css("pointer-events", "none");
    $("#paso3m").css('cursor', 'not-allowed');
  $("#paso3m").addClass('disabledTab');
  $("#paso3m").click(function (e) { return false; });
  $("#btnSiguientem").click(function (e) { return false; });

}



//---------------------------------------------enter-----------------------------------
$('.importem').keypress(function(event){
  var keycode = (event.keyCode ? event.keyCode : event.which);
  if(keycode == '13'){

    var valor = $(this).closest('td input').val();
    var indice = parseInt($(this).closest('tr').index());
    if (valor<0)
    {
      alert("El valor del importe no puede ser menor a 0");
      return false
    }
    else
    {
      localStorage.setItem("indice", indice);
      $(this).closest('td form').submit();
    }
  }
});

var aceptados = $('.aceptados').text();

if (aceptados =="$")
{
   
    $('#continuar').addClass('disabled');
}

    

});