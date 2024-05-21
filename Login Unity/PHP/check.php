<?php
include 'header.php';


try {
    //Realizamos conexion
    $conexion = mysqli_connect($server,$user,$password,$bd);
    
    //Comprobamos conexion
    if (!$conexion) {
        echo '{"codigo":400,"mensaje":"Conexión Fallida","respuesta":""}';
    }else{
        
        echo '{"codigo":200,"mensaje":"Conexión Exitosa","respuesta":""}';
    }

} catch (Exception $e) {
    echo '{"codigo":400,"mensaje":"Conexión Fallida","respuesta":""}';
}


include 'footer.php';

?>  