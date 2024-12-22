# <p align="center"><img src="https://hackmd.io/_uploads/Hyu6VjBryl.png" width="400"></p>

**Fur Quest** adalah game 2D platformer yang mengisahkan perjalanan penuh tantangan seorang ayah rubah bernama Reynard yang bertekad menemui anaknya. Dalam perjalanan ini, pemain akan menghadapi berbagai monster yang berbahaya, melompati rintangan, dan mengumpulkan buah-buahan untuk memulihkan energi. Dengan modern pixel art style dan dunia yang penuh warna, Fur Quest akan menguji ketangkasan serta strategi pemain dalam menyelesaikan setiap level.

## 🏛️ Design Pillars
### 🔹 Main Game View
FurQuest disajikan dalam perspektif 2D side-scrolling. Pemain akan melihat karakter sang rubah yang dapat bergerak dari kiri ke kanan serta lompat (atas ke bawah).

### 🔹 Core Player Activity
Tugas utama pemain adalah membantu sang ayah Rubah untuk mencapai anaknya dengan: 
- Melompati Rintangan, pemain harus melewati platform dan rintangan seperti jurang, jembatan atau tangga.
- Menghindari dan Melawan Monster, pemain harus menghindari kontak dengan monster jika tidak ingin mengurangi healthpoint mereka. Pemain pada awalnya memiliki 3 healthpoint artinya pemain memiliki kesempatan bersentuhan dengan monster maksimal 3 kali sebelum game over. Monster dapat dikalahkan dengan melompat diatas mereka. 
- Healthpoint Heal, dengan beberapa trik lompatan tertentu, pemain bisa mengambil buah cherry untuk mengembalikan healthpoint yang sudah hilang.

### 🔹 In-Game User Interface
<img src="https://hackmd.io/_uploads/rk6lFjrByx.png" width="400">

## 🎮 Genre/Story/Mechanics Summary
### 🔹 Character Background and Game Mood
Ayah rubah dalam Fur Quest, bernama Reynard, adalah sosok yang pemberani dan penuh kasih sayang terhadap anaknya. Setelah mendapat kabar bahwa anaknya memerlukan bantuan di rumah, Reynard dengan segera harus sampai ke rumah anaknya.

Walau dunia Fur Quest terlihat penuh warna, namun monster dalam game ini tetap merupakan ancaman bagi Reynard dan tentu akan mengganggu perjalanan Reynard.

### 🔹 Gameplay Mechanics
- Player Properties
  - Dapat bergerak ke arah kiri / kanan, dan atas / bawah (melompat)
  - Memiliki HP (health Point) sebesar 3 
  - Mengurangi 1 HP dan mengalami knockback ketika terkena serangan (bertabrakan) dengan musuh
  - Dapat mengalahkan musuh dengan cara mengenai kepala musuh
  - Mendapatkan jump-boost (1 ekstra lompatan) setelah mengalahkan musuh
  - Menambahkan 1 point HP ketika mengambil item cherry (selama HP saat ini di bawah 3)
- Frog Enemy
  - Dapat melompat
   - Mengurangi 1 HP jika menyentuh pemain
   - Dapat dikalahkan dengan melompat di kepala
- Opossum Enemy
  - Bergerak ke kanan dan ke kiri
   - Mengurangi 1 HP jika menyentuh pemain
   - Dapat dikalahkan dengan melompat di kepala
- Pig Enemy
  - Bergerak lebih cepat dibandingkan musuh lainnya
   - Mengurangi 1 HP jika menyentuh pemain
   - Dapat dikalahkan dengan melompat di kepala
- Eagle Enemy
  - Tidak menyerang atau bergerak
   - Berfungsi sebagai platform melayang
   - Dapat dikalahkan dengan melompat di kepala
## 🗺️ Level Design
Pada saat ini, FurQuest memiliki 2 level yang tersedia, pada masing masing level, terdapat jenis musuh yang berbeda, dan item berupa cherry. Pada level 1, terdapat sebuah portal yang jika disentuh akan membawa player ke level 2. Pada level 2, terdapat object pintu, yang dapat digunakan untuk mengulangi stage, dan terdapat rumah dari anak reynard yang menjadi tujuan akhir dari game in.

### 🔹 Level 1
<img src="https://hackmd.io/_uploads/rk5PcsBB1x.png" width="400">

### 🔹 Level 2
<img src="https://hackmd.io/_uploads/Hygq9irBkl.png" width="400">

## 🕹️ Interface
### 🔹 Kendali Player
| **Tombol**       | **Aksi**                 | **Game State**        |
|-------------------|--------------------------|-----------------------|
| Tombol apapun     | Start game               | Main Menu            |
| W, D             | Menggerakan player       | In-game              |
| Spacebar         | Melompat                 | In-game              |
| A, S             | Menaiki / menuruni tangga| In-game, at ladder   |
| Spacebar         | Melepas tangga           | In-game, at ladder   |

### 🔹 Interaksi Player
| **Objek/Entitas** | **Interaksi**                        | **Respons**                                                                |
|--------------------|--------------------------------------|----------------------------------------------------------------------------|
| Enemy (semua tipe) | Bersentuhan dari samping            | Healthpoint player -1                                                     |
| Enemy (semua tipe) | Bersentuhan dari atas               | Enemy mati, player mendapatkan *jump-boost*                               |
| Cherry             | Bersentuhan dengan benda            | Memulihkan/menambahkan 1 HP ketika HP saat ini < 3                        |
| Portal             | Bersentuhan dengan benda            | Player akan memasuki level berikutnya                                     |
| Door               | Bersentuhan dengan benda            | Player akan *respawn* (mengulangi stage dari awal)                        |
| Ladder             | Menekan A / S                       | Player memasuki mode *climbing*                                           |
| Ladder             | Menekan Spacebar                    | Player keluar dari mode *climbing*                                        |

## 🎵 Music/Sound Assets
| **Tipe** | **Deskripsi**                 | **Penggunaan**                         | **Nama File**             |
|----------|-------------------------------|-----------------------------------------|---------------------------|
| Musik    | Musik Main Menu (loop)        | Musik latar belakang Main Menu         | hurry_up_and_run.mp3      |
| Musik    | Musik Overworld (loop)        | Musik latar belakang level Overworld   | Hurt_and_heart.ogg        |
| Musik    | Musik Underground (loop)      | Musik latar belakang level Underground | under the rainbow.ogg     |

## 👨‍💻 Group Members
#### 🔹 **Anthonius Hendhy Wirawan** - 2306161795
#### 🔹 **Benedict Aurelius** - 2306209095
#### 🔹 **Christian Hadiwijaya** - 2306161952
#### 🔹 **Jonathan Frederick Kosasih** - 2306225981

##
<p align="center"><b>FurQuest</b> © 2024. All Rights Reserved.</p>