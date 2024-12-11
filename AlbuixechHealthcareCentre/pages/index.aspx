<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="AlbuixechHealthcareCentre.Index" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Albuixech Healthcare Centre</title>
    <link href="../styles/styles.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <header class="site-header">
        <div class="container">
            <a href="Index.aspx" class="logo">Albuixech Healthcare Centre</a>
            <a href="Login.aspx" class="login-button">Login</a>
        </div>
    </header>
    <main>
        <section class="hero">
            <div class="hero-content">
                <h1>Albuixech Healthcare Centre</h1>
                <p>Your Health, Our Priority</p>
                <a href="#info" class="scroll-arrow">&#8595;</a>
            </div>
        </section>
        <section id="info" class="info-section">
            <div class="container">
                <h2>About Us</h2>
                <p>Welcome to Albuixech Healthcare Centre, your trusted medical facility in the heart of Albuixech, near Valencia.</p>
                <img src="../img/healthcare.jpg" alt="Healthcare Centre">
            </div>
        </section>
    </main>
    <footer class="site-footer">
        <div class="container">
            <p>&copy; 2024 Albuixech Healthcare Centre. All rights reserved.</p>
            <p><a href="#">Privacy Policy</a> | <a href="#">Contact Us</a></p>
        </div>
    </footer>
</body>
</html>
