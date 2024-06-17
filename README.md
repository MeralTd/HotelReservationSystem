Hotel Reservation System


<h1>Kurulum</h1>

```
git clone https://github.com/MeralTd/HotelReservationSystem.git
cd HotelReservationSystem
```

<h2> Database Oluşturma </h2>

```
update-database
```


<h2> Docker RabbitMQ </h2>

Bu kurulum, docker-compose ve docker'ın kurulu olduğunu varsayar.


```
docker-compose up
```

http://localhost:15672/ adresini açın ve RabbitMQ giriş için bu bilgilerini kullanın

```
username: user
password: mypassword
```

<h2> Yeni Rezervasyon Oluşturma </h2>

```
{
  "userName": "string",
  "email": "string",
  "hotelName": "string",
  "roomNumber": "string",
  "hotelCheckinDate": "2024-06-17T21:47:29.776Z",
  "hotelCheckoutDate": "2024-06-17T21:47:29.776Z",
  "addressLine1": "string",
  "addressLine2": "string",
  "description": "string"
}
```

Database ve RabbitMq bağlantısı kurulduktan sonra Swaggerda /api/ReservationHotels/Add metodu ile yeni reservasyon oluşturulduğunda;

- Mesajlaşma Sistemi:

Concumer console uygulmasında RabbitMQ mesajlarını iletilme işlemleri yapmılmıştır.

Ekran Çıktısı

![Rabbitmq](https://github.com/MeralTd/HotelReservationSystem/blob/master/1.PNG?raw=true)

- Gerçek Zamanlı Bildirimler:

SignalR_Client uygulamasında yeni rezervasyonlar oluşturulduğunda bu bilgiyi gerçek zamanlı olarak
bağlı tüm istemcilere gönderir.

Ekran Çıktısı

![SignalR](https://github.com/MeralTd/HotelReservationSystem/blob/master/2.PNG?raw=true)
