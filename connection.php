<?php

function connection(){

    //creamos variables para la conexion con la base de satos
    $host = "localhost";
    $user = "root";
    $password = "";

    $bd = "api_web";

    //Generamos la conexion
    $connect = mysqli_connect($host,$user,$password );

    //Seleccionamos la base de datos y conexion
    mysqli_select_db($connect,$bd);

    return $connect;  
}

?>