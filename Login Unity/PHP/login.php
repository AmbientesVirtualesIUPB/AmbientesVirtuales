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
        if (isset($_POST['nombre']) && isset($_POST['pass'])) 
        {
            //Variables recibidas
            $usuario = $_POST['nombre'];
            $clave   = $_POST['pass'];

            //Ejecutamos el query
            $sql = "SELECT * FROM `usuarios` WHERE nombre = '".$usuario."' and pass = '".$clave."';";
            $resultado = $conexion->query($sql);
            
            //Comprobamos
            if ($resultado->num_rows > 0) {
                
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
                echo '{"codigo":205,"mensaje":"Inicio de sesion correcto","respuesta":"'.$texto.'"}';

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