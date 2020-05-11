#region Dateikopf
/* Autorin		: Fanny Vera
 * Datum		: 30.10.2019
 * Datei		: Kunde.cs
 * Klasse		: IA118
 * Beschreibung : Klasse Kunde zur modellierung eines Paketshop Kunden
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
    public class Kunde 
    {
        #region Eigenschaften
        private int _Kundenummer;
        private string _Name;
        private string _Adresse;
        private string _Benutzername;
        private string _Passwort;
        private List<Paket> _Pakete;
        private Controller _verwalter;
        #endregion

        #region Accesoren/Modifier
        public int Kundenummer { get => _Kundenummer; set => _Kundenummer = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Adresse { get => _Adresse; set => _Adresse = value; }
        public string Benutzername { get => _Benutzername; set => _Benutzername = value; }
        public string Passwort { get => _Passwort; set => _Passwort = value; }
        public List<Paket> Pakete { get => _Pakete; set => _Pakete = value; }
        internal Controller Verwalter { get => _verwalter; set => _verwalter = value; }
        #endregion

        #region Konstruktoren
        public Kunde()
        {
            Kundenummer = -1;
            Name = "Test Test";
            Adresse = "Irgendwo str";
            Benutzername = "noname";
            Passwort = "noname";
            Pakete = new List<Paket>();
            Verwalter = null;
        }
        
        public Kunde(int nummer, string name1, string adresse1, string value, string Kunde1)
        {
            Kundenummer = nummer;
            Name = name1;
            Adresse = adresse1;
            Benutzername = value;
            Passwort = Kunde1;
            Pakete = new List<Paket>();
            Verwalter = new Controller();
        }

        public Kunde(Kunde value)
        {
            Kundenummer = value.Kundenummer;
            Name = value.Name;
            Adresse = value.Adresse;
            Benutzername = value.Benutzername;
            Passwort = value.Passwort;
            Pakete = value.Pakete;
            Verwalter = value.Verwalter;
        }
        #endregion

        #region Worker
        public Paket PaketEinliefern()
        {
            //prüft ob Liste is leer
            if (this.Pakete == null)
                return null;
            else
            { }
            if (this.Pakete.Count <= 0)
                return null;
            else
            { 
            }
            Paket Pak1 = null;
            foreach (Paket p in this.Pakete)
            {
                if (p.Status == "Verschicken")
                {
                    Pak1 = new Paket(p);
                    Pak1.Statusaendern("Abzuholen");
                    this.Pakete.Remove(p);
                    break;
                }
            }
            return Pak1;
        }
        public bool PaketAbholen(Paket Paekchen)
        {
            bool ok = false;
            if (Paekchen != null)
            {
                Paekchen.Statusaendern("Abgeholt");
                this.Pakete.Add(Paekchen);
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }
        public bool Authentifizieren(string Ben, string Pass)
        {
            if (Ben.Equals(this.Benutzername) && Pass.Equals(this.Passwort))
            {
                return true;
            }
            else
            {
               return false;
            }          
        }
        public bool hatPaketabzugeben()
        {
            bool checkZuGeben = false;
            for (int i = 0; i < Pakete.Count; i++)
            {
                if (Pakete[i].Status == "Verschicken")
                {
                    checkZuGeben = true;
                    break;
                }
                else
                {  
                }
            }
            return checkZuGeben;
        }
        public bool hatPaketeabgeholt()
        {
            bool checkAbgeholt = false;
            for (int i = 0; i < Pakete.Count; i++)
            {
                if (Pakete[i].Status == "Abgeholt")
                {
                    checkAbgeholt = true;
                    break;
                }
                else
                { 
                }
            }
            return checkAbgeholt;
        }
        #endregion
    }
}


