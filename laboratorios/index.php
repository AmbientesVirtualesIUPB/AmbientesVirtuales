<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Web Dashboard</title>
    <link rel="stylesheet" href="../CSS/style_laboratorios.css">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>
<body>
    <div class="container">
        <div class="title">Laboratorios</div>
        <div class="search-bar">
            <input type="text" placeholder="Buscar laboratorios...">
        </div>
        <div class="main-content">
            <div class="graph-section">
                <div class="graph">
                    <canvas id="myChart"></canvas> <!-- Añadir un canvas para la gráfica -->
                </div>
            </div>
            <div class="info-section">
                <div class="info-box">
                    <div class="circle"></div>
                    <div class="info-details">
                        <p>Info 1</p>
                        <p>Info 2</p>
                    </div>
                </div>
                <div class="info-box">
                    <div class="highlight"></div>
                    <div class="info-details">
                        <p>Info 3</p>
                        <p>Info 4</p>
                    </div>
                </div>
            </div>
        </div>
        <section class="footer">
            <button onclick="window.location.href='../Index/index.php';">Regresar</button>
        </section>
    </div>
    
    <script>
        var ctx = document.getElementById('myChart').getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'line', // Tipo de gráfico: línea
            data: {
                labels: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio'],
                datasets: [{
                    label: 'Mis datos',
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: [0, 10, 5, 2, 20, 30, 45] // Datos de ejemplo
                }]
            },
            options: {}
        });
    </script>
    <!-- Bootstrap JS and Popper.js -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-kQtW33rZJAHjgefvhyyzcGFEDVi7A5vBPCDNBuPSSZn1w3XtOe9c/vkl0V5HI2z9" crossorigin="anonymous"></script>
</body>
</html>