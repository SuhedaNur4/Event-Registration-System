# Etkinlik Kayıt Sistemi (Event Registration System)

## Project Overview / Proje Özeti

**English:**
**Event Registration System** is a web application developed as part of the **Web Programming** course. Built with **ASP.NET Core MVC** and **Entity Framework Core**, it provides a streamlined interface for managing event registrations, implementing automated capacity checks, and dynamic event filtering.

**Türkçe:**
**Etkinlik Kayıt Sistemi**, **Web Programlama** dersi kapsamında geliştirilmiş kapsamlı bir web uygulamasıdır. **ASP.NET Core MVC** ve **Entity Framework Core** kullanılarak oluşturulan bu sistem; etkinlik kayıtlarını yönetmek, otomatik kapasite kontrolleri uygulamak ve dinamik etkinlik filtreleme sağlamak için modern bir arayüz sunar.

---

## Features / Özellikler

**English:**
*   **Event Management:** Listing events with titles, descriptions, dates, and capacities.
*   **Registration System:** Users can register for events using their name, surname, and email.
*   **Capacity Control:** Automatic prevention of new registrations once an event is full.
*   **Search & Filtering:** Filtering events by date and name.
*   **Database Integration:** Built with EF Core Code-First approach using SQLite.
*   **Modern UI:** Responsive design based on Bootstrap 5.

**Türkçe:**
*   **Etkinlik Yönetimi:** Başlık, açıklama, tarih ve kapasite bilgilerini içeren etkinlik listeleme.
*   **Kayıt Sistemi:** Ad, soyad ve e-posta ile etkinliklere kolay kayıt olma.
*   **Kapasite Kontrolü:** Kontenjanı dolan etkinlikler için otomatik kayıt engelleme.
*   **Arama ve Filtreleme:** Tarih ve isim bazlı dinamik etkinlik arama.
*   **Veritabanı Entegrasyonu:** EF Core Code-First yaklaşımı ve SQLite kullanımı.
*   **Modern Arayüz:** Bootstrap 5 tabanlı duyarlı (responsive) tasarım.

## Technologies Used / Kullanılan Teknolojiler

*   **Backend:** C#, ASP.NET Core MVC (.NET 8.0)
*   **ORM:** Entity Framework Core
*   **Database:** SQLite
*   **Frontend:** HTML5, CSS3, Bootstrap 5, Razor Views

## Installation / Kurulum

1.  **Clone the repository / Repoyu klonlayın:**
    ```bash
    git clone https://github.com/SuhedaNur4/Event-Registration-System.git
    ```
2.  **Navigate to the project directory / Proje dizinine gidin:**
    ```bash
    cd EventRegistrationSystem
    ```
3.  **Update the database / Veritabanını güncelleyin:**
    ```bash
    dotnet ef database update
    ```
4.  **Run the application / Uygulamayı çalıştırın:**
    ```bash
    dotnet run
    ```

## Expected Outputs / Beklenen Çıktılar

*The application provides a basic dashboard for event tracking and a user-friendly registration flow, meeting academic requirements for the Web Programming course.*

*Uygulama, etkinlik takibi için temel bir panel ve kullanıcı dostu bir kayıt akışı sunarak Web Programlama dersinin akademik gereksinimlerini karşılamaktadır.*
