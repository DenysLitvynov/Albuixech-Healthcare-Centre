<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Doctor.aspx.cs" Inherits="AlbuixechHealthcareCentre.pages.Doctor" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Doctor Page - Albuixech Healthcare Centre</title>
    <link href="/styles/styles.css" rel="stylesheet">
    <link href="/styles/doctor.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet">
</head>
<body>
    <!-- Header -->
    <header class="site-header">
        <div class="container">
            <a href="Index.aspx" class="logo">
                <img src="/img/AlbuixechLogo.png" alt="Logo">
            </a>
            <a href="Login.aspx" class="login-button">
                <img src="/img/InicioIcono.png" alt="Logout">
            </a>
        </div>
    </header>

    <!-- Main Content -->
    <main class="doctor-page">
        <div class="container">
            <h1>Doctor Dashboard</h1>

            <div class="info-columns">
                <section class="patient-management">
                    <h2>Manage Patients</h2>
                    <button>Create New Patient</button>
                    <button>Update Patient</button>
                    <button>Delete Patient</button>
                </section>

                <section class="record-management">
                    <h2>Manage Medical Records</h2>
                    <button>Create Record</button>
                    <button>Update Record</button>
                    <button>Delete Record</button>
                </section>

                <section class="search">
                    <h2>Search Patient</h2>
                    <form>
                        <input type="text" placeholder="Enter Patient Name" required>
                        <button type="submit">Search</button>
                    </form>
                </section>
            </div>
            <!-- Log Out Button -->
            <div class="logout-button-container">
                <a href="Login.aspx" class="logout-button">Log Out</a>
            </div>
        </div>
    </main>

    <!-- Footer -->
    <footer class="site-footer">
        <div class="container">
            <p>&copy; 2024 Albuixech Healthcare Centre. All rights reserved.</p>
            <p><a href="#">Privacy Policy</a> | <a href="#">Contact Us</a></p>
        </div>
    </footer>
</body>
</html>
