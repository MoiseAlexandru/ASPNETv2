Mic backend pentru un proiect de ASP .NET
Cod destul de messy

Ce face:
3 Controllere: User, Profile, Note
La crearea unui User se creeaza automat si un Profil. Se pot crea si notite (un profil poate avea mai multe notite)

___
USER:

POST /api/User/create-custom-user: se specifica un username, un mail, o parola si un rol

POST /api/User/create-default-user: se specifica un username, un mail, o parola. Orice rol este pus, va fi setat pe 0 / User (utilizator normal)

POST /api/User/create-admin: se specifica un username, un mail, o parola. Orice rol este pus, va fi setat pe 1 / Admin (administrator)

GET /api/User/get-user-list: afiseaza toti utilizatorii

DELETE /api/User/delete-user: sterge un utilizator. Se specifica username-ul. Am setat optiunea Cascade pentru a sterge si profilul asociat.

POST /api/User/authenticate: valideaza rolul si parola unui utilizator.

Cand se creeaza un utilizator, i se va construi si un profil basic (username, profilId, userId)

___
PROFILE:

GET /api/Profile/get-profile-list: afiseaza toate profilurile

PATCH /api/Profile/update-profile: se poate face update unui profil (ex. sa se puna FirstName, LastName, Address). Are nevoie de username.

Din moment ce profilul este strans legat de cont, nu are rost sa existe cont fara profil si invers. Asadar optiunea DELETE la profile nu exista.
Daca se doreste steregerea unui profil se poate sterge userul.

___
NOTE:

GET /api/Note/get-all-notes: afiseaza toate notitele.

POST /api/Note/create-note: creeaza o notita. Field-ul ProfileId poate fi ignorat deoarece userul se cauta dupa username.

DELETE /Note/delete-note: sterge o notita. Are nevoie de id, care se gaseste din comanda GET /api/Note/get-all-notes de mai sus.

PATCH /Note/modify-note: modifica o notita.

__

Ce mai trebuie facut:
1. Returnat exceptii acolo unde este cazul (Swagger intoarce erori undefined, insa ar fi bine sa fie specificate)
2. Organizare cod (exista comenzi ce nu se regasesc mai sus, dar sunt in program - acelea posibil sa intoarca o eroare - dependenta circulara)
3. Un mic bug legat de generarea id-urilor ce nu il gasesc momentan
