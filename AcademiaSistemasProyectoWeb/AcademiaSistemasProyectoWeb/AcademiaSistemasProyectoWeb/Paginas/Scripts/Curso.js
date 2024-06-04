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

    LlenarTablaCurso();
});

async function LlenarTablaCurso() {
    LlenarTablaXServicios("http://localhost:59268/api/Curso/Curso", "#tblCurso");
}

async function Consultar() {
    let ID_curso = $("#txtID_curso").val();
    //invocaremos el fetch-----------------------------------------------
    try {
        const Respuesta = await fetch("http://localhost:59268/api/Curso?ID_curso=" + ID_curso, {
            method: "GET",
            mode: "cors",//para que tenga permiso en el origen 
            headers: { "Content-Type": "application/json" },
        });
        // Leer la respuesta y presentarla en el div 
        const Resultado = await Respuesta.json();
        //AL CONSULTAR LA RESPUESTA se muestra en los campos
        $("#txtID_curso").val(Resultado.ID_curso);
        $("#txtNombre").val(Resultado.Nombre_curso);
        $("#txtDescripcion").val(Resultado.Descripcion);
        $("#txtDuracion").val(Resultado.Duracion);
        $("#txtCosto").val(Resultado.Costo);

    } catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }


}



async function EjecutarComando(Comando) {
    //para capturar los datos de entrada---------------------------------
    let ID_curso = $("#txtID_curso").val();
    let Nombre_curso = $("#txtNombre").val();
    let Descripcion = $("#txtDescripcion").val();
    let Duracion = $("#txtDuracion").val();
    let Costo = $("#txtCosto").val();
    //estructura json para enviar la inf al servidor---------------------
    let DatosCurso = {
        ID_curso: ID_curso,
        Nombre_curso: Nombre_curso,
        Descripcion: Descripcion,
        Duracion: Duracion,
        Costo: Costo,
    }
    //invocaremos el fetch-----------------------------------------------
    try
    {
        const Respuesta = await fetch("http://localhost:59268/api/Curso", {
            method: Comando,
            mode: "cors",//para que tenga permiso en el origen 
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(DatosCurso)//la estructura de json de los datos que recolecte 
        });
        // Leer la respuesta y presentarla en el div 
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
        LlenarTablaCurso();
    }catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }
}