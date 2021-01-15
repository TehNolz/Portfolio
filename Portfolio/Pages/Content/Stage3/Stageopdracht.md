# Het CRM

Ranshuijsen heeft op het moment een zelfgemaakte Custom Relations Management (CRM) systeem in gebruik. Hierin beheren zij allerlei verschillende zaken, zoals bijvoorbeeld;
* Gegevens van klanten, zoals contactpersonen, adressen, en andere data,
* Werkuren, vakantiedagen, ziekteverlof, e.d. van medewerkers.
* De inventarisatie van alle elektronica en hardware binnen het bedrijf.
* Binnengekomen Support Tickets
* Financiele en operationale rapportages

Dit systeem is puur voor intern gebruik, waardoor het wordt beschouwd als een soort zandbak waarin medewerkers kunnen experimenteren met nieuwe technologieën en ideeën. Omdat het systeem niet buiten Ranshuijsen wordt gebruikt, is het geen probleem als er tijdens deze experimenten iets mis gaat. Als er namelijk een fout wordt ontdekt in het systeem, dan kunnen zij dit zelf direct oplossen. Ook wordt het systeem gebruikt voor het inwerken van nieuwe medewerkers, zodat zij aan de bedrijfsomgeving kunnen wennen zonder dat zij direct met klanten moeten werken.

# Waarom Blazor?
Omdat Ranshuijsen veel oude (_legacy_) code onderhield waar ze vanaf wilde, hebben zij besloten om over te stappen naar een nieuwe, moderne softwarearchitectuur met nieuwe features. Zij hebben besloten om over te stappen naar Blazor, omdat zij verwachten dat Blazor het _platform voor de toekomst_ zal worden. Zij denken dat Blazor zeer voordelig zal zijn voor hun klanten.

Het grootste voordeel van Blazor voor Ranshuijsen is dat het een onderdeel is van ASP.NET Core, het webframework dat Ranshuijsen voorheen veel gebruikte voor hun projecten. Dit maakt het mogelijk om geleidelijk de oude systemen te migreren naar Blazor, waardoor het voor Ranshuijsen niet nodig is om tijdens de migratie twee losse systemen te onderhouden.

# Mijn taken

Op het moment is het systeem gemaakt met .NET Framework en ASP.NET MVC. In een poging om alle systemen van Ranshuijsen met elkaar consistent te houden, is er besloten om ook het CRM systeem over te zetten naar .NET 5 en Blazor. Als onderdeel van mijn stage ga ik hen hierbij ondersteunen, waarbij ik de volgende taken zal uitvoeren;

* Het onderzoeken van Blazor (beide client- en serverside)
* Het migreren van de oude ASP.NET MVC applicatie naar ASP.NET Core MVC
* Nieuwe, nog niet bestaande functionaliteit ontwerpen, implementeren, en testen, waaronder;
    * Een planningsmodule, waarin medewerkers van week tot week de planningen voor de verschillende projecten van Ranshuijsen kunnen inzien en beheren.
    * Een projectmodule, met daarin de mogelijkheid om product breakdowns op te zetten inclusief urenschattingen.
    * Een brievenboek module, waarmee documenten kunnen worden gegenereerd, bewaard, en gekoppeld aan onderwerpen zoals projecten, klanten, producten, of combinaties hiervan.
* Het meehelpen met de deployment van het vernieuwde systeem.

# Uitvoering

## CRM Onderzoek  
Ik ben met mijn stageopdracht begonnen door te onderzoeken hoe het CRM systeem precies werkt en hoe het is opgebouwd. Dit was vooral nodig omdat ik voor deze stageopdracht nog nooit met ASP.NET of vergelijkbare technologieen had gewerkt, waardoor ik geen idee had hoe het hele systeem in elkaar zat.

Dit onderzoek was ook gelijk een van mijn leerdoelen. Hoe ik te werk ben gegaan en wat de resultaten van dit onderzoek zijn staat daarom ook beschreven op de pagina [Leerdoel 3 - Projecten Analyseren](Content/Stage3/Leerdoelen/3).

## RvlCrmLibrary omzetten
Zoals beschreven in [Leerdoel 8 - Nieuwe Technologie](Content/Stage3/Leerdoelen/8) is Blazor een onderdeel van ASP.NET Core, die gemaakt is met behulp van .NET 5. Dit betekent echter dat het niet compatibel was met .NET Framework, waar het CRM voorheen op draaide. Om het CRM om te kunnen zetten naar Blazor, was het daarom nodig om het gehele systeem eerst om te zetten naar .NET 5.  
  
