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
        if (isset($_GET['nombre']) && isset($_GET['pass']) && isset($_GET['pass2']) && isset($_GET['jugador']) && isset($_GET['nivel'])) 
        {
            //Variables recibidas
            $usuario        = $_GET['nombre'];
            $clave          = $_GET['pass'];
            $clave2          = $_GET['pass2'];
            $nivelJugador   = $_GET['jugador'];
            $permiso        = $_GET['nivel'];

            //Ejecutamos el query
            $sql = "SELECT * FROM `usuarios` WHERE nombre = '".$usuario."' and pass = '".$clave."';";
            $resultado = $conexion->query($sql);
            
            //Comprobamos
            if ($resultado->num_rows > 0) {
                //Actualizamos la base de datos
                $sql = "UPDATE `usuarios` SET `pass` = '".$clave2."', `jugador` = '".$nivelJugador."', `nivel` = '".$permiso."' WHERE nombre = '".$usuario."';";
                //Ejecutamos query
                $conexion->query($sql);

                //Ejecutamos el query para traer los datos del usuario
                $sql = "SELECT * FROM `usuarios` WHERE nombre = '".$usuario."';";
                $resultado = $conexion->query($sql);
                $texto = '';
                //Leemos los resultados obtenidos
                while ($row = $resultado->fetch_assoc()) {
                    $texto = 
                        "{#id#:".$row['id']." ,
                         #nombre#:#".$row['nombre']."#,
                         #pass#:#".$row['pass']."#,
                         #jugador#:".$row['jugador'].",
                         #nivel#:".$row['nivel']."}";
                }
                echo '{"codigo":206,"mensaje":"Usuario actualizado con exito","respuesta":"'.$texto.'"}';

            }else {
                echo '{"codigo":204,"mensaje":"Usuario o password son incorrectos","respuesta":""}';
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