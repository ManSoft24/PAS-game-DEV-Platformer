const tahunSekarang = 2025;
const tahunLahir = 2009;
const umur = tahunSekarang - tahunLahir;
const sisaUmurBuatKTP = 17 - umur;
if (umur >= 17) {
    console.log(`Anda sudah boleh membuat KTP`);
    
} else if (umur > 10 && umur <= 17){
    console.log(`Anda akan membuat ktp ${sisaUmurBuatKTP} tahun lagi`);
} else {
    console.log(`Anda belum boleh membuat KTP`);
}
 

