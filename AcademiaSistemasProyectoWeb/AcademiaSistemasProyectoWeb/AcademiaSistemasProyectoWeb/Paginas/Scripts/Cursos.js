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
    let CursoID = $("#txtCursoID").val();
    //invocaremos el fetch-----------------------------------------------
    try {
        const Respuesta = await fetch("http://localhost:59268/api/Cursos?CursoID="+CursoID, {
            method: "GET",
            mode: "cors",//para que tenga permiso en el origen 
            headers: { "Content-Type": "application/json" },
        });
        // Leer la respuesta y presentarla en el div 
        const Resultado = await Respuesta.json();
        //AL CONSULTAR LA RESPUESTA se muestra en los campos
        $("#txtCursoID").val(Resultado.CursoID);
        $("#txtNombre").val(Resultado.Nombre);
        $("#txtDescripcion").val(Resultado.Descripcion);
        $("#txtDuracion").val(Resultado.Duracion);
        $("#txtCosto").val(Resultado.Costo);
        $("#txtProfesor_id").val(Resultado.Profesor_id);
        $("#cboEstado").val(Resultado.Estado);

    } catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }


}
async function EjecutarComando(Comando) {
    //para capturar los datos de entrada---------------------------------
    let CursoID = $("#txtCursoID").val();
    let Nombre = $("#txtNombre").val();
    let Descripcion = $("#txtDescripcion").val();
    let Duracion = $("#txtDuracion").val();
    let Costo = $("#txtCosto").val();
    let Profesor_id = $("#txtProfesor_id").val();
    let Estado = $("#cboEstado").val();
    //estructura json para enviar la inf al servidor---------------------
    let DatosCursos = {
        CursoID: CursoID,
        Nombre: Nombre,
        Descripcion: Descripcion,
        Duracion: Duracion,
        Costo: Costo,
        Profesor_id: Profesor_id,
        Estado: Estado
    }
    //invocaremos el fetch-----------------------------------------------
    try
    {
        const Respuesta = await fetch("http://localhost:59268/api/Cursos", {
            method: Comando,
            mode: "cors",//para que tenga permiso en el origen 
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(DatosCursos)//la estructura de json de los datos que recolecte 
        });
        // Leer la respuesta y presentarla en el div 
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    }catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }
}