Projekt sklepu płyt winylowych opiera się na stworzeniu API w języku C# na platformie .NET z wykorzystaniem Entity Frameworks Core oraz frontendu we frameworku React, a także Postgresql bazę danych na dockerze. Stworzone modele w języku C# zawierają takie klasy jak User, Announcement oraz ShoppingCart. 

Użyte technologie
BE: .NET C#, Entity Framework, 
BD: postgresql, docker
FE: React

Funkcjonalności na backendzie
[Post] Logowanie, Rejestracja, Dodaj ogłoszenie, Dodaj do koszyka
[Get] Wyświetl użytkownika, Wyświetl informacje o moim koncie,  Wyświetl ogłoszenie, wyświetl moje ogłoszenia, Wyświetl wszystkie ogłoszenia,  Wyświetl moje zamówienia
[Put] Aktualizuj ogłoszenie (tylko admin lub osoba tworząca ogłoszenie), Aktualizuj przedmiot w koszyku
[Delete] Usuń ogłoszenie (tylko admin lub osoba tworząca ogłoszenie), Wyczyść koszyk, Usuń konto

 
Uruchomienie projektu
1. Sklonowanie repozytorium, komenda: git clone https://github.com/mazurek321/ProgramowanieAplikacjiWebowych-Backend.git
2. Wejście do folderu, komenda: cd 
3. Uruchomić aplikację Docker Desktop.
4. W folderze komenda: docker build .
5. W tej samej lokalizacji komenda: docker compose up
6. W tej samej lokalizacj i nowym terminalu komenda: dotnet ef
migrations add „NowaMigracja”
7. Aktualizacja bazy: dotnet ef database update
8. Uruchomienie projektu: dotnet run
9.Wejście do swaggera, w przeglądarce internetowej:
http://localhost:5050/swagger/index.html
