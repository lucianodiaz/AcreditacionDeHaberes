function disable(){

	
	var table = $('#table2e tr').length;
	

	if (table == 0)
	{
		alert("Debe seleccionar al menos un archivo para eliminar.")
		$('#btnDelete').prop( "disabled", true );
	}

	
}

function disableEdit()
{
	
	var table = $('#table2e tr').length;
	if(table == 0){
		alert("Debe eleccionar un regitro para poder editarlo.")
		$('#btnEdit').prop( "disabled", true );
	}
	if ( table>1){
		alert("No puede seleccionar mas de un archivo para editar.");
		$('#btnEdit').prop( "disabled", true );
	}

}

function disablenuevo() {
   
    acre = $("#SelConvenio option:first").text();
   

    if (acre == "")
    {
        alert("no puede agregar un empreado sin seleccionar un tipo de acreditacion.")
        $('#btnNew').prop("disabled", true);
    }
}

//para empleados

function validarNewEmpleado()
{
   

    //dni
    var numero = new RegExp(/^[0-9]+$/);
    var dni = document.forms['new']["nDNI"].value;

    if ((!numero.test(dni)) || (dni.length < 7) || (dni.length > 8)) {
        $("#nDNI").addClass('border-danger');
        $("#nDNI").focus();
        alert('El campo DNI debe contener numeros y no superar los 7 dígitos.');
        return false;
    }
    $("#nDNI").removeClass('border-danger');

//nombre
  
var nombre = document.forms['new']['nNombre'].value;

//var caracter = new RegExp(/^[a-zA-Z\s]+$/);

if (nombre == "")
{
    $("#nNombre").addClass('border-danger');
    $("#nNombre").focus();
	alert("El campo nombre no estar vacío.");
	return false;
}
$("#nNombre").removeClass('border-danger');


// cuit
var cuit = document.forms["new"]["ncuit"].value;

if (cuit.length != 11 || !numero.test(cuit) || cuit == "") {
    $("#ncuit").addClass('border-danger');
    $("#ncuit").focus();
	alert("El numero de cuit no puede estar vacio, ni contener letras, ni tener menos de 11 caracteres.");
	return false;
}

var acumulado   = 0;
var digitos     = cuit.split("");
var digito      = digitos.pop();

for(var i = 0; i < digitos.length; i++) {
	acumulado += digitos[9 - i] * (2 + (i % 6));
}

var verif = 11 - (acumulado % 11);
if(verif == 11) {
	verif = 0;
} else if(verif == 10) {
	verif = 9;
}
// alert(digito == verif)
if (!(digito == verif)) {
    $("#ncuit").addClass('border-danger');
	alert("Cuit incorrecto");
	return false;
}
$("#ncuit").removeClass('border-danger');


// cuenta
//var cuenta = document.forms["new"]["nCuenta"].value;

//if(!numero.test(cuenta)|| cuenta == "" || cuenta.length > 7 || cuenta.length <2)
//{
//	alert("La cuenta ingresada no es valida.");
//	return false;
//}

//CBU
cbu = document.forms["new"]["ncbu"].value;
    
//alert(((cbu.value* 1) == 0));
//return false;

if ((!numero.test(cbu)) && (cbu != "")) {
    $("#ncbu").addClass('border-danger');
    $("#ncbu").focus();
    alert("El campo cbu no puede contener letras.");
    return false;
} else {
    
    if ((cbu.length < 22) || (cbu.length == 0)|| (cbu.value == 0)) {
        $("#ncbu").addClass('border-danger');
        $("#ncbu").focus();
            alert("El campo CBU ha sido rechazado.");
            return false;
        }

    
}
$("#ncbu").removeClass('border-danger');


return true;
}


////funcion validar CBU
//function validarCBU(cbu) {

//    var ponderador;
//    ponderador = '97139713971397139713971397139713';

//    var i;
//    var nDigito;
//    var nPond;
//    var bloque1;
//    var bloque2;

//    var nTotal;
//    nTotal = 0;

