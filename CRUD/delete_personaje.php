<?php
//Incluimos el archivo connection
include('connection.php');

$conect = connection();

$id=$_GET['id'];

$sql = "DELETE FROM personaje WHERE id='$id'";
//Ejecutamos el Query
$query = mysqli_query($conect , $sql);

if ($query) {
    //Header("Location: index.php");
    //echo '<script language="javascript">alert("Personaje Eliminado Con Exito");window.location.href="index.php"</script>';
}

?>