Ook werd de migratie nog complexer omdat het CRM gebruik maakte van het `Rvl.CommonLibrary` pakket dat Ranshuijsen had ontwikkeld. Ook dit paket was niet compatibel met het nieuwe .NET 5, en moest worden vervangen. Ranshuijsen heeft daarom een opvolger (`Rvl.Foundation`) op dit pakket ontwikkeld, die tijdens de migratie in het CRM moest worden geintegreerd. Veel van de functies en classes in het oude pakket waren echter aangepast, verplaatst, of zelfs verwijderd, waardoor er ook redelijk veel aanpassingen aan de CRM code nodig waren alles werkend te krijgen.

Ik ben met dit deel van de migratie begonnen door het _RvlCrmLibrary_ component van het CRM om te zetten naar .NET 5. Zoals beschreven in [Leerdoel 3](Content/Stage3/Leerdoelen/3) bevat dit onderdeel alle datatypes van het systeem, inclusief de code die deze datatypes ophaalt uit- en opslaat in de database. Om dit onderdeel over te zetten heb ik een nieuw component aan het CRM toegevoegd, die ik _RvlCrmLibrary-core_ noemde. Ik kopieerde vervolgens de `AppUser` class (het datatype dat gebruikers representeerd) uit _RvlCrmLibrary_ naar dit nieuwe component, en ben alle errors hierin gaan oplossen. Omdat veel van deze errors werden veroorzaakt door datatypes die niet bestonden in het nieuwe component, ben ik 1 voor 1 alle missende datatypes gaan overzetten. Ook ben ik hierbij bezig geweest met het opruimen en "mooi maken" van de code.

