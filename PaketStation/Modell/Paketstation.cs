#region Dateikopf
/* Autorin		: Fanny Vera
 * Datum	    : 30.10.2019
 * Datei		: Paketstation.cs
 * Klasse		: IA118
 * Beschreibung : Klasse Paketstation zu modellierung eines DHL Stations
 * 
 * */
#endregion 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaketStation
{
    public class Paketstation
    {
        #region Eigenschaften
        private List<Fach> _Faecher;
        private Controller _Verwalter;
        private UserInterface _Terminal;
        private int _id;
        private const int _max_Facher = 100;
        private const int _min_Facher = 9;
        #endregion

        #region Modifier/Accesoren
        public List<Fach> Faecher { get => _Faecher; set => _Faecher = value; }
        public UserInterface Terminal { get => _Terminal; set => _Terminal = value; }
        public int Id { get => _id; set => _id = value; }
        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }
        public static int Max_Facher => _max_Facher;
        public static int Min_Facher => _min_Facher;
        #endregion

        #region Konstruktoren
        public Paketstation()
        {
            this.Id = -1;          
            this.Faecher = new List<Fach>();    
            this.Terminal = new UserInterface();
            this.Verwalter = new Controller();           
        }
       public Paketstation(int ID)
        {
            this.Id = ID;
            Random random = new Random();
            List<string> Groesse = new List<string> {"XS", "S", "M", "L", "XL", "XXL"};
            
            this.Faecher = new List<Fach>();
            for (int i = 0; i < random.Next(Min_Facher, Max_Facher); i++)
            {     
                    this.Faecher.Add(new Fach(i + 1, Groesse[random.Next(Groesse.Count)]));                      
            }
            this.Terminal = new UserInterface();           
        }
        public Paketstation(Paketstation value)
        {
            this.Faecher = new List<Fach>(value.Faecher);     
            this.Terminal = value.Terminal;
            this.Id = value.Id;
        }
        #endregion

        #region Worker
        public Paket KundeholtPaketab()
        {
            Paket value = new Paket();
            foreach (Fach f in this.Faecher)
            {
                if (f.Inhalt.Status == "Abzuholen")
                {
                    f.Inhalt.Statusaendern("Abgeholt");
                    f.Belegt = false;
                    value = f.Inhalt;
                    f.Inhalt = null;
                }
                else
                { }
            }
            return value;
        }
        public void KundeLiefertPaket(Paket value)
        {
            foreach (Fach f in this.Faecher)
            {
                if (!f.istBelegt())
                {
                    //&& f.Groesse == value.PaketGroesse   
                    //muss prüfen, ob Fäch und Paket haben die gleiche Größe 
                    f.PaketAnnehmen(value);
                    break;
                }
                else
                {   }
            }
        }
        public List<Paket> MitarbeiterListeAbzuholenderPakete()
        {
            List<Paket> Liste = new List<Paket>();
            for (int i = 0; i < Faecher.Count; i++)
            {
                if (Faecher[i].istBelegt())
                {
                    if (Faecher[i].Inhalt.Status == "Abzuholen")
                    {
                        Faecher[i].Inhalt.PaketFachNr = Faecher[i].Fachnummer;
                        Liste.Add(Faecher[i].Inhalt);
                    }
                    else
                    { }
                }
                else
                { }
            }
            return Liste;
        }
        public bool IsteinPaketvorhanden(Kunde Kunde)
        {
            bool value = false;
            for (int i = 0; i < Faecher.Count; i++)
            {
                if (Faecher[i].istBelegt() && Faecher[i].Inhalt.Status == "Abholen")
                {
                    if (Kunde.Name == Faecher[i].Inhalt.EmpfangerName 
                            && Kunde.Adresse == Faecher[i].Inhalt.EmpfangerAdresse)
                    {
                        value = true;
                    }
                    else
                    { }
                }
                else
                { }
            }
            return value;
        }
        public int getPaketFachnummer(Kunde value)
        {
            int Fachnummer = 0;
            for (int i = 0; i < Faecher.Count; i++)
            {
                if (Faecher[i].istBelegt())
                {
                    if (value.Name == Faecher[i].Inhalt.EmpfangerName 
                            && value.Adresse == Faecher[i].Inhalt.EmpfangerAdresse)
                    {
                        Fachnummer = Faecher[i].Fachnummer;
                    }
                    else
                    { }
                }
                else
                { }
            }
            return Fachnummer;
        }
        public int getID()
        {
            return this.Id;
        }
        public void GeschaftsfuhrerEnterfentFach()
        {
            for (int i = this.Faecher.Count - 1; i >= 0 ; i--)
            {
                if (!this.Faecher[i].istBelegt())
                {
                    this.Faecher.RemoveAt(i);
                    break;
                }
            }
            Console.WriteLine("Sie haben einen Fach entfernt.");
            Console.WriteLine("Neu Anzahl Fächer : " + this.Faecher.Count);
            Console.ReadLine();
        }
        public void GeschaftsfuhrerHinzufugtFach()
        {
            this.Faecher.Add(new Fach());
            Console.WriteLine("Sie haben einen Fach hinzugefügt.");
            Console.WriteLine("Neu Anzahl Fächer : " + this.Faecher.Count);
            Console.ReadLine();
        }
        #endregion
    }
}