//    bloque1 = '0' + cbu.substring(0, 7);

//    for (i = 0; i <= 7; i++) {
//        nDigito = bloque1.charAt(i);
//        nPond = ponderador.charAt(i);
//        nTotal = nTotal + (nPond * nDigito) - ((Math.floor(nPond * nDigito / 10)) * 10);
//    }

//    i = 0;

//    while (((Math.floor((nTotal + i) / 10)) * 10) != (nTotal + i)) {
//        i = i + 1;
//    }

//    // i = digito verificador

//    var valido1 = cbu.substring(7, 8) == i;

//    // if (cbu.substring(7,8) != i){
//    // 	alert('Por favor, ingrese un CBU válido')
//    // 	return false;
//    // }

//    nTotal = 0;

//    bloque2 = '000' + cbu.substring(8, 21)

//    for (i = 0; i <= 15; i++) {
//        nDigito = bloque2.charAt(i)
//        nPond = ponderador.charAt(i)
//        nTotal = nTotal + (nPond * nDigito) - ((Math.floor(nPond * nDigito / 10)) * 10)
//    }

//    i = 0;

//    while (((Math.floor((nTotal + i) / 10)) * 10) != (nTotal + i)) {
//        i = i + 1;
//    }

//    // i = digito verificador

//    // if (cbu.substring(21,22) != i){
//    // 	alert('Por favor, ingrese un CBU válido');
//    // 	return false;
//    // }

//    var valido2 = cbu.substring(21, 22) == i;


//    if (!valido1 && !valido2) {
//        if ($('#ncbu').val() != "") {
//            $('#ncbu').addClass('border-danger');
//            $("#ncbu").focus();
//            alert("El campo CBU ha sido rechazado");
//            return false;
//        } else if ($('#CBUedit').val() != "") {
//            $('#CBUedit').addClass('border-danger');
//            $("#CBUedit").focus();
//            alert("El campo CBU ha sido rechazado");
//            return false;
//        }
//        $('#ncbu').removeClass('border-danger');
//        $('#CBUedit').removeClass('border-danger');
//        // true si es valido false si no lo es
//        return (valido1 && valido2);
//    }
//}

