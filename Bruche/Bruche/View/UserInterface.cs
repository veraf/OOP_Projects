/* Autorin: 	 Fanny Vera
 * Datum: 		 18.09.19
 * Beschreibung: Interagiert mit dem Nutzer
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bruche
{
    class UserInterface
    {
        #region Eigenschaften
        private Bruch _Bruch;
        private string _Text;
        #endregion

        #region Accesoren/Modifier
        public Bruch Bruch
        {
            get => _Bruch;
            set => _Bruch = value;
        }
        public string Text
        {
            get => _Text;
            set => _Text = value;
        }
        #endregion

        #region Konstruktoren
        //Standardkonstruktoren
        public UserInterface()
        {
        	this.Text = "Mein Bruchrechner.";
        	this.Bruch = new Bruch();
        }

        //Spezialkonstruktoren
         public UserInterface(Bruch value, string text)
        {
         	this.Text = text;
         	this.Bruch = value;
        }
        #endregion

        #region Worker
        public Bruch BruchEinlesen()
        {
        	Bruch NeuBruch = new Bruch();
        	
        	NeuBruch.Zaehler = ZahlEinlesen("Geben Sie ein Zähler ein.");
        	do
        	{
        		NeuBruch.Nenner = ZahlEinlesen("Geben Sie ein Nenner ein.");
        	
        	} while(NeuBruch.Nenner == 0);
        	
        	NeuBruch.BruchPruefen();
        	return NeuBruch;   	
        }
        
        public int ZahlEinlesen(string txt)
        {
            bool fehler = false;
            int zahl = 0;
            Console.WriteLine(txt);
            do
            {
                try
                {
                    zahl = Convert.ToInt32(Console.ReadLine());
                    fehler = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Bitte geben Sie ein Zahl ein.");
                    fehler = true;
                }
            } while (fehler);
            return zahl;
        }
       
        public void BruchAusgeben(Bruch value, string txt)
        {
            value.BruchPruefen();
        	
        	if (value.Zaehler == value.Nenner || value.Nenner == 1)
			{
				Console.WriteLine(txt + value.Zaehler);
			}
			else
			{
				Console.WriteLine(txt + value.Zaehler + "/" + value.Nenner);  
			}		
        }
        
        public void SplashAusgeben()
        {
			Console.ForegroundColor = ConsoleColor.White; 
			Console.WriteLine("Autorin           :     Fanny Vera");
            Console.WriteLine("Herstellungsdatum :     18.09.2019");
            Console.WriteLine("Beschreibung      :     OOP Programm zum Addieren, ");
            Console.WriteLine("                        Subtrahieren, Multiplizieren ");
            Console.WriteLine("                        und Dividieren zwei Brüche.");
            Console.WriteLine();        
        }

        public void MenueAusgeben()
        {
			Console.Clear();
			Console.WriteLine("      Hauptmenü");
			Console.WriteLine("----------------------");
            Console.WriteLine("(1) Brüche eingeben");
            Console.WriteLine("(2) Brüche zeigen");
            Console.WriteLine("(3) Addieren");
            Console.WriteLine("(4) Subtrahieren");
            Console.WriteLine("(5) Multiplizieren");
            Console.WriteLine("(6) Dividieren");
            Console.WriteLine("----------------------");
			Console.WriteLine("(0) Programm verlassen");
            Console.WriteLine();
            
            Console.WriteLine("Zahl auswählen und mit enter bestätigen");
        }
        public int MenueAuswahlEinlesen()
        {
            int Eingabe = 0;
            bool fehler = false;
            do
            {
                try
                {
                    Eingabe = Convert.ToInt32(Console.ReadLine());
                    fehler = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Bitte geben Sie eine Zahl zwischen 0 und 6.");
                    fehler = true;
                }
            } while (fehler);
            return Eingabe;
        }
        
        #endregion
    }
}
