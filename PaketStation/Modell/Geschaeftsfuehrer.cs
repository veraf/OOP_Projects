#region Dateikopf
/* Autorin		: Fanny Vera
 * Datum		: 30.10.2019
 * Datei		: Geschaeftsfuehrer.cs
 * Klasse		: IA118
 * Beschreibung : Klasse Geschäftsführer zur modellierung eines DHL Geschäftsführer
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
    public class Geschaeftsfuehrer
    {
        #region Eigenschaften
        private string _Benutzername;
        private string _Passwort;
        #endregion

        #region Accesoren/Modifier
        public string Benutzername { get => _Benutzername; set => _Benutzername = value; }
        public string Passwort { get => _Passwort; set => _Passwort = value; }
        #endregion

        #region Konstruktoren
        public Geschaeftsfuehrer()
        {
            this.Benutzername = "admin";
            this.Passwort = "admin";
        }
        public Geschaeftsfuehrer(string Name, string Pass)
        {
            this.Benutzername = Name;
            this.Passwort = Pass;
        }
        public Geschaeftsfuehrer(Geschaeftsfuehrer value)
        {
            this.Benutzername = value.Benutzername;
            this.Passwort = value.Passwort;
        }
        #endregion

        #region Worker
        public void KundeHinzufuegen(Controller Verwalter)
        {
            Verwalter.Kunde_Hinzufuegen();
        }
        public void KundeEntfernen(Controller Verwalter)
        {
            Verwalter.Kunde_Entfernen();
        }
        #endregion
    }
}
