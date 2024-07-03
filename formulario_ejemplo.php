<?php
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $datos = [];
    for ($i = 1; $i <= 9; $i++) {
        if (isset($_POST["pos$i"])) {
            $datos["pos$i"] = $_POST["pos$i"];
        } else {
            $datos["pos$i"] = null;
        }
    }
    // Devolver los datos en formato JSON
    echo json_encode($datos);
    exit; // Asegúrate de que el script termine aquí para que no incluya el HTML
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script>
        function recibirDatos() {
            var xhr = new XMLHttpRequest();
            xhr.open('POST', window.location.href, true);
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

            xhr.onreadystatechange = function() {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    try {
                        console.log("Respuesta recibida: ", xhr.responseText);
                        var datos = JSON.parse(xhr.responseText);
                        for (var i = 1; i <= 9; i++) {
                            document.querySelector(`input[name="pos${i}"]`).value = datos[`pos${i}`];
                        }
                    } catch (e) {
                        console.error("Error al procesar los datos:", e);
                    }
                }
            };

            xhr.send(''); // Enviar solicitud en blanco para obtener la respuesta
        }

        window.onload = recibirDatos;
    </script>
</head>
<body>
    <form action="formulario.php" method="POST">
        <input type="text" name="pos1">
        <input type="text" name="pos2">
        <input type="text" name="pos3">
        <input type="text" name="pos4">
        <input type="text" name="pos5">
        <input type="text" name="pos6">
        <input type="text" name="pos7">
        <input type="text" name="pos8">
        <input type="text" name="pos9">
        <input type="submit" value="Enviar">
    </form>

    <!-- Área para imprimir los datos -->
    <div id="datos-recibidos">
        <?php
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            for ($i = 1; $i <= 9; $i++) {
                if (isset($_POST["pos$i"])) {
                    echo "<p>Posición $i: " . htmlspecialchars($_POST["pos$i"]) . "</p>";
                } else {
                    echo "<p>Posición $i: no recibida</p>";
                }
            }
        }
        ?>
    </div>
</body>
</html>