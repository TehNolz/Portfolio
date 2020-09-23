# Intro

Deze repository bevat een webapplicatie dat ik gemaakt heb als bewijsmateriaal voor verschillende leerdoelen waar ik tijdens mijn 3rdejaars stage aan gewerkt heb. Zie mijn Portfolio voor meer informatie.

De webapplicatie is te vinden op het volgende address; TODO: Add URL

# Leerdoelen

## Leerdoel 2 - Nieuwe Technologie
Dit voorbeeldprogramma is gemaakt met [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor), een onderdeel van het ASP.NET Core framework. Deze technologie geeft ontwikkelaars de mogelijkheid om websites te bouwen die gebruik maken van C# in plaats van JavaScript.

Op het moment zijn er twee varianten van Blazor beschikbaar. De eerste variant is Blazor Server, waarbij alle C# code op de server wordt uitgevoerd. De browser download alleen een klein JavaScript package, en gebruikt deze om via een zogehete *SignalR* verbinding te maken met de server. Alle acties van de client (bijvoorbeeld button clicks) en alle UI updates van de server worden via deze verbinding verzonden. Deze variant kan echter niet worden gebruikt samen met GitHub Pages, aangezien er een aparte server voor nodig is.

De tweede variant is Blazor WebAssembly. Deze variant stuurt de gehele Blazor applicatie, alle dependencies, en een kleine versie van de .NET Runtime naar de browser. De gehele applicatie wordt dan uitgevoerd binnen de browser, net zoals de meeste websites dit doen. In tegenstelling tot Blazor Server kan Blazor WebAssembly wel worden gebruikt samen met GitHub Pages. Om deze reden gebruikt de voorbeeldapplicatie in deze repository daarom ook Blazor WebAssembly.

Voor meer informatie over de twee Blazor varianten, zie [ASP.NET Core Blazor hosting models](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-3.1).

## Leerdoel 5 - Testen
TODO

## Leerdoel 7 - Design Patterns
Tijdens het zoeken naar informatie voor Project A t/m D ben ik meerdere malen de term *Design Patterns* tegen gekomen. Omdat ik er nooit echt achter was gekomen wat deze term precies inhield, heb ik besloten om hier een leerdoel van te maken.

Om het kort uit te leggen; een Design Pattern is een generieke en daarom herbruikbare manier om een bepaald project te bouwen. Het is een soort sjabloon die ontwikkelaars kunnen gebruiken bij het ontwerpen van hun systeem, ongeacht van wat voor een systeem dit precies is.

Neem bijvoorbeeld de *Model, View, Controller* (MVC) design pattern. Deze design pattern wordt voornamelijk gebruikt voor het bouwen van websites, maar kan ook voor andere applicaties worden gebruikt. Software die MVC gebruiken zijn altijd opgebouwd uit 3 verschillende lagen;
* De *Model* laag, die aangeeft hoe de data die het programma is gestructureerd,
* De *View* laag, die de verschillende interfaces en menus bevat die de gebruiker zal zien en gebruiken,
* De *Controller* laag, die de communicatie tussen de andere twee lagen faciliteerd.  
  
In dit voorbeeldprogramma heb ik gebruik gemaakt van *Dependency Injection*, een design pattern waarbij dependencies van een applicatie worden geinjecteerd in plaats van dat deze direct aan de applicatie worden gekoppeld. Dit maakt het makkelijker om bepaalde applicaties te testen, omdat dependencies die normaalgesproken complexe taken uitvoeren gemakkelijk kunnen worden nagebootst.

TODO: Explain usage in this program

## Leerdoel 8 - CI/CD
TODO: Explain CI/CD

Doormiddel van GitHub Actions heb ik in deze repository een dergelijke CI/CD Pipeline opgezet. Elke keer dat ik de code van mijn webapplicatie verander, zullen de volgende taken automatisch worden uitgevoerd;
* TODO: Add CI/CD steps
