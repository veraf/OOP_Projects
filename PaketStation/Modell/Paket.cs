#region Dateikopf
/* Autorin		: Fanny Vera
 * Datum	    : 30.10.2019
 * Datei		: Paket.cs
 * Klasse		: IA118
 * Beschreibung : Klasse Paket modelliert ein zu verschickendes bzw. zu empfangenes Paket 
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
    public class Paket
    {
        #region Eigenschaften
        private long _Paketnummer;
        private string _AbsenderName;
        private string _AbsenderAdresse;
        private string _EmpfangerName;
        private string _EmpfangerAdresse;
        private string _Status;
        private int _PaketFachNr;
        private int _PaketStationNr;
        private string _PaketGroesse;
        #endregion

        #region Accesoren/Modifier
        public long Paketnummer { get => _Paketnummer; set => _Paketnummer = value; }
        public string AbsenderName { get => _AbsenderName; set => _AbsenderName = value; }
        public string AbsenderAdresse { get => _AbsenderAdresse; set => _AbsenderAdresse = value; }
        public string EmpfangerName { get => _EmpfangerName; set => _EmpfangerName = value; }
        public string EmpfangerAdresse { get => _EmpfangerAdresse; set => _EmpfangerAdresse = value; }
        public string Status { get => _Status; set => _Status = value; }
        public int PaketFachNr { get => _PaketFachNr; set => _PaketFachNr = value; }
        public int PaketStationNr { get => _PaketStationNr; set => _PaketStationNr = value; }
        public string PaketGroesse { get => _PaketGroesse; set => _PaketGroesse = value; }

        #endregion

        #region Konstruktoren
        public Paket()
        {
            this.AbsenderName = "Client1";
            this.AbsenderAdresse = "Hauptstr";
            this.EmpfangerName = "Client2";
            this.EmpfangerAdresse = "Hochstr";
            this.Status = "Verschicken";
            this.PaketFachNr = -1;
            this.PaketStationNr = -1;
            this.PaketGroesse = "M";
        }
        public Paket(long Nummer, string Name1, string Adresse1, string Name2, 
            string Adresse2, string Groesse)
        {
            this.Paketnummer = Nummer;
            this.AbsenderName = Name1;
            this.AbsenderAdresse = Adresse1;
            this.EmpfangerName = Name2;
            this.EmpfangerAdresse = Adresse2;
            this.Status = "Verschicken";
            this.PaketFachNr = -1;
            this.PaketStationNr = -1;
            this.PaketGroesse = Groesse;
        }

        public Paket(long Nr, string Name1, string Adresse1,
             string Status1, string Groesse)
        {
            this.Paketnummer = Nr;
            this.EmpfangerName = Name1;
            this.EmpfangerAdresse = Adresse1;
            this.Status = Status1;
            this.PaketFachNr = -1;
            this.PaketGroesse = Groesse;
        }

        public Paket(long Nr, string Name1, string Adresse1,
             string Status1, int Fachnr, string Groesse)
        {
            this.Paketnummer = Nr;
            this.EmpfangerName = Name1;
            this.EmpfangerAdresse = Adresse1;
            this.Status = Status1;
            this.PaketFachNr = Fachnr;
            this.PaketGroesse = Groesse;
        }

        public Paket(Paket value)
        {
            this.Paketnummer = value.Paketnummer;
            this.AbsenderName = value.AbsenderName;
            this.AbsenderAdresse = value.AbsenderAdresse;
            this.EmpfangerName = value.EmpfangerName;
            this.EmpfangerAdresse = value.EmpfangerAdresse;
            this.Status = value.Status;
            this.PaketFachNr = value.PaketFachNr;
            this.PaketStationNr = value.PaketStationNr;
            this.PaketGroesse = value.PaketGroesse;
        }
        #endregion

        #region Worker
        public void Statusaendern(string aktuelleStatus)
        {
            List<string> Zulaessig = new List<string>()
            {
                "Verschicken",
                "Transportieren",
                "Abholen",
                "Abgeholt",
                "Abzuholen"
            };

            if (Zulaessig.Contains(aktuelleStatus))
            {
                this.Status = aktuelleStatus;
            }
            else
            {
               throw (new Exception("Falscher Paketstatus!"));
            }
        }
        #endregion
    }
}

