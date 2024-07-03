<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $data = $_POST["data"]; // Obtén los datos enviados desde Unity

    // Decodifica el JSON
    $decoded = json_decode($data, true);
    
    if (json_last_error() !== JSON_ERROR_NONE) {
        echo "Error al decodificar JSON: " . json_last_error_msg();
        exit;
    }

    // Verifica el contenido del array
    if (!is_array($decoded) || !isset($decoded['data']) || !is_array($decoded['data'])) {
        echo "Los datos no son un array válido";
        exit;
    }

    $array = $decoded['data'];

    // Muestra los datos en un formulario HTML con estilo
    echo "<!DOCTYPE html>";
    echo "<html lang='en'>";
    echo "<head>";
    echo "<meta charset='UTF-8'>";
    echo "<meta name='viewport' content='width=device-width, initial-scale=1.0'>";
    echo "<title>Formulario de Datos</title>";
    echo "<style>";
    echo "body { font-family: Arial, sans-serif; background-color: #f0f0f0; margin: 0; padding: 0; display: flex; justify-content: center; align-items: center; height: 100vh; }";
    echo ".container { background-color: #fff; padding: 20px; border-radius: 5px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); }";
    echo "form { display: flex; flex-direction: column; }";
    echo "label { margin: 10px 0 5px; }";
    echo "input[type='text'] { padding: 10px; margin-bottom: 15px; border: 1px solid #ccc; border-radius: 3px; }";
    echo "input[type='submit'] { padding: 10px; background-color: #28a745; border: none; border-radius: 3px; color: #fff; cursor: pointer; }";
    echo "input[type='submit']:hover { background-color: #218838; }";
    echo "</style>";
    echo "</head>";
    echo "<body>";
    echo "<div class='container'>";
    echo "<form>";
    for ($i = 0; $i < count($array); $i++) {
        echo "<label for='pos$i'>Posición $i:</label>";
        echo "<input type='text' id='pos$i' name='pos$i' value='" . htmlspecialchars($array[$i]) . "'>";
    }
    echo "<input type='submit' value='Enviar'>";
    echo "</form>";
    echo "</div>";
    echo "</body>";
    echo "</html>";
} else {
    echo "Método no permitido";
}
?>