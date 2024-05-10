jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html")

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
    })
});
async function Consultar() {
    let ProfeID = $("#txtProfeID").val();
    //invocaremos el fetch-----------------------------------------------
    try {
        const Respuesta = await fetch("http://localhost:59268/api/Profesores?ID_profesor="+ProfeID, {
            method: "GET",
            mode: "cors",//para que tenga permiso en el origen 
            headers: { "Content-Type": "application/json" },
        });
        // Leer la respuesta y presentarla en el div 
        const Resultado = await Respuesta.json();
        //AL CONSULTAR LA RESPUESTA se muestra en los campos
        $("#txtProfeID").val(Resultado.ID_profesor);
        $("#txtNombre").val(Resultado.Nombre);
        $("#txtApellido").val(Resultado.Apellido);
        $("#txtCorreo").val(Resultado.Correo_electronico);
        $("#txtEspe").val(Resultado.Especialidad);

    } catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }


}
async function EjecutarComando(Comando) {
    //para capturar los datos de entrada---------------------------------
    let ID_profesor = $("#txtProfeID").val();
    let Nombre = $("#txtNombre").val();
    let Apellido = $("#txtApellido").val();
    let Correo_electronico = $("#txtCorreo").val();
    let Especialidad = $("#txtEspe").val();
    //estructura json para enviar la inf al servidor---------------------
    let DatosProfe = {
        ID_profesor: ID_profesor,
        Nombre: Nombre,
        Apellido: Apellido,
        Correo_electronico: Correo_electronico,
        Especialidad: Especialidad,
    }
    //invocaremos el fetch-----------------------------------------------
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
    }catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }
}