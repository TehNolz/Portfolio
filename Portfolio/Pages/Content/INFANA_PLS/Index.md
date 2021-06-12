
# Public Library System

Als onderdeel van het vak Analyse van mijn Informatica opleiding, heb ik een Public Library System ontwikkeld. Dit programma had de volgende eisen;

* Het systeem moest bibliotheekmedewerkers in staat stellen om boeken, klanten, en nieuwe medewerkers toe te voegen.  
* Het systeem moest gebruikers in staat stellen om een overzicht van alle boeken te kunnen zien, hierdoor te kunnen zoeken, en deze boeken vervolgens te lenen  
* Het systeem moest gegevens over boeken en klanten kunnen importeren uit JSON en CSV bestanden.
* Het systeem moest alle bovengenoemde data kunnen opslaan naar een JSON bestand. Ook moest het systeem dit zelfde soort JSON bestanden kunnen lezen om de data weer te laten.
* Het systeem moest gebruik maken van Object-Oriented Programming, wat betekende dat het classes nodig had voor boeken, klanten, medewerkers, etc.

De opdracht raadde aan om een console applicatie in Python te maken, maar andere programmeertalen en frameworks waren ook toegestaan mits de leraar dit goedkeurde. Omdat ik meer over C# wilde leren, heb ik besloten om de opdracht te maken met behulp van Windows Forms. Ook heb ik extra functionaliteit toegevoegd, zoals de mogelijkheid om automatisch data op te slaan en te laden.  

![](Assets/Images/PLS_image.png)  

^De boeken pagina van mijn Public Library System, zoals deze er voor medewerkers er uit ziet.^

Omdat .NET Framework geen (goede) ingebouwde manier heeft om met JSON bestanden te werken, heb ik gebruik gemaakt van de Newtonsoft Json.NET library. Achteraf bleek dit een goede keuze, omdat ik deze zelfde library later bij vrijwel elk project nodig had. De kennis die ik over deze library tijdens deze opdracht had opgedaan kwam daarom goed van pas.

Mijn applicatie, inclusief broncode, is te vinden [op GitHub](https://github.com/TehNolz/PLS).