let nama = "Canezares Keandre Arkana Totiro";
let Tahunsekarang = "2025";
let TahunLahir = "2009";
let umur = Tahunsekarang - TahunLahir;
let bisaBuatKtp = umur >= 17;
let sisaTahun = 17 - umur;

if (bisaBuatKtp) {
    console.log(`Nama Saya ${nama}, Umur saya ${umur} tahun. Saya sudah bisa membuat KTP.`);
} else {
    console.log(`Nama saya ${nama}. Umur saya ${umur} tahun. Saya akan bisa membuat KTP ${sisaTahun} tahun lagi.`);
}

