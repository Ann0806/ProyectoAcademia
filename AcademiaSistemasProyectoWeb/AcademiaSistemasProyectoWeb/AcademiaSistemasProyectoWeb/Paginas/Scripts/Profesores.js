
jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html");

    //levantaremos el evento click para insertar
    $("#btnInsertar").on("click", function () {
        EjecutarComando("POST");
    })
    $("#btnActualizar").on("click", function () {
        EjecutarComando("PUT");
    })

    $("#btnEliminar").on("click", function () {
        EjecutarComando("DELETE");
    })

    $("#btnConsultar").on("click", function () {
        Consultar();
    });

    LlenarComboCurso();
    LlenarTablaProfesores();
   

});

function Editar(Documento, Nombre, PrimerApellido, SegundoApellido, ID_curso, Telefono, Correo_electronico) {
    $("#txtDocumento").val(Documento);
    $("#txtNombre").val(Nombre);
    $("#txtPrimerApellido").val(PrimerApellido);
    $("#txtSegundoApellido").val(SegundoApellido);
    $("#txtCorreo").val(Correo_electronico);
    $("#txtTelefono").val(Telefono);
    $("#cboCurso").val(ID_curso);
}

async function LlenarTablaProfesores() {
    LlenarTablaXServicios("http://localhost:59268/api/Profesores/ListarProfesores", "#tblProfesores");
}

function LlenarComboCurso() {
    LlenarComboXServicios("http://localhost:59268/api/Curso/ListarCurso", "#cboCurso");
}

async function Consultar() {
    let Documento = $("#txtDocumento").val();
    try {
        const Respuesta = await fetch("http://localhost:59268/api/Profesores?Documento=" + Documento, {
            method: "GET",
            mode: "cors",//para que tenga permiso en el origen 
            headers: { "Content-Type": "application/json" },
        });
        // Leer la respuesta y presentarla en el div 
        const Resultado = await Respuesta.json();
        //AL CONSULTAR LA RESPUESTA se muestra en los campos
        $("#txtNombre").val(Resultado.Nombre);
        $("#txtPrimerApellido").val(Resultado.PrimerApellido);
        $("#txtSegundoApellido").val(Resultado.SegundoApellido);
        $("#cboCurso").val(Resultado.ID_Curso);
        $("#txtCorreo").val(Resultado.Correo_electronico);
        $("#txtTelefono").val(Resultado.Telefono);

    } catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }


}
async function EjecutarComando(Comando) {
    let Documento = $("#txtDocumento").val();
    let Nombre = $("#txtNombre").val();
    let PrimerApellido = $("#txtPrimerApellido").val();
    let SegundoApellido = $("#txtSegundoApellido").val();
    let Correo_electronico = $("#txtCorreo").val();
    let Telefono = $("#txtTelefono").val();
    let ID_Curso = $("#cboCurso").val();

    let DatosProfe = {
        Documento: Documento,
        Nombre: Nombre,
        PrimerApellido: PrimerApellido,
        SegundoApellido: SegundoApellido,
        Correo_electronico: Correo_electronico,
        Telefono: Telefono,
        ID_Curso: ID_Curso,
    }
    try
    {
        const Respuesta = await fetch("http://localhost:59268/api/Profesores", {
            method: Comando,
            mode: "cors",//para que tenga permiso en el origen 
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(DatosProfe)//la estructura de json de los datos que recolecte 
        });
        // Leer la respuesta y presentarla en el div 
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
        LlenarTablaProfesores();
    }catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }
  
   
}