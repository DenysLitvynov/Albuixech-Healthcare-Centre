﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreatePatient.aspx.cs" Inherits="AlbuixechHealthcareCentre.pages.CreatePatient" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Create Patient - Albuixech Healthcare Centre</title>
    <link href="/styles/styles.css" rel="stylesheet">
    <link href="/styles/doctor.css" rel="stylesheet">
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
                <li><a href="Doctor.aspx">Back to Dashboard</a></li>
            </ul>
        </nav>
    </header>

    <!-- Main Content -->
    <main class="create-patient-page">
        <div class="container">
            <h1>Create New Patient</h1>

            <form id="CreatePatientForm" runat="server">
                <!-- Sección: Información Básica -->
                <div class="form-section">
                    <h3>Basic Information</h3>
                    <div class="form-group">
                        <label for="Name">Name:</label>
                        <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="DateOfBirth">Date of Birth:</label>
                        <asp:TextBox ID="DateOfBirthTextBox" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <!-- Sección: Dirección y Contacto -->
                <div class="form-section">
                    <h3>Address and Contact</h3>
                    <div class="form-group">
                        <label for="Address">Address:</label>
                        <asp:TextBox ID="AddressTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Mobile">Mobile:</label>
                        <asp:TextBox ID="MobileTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <!-- Sección: Seguridad -->
                <div class="form-section">
                    <h3>Security</h3>
                    <div class="form-group">
                        <label for="PIN">PIN:</label>
                        <asp:TextBox ID="PINTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <!-- Sección: Usuario -->
                <div class="form-section">
                    <h3>User Information</h3>
                    <div class="form-group">
                        <label for="Username">Username:</label>
                        <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Password">Password:</label>
                        <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Role">Role:</label>
                        <asp:DropDownList ID="RoleDropDown" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Patient" Value="Patient"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Botón de Envío -->
                <div class="form-actions">
                    <asp:Button ID="CreatePatientButton" runat="server" Text="Create Patient" CssClass="btn" OnClick="CreatePatientButton_Click" />
                </div>
            </form>
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