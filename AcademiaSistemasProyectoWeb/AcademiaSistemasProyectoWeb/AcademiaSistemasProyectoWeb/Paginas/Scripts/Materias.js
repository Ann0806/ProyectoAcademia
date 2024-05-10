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
    let ID_materia = $("#txtID_materia").val();
    //invocaremos el fetch-----------------------------------------------
    try {
        const Respuesta = await fetch("http://localhost:59268/api/Materias?ID_materia=" + ID_materia, {
            method: "GET",
            mode: "cors",//para que tenga permiso en el origen 
            headers: { "Content-Type": "application/json" },
        });
        // Leer la respuesta y presentarla en el div 
        const Resultado = await Respuesta.json();
        //AL CONSULTAR LA RESPUESTA se muestra en los campos
        $("#txtID_materia").val(Resultado.ID_materia);
        $("#txtNombre").val(Resultado.Nombre_materia);
        $("#txtDescripcion").val(Resultado.Descripcion);

    } catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }


}
async function EjecutarComando(Comando) {
    //para capturar los datos de entrada---------------------------------
    let ID_materia = $("#txtID_materia").val();
    let Nombre_materia = $("#txtNombre").val();
    let Descripcion = $("#txtDescripcion").val();
    //estructura json para enviar la inf al servidor---------------------
    let DatosMateria = {
        ID_materia: ID_materia,
        Nombre_materia: Nombre_materia,
        Descripcion: Descripcion
    }
    //invocaremos el fetch-----------------------------------------------
    try
    {
        const Respuesta = await fetch("http://localhost:59268/api/Materias", {
            method: Comando,
            mode: "cors",//para que tenga permiso en el origen 
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(DatosMateria)//la estructura de json de los datos que recolecte 
        });
        // Leer la respuesta y presentarla en el div 
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    }catch (error) {
        $("#dvMensaje").html(error);//UN MENSAJE EN HTML QUE ME DICE ERROR 
    }
}