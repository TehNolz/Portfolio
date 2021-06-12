# Connect 4

In het eerste jaar van mijn Informatica opleiding kregen wij voor het vak Analyse de opdracht om het spel Vier-op-een-Rij (Connect 4) na te maken in Python met Turtle Graphics. De enige eis was dat twee spelers op dezelfde computer een geheel potje Vier-op-een-rij moesten kunnen spelen.

Deze opdracht bleek voor mij vrij makkelijk te zijn. Ik was na ongeveer een week al klaar, terwijl ik 8 weken de tijd had. Ik besloot daarom om wat extra functionaliteit aan mijn applicatie toe te voegen. Mijn uiteindelijke applicatie had de volgende functionaliteit;

* Ondersteuning voor maximaal 8 spelers tegelijk.
* Een simpele AI. Deze AI werkte als volgt;
  * Aan het begin van zijn ronde controleerde hij of er ergens een kans was om te winnen. Zo ja, dan ging hij direct voor deze kans.
  * Mocht hij in de huidige ronde niet kunnen winnen, dan zal hij controleren of een andere speler zou kunnen winnen. Mocht hij iets vinden, dan zal hij dit proberen te voorkomen.
  * Als geen enkele speler de kans heeft om te winnen, dan zal hij een willekeurige zet doen.
* Multiplayer over lokale netwerken, tot 8 spelers.
* Spectator Mode, waarmee spelers kunnen meekijken bij multiplayer potjes van andere spelers.
* Een hoofdmenu,
* Een bord met een aanpasbare hoogte en breedte.

Het programma is te vinden [op GitHub](https://github.com/TehNolz/connect4). Helaas bevat het programma meerdere bugs die ik toentertijd niet heb kunnen op te lossen.