<?php
include 'header.php';


try {
    //Realizamos conexion
    $conexion = mysqli_connect($server,$user,$password,$bd);
    
    //Comprobamos conexion
    if (!$conexion) {
        echo '{"codigo":400,"mensaje":"Conexión Fallida","respuesta":""}';
    }else{

        //Si las varibles existen ejecutamos
        if (isset($_GET['nombre'])) 
        {
            //Variable recibida
            $usuario = $_GET['nombre'];

            //Ejecutamos el query
            $sql = "SELECT * FROM `usuarios` WHERE nombre = '".$usuario."';";
            $resultado = $conexion->query($sql);
            
            //Comprobamos
            if ($resultado->num_rows > 0) {
                echo '{"codigo":202,"mensaje":"Usuario ya existe","respuesta":"'.$resultado->num_rows.'"}';
            }else {
                echo '{"codigo":203,"mensaje":"Usuario no existe","respuesta":"0"}';
            }
        //Si faltan datos por llenar    
        }else {
            echo '{"codigo":402,"mensaje":"Faltan datos para ejecutar la consulta","respuesta":""}';
        }
        
    }

} catch (Exception $e) {
    echo '{"codigo":400,"mensaje":"Conexión Fallida","respuesta":""}';
}


include 'footer.php';
?>  