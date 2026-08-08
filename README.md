# 🚗 RentCar - Araç Kiralama Platformu

Bu proje, **ASP.NET Core 8.0 Web API** ve **MVC UI** katmanları kullanılarak geliştirilmiş, mikroservis/katmanlı mimari prensiplerine uygun bir araç kiralama uygulamasıdır. Projede ORM olarak **Dapper** tercih edilmiş olup, performanslı veritabanı sorguları ve dinamik filtreleme mekanizmaları uygulanmıştır.

---

## 🚀 Öne Çıkan Özellikler

* **⚡ Yüksek Performanslı ORM (Dapper):** SQL sorgularının doğrudan yönetildiği, hafif ve hızlı veri erişim katmanı.
* **🔍 Dinamik Araç Filtreleme:** 
  * Yakıt Türü (Benzin, Dizel, Elektrik, Hibrit)
  * Vites Tipi (Otomatik, Manuel)
  * Minimum ve Maksimum Fiyat Aralığı
  * Araç Kategorisi / Marka Filtresi
* **📋 Araç Detay Sayfası:** Seçilen aracın teknik özelliklerini (Model Yılı, KM, Koltuk Sayısı, Motor Hacmi, Konum vb.) dinamik olarak getiren detay ekranı.
* **🎨 Modern UI / Responsive Tasarım:** Bootstrap ve özel CSS şablonları ile mobil uyumlu kullanıcı arayüzü.
* **🌐 RESTful API:** UI ve API katmanlarının tamamen ayrıştırıldığı, modüler mimari.

---

## 🛠️ Kullanılan Teknolojiler

* **Backend / API:** .NET 8.0, ASP.NET Core Web API
* **Data Access:** Dapper ORM
* **Database:** Microsoft SQL Server (MS SQL)
* **Frontend:** ASP.NET Core MVC (Razor Views), HTML5, CSS3, Bootstrap, JavaScript
* **Communication:** HttpClient, Newtonsoft.Json (JSON Deserialization)
* **Architecture:** Repository Pattern, DTO (Data Transfer Object) Design Pattern
