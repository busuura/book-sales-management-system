use görsel_proje;

DROP TABLE IF EXISTS satislar;
DROP TABLE IF EXISTS musteriler;
DROP TABLE IF EXISTS kitaplar;
DROP TABLE IF EXISTS personeller;

CREATE TABLE personeller (
    personelID INT IDENTITY PRIMARY KEY,
    tc NVARCHAR(11) NOT NULL,
    ad NVARCHAR(50) NOT NULL,
    soyad NVARCHAR(50) NOT NULL,
    tel NVARCHAR(20) NOT NULL,
    sifre NVARCHAR(50) NOT NULL
);

CREATE TABLE kitaplar (
    kitapID INT IDENTITY PRIMARY KEY,
    barkod NVARCHAR(11) NOT NULL,
    kitapAdi NVARCHAR(70) NOT NULL,
    yazar NVARCHAR(80) NOT NULL,
    fiyat DECIMAL(18,2) NOT NULL,
    stok INT NOT NULL
);


CREATE TABLE musteriler (
    musteriID INT IDENTITY PRIMARY KEY,
    ad NVARCHAR(50) NOT NULL,
    soyad NVARCHAR(50) NOT NULL,
    tel NVARCHAR(20),
    email NVARCHAR(100)
);


CREATE TABLE satislar (
    satisID INT IDENTITY PRIMARY KEY,
    musteriID INT NOT NULL,
    kitapID INT NOT NULL,
    adet INT NOT NULL,
    toplamTutar DECIMAL(18,2) NOT NULL,
    satisTarihi DATETIME DEFAULT GETDATE()
);

SELECT * FROM personeller;
SELECT * FROM  kitaplar;
SELECT * FROM  musteriler;
SELECT * FROM satislar;
 

 INSERT INTO kitaplar 
 (barkod, kitapAdi, yazar, fiyat, stok) 
VALUES 
('11111', 'Beyaz Geceler', 'Dostoyevski', 120.00, 50),
('22222', 'Küçük Prens', 'Antoine de Saint-Exupéry', 85.00, 30),
('33333', 'Simyacı', 'Paulo Coelho', 150.00, 40),
('44444', 'Suç ve Ceza', 'Dostoyevski', 165.00, 25),
('55555', 'Sefiller', 'Victor Hugo', 190.00, 15),
('66666', 'Kürk Mantolu Madonna', 'Sabahattin Ali', 95.00, 60),
('77777', '1984', 'George Orwell', 110.00, 45),
('88888', 'Hayvan Çiftliği', 'George Orwell', 75.00, 70),
('99999', 'Nutuk', 'Mustafa Kemal Atatürk', 200.00, 100),
('12345', 'Saatleri Ayarlama Enstitüsü', 'Ahmet Hamdi Tanpınar', 140.00, 20);


INSERT INTO musteriler 
(musteriId, ad, soyad, tel, email) 
VALUES 
('Ayşe', 'Yılmaz', '05551112233', 'ayse@gmail.com'),
( 'Ayşe', 'Kaya', '05552223344', 'aysekaya@gmail.com'),
( 'Berat', 'Yıldız', '05553334455', 'berat@gmail.com');