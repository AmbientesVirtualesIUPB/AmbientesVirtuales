<?php
//Incluimos el archivo connection
include('connection.php');

$conect = connection();

$id=$_GET['id'];

$sql = "SELECT * FROM personaje WHERE id=$id";
//Ejecutamos el Query para la actualizacion de datos
$query = mysqli_query($conect , $sql);
$row = mysqli_fetch_array($query)

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="CSS/style.css">
    <title>Editar Personaje</title>
</head>
<body>
    <div class="users-form">
        <form action="editar_personaje.php" method ="POST">
            <h1> Editar Personaje </h1>
            <!-- Reasignamos todos los datos para que solo se actualice lo que se desea modificar --> 
            <input type="hidden" name="id" value="<?= $row['id'] ?>">
            <label for="opciones">Género</label>
                <select id="opciones" name="genero" multiple>
                    <option value="Masculino">Masculino</option>
                    <option value="Femenino">Femenino</option>
                </select>
            <input type="text" name="cuerpo" placeholder="Cuerpo"value="<?= $row['cuerpo'] ?>" >
            <input type="text" name="cabeza" placeholder="Cabeza"value="<?= $row['cabeza'] ?>">
            <input type="text" name="cejas" placeholder="Cejas"value="<?= $row['cejas'] ?>">
            <input type="text" name="cabello" placeholder="Cabellos"value="<?= $row['cabello'] ?>">
            <input type="text" name="reloj" placeholder="Relojes"value="<?= $row['reloj'] ?>">
            <input type="text" name="sombrero" placeholder="Sombrero"value="<?= $row['sombrero'] ?>">
            <input type="text" name="zapatos" placeholder="Zapatos"value="<?= $row['zapatos'] ?>">
            <input type="text" name="ojos" placeholder="Ojos"value="<?= $row['ojos'] ?>">
            <input type="text" name="maleta" placeholder="Maleta"value="<?= $row['maleta'] ?>">

            <input type="submit" value="Actualizar Personaje" class="users-table--edit">


        </form>
    </div>
    
</body>
</html>