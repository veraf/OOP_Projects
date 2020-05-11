/* Autorin      : Fanny Vera
 * Datum        : 30.10.2019
 * Datei		: Controller.cs
 * Klasse      	: IA118
 * Beschreibung : Klasse Controller
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PaketStation
{
    public class Controller
    {
        #region Eigenschaften
        private List<Kunde> _personen;
        private List<Mitarbeiter> _mitarbeiter;
        private List<Paketstation> _stationen;
        private List<Geschaeftsfuehrer> _boss;
        private UserInterface _IO;
        private object _aktivUser;
        private Paketstation _aktuelleStation;
        private bool _Authentifiziert;
        private const int _max_Stationen = 100;
        #endregion

        #region Accessoren/Modifier
        public List<Kunde> Personen { get => _personen; set => _personen = value; }
        public List<Mitarbeiter> Mitarbeiter { get => _mitarbeiter; set => _mitarbeiter = value; }
        public List<Paketstation> Stationen { get => _stationen; set => _stationen = value; }
        public UserInterface IO { get => _IO; set => _IO = value; }
        public object AktivUser { get => _aktivUser; set => _aktivUser = value; }
        public Paketstation AktuelleStation { get => _aktuelleStation; set => _aktuelleStation = value; }
        public bool Authentifiziert { get => _Authentifiziert; set => _Authentifiziert = value; }
        public static int Max_Stationen => _max_Stationen;
        public List<Geschaeftsfuehrer> Boss { get => _boss; set => _boss = value; }

        #endregion

        #region Konstruktoren
        public Controller()
        {
            this.Personen = new List<Kunde>();
            this.Mitarbeiter = new List<Mitarbeiter>();
            this.Stationen = new List<Paketstation>();
            this.IO = new UserInterface();
            this.AktivUser = null;
            this.Authentifiziert = false;
            this.Boss = new List<Geschaeftsfuehrer>();
        }
        public Controller(List<Kunde> value1, List<Mitarbeiter> value2, List<Paketstation> value3, List<Geschaeftsfuehrer> value4, object value)
        {
            this.Personen = value1;
            this.Mitarbeiter = value2;
            this.Stationen = value3;
            this.Boss = value4;
            this.IO = new UserInterface();
            this.AktivUser = value;
            this.AktuelleStation = new Paketstation();
            this.Authentifiziert = false;
        }
        public Controller(Controller value)
        {
            this.Personen = value.Personen;
            this.Mitarbeiter = value.Mitarbeiter;
            this.Stationen = value.Stationen;
            this.Boss = value.Boss;
            this.IO = value.IO;
            this.AktivUser = value.AktivUser;
            this.AktuelleStation = value.AktuelleStation;
            this.Authentifiziert = value.Authentifiziert;
        }
        #endregion

        #region Worker
        public void run()
        {
            #region lokale Variablen
            bool weiter = true;
            bool haupt = true;
            string Auswahl = "";
            #endregion

            #region Testdaten
            //Kunden-Liste 
            this.Personen.Add(new Kunde(11, "Test", "Teststr. 1", "Test1", "1234"));
            this.Personen.Add(new Kunde(22, "Kylo Ren", "Hauptstr. 1", "Kunde1", "1111"));
            this.Personen.Add(new Kunde(33, "Rey Skywalker", "Mainstr. 1", "Kunde2", "2222"));
            this.Personen.Add(new Kunde(44, "Ar Turito", "Heißstr. 2", "Kunde3", "3333"));

            //Mitarbeiter-Liste
            this.Mitarbeiter.Add(new Mitarbeiter(123, "Müller", "Mitarbeiter1", "6666"));
            this.Mitarbeiter.Add(new Mitarbeiter(234, "Heinz", "Mitarbeiter2", "Mitarbeiter2"));
            this.Mitarbeiter.Add(new Mitarbeiter(345, "Walker", "Mitarbeiter3", "Mitarbeiter3"));

            //Geschäfstfuehrer
            this.Boss.Add(new Geschaeftsfuehrer("admin", "admin"));

            //Pakete für Kunde zum Versenden
            this.Personen[0].Pakete.Add(new Paket(359, "Test", "Teststr. 1", "Ar Turito", "Heißstr. 2", "L")); //status Verschicken
            this.Personen[0].Pakete.Add(new Paket(616, "Test", "Teststr. 1", "Kylo R", "Heißstr. 1", "XXL")); //status Verschicken

            //Pakete für Mitarbeiter zur Auslieferung
            this.Mitarbeiter[0].LieferPakete.Add(new Paket(130, "Test", "Teststr. 1", "Transportieren", "XL"));
            this.Mitarbeiter[0].LieferPakete.Add(new Paket(929, "Rey Skywalker", "Mainstr. 1", "Transportieren", "XXL"));

            //Stationen
            for (int i = 0; i < (Max_Stationen - 10); i++) //Fangen mit 90 Stationen an
            {
                this.Stationen.Add(new Paketstation(i + 1));
            }
            Random rnd = new Random(DateTime.Now.GetHashCode());

            this.AktuelleStation = this.Stationen[rnd.Next(0, Max_Stationen - 10)];

            //Pakete für Mitarbeiter, die abgeholt werden sollen
            this.AktuelleStation.Faecher[0] = new Fach(1, true, new Paket(111, "Test", "Teststr. 1", "Abzuholen", 1, "M"), "M");
            this.AktuelleStation.Faecher[1] = new Fach(2, true, new Paket(112, "Kylo Ren", "Hauptstr. 1", "Abzuholen", 2, "L"), "L");
            this.AktuelleStation.Faecher[2] = new Fach(3, true, new Paket(113, "Rey Skywalker", "Mainstr. 1", "Abzuholen", 3, "XL"), "XL");

            //Pakete für Kunde, die abgeholt werden sollen
            this.AktuelleStation.Faecher[3] = new Fach(4, true, new Paket(222, "Test", "Teststr. 1", "Abholen", 4, "XS"), "XS");
            this.AktuelleStation.Faecher[4] = new Fach(5, true, new Paket(223, "Kylo Ren", "Hauptstr. 1", "Abholen", 5, "S"), "S");
            this.AktuelleStation.Faecher[5] = new Fach(6, true, new Paket(333, "Rey Skywalker", "Mainstr. 1", "Abholen", 6, "M"), "M");
            this.AktuelleStation.Faecher[6] = new Fach(7, true, new Paket(777, "Test", "Teststr. 1", "Abholen", 7, "L"), "L");
            this.AktuelleStation.Faecher[7] = new Fach(8, true, new Paket(888, "Kylo Ren", "Hauptstr. 1", "Abholen", 8, "XL"), "XL");
            this.AktuelleStation.Faecher[8] = new Fach(9, true, new Paket(999, "Rey Skywalker", "Mainstr. 1", "Abholen", 9, "S"), "S");
            #endregion

            #region Splashinfo und Willkommen
            SplashInfoAnzeigen();
            Willkommen();
            #endregion

            #region Hauptschleife
            while (haupt)
            {
                weiter = true;
                while (Authentifiziert == false)
                {
                    Authentifizieren();
                }

                while (weiter)
                {
                    Auswahl = HauptMenue();
                    if (this.AktivUser is Kunde)
                    {
                        switch (Auswahl)
                        {
                            case "1":
                                KundeLiefertPaket();
                                break;
                            case "2":
                                KundeHoltPaket();
                                break;
                            case "3":
                                weiter = false;
                                Authentifiziert = false;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (this.AktivUser is Mitarbeiter)
                    {
                        switch (Auswahl)
                        {
                            case "1":
                                MitarbeiterLiefertPakete();
                                break;

                            case "2":
                                MitarbeiterHoltPakete();
                                break;

                            case "3":
                                PaketeListen();
                                break;
                            case "4":
                                weiter = false;
                                Authentifiziert = false;
                                break;
                            case "0":
                                haupt = false;
                                weiter = false;
                                break;
                            default:
                                weiter = false;
                                break;
                        }
                    }
                    else if (this.AktivUser is Geschaeftsfuehrer)
                    {
                        string Wahl = "";
                        bool stop = true;
                        switch (Auswahl)
                        {
                            case "1":
                                Wahl = IO.MenuKundeVerwalten();
                                if (Wahl == "1")
                                {
                                    Kunde_Hinzufuegen();
                                }
                                else if (Wahl == "2")
                                {
                                    Kunde_Entfernen();
                                }
                                else if (Wahl == "3")
                                {
                                    stop = false;
                                }
                                break;
                            case "2":
                                Wahl = IO.MenuMitarbeiterVerwalten();
                                if (Wahl == "1")
                                {
                                    Mitarbeiter_Hinzufuegen();
                                }
                                else if (Wahl == "2")
                                {
                                    Mitarbeiter_Entfernen();
                                }
                                else if (Wahl == "3")
                                {
                                    stop = false;
                                }
                                break;
                            case "3":
                                Station_Verwalten();
                                break;
                            case "4":
                                Kunden_Listen();
                                break;
                            case "5":
                                Mitarbeiter_Listen();
                                break;
                            case "6":
                                weiter = false;
                                Authentifiziert = false;
                                break;
                            case "0":
                                haupt = false;
                                weiter = false;
                                break;
                            default:
                                weiter = false;
                                break;
                        }
                    }
                    else
                    {
                        haupt = false;
                    }
                }
            }
            #endregion
        }
        public string HauptMenue()
        {
            string ergebnis = "";
            if (this.AktivUser is Kunde)
            {
                ergebnis = IO.KundenMenueAnzeigen();
            }
            else if (this.AktivUser is Mitarbeiter)
            {
                ergebnis = IO.MitarbeiterMenueAnzeigen();
            }
            else if (this.AktivUser is Geschaeftsfuehrer)
            {
                ergebnis = IO.GeschaeftsfuehrerMenueAnzeigen();
            }
            return ergebnis;
        }
        public void PaketeListen()
        {
            List<Paket> abzuholendePakete = this.AktuelleStation.MitarbeiterListeAbzuholenderPakete();
            if (abzuholendePakete.Count > 0)
            {
                IO.PaketezumAbholenAuflisten(abzuholendePakete, true);
            }
            else
            {
                IO.TextAusgeben("Es gibt keine abzuholende Pakete für Sie in dieser Station.");
            }
            IO.WeitermitTaste();
        }
        public void KundeLiefertPaket()
        {
            Kunde aktuelleKunde = (Kunde)AktivUser;

            if (aktuelleKunde.hatPaketabzugeben())
            {
                Paket p = aktuelleKunde.PaketEinliefern();
                AktuelleStation.KundeLiefertPaket(p);
                IO.TextAusgeben("Paket Nr. " + p.Paketnummer +
                    " Größe " + p.PaketGroesse + " wurde in das Fach Nr. " + p.PaketFachNr + " eingelegt.");
            }
            else
            {
                IO.TextAusgeben("Sie haben keine Pakete zu versenden.");
            }
            IO.WeitermitTaste();
        }
        public void KundeHoltPaket()
        {
            Kunde aktuelleKunde = (Kunde)this.AktivUser;
            if (AktuelleStation.IsteinPaketvorhanden(aktuelleKunde))
            {
                for (int i = 0; i < AktuelleStation.Faecher.Count; i++)
                {
                    if (AktuelleStation.Faecher[i].istBelegt() && AktuelleStation.Faecher[i].Inhalt.Status == "Abholen")
                    {
                        if (aktuelleKunde.Name == AktuelleStation.Faecher[i].Inhalt.EmpfangerName
                                && aktuelleKunde.Adresse == AktuelleStation.Faecher[i].Inhalt.EmpfangerAdresse)
                        {
                            IO.TextAusgeben("Das Paket Nr. " + AktuelleStation.Faecher[i].Inhalt.Paketnummer
                                    + " wurde aus dem Fach Nr. " + AktuelleStation.Faecher[i].Inhalt.PaketFachNr + " entnommen.");
                            aktuelleKunde.PaketAbholen(AktuelleStation.Faecher[i].getPaket());
                        }
                    }
                    else
                    { }
                }
            }
            else
            {
                IO.TextAusgeben("Es gibt keine Pakete für Sie in dieser Station.");
            }
            IO.WeitermitTaste();
        }
        public void MitarbeiterLiefertPakete()
        {
            Mitarbeiter AktivMitarbeiter = (Mitarbeiter)AktivUser;
            List<Paket> geliefertePakete = new List<Paket>(AktivMitarbeiter.PaketLiefern());
            if (geliefertePakete.Count > 0)
            {
                for (int i = geliefertePakete.Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < AktuelleStation.Faecher.Count; j++)
                    {
                        if (!AktuelleStation.Faecher[j].istBelegt() &&
                                AktuelleStation.Faecher[j].Groesse == geliefertePakete[i].PaketGroesse)
                        {
                            AktuelleStation.Faecher[j].PaketAnnehmen(geliefertePakete[i]);
                            IO.TextAusgeben("Paket Nr. " + geliefertePakete[i].Paketnummer + " Größe " +
                                    geliefertePakete[i].PaketGroesse + " wurde in das Fach Nr. " +
                                    geliefertePakete[i].PaketFachNr + " eingelegt.");
                            geliefertePakete.RemoveAt(i);
                            break;
                        }
                        else
                        { }
                    }
                }
            }
            else
            {
                IO.TextAusgeben("Keine weiteren Pakete zum hineinlegen verfügbar.");
            }
            if (geliefertePakete.Count != 0)
            {
                IO.TextAusgeben("Es gibt kein verfügbares Fach mehr.");
                for (int i = 0; i < geliefertePakete.Count; i++)
                {
                    geliefertePakete[i].Statusaendern("Transportieren");
                    AktivMitarbeiter.LieferPakete.Add(geliefertePakete[i]);
                }
            }
            IO.WeitermitTaste();          
        }
        public void MitarbeiterHoltPakete()
        {
            Mitarbeiter AktivMitarbeiter = (Mitarbeiter)AktivUser;
            List<Paket> abzuholendePakete = this.AktuelleStation.MitarbeiterListeAbzuholenderPakete();

            for (int i = 0; i < abzuholendePakete.Count; i++)
            {
                abzuholendePakete[i].Statusaendern("Transportieren");
                AktivMitarbeiter.AbgeholtePakete.Add(abzuholendePakete[i]);
            }
            if (abzuholendePakete.Count > 0)
            {
                string Nr = "";
                for (int i = 0; i < abzuholendePakete.Count; i++)
                {
                    Nr += "(Paket Nr. " + abzuholendePakete[i].Paketnummer + " " + "vom Fach Nr. "
                                    + abzuholendePakete[i].PaketFachNr + ")" + "\r\n";
                }
                IO.TextAusgeben("Sie haben " + abzuholendePakete.Count + " Pakete abgeholt. " + "\r\n" + Nr);
            }
            else
            {
                IO.TextAusgeben("Es gibt keine Pakete zur Abholung in der Station.");
            }
            IO.WeitermitTaste();
        }
        public void SplashInfoAnzeigen()
        {
            IO.SplashAusgeben();
            Console.Clear();
        }
        public void Willkommen()
        {
            IO.Willkommen(this.AktuelleStation);
        }
        public void Authentifizieren()
        {
            string Name = "";
            string Passwort = "";
            string Info = "";

            Console.WriteLine("--------------------------");
            IO.loginAufforderung(ref Name, ref Passwort);

            for (int i = 0; i < Personen.Count; i++)
            {
                if (Name == Personen[i].Benutzername && Passwort == Personen[i].Passwort)
                {
                    Info = "Kunde";
                    this.AktivUser = new Kunde(Personen[i]);
                    Authentifiziert = true;
                }
            }
            for (int i = 0; i < Mitarbeiter.Count; i++)
            {
                if (Name == Mitarbeiter[i].Benutzername && Passwort == Mitarbeiter[i].Passwort)
                {
                    Info = "Mitarbeiter";
                    this.AktivUser = new Mitarbeiter(Mitarbeiter[i]);
                    Authentifiziert = true;
                }
            }
            for (int i = 0; i < Boss.Count; i++)
            {
                if (Name == Boss[i].Benutzername && Passwort == Boss[i].Passwort)
                {
                    Info = "Geschäftsführer";
                    this.AktivUser = new Geschaeftsfuehrer(Boss[i]);
                    Authentifiziert = true;
                }
            }
            if (Authentifiziert == false)
            {
                IO.TextAusgeben("Falscher Login. Bitte prüfen Sie Ihre Login-Data.");
                IO.WeitermitTaste();
            }
            else
            {
                IO.TextAusgeben("Sie sind als " + Info + " gemeldet.");
                IO.WeitermitTaste();
            }
        }
        public void Kunde_Hinzufuegen()
        {
            string Name = "";
            string Adresse = "";
            string Benutzer = "";
            string Passwort = "";

            IO.TextAusgeben("Welchen Kunde wollten Sie registrieren?");
            this.AktuelleStation.Terminal.TextEingeben(ref Name, "Name: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Adresse, "Adresse: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Benutzer, "Benutzername: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Passwort, "Passwort: ");
            Kunde Neu = new Kunde(this.Personen.Count - 1, Name, Adresse, Benutzer, Passwort);

            this.Personen.Add(Neu);
            IO.TextAusgeben("\nKunde erfolgreich registriert.");
            IO.WeitermitTaste();
        }
        public void Kunde_Entfernen()
        {
            string Name = "";
            string Adresse = "";
            string Benutzer = "";
            string Passwort = "";

            IO.TextAusgeben("Welchen Kunde wollten Sie entfernen?");
            this.AktuelleStation.Terminal.TextEingeben(ref Name, "Name: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Adresse, "Adresse: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Benutzer, "Benutzername: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Passwort, "Passwort: ");
            Kunde Todelete = new Kunde(this.Personen.Count - 1, Name, Adresse, Benutzer, Passwort);

            for (int i = 0; i < this.Personen.Count; i++)
            {
                if (this.Personen[i].Name == Todelete.Name && this.Personen[i].Adresse == Todelete.Adresse
                       && this.Personen[i].Benutzername == Todelete.Benutzername && this.Personen[i].Passwort == Todelete.Passwort)
                {
                    this.Personen.RemoveAt(i);
                    IO.TextAusgeben("\nKunde erfolgreich entfernt. ");
                    break;
                }
            }
            IO.WeitermitTaste();
        }
        public void Mitarbeiter_Hinzufuegen()
        {
            string Name = "";
            string id = "";
            string Benutzer = "";
            string Passwort = "";

            IO.TextAusgeben("\nWelchen Mitarbeiter wollten Sie registrieren?");
            this.AktuelleStation.Terminal.TextEingeben(ref Name, "Name: ");
            this.AktuelleStation.Terminal.TextEingeben(ref id, "ID: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Benutzer, "Benutzername: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Passwort, "Passwort: ");
            int Id = Convert.ToInt32(id);
            Mitarbeiter Neu = new Mitarbeiter(Id, Name, Benutzer, Passwort);

            this.Mitarbeiter.Add(Neu);
            IO.TextAusgeben("\nMitarbeiter erfolgreich registriert.");
            IO.WeitermitTaste();
        }
        public void Mitarbeiter_Entfernen()
        {
            string Name = "";
            string Id = "";
            string Benutzer = "";
            string Passwort = "";

            IO.TextAusgeben("\nWelchen Mitarbeiter wollten Sie entfernen?");
            this.AktuelleStation.Terminal.TextEingeben(ref Name, "Name: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Id, "ID: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Benutzer, "Benutzername: ");
            this.AktuelleStation.Terminal.TextEingeben(ref Passwort, "Passwort: ");
            int ID = Convert.ToInt32(Id);
            Mitarbeiter Todelete = new Mitarbeiter(ID, Name, Benutzer, Passwort);

            for (int i = 0; i < this.Mitarbeiter.Count; i++)
            {
                if (this.Mitarbeiter[i].Name == Todelete.Name && this.Mitarbeiter[i].Benutzername == Todelete.Benutzername) //pruft 
                {
                    this.Mitarbeiter.RemoveAt(i);
                    break;
                }
            }
            IO.TextAusgeben("\nMitarbeiter erfolgreich entfernt. ");
            IO.WeitermitTaste();
        }
        public void Station_Hinzufuegen()
        {
            if (this.Stationen.Count < Max_Stationen)
            {
                Paketstation Neu = new Paketstation(this.Stationen.Count);
                this.Stationen.Add(Neu);
                IO.TextAusgeben("Sie haben einen Station hinzugefügt. Anzahl Stationen: " + this.Stationen.Count);
            }
            else
            {
                IO.TextAusgeben("Die maximalen Anzahl der Stationen wird erreicht.");
            }
            IO.WeitermitTaste();
        }
        public void Station_Entfernen()
        {
            if (this.Stationen.Count > 1)
            {
                int Nummer = 0;
                IO.TextAusgeben("Welche Station möchten Sie entfernen? ");
                Nummer = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < this.Stationen.Count; i++)
                {
                    if (this.Stationen[i].getID() == (Nummer + 1))
                    {
                        this.Stationen.RemoveAt(i);
                        IO.TextAusgeben("Sie haben Station Nr. " + i + " entfernt.");
                        break;
                    }
                }
            }
            else
            {
                IO.TextAusgeben("Es gibt nur eine Station.");
            }
        }
        public void Kunden_Listen()
        {
            IO.TextAusgeben("Alle Kunden: ");
            for (int i = 0; i < this.Personen.Count; i++)
            {
                IO.TextAusgeben((i + 1) + " - Name: " + this.Personen[i].Name);
            }
            IO.WeitermitTaste();
        }
        public void Mitarbeiter_Listen()
        {
            IO.TextAusgeben("Alle Mitarbeiter: ");
            for (int i = 0; i < this.Mitarbeiter.Count; i++)
            {
                IO.TextAusgeben((i + 1) + " - Name: " + this.Mitarbeiter[i].Name);
            }
            IO.WeitermitTaste();
        }
        public void Station_Verwalten()
        {
            string Eingabe;
            bool weiter = true;
            Eingabe = IO.MenuStationenVerwalten();
            switch (Eingabe)
            {
                case "1":
                    Station_Hinzufuegen();
                    break;
                case "2":
                    Station_Entfernen();
                    break;
                case "3":
                    Station_Erweitern();
                    break;
                default:
                    break;
            }
        }
        public void Station_Erweitern()
        {
            string Eingabe;
            bool weiter = true;
            Eingabe = IO.ErweiterungsMenu();
            switch (Eingabe)
            {
                case "1":
                    this.AktuelleStation.GeschaftsfuhrerHinzufugtFach();
                    break;
                case "2":
                    this.AktuelleStation.GeschaftsfuhrerEnterfentFach();
                    break;
                default:
                    weiter = false;
                    break;
            }
        }
        #endregion
    }
}

