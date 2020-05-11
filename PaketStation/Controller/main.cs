#region Dateikopf
/* Autorin 	    : Fanny Vera
 * Datum        : 30.10.2019
 * Datei		: main.cs
 * Klasse       : IA118
 * Beschreibung : Hauptprogramm
 * Veränderungen: 
 * 04.11.2019     Klassen Eigenschaften und Funktionen angefangen
 * 12.11.2019     Klasse Paket erstellen und testen  
 * 19.11.2019     Klasse Paketfach erstellen und testen
 * 26.11.2019     UserInterface erstellt und getestet
 * 27.11.2019     IO und Kunde/Mitarbeiter Klassen verändern 
 * 01.12.2019     IO und Kunde/Mitarbeiter Klassen fertigstellen
 * 04.12.2019     mit dem Teste weiterarbeitet
 * 18.12.2019     Klasse Paketstation angefangen zu erstellen
 * 30.12.2019     Klasse Paketstation fertiggestellt und K. Controller weiter entwickelt
 * 05.01.2020     Klasse Controller fertiggestellt und Tests entwickelt
 * 07.01.2020     Version 1 vorl. abgeschlossen
 * 18.01.2020     Erweiterungen der Station angefangen
 * 27.01.2010     Extra-Erweiterungen entwickelt: Metacontroller Konzept nicht verstanden.
 * */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaketStation
{
    partial class main
    {
        static void Main(string[] args)
        {
            /* Hinweise: (BN = Benutzername PW = Passwort)
             * BN: admin, admin
             * BN: Test1, PW: 1234
             * BN: Kunde1, PW: 1111
             * BN: Kunde2, PW: 2222
             * BN: Kunde3, PW: 3333
             * BN: Mitarbeiter1, PW: 6666
             * BN: Mitarbeiter2, PW: Mitarbeiter2
             * BN: Mitarbeiter3, PW: Mitarbeiter3
             * */
            Controller Test = new Controller();
            Test.run();
        }
    }
}

