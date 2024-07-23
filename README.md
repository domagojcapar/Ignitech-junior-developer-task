# School fullstack

Ovaj projekt napravljen je kao rješenje developer taska koji sam dobio od firme Ignitech.

## Pokretanje Backend

Pozicioniramo se s `cd ./SchoolApi` unutar jednog terminala te upišemo naredbu `dotnet run`.

## Pokretanje Frontend

Pozicioniramo se s `cd ./SchoolFrontend` unutar drugog terminala te upišemo naredbu `npm start`.

### Testiranje metoda

Teacher code i Student code su jedinstvene vrijednosti koje su sastavljene od prva dva slova imena te prva dva slova prezimena.

Teacher code kojim se mogu testirati prve dvije metode su DoCa, JoDo, JaSm te BaBa. Za jedinstvene Teacher code DoCa te JoDo dobivamo ispis za obje funkcije, JaSm ne predaje niti jedan predmet te zato dobivamo alert ako pozovemo drugu metodu, dok BaBa nema niti jednog studenta te ne predaje niti jedan predmet tako da dobivamo alert za obje metode. 
Student code kojim se testiraju ostale četiri funkcije su EmSt, BrPi, JaJa te PaZv. Svi studenti osim PaZv imaju upisan barem jedan predmet pa dobivamo ispis u prvoj funkciji za njih. Kombinacijom upisa EmSt te Matematika dobivamo ispis koji točno profesor studentu EmSt predaje matematiku, također za istog studenta možemo provjeriti još i Fiziku. Ako pokušamo kombinaciju EmSt i Napredna matematika vidimo da ta kombinacija neće dati ime nijednog profesora. Također kombinacijom EmSt te Matematika možemo vidjeti sve ocjene koje student ima iz tog predmeta te koja je prosječna ocjena. Postoji još kombinacija koje daju odgovore dok neke kombinacije javljaju kako podatci nisu ispravni. 