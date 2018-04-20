# news-app
Aplikacja służy do agregowania najnowszych informacji. Informacje podzielone są na kategorie. W celu skorzystania z aplikacji użytkownik musi zarejestrować się i założyć nowe konto. Jeżeli użytkownik założył już konto, musi się zalogować.
Artykuły aktualizowane są przez administratora.

Dane do konta administratora, które jest automatycznie tworzone przy pierwszym uruchomieniu aplikacji:                
Login: admin@abc.pl
Hasło: Admin!2

Administrator ma możliwość zaktualizowania jednocześnie wszystkich kategorii lub wybranej pojedynczej z poziomu zakładki "Panel administracyjny"

Przy pierwszym uruchomieniu baza jest pusta i najpierw trzeba zaktualizować artykuły z poziomu administratora. Artykuły dla użytkownika są wyświetlane z bazy i tylko administrator może aktualizować zwartość bazy danych. Bez tego żaden użytkownik nie zobaczy żadnych wpisów.

Korzystam z web app: News api. Baza danych jest automatycznie generowana przy użyciu Entity Framework.
