<?php
//Incluimos el archivo connection
include('connection.php');

$conect = connection();

//Obtenemos los datos en variables con le metodo POST
$id = null;
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

//Validamos que las casillas esten llenas
if ($genero == "") {
    echo '<script language="javascript">alert("Falta seleccionar Género");window.location.href="formulario.php"</script>';
}elseif ($cuerpo == "") {
    echo '<script language="javascript">alert("Falta dato Cuerpo");window.location.href="formulario.php"</script>';
}elseif ($cabeza == null) {
    echo '<script language="javascript">alert("Falta dato Cabeza");window.location.href="formulario.php"</script>';
}elseif ($ceja == null) {
    echo '<script language="javascript">alert("Falta dato Cejas");window.location.href="formulario.php"</script>';
}elseif ($cabello == "") {
    echo '<script language="javascript">alert("Falta dato Cabellos");window.location.href="formulario.php"</script>';
}elseif ($reloj == null) {
    echo '<script language="javascript">alert("Falta dato Relojes");window.location.href="formulario.php"</script>';
}elseif ($sombrero == "") {
    echo '<script language="javascript">alert("Falta dato Sombrero");window.location.href="formulario.php"</script>';
}elseif ($zapato == "") {
    echo '<script language="javascript">alert("Falta dato Zapatos");window.location.href="formulario.php"</script>';
}elseif ($ojos == "") {
    echo '<script language="javascript">alert("Falta dato Ojos");window.location.href="formulario.php"</script>';
}elseif ($maleta == "") {
    echo '<script language="javascript">alert("Falta dato Maleta");window.location.href="formulario.php"</script>';
}else 
{
    //Si todo se cumple Insertamos los valores obtenidos en la tabla
    $sql = "INSERT INTO personaje VALUES ('$id','$genero','$cuerpo','$cabeza','$ceja','$cabello','$reloj','$sombrero','$zapato','$ojos','$maleta')";
    //Ejecutamos el Query
    $query = mysqli_query($conect , $sql);

    //Header, una vez se inserten los datos, redirecciona al usuario al formulario o a recargar archivo  
    if ($query) {
    //Header("Location: formulario.php");
    //echo '<script language="javascript">alert("Personalización Exitosa");window.location.href="formulario.php"</script>';
}

}
?>