<?php
//Incluimos el archivo connection
include('connection.php');

$conect = connection();

//Obtenemos los datos en variables con le metodo POST
$id = $_POST["id"];
$genero = $_POST["genero"];
$cuerpo = $_POST["cuerpo"];
$cabeza = $_POST["cabeza"];
$ceja = $_POST["cejas"];
$cabello = $_POST["cabello"];
$reloj = $_POST["reloj"];
$sombrero = $_POST["sombrero"];
$zapato = $_POST["zapatos"];
$ojos = $_POST["ojos"];
$maleta = $_POST["maleta"];

//Si todo se cumple Insertamos los valores obtenidos en la tabla
$sql = "UPDATE personaje SET genero='$genero', cuerpo='$cuerpo', cabeza='$cabeza', cejas='$ceja', cabello='$cabello ', reloj='$reloj', sombrero='$sombrero', zapatos='$zapato', ojos='$ojos', maleta='$maleta' WHERE id='$id' ";
//Ejecutamos el Query
$query = mysqli_query($conect , $sql);

if ($query) {
    //Header("Location: index.php");
    echo '<script language="javascript">alert("Personaje Actualizado Con Exito");window.location.href="index.php"</script>';
}

?>