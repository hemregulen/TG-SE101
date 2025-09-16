
# Architecture
Application: İş kuralları, CQRS (Command/Query) yapısı, MediatR ve FluentValidation içerir.
Domain: Entity tanımları (Order, Product, User, Waybill). Hiçbir dış bağımlılık yok.
Infrastructure: EF Core tabanlı veri erişimi, repository & unit of work, DbInitializer ile seed mekanizması.
EcommerceApi: API giriş noktası, controller’lar, Swagger, RabbitMQ integration.
# Design Patterns & Principles
CQRS: Command ve Query işlemleri ayrıldı.
MediatR: Request/response pattern ile loose coupling.
Repository & UoW: Veri erişim soyutlaması.
DI & Pipeline Behaviors: Exception handling gibi cross-cutting concern’ler merkezi yönetim.
# Error Handling & Logging
Global exception handling MediatR pipeline ile sağlandı.
Logging için Microsoft.Extensions.Logging (alternatif: Serilog) tercih edilebilir.
# Validation
FluentValidation ile command bazlı validation kuralları tanımlandı.
# Database
SQL Server + EF Core migrations.
DbInitializer ile başlangıç verileri (seed).
# Messaging
RabbitMQ ile asenkron iletişim.
Publisher ve Consumer ayrı servisler olarak konumlandırıldı.
# Bonus
Swagger entegrasyonu mevcut.
