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

 

uruchomienie: dotnet run