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
        if (isset($_GET['nombre']) && isset($_GET['pass']) && isset($_GET['jugador']) && isset($_GET['nivel'])) 
        {
            //Variables recibidas
            $usuario        = $_GET['nombre'];
            $clave          = $_GET['pass'];
            $nivelJugador   = $_GET['jugador'];
            $permiso        = $_GET['nivel'];

            //Ejecutamos el query
            $sql = "SELECT * FROM `usuarios` WHERE nombre = '".$usuario."';";
            $resultado = $conexion->query($sql);
            
            //Comprobamos
            if ($resultado->num_rows > 0) {
                echo '{"codigo":403,"mensaje":"Ya existe un usuario con ese nombre","respuesta":"'.$resultado->num_rows.'"}';
            }else {
                //Insertamos en la base de datos
                $sql = "INSERT INTO `usuarios` (`id`, `nombre`, `pass`, `jugador`, `nivel`) VALUES (NULL, '".$usuario."', '".$clave."', '".$nivelJugador."', '".$permiso."');";
                
                //Comprobamos
                if ($conexion->query($sql) === TRUE) {

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

                    echo '{"codigo":201,"mensaje":"Usuario creado exitosamente","respuesta":"'.$texto.'"}';
                }else {
                    echo '{"codigo":401,"mensaje":"Error al crear usuario","respuesta":""}';
                }
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