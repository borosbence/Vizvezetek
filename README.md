# Vízvezetékszerelő munkalapok #

A sárgahegyi Tiszta Víz Kft. hosszú ideje áll a lakosság szolgálatában.
Munkatársai az építkezéseken végzett munka mellett bármilyen problémát
gyorsan orvosolnak, legyen szó csöpögő csapról vagy csőtörésről.

A cégnek szüksége van egy Web API alkalmazásra, ami az adatbázisban
szereplő munkákat adja ki a megfelelő formátumban.

**0.)** Töltse fel a MySQL adatbázist a mellékelt *vizvezetek.sql* fájl
alapján.

**1.)** Készítsen egy ASP.NET Core Web API projektet VizvezetekAPI
néven\!

**2.)** Az alkalmazás üzemeltetője szeretné majd a későbbiekben
áttelepíteni a náluk futó adatbázist, így a kapcsolati adatok
módosulnak. Készítse fel az alkalmazást, hogy az adatbázis kapcsolódási
adatokat egy konfigurációs fájlból olvassa be\!

**5.)** Az alkalmazás az *api/Munkalapok* erőforrásokon kell, hogy
kommunikáljon.

6.) Fontos formai megkötés, hogy a munkalapokat majd az alábbi
formátumban kell szolgáltatnia a Web API-nak:

{

    "id": 1,

    "beadas\_datum": "2001-05-28T00:00:00",

    "javitas\_datum": "2001-05-31T00:00:00",

    "helyszin": "Kőváros, Harcsa u. 99.",

    "szerelo": "Szabó György",

    "munkaora": 2,

    "anyagar": 3721

}

A formátum átalakításához használjon egy segéd osztályt és tegye a
*DTOs* mappába. A helyszín mező a *telepules (vessző) utca* formátumot
adja vissza.

**6.)** Hozzon létre egy paraméter nélküli végpontot, amit HTTP GET
metódussal lehet elérni *Getmunkalapok* néven. A végpont adja vissza az
összes adatot a munkalapon, a megszabott formátumban.

**7.)** Hozzon létre egy másik HTTP GET végpontot, ami egy munkalap
azonosítót kér, és adja vissza a talált rekordot. Építsen hozzá
útvonalszabályt ilyen módon: *api/Munkalap/5*.

**8.)** Készítsen egy másik osztályt a *DTOs* mappában
*MunkalapKeresesDto* néven. Az osztálynak két tulajdonság értéke legyen:
helyszín azonosító, és szerelő azonosító.

**9.)** Hozzon létre egy HTTP POST végpontot *Kereses* néven.
Paraméterként kapja meg a *MunkalapKeresesDto* objektumot és keresse
ki, hogy a kapott helyszín és szerelő együtt milyen munkalapokon
szerepel.

**10.)** Egészítse ki az *api/Munkalapok* lekérdezést opcionális évszám
kereséssel a lezárt munkalapokra. Például az *api/Munkalapok/2022* adja
vissza a 2022-ben lezárt munkalapok listáját.
