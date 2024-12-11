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
    <!-- Header -->
    <header class="site-header">
        <div class="container">
            <a href="Index.aspx" class="logo">Albuixech Healthcare Centre</a>
            <nav>
                <a href="Login.aspx" class="login-button">Logout</a>
            </nav>
        </div>
    </header>

    <!-- Main Content -->
    <main class="patient-page">
        <div class="container">
            <h1>Personal Information</h1>
            <div class="personal-info">
                <p><strong>Name:</strong> John Doe</p>
                <p><strong>Date of Birth:</strong> 01/01/1980</p>
                <p><strong>Address:</strong> 123 Main St, Albuixech</p>
                <p><strong>Phone:</strong> +34 123 456 789</p>
                <img src="/img/patient-placeholder.jpg" alt="Patient Photo" class="patient-photo">
            </div>

            <h2>Medical Records</h2>
            <div class="medical-records">
                <ul>
                    <li><strong>01/12/2024:</strong> General Checkup - Healthy</li>
                    <li><strong>15/11/2024:</strong> Flu Symptoms - Prescribed Medication</li>
                    <li><strong>01/10/2024:</strong> Routine Blood Test - Normal</li>
                </ul>
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
