/* Autorin: 	 Fanny Vera
 * Datum: 		 18.09.19
 * Beschreibung: Deklaration der Klasse Bruch
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruche
{
    class Bruch
    {
        #region Eigenschaften
        private int _Zaehler;
        private int _Nenner;
        private char _Vorzeichen;
        #endregion

        #region Accessoren/Modifier
        public int Zaehler
        {
            get => _Zaehler;
            set => _Zaehler = value;
        }
        public int Nenner
        {
            get => _Nenner;
            set => _Nenner = value;
        }
        public char Vorzeichen
        {
            get => _Vorzeichen;
            set => _Vorzeichen = value;
        }
        #endregion

        #region Konstruktoren
        //Standardkonstruktoren
        public Bruch()
        {
            this.Zaehler = 1;
            this.Nenner = 2;
        }

        //Spezialkonstruktoren
        public Bruch(int value1, int value2)
        {
            this.Zaehler = value1;
            this.Nenner = value2;
        }
        
        public Bruch(Bruch original)
        {
            this.Zaehler = original.Zaehler;
            this.Nenner = original.Nenner;
        }
        #endregion

        #region Worker
        public Bruch Addieren(Bruch value)
        {
            Bruch ergebnis = new Bruch();
            ergebnis.Zaehler = this.Zaehler * value.Nenner + value.Zaehler * this.Nenner;
            ergebnis.Nenner = this.Nenner * value.Nenner;
            ergebnis.Kuerzen();
            return ergebnis;
        }
        
        public Bruch Subtrahieren(Bruch value)
        {
            Bruch ergebnis = new Bruch();
            ergebnis.Zaehler = this.Zaehler * value.Nenner - value.Zaehler * this.Nenner;
            ergebnis.Nenner = this.Nenner * value.Nenner;
            ergebnis.Kuerzen();
            return ergebnis;
        }      
        public Bruch Multiplizieren(Bruch value)
        {
            Bruch ergebnis = new Bruch();
            ergebnis.Zaehler = this.Zaehler * value.Zaehler;
            ergebnis.Nenner = this.Nenner * value.Nenner;
            ergebnis.Kuerzen();
            return ergebnis;           
        }
        
        public Bruch Dividieren(Bruch value)
        {
            Bruch ergebnis = new Bruch();
            ergebnis.Zaehler = this.Zaehler * value.Nenner;
            ergebnis.Nenner = this.Nenner * value.Zaehler;
            ergebnis.BruchPruefen();
            ergebnis.Kuerzen();
            return ergebnis;
        }
       
        public Bruch Zuweisung(Bruch Value)
        {
            Bruch ergebnis = new Bruch();
            ergebnis.Zaehler = this.Zaehler = Value.Zaehler;
            ergebnis.Nenner = this.Nenner = Value.Nenner;
            return ergebnis;
        }

        public void Kuerzen()
        {
            int temp;
            if (this.Zaehler > this.Nenner)
            {
                temp = this.Zaehler;
            }
            else
            {
                temp = this.Nenner;
            }

            for (int i = temp; i > 1; i--)
            {
                if ((this.Zaehler % i == 0) && (this.Nenner % i == 0))
                {
                    this.Zaehler = this.Zaehler / i;
                    this.Nenner = this.Nenner / i;
                }
            }
        }   
		
       	public void BruchPruefen()
		{	
			if ((this.Zaehler < 0 && this.Nenner < 0) || (this.Nenner < 0)) 
			{
				this.Zaehler = this.Zaehler * -1;
				this.Nenner = this.Nenner * -1;
			}
		}                
        #endregion
    }
}