Ook waren er veel errors opgetreden omdat `Rvl.CommonLibrary` niet meer bestond. Door gebruik te maken van de "Add missing references" tool in [Resharper](https://www.jetbrains.com/resharper/) heb ik een groot deel van deze errors met gemak kunnen oplossen. Zoals eerder genoemd zijn veel van de missende functies en datatypes die voorheen in `Rvl.CommonLibrary` zaten verplaatst naar het nieuwe `Rvl.Foundation`, waardoor deze errors opgelost konden worden door simpelweg de referenties aan te passen.

De errors die werden veroorzaakt door missende of hernoemde functionaliteit heb ik opgelost door in `Rvl.Foundation` te zoeken naar alternatieven. Errors die werden veroorzaakt door aangepaste functies heb ik opgelost door de code zodanig aan te passen dat de functies weer correct worden aangeroepen.

Uiteindelijk is het mij gelukt om een .NET 5 versie van het _RvlCrmLibrary_ component te maken.

## Blazor experimenten

De volgende stap in het migratieproces was om paginas over te zetten naar Blazor. Omdat ik voor een directe migratie wilde gaan, heb ik hiervoor een nieuw component aan het CRM toegevoegd, genaamd _RvlCrmWeb-core_. Dit component zou een nieuwe versie van _RvlCrmWeb_ worden, het component waar alle webpaginas van het CRM in stonden.

Dit component heb ik aangemaakt met behulp van de _Blazor Server_ sjabloon van Visual Studio. Alles wat ik nodig had om met Blazor te werken werd daarmee automatisch voor mij opgezet, waardoor ik gelijk aan de slag kon gaan met het overzetten van verschillende paginas.

De eerste pagina die ik had overgezet was de loginpagina van het systeem. Hiervoor moest ik een geheel nieuw loginsysteem opzetten, omdat het oude systeem niet werkte in Blazor. Dit heb ik gedaan met behulp van de Microsoft ASP.NET Core documentatie, tips van andere ontwikkelaars van Ranshuijsen, en een ander project van Ranshuijsen dat ik als voorbeeld kon gebruiken.

Vervolgens heb ik verschillende kleine paginas 1 voor 1 overgezet. Dit waren vooral kleine, simpele paginas, zoals bijvoorbeeld de pagina waar medewerkers declaraties kunnen indienen of de pagina waar de hardware inventaris van Ranshuijsen wordt beheert. Ik ben bij de simpele paginas begonnen omdat ik nog weinig ervaring had met Blazor, waardoor de meer complexere paginas net te moeilijk waren om over te zetten. De designs voor de vernieuwde paginas waren op dit moment nog niet klaar, waardoor ik ze nog niet kon implementeren.

### Authenticatie
In principe bestond het CRM nu uit twee websites; de oude ASP.NET MVC website, en de vernieuwde Blazor website. Beide websites hadden echter hun eigen inlogsysteem, wat betekende dat gebruikers twee keer zouden moeten inloggen om beide systemen te kunnen gebruiken. Dit was natuurlijk onhandig voor de gebruiker, en dit moest daarom worden opgelost.

Ik heb een aantal dagen besteed aan het zoeken naar een oplossingen, en heb mijn vindingen verwerkt in een ontwerpdocument waarin ik de twee mogelijkheden beschreef die ik had bedacht. Dit document kon ik ook gelijk gebruiken als bewijsmateriaal voor [Leerdoel 6](Content/Stage3/Leerdoelen/6). De mogelijkheden die ik had gevonden zijn als volgt;  
  
1. Het was mogelijk om de inlogpagina van het oude systeem te koppelen met het inlogsysteem van de Blazor website. Hiervoor hadden wij echter een API Endpoint nodig in de Blazor website, terwijl je over het algemeen geen API gebruikt in Blazor.
2. Het was mogelijk om de nieuwe loginpagina van de Blazor website te koppelen met het oude inlogsysteem. Hier konden wij de bestaande API Endpoint in het oude systeem voor gebruiken.

Uiteindelijk heeft mijn bedrijfsbegeleider besloten om voor de tweede optie te kiezen. Ik ben vervolgens hiermee aan de slag gegaan, en het was mij redelijk snel gelukt om beide inlogsystemen op deze manier met elkaar te koppelen.

## Geleidelijke migratie
Op een gegeven moment werd er een andere medewerker van Ranshuijsen bij het project gehaald, zodat hij ook mee kon werken. Dit omdat het CRM een enorm systeem is met ruim 90 paginas, wat simpelweg te veel is voor 1 persoon om te migreren.

Deze medewerker had echter andere ideeen over hoe deze migratie het beste kon worden uitgevoerd. Hij stelde voor om geleidelijke migratie te doen. In plaats van dat we alles in 1 keer gingen overzetten, zouden we geleidelijk alle paginas overzetten. Dit zou voorkomen dat wij problemen krijgen met het beheren van twee CRM websites tegelijkertijd, zoals bijvoorbeeld het eerdergenoemde inlogprobleem. We hebben dit voorstel tijdens een meeting met mijn bedrijsbegeleider besproken, en hebben uiteindelijk besloten om een geleidelijke migratie te doen zoals voorgesteld.

## Migratie naar ASP.NET Core.
 Een geleidelijke migratie betekende echter dat de huidige _RvlCrmWeb_ component eerst moest worden overgezet naar ASP.NET Core alvorens we het naar Blazor konden migreren. Ik heb dit gedaan door een nieuw component aan te maken met behulp van de ASP.NET Core sjabloon, alle bestanden van _RvlCrmWeb_ hiernaar te verplaatsen, het oude _RvlCrmWeb_ te verwijderen, en tot slot het nieuwe component te hernoemen naar _RvlCrmWeb_. Dit zorgde voor meer dan tweeduizend errors die opgelost moesten worden.

Net zoals bij het _RvlCrmLibrary_ component, moest _RvlCrmWeb_ gebruik maken van `Rvl.Foundation`. Ook hier kreeg ik problemen met functies die waren hernoemd, aangepast, of verwijderd. Ik heb deze problemen op dezelfde manier opgelost als dat ik dit bij _RvlCrmLibrary_ had gedaan. _RvlCrmWeb_ gebruikte echter veel verschillende functies van `Rvl.Foundation`, waarvan een groot deel was verwijdert. Om dit op te lossen heb ik delen van `Rvl.CommonLibrary` direct in het CRM project geplaatst, om zo alles alsnog werkend te krijgen.  

Er zit een enorm verschil tussen het oude ASP.NET MVC en het nieuwe ASP.NET Core. Veel errors werden dan ook veroorzaakt door ASP.NET functionaliteit die verwijdert of aangepast was. De deel van deze errors heb ik kunnen oplossen doormiddel van de ASP.NET Core documentatie en websites zoals StackOverflow. Een groot deel van de errors werd echter veroorzaakt door de authenticatie en authorizatie delen van het CRM, die dankzij de wijzigingen in ASP.NET Core niet meer werkte. Ik ben daarom een tijd bezig geweest om het gehele inlogsysteem om te gooien. Hierbij heb ik ook hulp gekregen van een medewerker van Ranshuijsen, die recent een soortgelijke migratie had gedaan bij een ander project.  
  
Ook het configuratiesysteem moest worden aangepast. De instellingen van het CRM werden namelijk opgeslagen in XML bestanden, terwijl elk ander systeem van Ranshuijsen met JSON bestanden werkt. Met behulp van de Microsoft documentatie en enkele tips van een medewerker van Ranshuijsen is het gelukt om een nieuw configuratiesysteem op te zetten voor het CRM.

Na ruim twee weken te werken, heb ik alle errors op weten te lossen, waardoor het systeem eindelijk weer opgestart kon worden.  

## Bugfixes
Dat het systeem kan worden opgestart, betekent natuurlijk niet dat alles naar behoren werkt. Er zaten nog veel fouten in het systeem die ontdekt en opgelost moesten worden. Ik heb daarom ook een lange tijd besteed aan het testen van het systeem, en aan het oplossen van eventuele problemen die ik ben tegengekomen. De meest noemenswaardige problemen zijn hieronder beschreven;  
  
1. Alle CSS bleek niet meer te werken. Dit kwam omdat de `.LESS` bestanden waar de CSS in stond niet meer werden gecompileerd naar CSS. Een medewerker van Ranshuijser had mij verteld dat ik het beste al deze bestanden kon overzetten naar `.SCSS`, omdat Ranshuijsen dit tegenwoordig voor alle andere projecten is gaan gebruiken. Deze bestanden kon ik vervolgens laten compileren met behulp van de _WebCompiler_ extensie voor Visual Studio.  
2. Ook was er een probleem met de CSS van de inlogpagina. Het systeem weigerde deze naar de browser te sturen omdat de gebruiker op dat moment niet was ingelogd. Ik heb deze beveiliging uitgezet voor statische bestanden, zodat de CSS wel naar behoren werkt.
3. Er ontstonden errors op meerdere paginas omdat zij niet meer informatie over de huidig ingelogde gebruiker konden ophalen. Dit heb ik opgelost door deze paginas te koppelen aan het eerder genoemde vernieuwde inlogsysteem.
4. Ook in de JavaScript code van het CRM waren fouten opgetreden. Zo konden sommige paginas niet goed data versturen naar het CRM, en ontstonden er errors op andere paginas omdat bepaalde functies niet meer konden worden gevonden. Ook al heb ik zelf weinig ervaring met JavaScript, is het mij toch gelukt om deze errors op te lossen.

# Planning
Aan het begin van mijn stage heb ik een planning gemaakt die beschrijft hoe lang ik verwacht met elk van de bovenstaande taken bezig te zijn. Deze planning is als volgt;

+---------+--------------------------------------+-----------------------------------------------------------------------------+
| *Week*  | *Leerdoel*                           | *Activiteit* 
+=========+======================================+=============================================================================+
|**OP1**  |                                      |              
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 1       | 10, 9, 3, 1, Algemeen, Stageopdracht | * Informatiebeveiligingscursus en Onboarding Nieuwe Medewerker modules maken. Bewijs hiervan verwerken in portfolio.
|         |                                      | * Stageplan opzetten met goeie opmaak
|         |                                      | * CRM-systeem analyseren
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 2       | 3, 1, 10, Algemeen, Stageopdracht    | * Stageplan verbeteren.
|         |                                      | * CRM backend overzetten naar .NET Core.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 3       | 3, 1, Stageopdracht	                 | * CRM backend overzetten naar .NET Core.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 4       | 3, 1, 10, Stageopdracht              | * Afronden overzetten CRM backend naar .NET Core (indien nodig)
|         |                                      | * Document opzetten dat de werking van het huidige CRM-systeem beschrijft, en deze in portfolio verwerken.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 5       | 10, 4, 2, 3, 1, Stageopdracht        | * Document CRM-beschrijving afmaken (indien nodig)
|         |                                      | * CRM-homepagina overzetten naar .NET Core
|         |                                      | * Opzetten adviesrapport Blazor en verwerken in portfolio.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 6       | 10, 4, 2, 1, Stageopdracht           | * CRM-homepagina overzetten naar Blazor
|         |                                      | * Adviesrapport Blazor afmaken (indien nodig)
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 7       | 10, 4, 2, 1, Stageopdracht           | * Afronden overzetten CRM-homepagina naar Blazor (indien nodig)
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 8       | 4, 2, 1, Stageopdracht               | * Overige CRM-pagina’s overzetten naar Blazor
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 9       | 4, 2, 1, Stageopdracht               | * Overige CRM-pagina’s overzetten naar Blazor
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 10      | 7, 2, 1, Stageopdracht               | * Implementeren van planningsmodule in CRM.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
|**OP2**  |                                      |
+---------+--------------------------------------+-----------------------------------------------------------------------------+     
| 1       | 7, 2, 1, Stageopdracht               | * Implementatie planningsmodule afronden (indien nodig) 
|         |                                      | * Implementeren projectmodule in CRM
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 2       | 7, 2, 1, Stageopdracht               | * Implementatie projectmodule afronden (indien nodig)
|         |                                      | * Implementeren brievenboekmodule in CRM
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 3       | 7, 2, 1, Stageopdracht               | * Implementatie brievenboekmodule afronden (indien nodig)
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 4       | 10, 5, 1, Stageopdracht              | * Testrapport opstellen en in portfolio verwerken.
|         |                                      | * Geschreven (en gewijzigde) code testen m.b.v. Unit Tests. Code snippets hiervan verwerken in portfolio.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 5       | 7, 2, 1, Stageopdracht               | * Uitlooptijd implementatie CRM-modules (indien nodig). 
|         |                                      | * Dependency Injection code snippets verzamelen en in portfolio verwerken.
|         |                                      | * Klein demonstratieprogramma opzetten om Blazor te demonstreren, en deze verwerken in portfolio.
|         |                                      | * Onderzoeksrapport schrijven over hoe ik Blazor heb onderzocht, en deze in portfolio verwerken.
|         |                                      | * Screenshots van het gebruik van SVN repositories in portfolio verwerken.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 6       | 8, Stageopdracht                     | * Meehelpen met de deployment van het nieuwe systeem. Bewijs hiervan verwerken in portfolio.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 7       | 6, 10                                | * Technisch ontwerp van nieuw (fictief) systeem opzetten.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 8       | 6, 10                                | * Technisch ontwerp van nieuw (fictief) systeem opzetten. Document in portfolio verwerken.
|         |                                      | * Portfolio afronden.
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 9       | 1 t/m 10, Stageopdracht              | * Uitloopweek
+---------+--------------------------------------+-----------------------------------------------------------------------------+
| 10      | 1 t/m 10, Stageopdracht              | * Uitloopweek
+---------+--------------------------------------+-----------------------------------------------------------------------------+  
  
Het is mij echter niet gelukt om mij aan deze planning te houden. Dit komt omdat ik in het begin mij niet realizeerde hoe groot het CRM daadwerkelijk was. Mijn account op de productieomgeving heeft niet genoeg rechten om bij alle paginas te kunnen komen, waardoor het net leek alsof het systeem veel kleiner was dan ik dacht. Pas toen ik deze planning had ingelevert en echt met mijn stageopdracht begon, zag ik dat het systeem ruim 4 keer groter is dan ik eerst dacht. Ook bleek de migratie naar .NET 5 moeilijker en complexer dan ik had gedacht. Ik had niet verwacht dat ik zo veel verschillende errors zou tegengekomen, en dat sommige van deze errors zo lastig zouden zijn om op te lossen.

Door deze stageopdracht heb ik wel veel geleerd over wat een migratie precies inhoudt, en wat hier voor nodig is. Mocht ik later tijdens mijn werk een soortgelijke opdracht krijgen, dan kan ik de kennis die ik tijdens mijn stage heb opgedaan hier goed voor gebruiken. Ik denk daarom ook dat nu ik weet hoe complex een migratie kan zijn, ik de volgende keer wel een veel nauwkeurigere planning hiervoor kan maken.


# Feedback bedrijfsbegeleider

*Zoals in de feedback op een aantal leerdoelen heb je laten zien dat je redelijk gestructureerd te werk kan gaan en dat je kunt volharden om een probleem op te lossen. De keuzes die je gemaakt hebt (al dan niet met hulp) tonen aan dat je een goede developer bent en dat complexiteit geen issue is voor jou.*  

# Reflectie
  
Ik vond dit een erg leuk, uitdagend, en vooral zeer interresant project om aan te werken. Ik ben heel veel nieuwe dingen tegengekomen; ik had nog nooit met ASP.NET gewerkt, ik had nog nooit met Blazor gewerkt, ik had nog nooit een migratie uitgevoerd, enzovoort. Ik heb na het uitvoeren van de taken die ik binnen dit project heb gedaan sowieso het idee dat ik dankzij deze stageopdracht een betere programmeur ben geworden. De kennis die ik tijdens mijn stage heb opgedaan zal dan ook erg goed van pas komen tijdens de rest van mijn studie, later tijdens mijn werk, en bij mijn eigen hobbyprojecten.

Helaas is het mij niet gelukt om de gehele stageopdracht af te ronden. Dit komt grotendeels door de schaal van het project. Vanaf het begin van mijn stage werd er al tegen mij verteld dat dit geen eenmansproject is, omdat het CRM systeem simpelweg te groot is. Halverwege mijn stage kreeg ik daarom ook hulp van een aantal andere medewerkers van Ranshuijsen, die een deel van het werk op zich namen. Zij zijn op dit moment nog steeds bezig met het afronden van dit project.