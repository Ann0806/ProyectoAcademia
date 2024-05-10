jQuery(function () {

     //LlenarTablaEstudiantes();

    $("#dvMenu").load("../Paginas/Menu.html");
    $("#btnInsertar").on("click", function () {
        EjecutarComando("POST");
    });
    $("#btnActualizar").on("click", function () {
        EjecutarComando("PUT");
    });
    $("#btnEliminar").on("click", function () {
        EjecutarComando("DELETE");
    });
    $("#btnConsultar").on("click", function () {
        Consultar();
    });
});


async function LlenarTablaEstudiantes() {
    LlenarTablaXServicios("http://localhost:59268/api/Estudiante", "#tblEstudiantes");
}

async function Consultar() {

    let Documento = $("#txtDocumento").val();
    try {
        const Respuesta = await fetch("http://localhost:59268/api/Estudiante?Documento=" + Documento, {
            method: "GET",
            mode: "cors",
            headers: { "Content-Type": "application/json" }
        });

        const Resultado = await Respuesta.json();

        $("#txtNombre").val(Resultado.Nombre);
        $("#txtPrimerApellido").val(Resultado.PrimerApellido);
        $("#txtSegundoApellido").val(Resultado.SegundoApellido);
        $("#txtFechaNacimiento").val(Resultado.Fecha_Nacimiento);
        $("#txtCorreo").val(Resultado.Correo_electronico);
        $("#txtTelefono").val(Resultado.Telefono);

           }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}
async function EjecutarComando(Comando) {
    let Documento = $("#txtDocumento").val();
    let Nombre = $("#txtNombre").val();
    let PrimerApellido = $("#txtPrimerApellido").val(); 
    let SegundoApellido = $("#txtSegundoApellido").val();
    let Fecha_Nacimiento = $("#txtFechaNacimiento").val();
    let Correo_electronico = $("#txtCorreo").val();
    let Telefono = $("#txtTelefono").val();

    let DatosEstudiante = {
        Documento: Documento,
        Nombre: Nombre,
        PrimerApellido: PrimerApellido,
        SegundoApellido: SegundoApellido,
        Fecha_Nacimiento: Fecha_Nacimiento,
        Correo_electronico: Correo_electronico,
        Telefono: Telefono
    }

    try {
        const Respuesta = await fetch("http://localhost:59268/api/Estudiante",
            {
                method: Comando,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DatosEstudiante)
            });
        // Leer la respuesta y presentarla en el div
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    } catch (error) {
        $("#dvMensaje").html(error);
    }
}

