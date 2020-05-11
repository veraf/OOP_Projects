#region Dateikopf
/* Autorin		: Fanny Vera
 * Datum		: 30.10.2019
 * Datei		: Paketfach.cs
 * Klasse		: IA118
 * Beschreibung : Klasse Fach
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
    public class Fach
    {
        #region Eigenschaften
        private int _Fachnummer;
        private bool _Status;
        private bool _Belegt;
        private Paket _Inhalt;
        private string _Groesse;
        private int _Station;
        #endregion

        #region Accesoren/Modifier
        public int Fachnummer { get => _Fachnummer; set => _Fachnummer = value; }
        public bool Status { get => _Status; set => _Status = value; }
        public bool Belegt { get => _Belegt; set => _Belegt = value; }
        internal Paket Inhalt { get => _Inhalt; set => _Inhalt = value; }
        public string Groesse { get => _Groesse; set => _Groesse = value; }
        public int Station { get => _Station; set => _Station = value; }
        #endregion

        #region Konstruktoren
        public Fach()
        {
            this.Fachnummer = -1;
            this.Status = true;
            this.Belegt = false;
            this.Inhalt = null;
            this.Groesse = "M";
            this.Station = -1;
        }
        public Fach(int Nummer)
        {
            this.Fachnummer = Nummer;
            this.Status = true;
            this.Belegt = false;
            this.Inhalt = null;
            this.Groesse = "M"; //pensar como inicializar con distintos tamanhos
        }
        public Fach(int Nummer, string Groesse)
        {
            this.Fachnummer = Nummer;
            this.Status = true;
            this.Belegt = false;
            this.Inhalt = null;
            this.Groesse = Groesse;
        }
        public Fach(int num, bool bel, Paket inha, string groesse)
        {
            this.Fachnummer = num;
            this.Status = true;
            this.Belegt = bel;
            this.Inhalt = inha;
            if (inha == null)
                this.Belegt = false;
            this.Groesse = groesse;
        }
        public Fach(Fach Value)
        {
            this.Fachnummer = Value.Fachnummer;
            this.Belegt = Value.Belegt;
            this.Inhalt = Value.Inhalt;
            this.Groesse = Value.Groesse;
        }
        #endregion

        #region Worker
        public bool istBelegt()
        {
            return this.Belegt;
        }
        public Paket getPaket()
        {
            Paket temp = this.Inhalt;
            this.Inhalt = null;
            this.Belegt = false;
            return temp;
        }
        public void PaketAnnehmen(Paket Test) //Paket akzeptieren beim Fach
        {
            this.Inhalt = Test;
            this.Belegt = true;
            this.Inhalt.PaketFachNr = this.Fachnummer;
        }
        #endregion
    }
}


