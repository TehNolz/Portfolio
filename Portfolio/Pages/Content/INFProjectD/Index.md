# Project D : FireChat

Voor het vierde en laatste project van mijn Informatica opleiding op de Hogeschool Rotterdam, kregen wij de opdracht om met behulp van een _emerging technology_ een probleem op te lossen voor de Rotterdam-Rijnmond Meldkamer.

De meldkamer gaf aan dat zij de volgende communicatieproblemen hadden;

* De berichten die zij naar medewerkers moesten sturen waren vaak te lang, waardoor veel van de medewerkers niet het (hele) bericht lazen.  
* Er waren te veel WhatsApp groepen voor de projecten waar de meldkamer aan werkte. Dit maakte communicatie soms lastig omdat het niet altijd duidelijk was wanneer en waar een bericht was geplaatst.
* De verschillende documenten (zoals notulen) waren vaak te onduidelijk, en er was geen centrale plek om deze op te slaan en te beheren.

Ik heb samen met de andere studenten onderzoek gedaan naar welke technologie wij konden gebruiken om deze problemen op te lossen. Wij kwamen uit bij de volgende drie ideeën;

* Blockchain zou kunnen worden gebruikt voor het bijhouden van chatberichten. Ook zouden hiermee backups van bestanden kunnen worden gemaakt.
* Machine Learning zou kunnen worden gebruikt om automatisch lange teksten samen te vatten, en om de belangrijkste informatie er uit te halen.
* Self-Healing System Technology zou de kans op storingen binnen een systeem aanzienlijk kunnen verlagen, door zelf problemen op te sporen en deze te repareren.

Uiteindelijk hebben wij besloten om een webapplicatie te bouwen met een chat functie. Dit zou de werknemers van de meldkamer de mogelijkheid geven om vanaf elk apparaat met hun collegas te kunnen communiceren. Door gebruik te maken van Self-Healing System Technology (SHST) kunnen wij garanderen dat dit systeem vrijwel altijd beschikbaar zal zijn, wat erg belangrijk is voor organisaties die levensreddende taken uitvoeren zoals de meldkamer.

Het resultaat is een webapplicatie genaamd _FireChat_. Het systeem heeft de volgende functies;  

* Een chat, waarmee gebruikers gemakkelijk met elkaar kunnen communiceren. Beheerders kunnen gemakkelijk chatgroepen aanmaken, aanpassen, en verwijderen om zo de chatgroepen georganiseerd te houden.
* Een nieuwsfeed, waarmee belangrijke berichten gemakkelijk kunnen worden gedeeld.
* Een ingebouwd load balancer systeem, die;
  * Automatisch het binnenkomend verkeer verspreidt over een netwerk van servers.
  * De mogelijkheid geeft om automatisch servers aan het netwerk toe te voegen of te verwijderen, om zo de capaciteit van het systeem aan te passen. Ook als een server onverwachts uitvalt, dan kan het systeem hier normaal mee omgaan.
  * De database van het systeem automatisch repliceert naar alle servers in het netwerk.

De backend van het systeem is gebaseerd op de webserver waar ik tijdens [Project C](Content/INFProjectC) aan heb gewerkt, en op de Web API waar ik tijdens [Project B](Content/INFProjectB) mee bezig ben geweest. Deze backend is te vinden [op GitHub](https://github.com/TehNolz/ProjectD).

De frontend van het systeem is gemaakt met React, en is te vinden [op GitHub](https://github.com/avie0108/ProjectDFrontEnd)