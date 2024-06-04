//Se define una variable de tipo datable, púlica para la página
var oTabla = $("#tblUsuarios").DataTable();
jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html");
    //Activar el evento de click en los botones que vamos a programar
    //Con jquery, los objetos se identifican con "$(#" al inicio del nombre del objeto
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
    //Llenar el combo de tipo producto
    LlenarComboTipoProductos();
    //Llena la información de la tabla
    LlenarTabla();
});
function LlenarComboTipoProductos() {
    LlenarComboXServicios("http://localhost:52167/api/Perfiles/ListarPerfiles", "#cboPerfil");
}
function 