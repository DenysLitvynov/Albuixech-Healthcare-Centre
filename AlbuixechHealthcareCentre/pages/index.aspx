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
    <header>
        <div class="logo">
            <img src="../img/AlbuixechLogo.png" alt="Logo">
        </div>
        <nav>
            <ul>
                <li><a href="#">Home Page</a></li>
                <li><a href="/pages/login.aspx">Log In</a></li>
            </ul>
        </nav>
    </header>
    <main>
        <section class="hero">
            <img src="/img/ImgLan.jpg" alt="Healthcare Centre" class="landing-image">
            <div class="hero-content">
                <h1>Albuixech Healthcare Centre</h1>
                <p>Your Health, Our Priority</p>
                <a href="#info" class="scroll-arrow">&#8595;</a>
            </div>
        </section>
        <section id="info" class="additional-content">
            <div class="image-container">
                <img src="/img/ImgLan2.jpg" />
            </div>
                <div class="text-content">
                    <h3>Comprehensive Healthcare in the Heart of Albuixech</h3>
                    <p>
                       At our medical center in Albuixech, we provide comprehensive and personalized healthcare for the entire family. 
                        Conveniently located in this charming town near Valencia, our dedicated team of healthcare professionals works 
                        tirelessly to ensure the well-being of our community. From general medical consultations to specialties such as 
                        pediatrics, cardiology, and physiotherapy, we offer modern facilities and advanced equipment to deliver the 
                        highest quality care. With a strong focus on preventive health and a compassionate approach, we are your trusted 
                        partner in looking after you and your loved ones.
                    </p>
                </div>
        </section>
        <section class="additional-content2">
            <div class="text-content2">
                <h3>Your Health, Our Priority: Albuixech Medical Center</h3>
                <p>At Albuixech Medical Center, we are committed to providing top-quality healthcare services tailored to meet the needs 
                    of every patient. Located in a serene setting near Valencia, we combine the expertise of our physicians with 
                    state-of-the-art technology to ensure accurate diagnoses and effective treatments. Our wide range of services 
                    includes routine check-ups, vaccinations, and specialized care in fields like gynecology and dermatology. 
                    Guided by a philosophy of promoting healthy lifestyles, preventing illnesses, and offering comprehensive support 
                    at every stage of life, we are here to take care of your health with warmth and professionalism.
                </p>
            </div>
            <div class="image-container2">
                <img src="/img/ImgLan1.jpg" />
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
