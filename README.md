# 🏗️ Arkitektur

## 📌 Proje Hakkında

**Arkitektur**, ASP.NET Core kullanılarak geliştirilmiş, **N-Layer (Katmanlı) Mimari** prensiplerini temel alan bir web uygulamasıdır.  
Proje; **temiz kod**, **sorumlulukların net şekilde ayrılması** ve **sürdürülebilir yazılım mimarisi** anlayışıyla tasarlanmıştır.

Katmanlı mimari yaklaşımı sayesinde uygulama; kurumsal projelerde tercih edilen, okunabilir ve geliştirilebilir bir yapı sunar.

---

## 🧩 Mimari Yaklaşım

Projede **N-Layer Architecture** uygulanmıştır. Her katman yalnızca kendi sorumluluk alanına odaklanır ve diğer katmanlarla doğrudan bağımlılık kurmaz.

Katmanlar arası iletişim aşağıdaki prensipler doğrultusunda tasarlanmıştır:

- Interface (soyutlama) kullanımı  
- Dependency Injection  
- Loose Coupling (gevşek bağlılık)

Bu yaklaşım, kodun test edilebilirliğini artırır ve bakım süreçlerini kolaylaştırır.

---

## 📚 Katman Mantığı

### API Katmanı
- RESTful API endpoint’lerini barındırır  
- HTTP isteklerinin karşılandığı katmandır  
- Controller yapıları bu katmanda yer alır  
- Uygulamanın dış dünyaya açılan yüzüdür  

### Business Katmanı
- İş kurallarının uygulandığı ana katmandır  
- Servis sınıfları bu katmanda konumlandırılmıştır  
- Validation ve business logic süreçleri burada yönetilir  
- Veri erişimi soyutlamalar üzerinden sağlanır  

### Data Access Katmanı
- Veritabanı işlemlerinin gerçekleştirildiği katmandır  
- Entity Framework Core kullanılmıştır  
- Repository Pattern uygulanmıştır  
- Veri erişimi merkezi ve kontrollü şekilde yapılır  

### Entity Katmanı
- Domain modelleri ve entity sınıflarını içerir  
- Veritabanı tablolarını temsil eden yapılar burada tanımlanır  
- Diğer katmanlardan bağımsızdır  

### WebUI Katmanı
- Kullanıcı arayüzünün bulunduğu katmandır  
- MVC mimarisi ile yapılandırılmıştır  
- API katmanı ile haberleşerek verileri sunar  
- UI ve backend ayrımını net şekilde yansıtır  

---

## 🚀 Kullanılan Teknolojiler ve Yaklaşımlar

- ASP.NET Core  
- Entity Framework Core  
- N-Layer Architecture  
- Repository Pattern  
- Dependency Injection  
- DTO Pattern  
- SOLID prensipleri  
- RESTful API mimarisi  

---

## 🎯 Projenin Amacı

- Katmanlı mimarinin gerçek bir projede uygulanışını göstermek  
- Kurumsal projelere uygun, temiz ve sürdürülebilir bir mimari sunmak  
- Kod tekrarını azaltan, okunabilir bir yapı oluşturmak  
- Genişletilebilir ve geliştirilebilir bir temel altyapı sağlamak  

---

## ✨ Öne Çıkan Noktalar

- Katmanlar arası gevşek bağlı yapı  
- Okunabilir ve maintainable kod düzeni  
- Modüler ve genişletilebilir mimari  
- Kurumsal yazılım standartlarına uygun altyapı  

---

## 👨‍💻 Geliştirici

**Emirhan Hacıoğlu**  
ASP.NET Core | Backend Development | N-Layer Architecture

<img width="1893" height="860" alt="Ekran görüntüsü 2025-12-22 014034" src="https://github.com/user-attachments/assets/6835a304-ceee-442a-bbb2-b0f9210577ef" />

<img width="1881" height="845" alt="Ekran görüntüsü 2025-12-22 004636" src="https://github.com/user-attachments/assets/dbfd2e78-3134-4f61-8c33-a05cc0cb502d" />

<img width="1876" height="862" alt="Ekran görüntüsü 2025-12-22 004712" src="https://github.com/user-attachments/assets/cb3cac8e-6284-4b5a-a35d-8eb18e25e128" />

<img width="1886" height="848" alt="Ekran görüntüsü 2025-12-22 004730" src="https://github.com/user-attachments/assets/94ec6bef-ee6b-4d8b-925f-cdb256c12c98" />

<img width="1875" height="857" alt="Ekran görüntüsü 2025-12-22 005032" src="https://github.com/user-attachments/assets/401c8de1-b406-489c-b49a-903dc2cea295" />

<img width="1876" height="832" alt="Ekran görüntüsü 2025-12-22 005323" src="https://github.com/user-attachments/assets/5e8ab8bc-802a-4006-8e20-cf77058914dc" />

<img width="1893" height="849" alt="Ekran görüntüsü 2025-12-22 005345" src="https://github.com/user-attachments/assets/cc88acc4-f7f2-473e-84b2-396da142781e" />

<img width="424" height="603" alt="Ekran görüntüsü 2025-12-22 005534" src="https://github.com/user-attachments/assets/7a1910a9-5b89-4a1e-b054-bf7d4a4052c7" />

<img width="1894" height="767" alt="Ekran görüntüsü 2025-12-22 011242" src="https://github.com/user-attachments/assets/4bbc46a1-8012-4f0d-9935-8fd69d0c8bf8" />

<img width="1899" height="764" alt="Ekran görüntüsü 2025-12-22 011126" src="https://github.com/user-attachments/assets/753ad188-721f-4839-bf2c-cc9d9ebc4f1d" />

<img width="1895" height="847" alt="Ekran görüntüsü 2025-12-22 011225" src="https://github.com/user-attachments/assets/a7a6bd35-2eb1-4415-b706-01cd7210a8fb" />
