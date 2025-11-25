const nama = "Nezar";

console.log(`Halo, nama saya ${nama}`);

//let merupakan cara mendeklarasikan variabel yang nilainya bisa diubah
//cost merupakan cara mendeklarasikan variabel yang nilainya tetap tidak bisa diubah-ubah
//variabel
let a = 10
a = 20
a = "dua puluh"

//variabel a bisa diubah-ubah tipenya karena memakai let
console.log(`Nilai a adalah ${a}`);

const b = 20

//b = "dua puluh"
//const tidak boleh memakai key (b) lebih dari 1 karena bersifat tetap / konstan
console.log(`Nilai b adalah ${b}`);



//apa aja type data di JavaScript?
 //string
 const salam = "Selamat pagi";
 const namaSaya = 'Nezar';
    console.log(`${salam}, nama saya ${namaSaya}`);
    console.log(salam + "nama saya " + namaSaya);
//number
const c = 30
const d = 20
console.log(`nilai ${c}lebih besar dari nilai ${d}`);

 //boolean
    const benar = true;
    console.log(`nilai ${c}lebih besar dari nilai ${d} adalah ${benar}`);

 //null/undefined
 const nope = null;
 console.log(`nilai nope berisi ${nope}`);

 //operator 
 //aritmatika (+ - * / % )
 const angka1 = 20
    const angka2 = 15
    const hasil = angka1 + angka2
    console.log(`hasil dari ${angka1} + ${angka2} = ${hasil}`);

 // perbandingan (== === != !== > < >= <=)
 const angka3 = 15
 const angka4 =  10
 const hasilPerbandingan = angka3 >= angka4
 console.log(`hasil dari ${angka3} >= ${angka4} = ${hasilPerbandingan}`);

 //logika (&& || !)
 // && = dan and
 // || = atau or
 // ! = tidak not
    const logika1 = 10 > (30 - 21)
    const logika2 = (10 + 1 ) <= 11
    const hasilLogika = logika1 && logika2
    console.log(`hasil dari logika tersebut adalah ${logika1} && ${logika2} = ${hasilLogika}`);
    
    const logika3 =(30 % 10 <=  10)
    const logika4 = (10 + 1) <= 12
    const logika = logika3  || logika4
    
 // penugasan (= += -= *= /= %=) 