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
    <header>
        <div class="logo">
            <img src="../img/AlbuixechLogo.png" alt="Logo">
        </div>
        <nav>
            <ul>
                <li><a href="/pages/index.aspx">Home Page</a></li>
                <li><a href="Login.aspx">Log Out</a></li>
            </ul>
        </nav>
    </header>

    <!-- Main Content -->
    <main class="doctor-page">
        <div class="container">
            <h1>Doctor Dashboard</h1>

            <form id="doctorForm" runat="server">
                <div class="info-columns">
                    <!-- Patient Management -->
                    <section class="patient-management" style="margin-top: 2rem;">
                        <h2>Manage Patients</h2>
                        <a href="/pages/createPatient.aspx" class="button">Create New Patient</a>
                    </section>

                    <!-- Search -->
                    <section class="search" style="margin-top: 2rem;">
                        <h2>Search Patient</h2>
                        <asp:TextBox ID="SearchTextBox" runat="server" CssClass="search-input" Placeholder="Enter Patient Name"></asp:TextBox>
                        <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="search-button" OnClick="SearchButton_Click" />
                    </section>

                    <!-- Patient List -->
                    <section class="patient-list" style="margin-top: 2rem;">
                        <h2>Patient List</h2>
                        <asp:GridView ID="PatientGridView" runat="server" AutoGenerateColumns="False" CssClass="table" OnSelectedIndexChanged="PatientGridView_SelectedIndexChanged" DataKeyNames="PatientID" OnRowCommand="PatientGridView_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="PatientID" HeaderText="ID" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:CommandField ShowSelectButton="True" SelectText="Select" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="EditPatientLink" runat="server" NavigateUrl='<%# "UpdatePatient.aspx?PatientID=" + Eval("PatientID") %>' Text="Edit" CssClass="edit-link"></asp:HyperLink>
                                        <asp:Button ID="DeletePatientButton" runat="server" CommandName="DeletePatient" CommandArgument='<%# Eval("PatientID") %>' Text="Delete" CssClass="delete-button" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </section>

                    <!-- Medical Records -->
                    <section class="medical-records" style="margin-top: 2rem;">
                        <h2>Medical Records</h2>
                        <asp:Label ID="NoPatientSelectedLabel" runat="server" Text="Please select a patient" CssClass="no-records-message" Visible="False"></asp:Label>
                        <asp:GridView ID="MedicalRecordGridView" runat="server" AutoGenerateColumns="False" CssClass="table" Visible="False" OnRowCommand="MedicalRecordGridView_RowCommand" DataKeyNames="RecordID">
                            <Columns>
                                <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis" />
                                <asp:BoundField DataField="Treatment" HeaderText="Treatment" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="EditButton" runat="server" CommandName="EditRecord" Text="Edit" CommandArgument='<%# Eval("RecordID") %>' CssClass="edit-button" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="DeleteButton" runat="server" CommandName="DeleteRecord" Text="Delete" CommandArgument='<%# Eval("RecordID") %>' CssClass="delete-button" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="CreateRecordButton" runat="server" CssClass="button" Text="Create New Record" OnClick="CreateRecordButton_Click" Visible="False" />
                    </section>

                    <!-- Medical Record Form -->
                    <section class="medical-record-form" style="margin-top: 2rem;">
                        <h2>Edit Medical Record</h2>
                        <asp:Panel ID="MedicalRecordForm" runat="server" CssClass="form-panel" Visible="False">
                            <asp:HiddenField ID="RecordIDHiddenField" runat="server" />
                            <asp:TextBox ID="AppointmentDateTextBox" runat="server" CssClass="form-input" Placeholder="Appointment Date (yyyy-MM-dd)" />
                            <asp:TextBox ID="DiagnosisTextBox" runat="server" CssClass="form-input" Placeholder="Diagnosis" />
                            <asp:TextBox ID="TreatmentTextBox" runat="server" CssClass="form-input" Placeholder="Treatment" />
                            <asp:Button ID="SaveRecordButton" runat="server" Text="Save" CssClass="form-button" OnClick="SaveRecordButton_Click" />
                            <asp:Button ID="CancelEditButton" runat="server" Text="Cancel" CssClass="form-button" OnClick="CancelEditButton_Click" />
                        </asp:Panel>
                    </section>
                </div>
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
