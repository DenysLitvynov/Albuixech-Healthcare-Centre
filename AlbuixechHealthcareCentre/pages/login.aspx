<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AlbuixechHealthcareCentre.pages.Login" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Login - Albuixech Healthcare Centre</title>
    <link href="/styles/styles.css" rel="stylesheet">
    <link href="/styles/login.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <form runat="server">
        <div class="login-page">
            <a href="Index.aspx" class="back-arrow" aria-label="Back">
                <img src="/img/flechavolveratras.png" alt="Back" class="back-img">
            </a>
            <div class="login-container">
                <img src="/img/AlbuixechLogo.png" alt="Logo" class="logo">
                <div class="input-group">
                    <input type="text" name="email" placeholder="Email" required />
                    <span class="input-icon">&#x1F4E7;</span>
                </div>
                <div class="input-group">
                    <input type="password" name="password" placeholder="Password" required />
                    <button type="button" class="toggle-password">Show</button>
                    <span class="input-icon">&#x1F512;</span>
                </div>
                <a href="#" class="forgot-password">Forgot Password?</a>
                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" CssClass="login-button" />
            </div>
        </div>
    </form>
</body>
</html>
