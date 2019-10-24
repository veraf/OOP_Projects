/* Autorin: 	 Fanny Vera
 * Datum: 		 18.09.19
 * Beschreibung: Verwaltet die Daten
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bruche
{
    class Controller
    {
        #region Eigenschaften
        private Bruch[] _Brueche;
        private UserInterface _IO;

        #endregion

        #region Accessoren/Modifier
        internal Bruch[] Brueche
        {
            get => _Brueche;
            set => _Brueche = value;
        }
        internal UserInterface IO
        {
            get => _IO;
            set => _IO = value;
        }
        #endregion

        #region Konstruktoren
        //Standardkonstruktoren
        public Controller()
		{
			this.Brueche = new Bruch[3];

            Brueche[0] = new Bruch();
            Brueche[1] = new Bruch();
            Brueche[2] = new Bruch();

			this.IO = new UserInterface();
		}

        //Spezialkonstruktoren 
        public Controller(UserInterface value)
        {
            this.Brueche = new Bruch[3];

            Brueche[0] = new Bruch();
            Brueche[1] = new Bruch();
            Brueche[2] = new Bruch();

            this.IO = value;
        }
        #endregion

        #region Worker
        public void run()
        {
        	SplashAnzeigen();
        	int Auswahl; 
        	do
        	{	
        		Auswahl = MenuAnzeigen();
        		
        		if(Auswahl == 1)
        		{
        			Brueche[0].Zuweisung(IO.BruchEinlesen());
        			Brueche[1].Zuweisung(IO.BruchEinlesen());
        			Console.ReadKey();
        		}
        		else if(Auswahl == 2)
        		{
        			IO.BruchAusgeben(Brueche[0], "Bruch 1: ");
        			IO.BruchAusgeben(Brueche[1], "Bruch 2: ");    
        			Console.ReadKey();
        		}
        		else if(Auswahl == 3)
        		{
        			BruecheAddieren();
        		}
           		else if(Auswahl == 4)
        		{
        			BruecheSubtrahieren();
        		}
        		else if(Auswahl == 5)
        		{
        			BruecheMultiplizieren();
        		}
        		else if(Auswahl == 6)
        		{
        			BruecheDividieren();
        		}
        		else if(Auswahl != 0)
        		{
        			Console.WriteLine("Bitte geben Sie ein Zahl zwischen 0 und 6.");
        			Console.WriteLine("Weiter mit beliebiger Taste");
					Console.ReadKey();	
        		}	
        	
        	} while(Auswahl != 0);
        }
        
        public void SplashAnzeigen()
        {
        	IO.SplashAusgeben();
        	Thread.Sleep(2000);
			Console.Clear();  
        }		
		
        public int MenuAnzeigen()
        {
        	IO.MenueAusgeben();
        	int Auswahl = IO.MenueAuswahlEinlesen();
        	return Auswahl;
        }
		
        public void BruecheAddieren()
        {
        	Brueche[2].Zuweisung(Brueche[0].Addieren(Brueche[1]));    	
        	ErgebnisAnzeigen();
        }
		
        public void BruecheSubtrahieren()
        {
			Brueche[2].Zuweisung(Brueche[0].Subtrahieren(Brueche[1]));
        	ErgebnisAnzeigen();
        }
		
        public void BruecheMultiplizieren()
        {
			Brueche[2].Zuweisung(Brueche[0].Multiplizieren(Brueche[1]));
        	ErgebnisAnzeigen();
        }
		
        public void BruecheDividieren()
        {
			Brueche[2].Zuweisung(Brueche[0].Dividieren(Brueche[1]));
        	ErgebnisAnzeigen();
        }
		
        public void ErgebnisAnzeigen()
        {
        	IO.BruchAusgeben(Brueche[0], "Bruch 1: ");
        	IO.BruchAusgeben(Brueche[1], "Bruch 2: "); 
        	Console.WriteLine("---------------");
        	IO.BruchAusgeben(Brueche[2], "Ergebnis: ");
        	Console.ReadKey();
        }
        
        #endregion
    }
}
