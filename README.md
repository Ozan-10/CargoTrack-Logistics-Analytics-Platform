# 🚚 CargoTrack Logistics Analytics Platform

CargoTrack, ASP.NET Core MVC, Dapper ve SQL Server kullanılarak geliştirilmiş bir lojistik operasyon ve analitik platformudur.

Proje; kargo gönderilerinin yönetilmesi, kurye performanslarının takip edilmesi, teslimat süreçlerinin analiz edilmesi ve yüksek hacimli verilerin sisteme hızlı şekilde aktarılması amacıyla geliştirilmiştir.

---

# 📸 Proje Görselleri

## Dashboard

<img width="1676" height="906" alt="dashboard" src="https://github.com/user-attachments/assets/fe64b4be-0ec7-4607-9da6-158db43d54a7" />


## Courier Performance Dashboard

<img width="1575" height="906" alt="shipments" src="https://github.com/user-attachments/assets/c591d2ff-7fb2-4534-93b2-119afa115f7a" />

<img width="1673" height="900" alt="shipments2" src="https://github.com/user-attachments/assets/ac935fc0-55c6-406a-af66-11e8b892f79c" />



## Shipment Detail

<img width="1573" height="916" alt="shipments3" src="https://github.com/user-attachments/assets/7724efdc-8e46-4987-abef-7088e2c0cb24" />



---

# ✨ Özellikler

- Kargo Yönetim Modülü
- Kurye Yönetim Modülü
- Dashboard ve Operasyon Analitiği
- Kurye Performans Takibi
- Teslimat Durum Analizi
- Shipment Tracking Ekranları
- Shipment Timeline Görselleştirmesi
- Chart.js ile Raporlama
- CSV Veri Aktarma Modülü
- SqlBulkCopy ile Toplu Veri İşleme
- Responsive Admin Panel Tasarımı

---

# ⚡ Yüksek Performanslı CSV Import

Projenin en önemli özelliklerinden biri yüksek hacimli veri aktarım altyapısıdır.

Kullanıcı tarafından yüklenen CSV dosyaları sistem tarafından okunarak DataTable yapısına dönüştürülmekte ve SqlBulkCopy kullanılarak SQL Server veritabanına toplu şekilde aktarılmaktadır.

### İş Akışı

1. CSV Dosyası Yükleme
2. Satırların Okunması
3. DataTable Oluşturulması
4. SqlBulkCopy ile Toplu Aktarım
5. Dashboard Verilerinin Güncellenmesi

### Test Sonucu

- 1.000.000 Shipment Kaydı Başarıyla Aktarıldı

---

# 📊 Dashboard Metrikleri

Dashboard ekranında aşağıdaki bilgiler sunulmaktadır:

- Toplam Gönderi Sayısı
- Teslim Edilen Gönderiler
- Geciken Gönderiler
- Aktif Şube Sayısı
- Aylık Gönderi Hacmi
- Gönderi Durum Dağılımı

---

# 🚚 Courier Performance Modülü

Kurye performans ekranında:

- Toplam Teslimat Sayısı
- Başarı Oranı
- Ortalama Teslim Süresi
- Aylık Gelir Bilgisi
- Teslimat Performans Grafiği
- Kurye Değerlendirme Puanı
- Son Teslimatlar

bilgileri görüntülenmektedir.

---

# 📦 Shipment Tracking Modülü

Gönderi detay ekranında:

- Takip Kodu
- Gönderici Şehri
- Alıcı Şehri
- Kargo Ücreti
- Kurye Bilgileri
- Şube Bilgileri
- Teslimat Süreci
- Teslimat Zaman Çizelgesi

bilgileri yer almaktadır.

---

# 🛠 Kullanılan Teknolojiler

## Backend

- ASP.NET Core MVC
- Dapper
- SQL Server

## Frontend

- Bootstrap 5
- Chart.js
- HTML5
- CSS3
- JavaScript

---

# 🏗 Mimari Yapı

```text
Controllers
│
├── Repositories
│
├── Models
│
├── Views
│
└── SQL Server
