<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientPage.aspx.cs" Inherits="AlbuixechHealthcareCentre.pages.PatientPage" %>
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
                <li><a href="Login.aspx">Log Out</a></li>
            </ul>
        </nav>
    </header>

    <!-- Main Content -->
    <main class="patient-page">
        <div class="container">
            <h1>Welcome, <asp:Label ID="PatientNameLabel" runat="server" Text="Patient Name"></asp:Label></h1>

            <!-- Formulario de servidor -->
            <form id="PatientPageForm" runat="server">
                <!-- Personal Information -->
                <section class="personal-info">
                    <h2>Personal Information</h2>
                    <p><strong>Date of Birth:</strong> <asp:Label ID="DateOfBirthLabel" runat="server"></asp:Label></p>
                    <p><strong>Address:</strong> <asp:Label ID="AddressLabel" runat="server"></asp:Label></p>
                    <p><strong>Mobile:</strong> <asp:Label ID="MobileLabel" runat="server"></asp:Label></p>
                    <p><strong>PIN:</strong> <asp:Label ID="PINLabel" runat="server"></asp:Label></p>
                </section>

                <!-- Medical Records -->
                <section class="medical-records">
                    <h2>Medical Records</h2>
                    <asp:GridView ID="MedicalRecordGridView" runat="server" AutoGenerateColumns="False" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis" />
                            <asp:BoundField DataField="Treatment" HeaderText="Treatment" />
                        </Columns>
                    </asp:GridView>
                </section>
            </form>
        </div>
    </main>

    <!-- Footer -->
    <footer class="site-footer">
        <div class="container">
            <p>&copy; 2024 Albuixech Healthcare Centre. All rights reserved.</p>
        </div>
    </footer>
</body>
</html>
