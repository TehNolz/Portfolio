# Het CRM

Ranshuijsen heeft op het moment een zelfgemaakte Custom Relations Management (CRM) systeem in gebruik. Hierin beheren zij allerlei verschillende zaken, zoals bijvoorbeeld;
* Gegevens van klanten, zoals contactpersonen, adressen, en andere data,
* Werkuren, vakantiedagen, ziekteverlof, e.d. van medewerkers.
* De inventarisatie van alle elektronica en hardware binnen het bedrijf.
* Binnengekomen Support Tickets
* Financiele en operationale rapportages

Dit systeem is puur voor intern gebruik, waardoor het wordt beschouwd als een soort zandbak waarin medewerkers kunnen experimenteren met nieuwe technologieën en ideeën. Omdat het systeem niet buiten Ranshuijsen wordt gebruikt, is het geen probleem als er tijdens deze experimenten iets mis gaat. Als er namelijk een fout wordt ontdekt in het systeem, dan kunnen zij dit zelf direct oplossen. Ook wordt het systeem gebruikt voor het inwerken van nieuwe medewerkers, zodat zij aan de bedrijfsomgeving kunnen wennen zonder dat zij direct met klanten moeten werken.

# Waarom Blazor?
Omdat Ranshuijsen veel oude (_legacy_) code onderhield waar ze vanaf wilde, hebben zij besloten om over te stappen naar een nieuwe, moderne softwarearchitectuur met nieuwe features. Zij hebben besloten om over te stappen naar Blazor, omdat zij verwachten dat Blazor het _platform voor de toekomst_ zal worden. Zij denken dat Blazor zeer voordelig zal zijn voor hun klanten, en zijn daarom druk bezig geweest om de systemen die zij ontwikkelen te migreren naar Blazor. Op het moment is het meerendeel van deze systemen overgezet.

Het grootste voordeel van Blazor voor Ranshuijsen is dat het een onderdeel is van ASP.NET Core, het webframework dat Ranshuijsen voorheen veel gebruikte voor hun projecten. Dit maakt het mogelijk om geleidelijk de oude systemen te migreren naar Blazor, waardoor het voor Ranshuijsen niet nodig is om tijdens de migratie twee losse systemen te onderhouden.

# Mijn taken

Op het moment is het systeem gemaakt met .NET Framework en ASP.NET MVC. In een poging om alle systemen van Ranshuijsen met elkaar consistent te houden, is er besloten om ook het CRM systeem over te zetten naar .NET 5 en Blazor. Als onderdeel van mijn stage ga ik zij hierbij ondersteunen, waarbij ik de volgende taken zal ondernemen;

* Het onderzoeken van Blazor (beide client- en serverside)
* Het migreren van de oude ASP.NET MVC applicatie naar ASP.NET Core MVC
* Nieuwe, nog niet bestaande functionaliteit ontwerpen, implementeren, en testen, waaronder;
    * Een planningsmodule, waarin medewerkers van week tot week de planningen voor de verschillende projecten van Ranshuijsen kunnen inzien en beheren.
    * Een projectmodule, met daarin de mogelijkheid om product breakdowns op te zetten inclusief urenschattingen.
    * Een brievenboek module, waarmee documenten kunnen worden gegenereerd, bewaard, en gekoppeld aan onderwerpen zoals projecten, klanten, producten, of combinaties hiervan.
* Het meehelpen met de deployment van het vernieuwde systeem.

# Uitvoering
==TODO Werkwijze, hoe is het gegaan, etc etc==