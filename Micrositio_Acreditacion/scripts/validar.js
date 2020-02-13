function disable(){

	var table = $('#table2e tr').length;
	

	if (table == 0)
	{
		alert("Debe seleccionar al menos un archivo para eliminar")
		$('#btnDelete').prop( "disabled", true );
	}

	
}


function disableEdit()
{
	var table = $('#table2e tr').length;
	if(table == 0){
		alert("Debe seleccionar al menos un registro para ser eliminado")
		$('#btnEdit').prop( "disabled", true );
	}
	if ( table>1){
		alert("No puede seleccionar mas de un archivo para editar");
		$('#btnEdit').prop("disabled", true);

	}

}

function disablenuevo() {
    alert("hdhdhd");
}

//para empleados

function validarNewEmpleado()
{
//nombre
var nombre =  document.forms['new']['nNombre'].value;

var caracter = new RegExp(/^[a-zA-Z\s]+$/);

if (!caracter.test(nombre))
{
	alert("El campo nombre no bebe contener números ni estar vacío");
	return false;
}

//dni
var numero = new RegExp(/^[0-9]+$/);
var dni = document.forms['new']["nDNI"].value;

if ((!numero.test(dni)) || (dni.length<7) || (dni.length>8))
{
	alert('El campo DNI debe contener numeros y no superar los 7 dígitos');
	return false;
}

// cuit
var cuit = document.forms["new"]["ncuit"].value;

if (!numero.test(cuenta) || cuenta == "" || cuenta.length > 7 || cuenta.length < 2) {
	alert("El numero de cuit no puede estar vacio, ni contener letras, ni tener menos de 11 caracteres");
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
	alert("Cuit incorrecto");
	return false;
}

// cuenta
var cuenta = document.forms["new"]["nCuenta"].value;

if(!numero.test(cuenta)|| cuenta == "" || cuenta.length != 7)
{
	alert("El campo cuenta no puede estar vacío ni contener letras y tener exactamente 7 caracteres");
	return false;
}

//CBU
cbu = document.forms["new"]["ncbu"].value;
alert(cbu);
if ((!numero.test(cbu) && (cbu != ""))) {
    alert("El campo cbu no puede contener letras");
    return false;
} else {
    {
        if ((cbu.length < 22) && (cbu.length != 0)) {
            alert("El campo CBU puede estar vacio o contener 22 caracteres");
            return false;
        }

    }
}


return true;
}



function validarEditEmpleado()
{
	//nombre
	var nombre =  document.forms['editForm']['eNombre'].value;

	var caracter = new RegExp(/^[a-zA-Z\s]+$/);

	if (!caracter.test(nombre))
	{
		alert("El campo nombre no bebe contener números ni estar vacío");
		return false;
	}

//dni
var numero = new RegExp(/^[0-9]+$/);
var dni = document.forms['editForm']["eDNI"].value;

if ((!numero.test(dni)) || (dni.length<7) || (dni.length>8))
{
	alert('El campo DNI debe contener numeros y no superar los 7 dígitos');
	return false;
}

// cuit
var cuit = document.forms["editForm"]["eCuil"].value;

if(cuit.length != 11 || !numero.test(cuit) || cuit=="" ) {
	alert("El numero de cuit no puede estar vacio, ni contener letras, ni tener menos de 11 caracteres");
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
	alert("Cuit incorrecto");
	return false;
}

// cuenta
var cuenta = document.forms["editForm"]["eCuenta"].value;

if (!numero.test(cuenta) || cuenta == "" || cuenta.length > 7 || cuenta.length < 2)
{
	alert("El campo cuenta no puede estar vacío ni contener letras y tener exactamente 7 caracteres");
	return false;
}

//CBU
cbu = document.forms["editForm"]["CBUedit"].value;

//if ( (cbu.length < 22) || (cbu.length < 0)) {
//	alert("El campo CBU debe contener solo numeros y tener 22 caracteres exactamente1");
//	return false;
    //}
if ((!numero.test(cbu) && (cbu != ""))) {
    alert("El campo cbu no puede contener letras");
    return false;
} else {
    {
        if ((cbu.length < 22) && (cbu.length != 0)) {
            alert("El campo CBU puede estar vacio o contener 22 caracteres");
            return false;
        }

    }
}


return true;
}


