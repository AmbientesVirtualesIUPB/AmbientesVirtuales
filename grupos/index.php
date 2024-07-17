<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Grupos</title>
    <link rel="stylesheet" href="../CSS/style_gr.css">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>
<body>
    <div class="container">
        <section class="intro">
            <h1>Grupos</h1>
        </section>
        <header class="header">
            <div class="profile">
                <img src="../imagenes/profile.png" alt="User Profile">
                <p>Nombre de Usuario</p>
            </div>
        </header>
        <aside class="sidebar">
            <div class="sidebar-item">Opción 1</div>
            <div class="sidebar-item">Opción 2</div>
            <div class="sidebar-item">Opción 3</div>
            <div class="sidebar-item">Opción 4</div>
        </aside>
        <main class="main-content">
            <div class="info-card">
                <h2>Nombre del grupo</h2>
                <p>Información relevante.</p>
            </div>
            <div class="chart-card">
                <canvas id="myChart" width="400" height="400"></canvas>
            </div>
        </main>
        <section class="footer">
            <button onclick="window.location.href='../Index/index.php';">Regresar</button>
        </section>
    </div>
    <script>
        var ctx = document.getElementById('myChart').getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: ['Rojo', 'Azul', 'Amarillo'],
                datasets: [{
                    data: [10, 20, 30],
                    backgroundColor: ['#ff6384', '#36a2eb', '#ffce56']
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false
            }
        });
    </script>
</body>
</html>