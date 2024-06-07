<?php

//Variables del servidor
$server = "localhost";
$user = "root";
$password = "";

//Base de datos
$bd = "api";


//Realizamos conexion
$conexion = new mysqli($server,$user,$password,$bd);


//Comprobamos conexion
if ($conexion->connect_error) {
    die("Conexión fallida" . $conexion->connect_error);
}else{
    echo "Conexión exitosa ";
}


//Recepcion de informacion y devolucion de datos en formato Json utilizando cabecera
header("Content-Type: application/json");
//No aseguramos que se realice la devolucion
$metodo = $_SERVER['REQUEST_METHOD'];


//Retornamos el Path de la URL
$path = isset($_SERVER['PATH_INFO'])?$_SERVER['PATH_INFO']:'/';
//Buscamos el id en todo el path que se nos ha enviado
$buscarId = explode('/',$path);
//si hay algo, obtenemos el id, de lo contrario es null
$id = ($path!=='/') ? end($buscarId):null;


//Analizando los metodos
switch ($metodo) {
    //SELECT
    case 'GET':
        consulta($conexion, $id);
        break;
    //INSERT
    case 'POST':
        insertar($conexion);
        break;
    //UPDATE
    case 'PUT':
        actualizar($conexion, $id);
        break;
    //DELETE
    case 'DELETE':
        borrar($conexion, $id);
        break;
    default:
        echo "Metodo no aceptado";
        break;
}



//Funcion para ejecutar el metodo GET
function consulta($conexion,$id){
    //Si se consulta un id especifico trae ese registro, sino trae todos los datos
    $sql = ($id===null) ? "SELECT * FROM usuarios":"SELECT * FROM usuarios WHERE id = $id" ;
    $resultado = $conexion->query($sql);

    //Si existe un resultado lo leemos 1 a 1
    if ($resultado) {
        $datos = array();
        while ($fila = $resultado->fetch_assoc()) {
            $datos[] = $fila;
        }
        //Convertimos la informacion que sacamos de la base de datos en formato json 
        echo json_encode($datos);
    }
}


//Funcion para ejecutar el metodo POST
function insertar($conexion){
    //Decodificamos a partir de un dato recibido
    $dato = json_decode(file_get_contents('php://input'),true);
    $nombre = $dato['nombre'];
    
    $sql = "INSERT INTO usuarios(nombre) VALUES ('$nombre')";
    $resultado = $conexion->query($sql);

    //Si hay un resultado mostramos el dato insertado
    if ($resultado) {
        //Nos devuelve el ultimo id insertado
        $dato['id'] = $conexion->insert_id;
        //Decodificamos
        echo json_encode($dato);
    }else {
        echo json_encode(array('error'=>'Error al crear usuario'));
    }
}


//Funcion para ejecutar el metodo DELETE
function borrar($conexion, $id){

    $sql = "DELETE FROM usuarios WHERE id = $id";
    $resultado = $conexion->query($sql);

    //Si hay un resultado mostramos el dato borrado
    if ($resultado) {
        echo json_encode(array('mensaje'=>'Usuario borrado'));
    }else {
        echo json_encode(array('error'=>'Error al borrar usuario'));
    }

}


//Funcion para ejecutar el metodo UPDATE
function actualizar($conexion, $id){
    //Decodificamos a partir de un dato recibido
    $dato = json_decode(file_get_contents('php://input'),true);
    $nombre = $dato['nombre'];

    $sql = "UPDATE usuarios SET nombre = '$nombre' WHERE id = $id";
    $resultado = $conexion->query($sql);

    //Si hay un resultado mostramos el dato actualizado
    if ($resultado) {
        echo json_encode(array('mensaje'=>'Usuario actualizado'));
    }else {
        echo json_encode(array('error'=>'Error al actualizar usuario'));
    }
}


?>