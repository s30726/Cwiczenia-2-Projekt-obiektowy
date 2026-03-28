# Cwiczenia-2-Projekt-obiektowy

Aplikacja konsolowa do obsługi wypożyczalni sprzętu uczelnianego. Pozwala zarządzać użytkownikami, urządzeniami, wypożyczeniami i naliczaniem kar za opóźnienia, zgodnie z wymaganiami zadania.

Struktura projektu
Models – klasy domenowe (Device + dziedziczenie, User + dziedziczenie i Rental)\
Services – logika biznesowa (RentalService, PenaltyService, DeviceService, ReportService, UserService)\
Interfaces – "co robi" (IPenaltyPolicy i IRentalService)\
UI – ConsoleMenu (obsługa użytkownika)

Decyzje projektowe

Kohezja: każda klasa robi jedną rzecz, np. DeviceService zajmuje się tylko sprzętem

Coupling: użyłem interfejsów, żeby ograniczyć zależności i łatwiej było coś zmienić

SOLID:
1. Klasy mają swoją odpowiedzialność, np. DeviceService zajmuje się wyłącznie urządzeniami
2. Można łatwo rozszerzać kod, np. dodać regułę w IPenaltyService
3. Obiekt pochodne można używać zamiast bazowychk, np. ażdego usera można zamienić na studenta
4. Interfejsy odpowiadają za konkretną funkcję co ma robić klasa
5. Łatwo podmienić implenetację bez naruszania logiki




Projekt został podzielony na modele, serwisy i UI. Logika nie jest porozrzucana po całym kodzie, tylko w serwisach.

Instrukcja uruchomienia:

1. Kliknąć "Run 'SchoolRental'"
2. Najpierw wykona się demo przestawiające wszystkie funkcjonalności
3. Postępować zgodnie z menu konsolowych