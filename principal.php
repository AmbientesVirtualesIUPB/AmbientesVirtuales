<?php
include('header.html');
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ambiente Virtual</title>
    <link rel="stylesheet" href="CSS/style5.css">
</head>
<body>
    <section class="hero">
        <div class="hero-content">
            <h1>Tu Perfil</h1>
            <p class ="parrafos">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam fermentum diam quis porta lobortis.</p>
        </div>
    </section>

    <section class="services">
        <div class="service">
            <img src="imagenes/personalizacion.png">
            <h2>Personalización</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            <a href="#">Read more...</a>
        </div>
        <div class="service">
            <img src="imagenes/tiempo.png">
            <h2>Tiempo De Conexión</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            <a href="#">Read more...</a>
        </div>
        <div class="service">
            <img src="imagenes/conexiones.png">
            <h2>Conexiones</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            <a href="#">Read more...</a>
        </div>
        <div class="service">
            <img src="imagenes/puntaje.png">
            <h2>Puntaje</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            <a href="#">Read more...</a>
        </div>
    </section>

    <section class="gallery">
        <div class="gallery-item">
            <img src="imagenes/cis.png">
            <div class="gallery-info">
                <h3>Laboratorio CIS</h3>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                <a href="#">Read more...</a>
            </div>
        </div>
        <div class="gallery-item">
            <img src="imagenes/grupos.png">
            <div class="gallery-info">
                <h3>Grupos</h3>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                <a href="#">Read more...</a>
            </div>
        </div>
        <div class="gallery-item">
            <img src="imagenes/laboratorios.png">
            <div class="gallery-info">
                <h3>Laboratorios</h3>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                <a href="#">Read more...</a>
            </div>
        </div>
    </section>
    <script> //JavaScript
        // Espera a que el documento esté completamente cargado
        document.addEventListener('DOMContentLoaded', function() {
            // Selecciona todas las imágenes dentro de los elementos con la clase 'gallery-item'
            var images = document.querySelectorAll('.gallery-item img');

            // Itera sobre cada imagen seleccionada
            images.forEach(function(image) {
                // Añade un evento para cuando el cursor entra en la imagen
                image.addEventListener('mouseenter', function() {
                    // Añade la clase 'zoomed' a la imagen para aplicar el efecto de zoom
                    this.classList.add('zoomed');
                });

                // Añade un evento para cuando el cursor sale de la imagen
                image.addEventListener('mouseleave', function() {
                    // Remueve la clase 'zoomed' de la imagen para quitar el efecto de zoom
                    this.classList.remove('zoomed');        
                });
            });
        });

        document.addEventListener('DOMContentLoaded', function() {
        // Selecciona todos los elementos .service
        var services = document.querySelectorAll('.service');

        // Añade eventos para cada elemento .service
        services.forEach(function(service) {
            // Añade la clase 'zoomed' al pasar el ratón
            service.addEventListener('mouseenter', function() {
                this.classList.add('zoomed');
            });

            // Quita la clase 'zoomed' al salir el ratón
            service.addEventListener('mouseleave', function() {
                this.classList.remove('zoomed');
            });
        });
    });

    document.addEventListener('DOMContentLoaded', function() {
        // Selecciona el h1 dentro de .hero-content
        var heroTitle = document.querySelector('.hero-content h1');

        // Añade la clase 'zoomed' al pasar el ratón
        heroTitle.addEventListener('mouseenter', function() {
            this.classList.add('zoomed');
        });

        // Quita la clase 'zoomed' al salir el ratón
        heroTitle.addEventListener('mouseleave', function() {
            this.classList.remove('zoomed');
        });
    });
    </script>

</body>
</html>


<?php
include('footer.html');
?>