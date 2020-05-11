#region Dateikopf
/* Autorin		: Fanny Vera
 * Datum		: 30.10.2019
 * Datei		: Mitarbeiter.cs
 * Klasse		: IA118
 * Beschreibung : Klasse Mitarbeiter zur modellierung eines DHL Mitarbeiters
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
    public class Mitarbeiter 
    {
        #region Eigenschaften
        private int _MitarbeiterID;
        private string _Name;
        private string _Benutzername;
        private string _Passwort;
        private List<Paket> _LieferPakete;
        private List<Paket> _AbgeholtePakete;
        private Controller _Verwalter;
        #endregion

        #region Accesoren/Modifier
        public int MitarbeiterID { get => _MitarbeiterID; set => _MitarbeiterID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Benutzername { get => _Benutzername; set => _Benutzername = value; }
        public string Passwort { get => _Passwort; set => _Passwort = value; }
        public List<Paket> LieferPakete { get => _LieferPakete; set => _LieferPakete = value; }
        public List<Paket> AbgeholtePakete { get => _AbgeholtePakete; set => _AbgeholtePakete = value; }
        internal Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }
        #endregion

        #region Konstruktoren
        public Mitarbeiter()
        {
            MitarbeiterID = -1;
            Name = "Mitarbeiter";
            Benutzername = "Mitarbeiter";
            Passwort = "noname";
            this.LieferPakete = new List<Paket>();
            this.AbgeholtePakete = new List<Paket>();
            Verwalter = null;
        }
        public Mitarbeiter(int nummer, string name1, string benutzer, string value)
        {
            MitarbeiterID = nummer;
            Name = name1;
            Benutzername = benutzer;
            Passwort = value;
            this.LieferPakete = new List<Paket>();
            this.AbgeholtePakete = new List<Paket>();
            Verwalter = new Controller();
        }
        public Mitarbeiter(Mitarbeiter value)
        {
            MitarbeiterID = value.MitarbeiterID;
            Name = value.Name;
            Benutzername = value.Benutzername;
            Passwort = value.Passwort;
            this.LieferPakete = value.LieferPakete;
            this.AbgeholtePakete = value.AbgeholtePakete;
            Verwalter = value.Verwalter;
        }
        #endregion

        #region Worker
        public List<Paket> PaketLiefern()
        {
            List<Paket> Lieferung = new List<Paket>();
            for (int i = LieferPakete.Count - 1; i >= 0; i--)
            {
                if (LieferPakete[i].Status == "Transportieren")
                {
                    LieferPakete[i].Statusaendern("Abholen");
                    Lieferung.Add(LieferPakete[i]);
                    LieferPakete.RemoveAt(i);
                }
            }
            return Lieferung;
        }
        public void PaketeAbholen(List<Paket> List)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].Status == "Abholen")
                {
                    List[i].Status = "Transportieren";
                    LieferPakete.Add(List[i]);
                    List.RemoveAt(i);
                }
            }
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
        public int getAuszulieferndePakete()
        {
            int ZahlPakete = 0;
            ZahlPakete = LieferPakete.Count;
            return ZahlPakete;
        }
        public int getAbgeholtePakete()
        {
            int ZahlPakete = 0;
            ZahlPakete = AbgeholtePakete.Count;
            return ZahlPakete;
        }
        #endregion
    }
}





