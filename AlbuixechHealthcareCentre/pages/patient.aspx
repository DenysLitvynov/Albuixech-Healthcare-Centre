<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Patient.aspx.cs" Inherits="AlbuixechHealthcareCentre.pages.Patient" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Patient Page - Albuixech Healthcare Centre</title>
    <link href="/styles/styles.css" rel="stylesheet">
    <link href="/styles/patient.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet">
</head>
<body>
    <header>
        <div class="logo">
            <img src="../img/AlbuixechLogo.png" alt="Logo">
        </div>
        <nav>
            <ul>
                <li><a href="/pages/index.aspx">Home Page</a></li>
                <li><a href="#">Log In</a></li>
            </ul>
        </nav>
    </header>

    <!-- Main Content -->
    <main class="patient-page">
        <div class="container">
            <div class="info-columns">
                <div class="personal-info" style="margin-top: 2rem; margin-right: 2rem;">
                    <h1>Personal Information</h1>
                    <p><strong>Name:</strong> John Doe</p>
                    <p><strong>Date of Birth:</strong> 01/01/1980</p>
                    <p><strong>Address:</strong> 123 Main St, Albuixech</p>
                    <p><strong>Phone:</strong> +34 123 456 789</p>
                    <img src="/img/patient-placeholder.jpg" alt="Patient Photo" class="patient-photo">
                </div>
                <div class="medical-records" style="margin-top: 2rem;">
                    <h2>Medical Records</h2>
                    <ul>
                        <li><strong>01/12/2024:</strong> General Checkup - Healthy</li>
                        <li><strong>15/11/2024:</strong> Flu Symptoms - Prescribed Medication</li>
                        <li><strong>01/10/2024:</strong> Routine Blood Test - Normal</li>
                    </ul>
                </div>
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
