
$(function () {
    //multiselect
    $('#table1e').multiSelect({
      actcls: 'bg-warning', 
      selector: 'tbody tr', 
      except: ['tbody'], 

      callback: function (items) {
        $('#table2e').empty().append(items.clone().removeClass('bg-warning').addClass('bg-success'));

        var table = $('#table2e tr').length;
        

        

        if (table > 0)
        {
            

          $('#btnDelete').prop( "disabled", false );
          $('#btnEdit').prop( "disabled", false );
         
          id = document.getElementById("table2e").rows[0].cells[0].innerHTML;
          document.forms['editForm']['eId'].value = id;
          
          nomEmp = document.getElementById("table2e").rows[0].cells[1].innerHTML;
          
            document.forms['editForm']['eNombre'].value = nomEmp;
            
            dniEmp = document.getElementById("table2e").rows[0].cells[2].innerHTML;
            document.forms['editForm']['eDNI'].value = dniEmp;
            cuilEmp = document.getElementById("table2e").rows[0].cells[3].innerHTML;
            document.forms['editForm']['eCuil'].value = cuilEmp;
            cueEmp = document.getElementById("table2e").rows[0].cells[6].innerHTML;
            document.forms['editForm']['eCuenta'].value = cueEmp;
            
            
            sucEmp = document.getElementById("table2e").rows[0].cells[9].innerHTML;
           
            $( '#eSucursal' ).find('option[value='+sucEmp+']').attr('selected','selected');
            
            estEmp = document.getElementById("table2e").rows[0].cells[6].innerHTML;
           

      

            if (estEmp == '1')
            {
                $('#eTipoCuenta').find('option[value=' + 1 + ']').prop('selected', 'selected');
                
          }
          else
          {
                $('#eTipoCuenta').find('option[value=' + 2 + ']').prop('selected', 'selected');
               
          }

            CBU = document.getElementById("table2e").rows[0].cells[8].innerHTML;
           

          document.forms['editForm']['CBUedit'].value = CBU;

          estadoEmpleado = document.getElementById("table2e").rows[0].cells[9].innerHTML;
         
          
          if(estadoEmpleado == "Activo")
          {

              //myonoffswitch3
              document.forms['editForm']['myonoffswitch3'].checked = true;
             
              
          }
          else
          {
              document.forms['editForm']['myonoffswitch3'].checked = false;
             
          }

          

            // multiselect table for delete
            var arr = [];
            $("#table2e tr").each(function () {
           
            arr.push($(this).find("td:eq(0)").text()); //put elements into array
            arr.shift;
        });
            var valInput = arr.join();

            //only one

          
            document.getElementById("deleteInput").value = valInput;
            console.log(valInput);

       


        }
    }

});
});

$(document).ready(function(){

    //seleccionar dentro del combo el valor elegido
   
    var tipo = $(".tipo").text();
    
    $("#SelConvenio").val(tipo).attr("selected", "selected");


//solo para carga de empleados evento onchange de tipoAcreditacion
$("#SelConvenio").on("change", function(){

  $("#SelConvenioForm").submit();
});

var empGral = $("#table1e tbody tr").length;



document.getElementById("TotEmp1").innerHTML = "Total de empleados: " + empGral;
document.getElementById("TotImporte").innerHTML = 0;


//---------------------------------------------------------------------



});