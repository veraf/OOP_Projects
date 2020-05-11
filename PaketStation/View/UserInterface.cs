#region Dateikopf
/* Autorin		: Fanny Vera
 * Datum		: 30.10.2019
 * Datei		: UserInterface.cs
 * Klasse		: IA118
 * Beschreibung : Klasse UserInterface
 * 
 * */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaketStation
{
    public class UserInterface
    {
        #region Eigenschaften
        private string _Text;
        private List<Paket> _Liste;
        private ConsoleKeyInfo _Input;
        #endregion

        #region Accesoren/Modifier
        public string Text { get => _Text; set => _Text = value; }
        internal List<Paket> Liste { get => _Liste; set => _Liste = value; }
        public ConsoleKeyInfo Input { get => _Input; set => _Input = value; }
        #endregion

        #region Konstruktoren
        public UserInterface()
        {
            this.Text = "";
            this.Liste = null;
        }
        public UserInterface(string value1)
        {
            this.Text = value1;
        }
        public UserInterface(UserInterface value)
        {
            this.Text = value.Text;
            this.Liste = value.Liste;
            this.Input = value.Input;
        }
        #endregion

        #region Worker
        public void SplashAusgeben()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Autorin           :     Fanny Vera");
            Console.WriteLine("Herstellungsdatum :     30.10.2019");
            Console.WriteLine("Beschreibung      :     PaketShop-Programm zum Versenden und Abholen");
            Console.WriteLine("                        von Paketen für Kunden und Mitarbeiter. ");
            Console.WriteLine("--------------------------------------------------------------------");
            Thread.Sleep(2000);
            Console.Clear();
        }
        public void loginAufforderung(ref string Benutzername, ref string Passwort)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------");
            Console.WriteLine("Authentifizieren Sie sich ");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Benutzername:		");
            Benutzername = TextEinlesen();
            Console.WriteLine("Passwort:		");
            Passwort = TextEinlesen();
        }
        public void TextAusgeben(string value)
        {
            this.Text = value;
            Console.WriteLine(this.Text);
        }
        public bool WeiterESC()
        {
            bool ergebnis = false;
            while (!Console.KeyAvailable) ;
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape)
            {
                ergebnis = true;
            }
            else
            {
                ergebnis = false;
            }
            return ergebnis;
        }
        public void WeitermitTaste()
        {
            Console.WriteLine();
            this.TextAusgeben("Weiter mit einer beliebigen Taste.");
            while (!Console.KeyAvailable) ;
            Console.ReadKey();
        }
        public string KundenMenueAnzeigen()
        {
            string Eingabe = "";

            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("   Hauptmenü Kunde");
            Console.WriteLine("----------------------");
            Console.WriteLine("(1) Paket versenden");
            Console.WriteLine("(2) Paket abholen");
            Console.WriteLine("(3) Ausloggen");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            Console.WriteLine("Zahl auswählen und mit enter bestätigen.");
            while (!Console.KeyAvailable) ;
            Eingabe = Console.ReadLine();

            return Eingabe;
        }
        public string MitarbeiterMenueAnzeigen()
        {
            string eingabe = "";
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("  Hauptmenü Mitarbeiter");
            Console.WriteLine("-----------------------");
            Console.WriteLine("(1) Paket versenden");
            Console.WriteLine("(2) Paket abholen");
            Console.WriteLine("(3) Paket listen");
            Console.WriteLine("(4) Ausloggen");
            Console.WriteLine("-----------------------");
            Console.WriteLine("(0) Programm verlassen");
            Console.WriteLine();

            Console.WriteLine("Zahl auswählen und mit enter bestätigen.");
            while (!Console.KeyAvailable) ;
            eingabe = Console.ReadLine();

            return eingabe;
        }
        public string GeschaeftsfuehrerMenueAnzeigen()
        {
            string eingabe = "";
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("  Hauptmenü Geschäftsführer");
            Console.WriteLine("----------------------------");
            Console.WriteLine("(1) Kunde verwalten");
            Console.WriteLine("(2) Mitarbeiter verwalten");
            Console.WriteLine("(3) Stationen verwalten");
            Console.WriteLine("(4) Kunden listen");
            Console.WriteLine("(5) Mitarbeiter listen");
            Console.WriteLine("(6) Loggout");
            Console.WriteLine("----------------------------");
            Console.WriteLine("(0) Programm verlassen");
            Console.WriteLine();

            Console.WriteLine("Zahl auswählen und mit enter bestätigen.");
            while (!Console.KeyAvailable) ;
            eingabe = Console.ReadLine();

            return eingabe;
        }
        public string MenuKundeVerwalten()
        {
            string Eingabe = "";
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("  Untermenü Kunde Verwaltung");
            Console.WriteLine("----------------------------");
            Console.WriteLine("(1) Kunde hinzufügen");
            Console.WriteLine("(2) Kunde entfernen");
            Console.WriteLine("(3) Züruck");
            Console.WriteLine("----------------------------");
        
            Console.WriteLine();

            Console.WriteLine("Zahl auswählen und mit enter bestätigen.");
            while (!Console.KeyAvailable) ;
            Eingabe = Console.ReadLine();

            return Eingabe;
        }
        public string MenuMitarbeiterVerwalten()
        {
            string Eingabe = "";
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("  Untermenü Mitarbeiter Verwaltung");
            Console.WriteLine("----------------------------");
            Console.WriteLine("(1) Mitarbeiter hinzufügen");
            Console.WriteLine("(2) Mitarbeiter entfernen");
            Console.WriteLine("(3) Züruck");
            Console.WriteLine("----------------------------");
            
            Console.WriteLine();

            Console.WriteLine("Zahl auswählen und mit enter bestätigen.");
            while (!Console.KeyAvailable) ;
            Eingabe = Console.ReadLine();

            return Eingabe;
        }
        public string MenuStationenVerwalten()
        {
            string Eingabe = "";
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("  Untermenü Stationen Verwaltung");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("(1) Station hinzufügen");
            Console.WriteLine("(2) Station entfernen");
            Console.WriteLine("(3) Station erweitern");
            Console.WriteLine("(4) Züruck");
            Console.WriteLine("----------------------------");
        
            Console.WriteLine();

            Console.WriteLine("Zahl auswählen und mit enter bestätigen.");
            while (!Console.KeyAvailable) ;
            Eingabe = Console.ReadLine();

            return Eingabe;
        }
        public string ErweiterungsMenu()
        {
            string Eingabe = "";
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("  Stationen Erweiterung");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("(1) Fach hinzufügen");
            Console.WriteLine("(2) Fach entfernen");
            Console.WriteLine("(3) Züruck");
            Console.WriteLine("----------------------------");

            Console.WriteLine();

            Console.WriteLine("Zahl auswählen und mit enter bestätigen.");
            while (!Console.KeyAvailable) ;
            Eingabe = Console.ReadLine();

            return Eingabe;
        }
        public void PaketezumAbholenAuflisten(List<Paket> Pakete, bool abholen)
        {
            int index = 1;
            if (abholen)
            {
                Console.Write("Folgende Pakete sind abzuholen: " + "\n");
            }
            else
            {
                Console.Write("Folgende Pakete wurden geliefert:" + "\n");
            }
            foreach (Paket p in Pakete)
            {
                Console.Write(index + " Paket: " + p.EmpfangerName + ", in Fach Nr: " 
                        + p.PaketFachNr + "\r\n");
                index++;
            }
        }
        public string TextEinlesen()
        {
            this.Text = Console.ReadLine();
            return this.Text;
        }
        public void TextEingeben(ref string Value, string Text)
        {
            Console.Write(Text);
            this.Text = Convert.ToString(Console.ReadLine());
            Value = this.Text;
        }
        public void Willkommen(Paketstation aktuelle)
        {
            string zusatz = "\n" + "Sie befinden sich an der Station " +
                    aktuelle.getID() + " mit " + aktuelle.Faecher.Count + " Fäecher.";
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("                    Willkommen");
            Console.WriteLine("---------------------------------------------------");
            TextAusgeben(zusatz);
            WeitermitTaste();
        }
        #endregion
    }
}