function validarCBUNew(cbu) {
    console.log(cbu);
    
    
    var ponderador;
    ponderador = '97139713971397139713971397139713';

    var i;
    var nDigito;
    var nPond;
    var bloque1;
    var bloque2;

    var nTotal;
    nTotal = 0;

    bloque1 = '0' + cbu.substring(0, 7);

    for (i = 0; i <= 7; i++) {
        nDigito = bloque1.charAt(i);
        nPond = ponderador.charAt(i);
        nTotal = nTotal + (nPond * nDigito) - ((Math.floor(nPond * nDigito / 10)) * 10);
    }

    i = 0;

    while (((Math.floor((nTotal + i) / 10)) * 10) != (nTotal + i)) {
        i = i + 1;
    }

    // i = digito verificador

    var valido1 = cbu.substring(7, 8) == i;

    // if (cbu.substring(7,8) != i){
    // 	alert('Por favor, ingrese un CBU válido')
    // 	return false;
    // }

    nTotal = 0;

    bloque2 = '000' + cbu.substring(8, 21)

    for (i = 0; i <= 15; i++) {
        nDigito = bloque2.charAt(i)
        nPond = ponderador.charAt(i)
        nTotal = nTotal + (nPond * nDigito) - ((Math.floor(nPond * nDigito / 10)) * 10)
    }

    i = 0;

    while (((Math.floor((nTotal + i) / 10)) * 10) != (nTotal + i)) {
        i = i + 1;
    }

    // i = digito verificador

    // if (cbu.substring(21,22) != i){
    // 	alert('Por favor, ingrese un CBU válido');
    // 	return false;
    // }

    var valido2 = cbu.substring(21, 22) == i;

    
    if (!valido1 && !valido2) {
        if ($('#ncbu').val() != "") {
            $('#ncbu').addClass('border-danger');
            $("#ncbu").focus();
            alert("El campo CBU ha sido rechazado");
            return false;
        } else if ($('#CBUedit').val() != "") {
            $('#CBUedit').addClass('border-danger');
            $("#CBUedit").focus();
            alert("El campo CBU ha sido rechazado");
            return false;
        }
        $('#ncbu').removeClass('border-danger');
        $('#CBUedit').removeClass('border-danger');
        // true si es valido false si no lo es
        return (valido1 && valido2);
    }
}

    function validarEditEmpleado() {

        //dni
        var numero = new RegExp(/^[0-9]+$/);
        var dni = document.forms['editForm']["eDNI"].value;

        if ((!numero.test(dni)) || (dni.length < 7) || (dni.length > 8)) {
            $("#eDNI").addClass('border-danger');
            $("#eDNI").focus();
            alert('El campo DNI debe contener numeros y no superar los 7 dígitos');
            return false;
        }
        $("#eDNI").removeClass('border-danger');


        //nombre
        var nombre = document.forms['editForm']['eNombre'].value;

        //var caracter = new RegExp(/^[a-zA-Z\s]+$/);

        if (nombre == "") {
            $("#eNombre").addClass('border-danger');
            $("#eNombre").focus();
            alert("El campo nombre no bebe contener números, ni caracteres especiales, ni estar vacío.");
            return false;
        }
        $("#eNombre").removeClass('border-danger');




        // cuit
        var cuit = document.forms["editForm"]["eCuil"].value;

        if (cuit.length != 11 || !numero.test(cuit) || cuit == "") {
            $("#eCuil").addClass('border-danger');
            $("#eCuil").focus();
            alert("El numero de cuit no puede estar vacio, ni contener letras, ni tener menos de 11 caracteres.");
            return false;
        }

        var acumulado = 0;
        var digitos = cuit.split("");
        var digito = digitos.pop();

        for (var i = 0; i < digitos.length; i++) {
            acumulado += digitos[9 - i] * (2 + (i % 6));
        }

        var verif = 11 - (acumulado % 11);
        if (verif == 11) {
            verif = 0;
        } else if (verif == 10) {
            verif = 9;
        }

        if (!(digito == verif)) {
            $("#eCuil").addClass('border-danger');
            $("#eCuil").focus();
            alert("Cuit incorrecto");
            return false;
        }
        $("#eCuil").removeClass('border-danger');

        // cuenta
        //var cuenta = document.forms["editForm"]["eCuenta"].value;

        //if ((!numero.test(cuenta) || cuenta == "" || cuenta.length > 7 || cuenta.length < 2))
        //{
        //    alert("La cuenta ingresada no es valida");
        //	return false;
        //}

        //CBU
        cbu = document.forms["editForm"]["CBUedit"].value;
        //console.log(cbu * 1);
        //return false;
        alert(((!numero.test(cbu)) && (cbu != "")));
       
        if ((!numero.test(cbu)) && (cbu != "")) {
            console.log("esta mal" + cbu)
            $("#CBUedit").addClass('border-danger');
            $("#CBUedit").focus();
            alert("El campo cbu no puede contener letras.");
            return false;
        } else {

            if ((cbu.length < 22) || (cbu.length == 0) || ((cbu * 1)===0)) {
                $("#CBUedit").addClass('border-danger');
                $("#CBUedit").focus();
                alert("El campo cbu ha sido rechazado.");
                return false;
            }


        }
        
        $("#CBUedit").removeClass('border-danger');
        
        return true;
    }

//validacion solicitar archivo

    function ValidarSolicitud() {
        var archivo = $('#fileSol')[0].files[0];
        //alert(archivo);
        
        if (archivo != null) {
            myVar = setTimeout(showModal, 5000);
            
           

            return true
        }
        else {
            alert("No ha seleccionado un archivo valido vuelva a cargar el archivo.");
            //$("#staticBackdrop").modal();
            return false;
        }
    }

    function showModal() {
        $("#staticBackdrop").modal();
    }



