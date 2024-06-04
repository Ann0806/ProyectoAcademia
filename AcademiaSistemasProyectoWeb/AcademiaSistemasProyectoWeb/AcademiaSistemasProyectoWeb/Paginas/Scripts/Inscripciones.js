jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html");
    $("#txtID_inscripcion").val("0");
    $("#btnBuscar").on("click", function () {
        Consultar();
    });
    
    LlenarComboCurso();
    LlenarTablaInscripcion();
});


async function LlenarComboCurso() {
    let rpta = await LlenarComboXServicios("http://localhost:59268/api/Curso/ListarCurso", "#cboCurso");
    LlenarComboProfesor();
    PresentarValorCurso();
}
async function LlenarComboProfesor() {
    let ID_curso = $("#cboCurso").val();
    let rpta = await LlenarComboXServicios("http://localhost:59268/api/Profesores/LlenarCombo?ID_curso=" + ID_curso, "#cboProfesor");
    
}
async function LlenarTablaInscripcion() {
    LlenarTablaXServicios("http://localhost:59268/api/Inscripciones/ListarInscripcion", "#tblInscripcion");
}

async function Limpiarcampos() {
    document.getElementById('txtID_inscripcion').value = '';
    document.getElementById('txtDocumento').value = '';
    document.getElementById('txtNombreEstudiante').value = '';
    document.getElementById('cboCurso').selectedIndex = 0;
    document.getElementById('cboProfesor').selectedIndex = 0;
    document.getElementById('txtDuracion').value = '';
    document.getElementById('txtCosto').value = '';
    document.getElementById('txtFecha_inscripcion').value = '';
}

async function Consultar() {
    let Documento_estudiante = $("#txtDocumento").val();
    try {
        const Respuesta = await fetch("http://localhost:59268/api/Estudiante?Documento=" + Documento_estudiante,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Resultado = await Respuesta.json();
        $("#txtNombreEstudiante").val(Resultado.Nombre + " " + Resultado.PrimerApellido + " " + Resultado.SegundoApellido);
    }
    catch (_error) {
        $("#dvMensaje").html(_error);
    }
}

async function PresentarValorCurso() {
    let ID_curso = $("#cboCurso").val();
    try {
        const Respuesta = await fetch("http://localhost:59268/api/Curso?ID_curso=" + ID_curso,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Resultado = await Respuesta.json();
        $("#txtDuracion").val(Resultado.Duracion);
        $("#txtCosto").val(Resultado.Costo);
    }
    catch (_error) {
        $("#dvMensaje").html(_error);
    }
}


async function GrabarInscripciones() {

    $("#txtID_inscripcion").val("0");
    var table = new DataTable('#tblInscripcion');
    table.clear().draw();
    let ID_inscripcion = $("#txtID_inscripcion").val();
    let Documento_estudiante = $("#txtDocumento").val();
    let ID_curso = $("#cboCurso").val(); 
    let Documento_profesor = $("#cboProfesor").val();
    let Duracion = $("#txtDuracion").val();
    let Costo = $("#txtCosto").val();
    let Fecha_inscripcion = $("#txtFecha_inscripcion").val();

    let DatosInscripcion = {
        ID_inscripcion: ID_inscripcion,
        Documento_estudiante: Documento_estudiante,
        ID_curso: ID_curso,
        Fecha_inscripcion: Fecha_inscripcion
     
        }
    if (ID_inscripcion == 0) {
        //Se graba el encabezado
        try {
            const Respuesta = await fetch("http://localhost:59268/api/Inscripciones/GrabarInscripciones",
                {
                    method: "POST",
                    mode: "cors",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(DatosInscripcion)
                });
            //Leer la respuesta del servicio
            const Resultado = await Respuesta.json();
            ID_inscripcion = Resultado;
            $("#txtID_inscripcion").val(ID_inscripcion);
        }
        catch (_error) {
            //Presentar a respuesta del error en el html
            $("#dvMensaje").html(_error);
        }
    }
    
    let DatosDetalle = {
        ID_inscripcion: ID_inscripcion,
        ID_curso: ID_curso,
        Documento_estudiante: Documento_estudiante,
        Documento_profesor: Documento_profesor,
        Costo: Costo,
        Duracion: Duracion
    }
    try {
        const Respuesta = await fetch("http://localhost:59268/api/Inscripciones/GrabarDetalle",
            {
                method: "POST",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(DatosDetalle)
            });
        //Leer la respuesta del servicio
        const Resultado = await Respuesta.json();
        LlenarTablaInscripcion();
    }
    catch (_error) {
        //Presentar a respuesta del error en el html
        $("#dvMensaje").html(_error);
    }
    
}
async function Eliminar(idIns) {


    try {
        const Respuesta = await fetch("http://localhost:59268/api/Inscripciones/EliminarInscripcion?ID_inscripcion=" + idIns,
            {
                method: "DELETE",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        //Leer la respuesta del servicio
        const Resultado = await Respuesta.json();
        LlenarTablaInscripcion();
    }
    catch (_error) {
        //Presentar a respuesta del error en el html
        $("#dvMensaje").html(_error);
    }
}


