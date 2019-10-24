/* Autorin: 	 	Fanny Vera
 * Datum: 	 	 	18.09.19
 * Beschreibung: 	Hauptfunktion
 * Veränderungen: 
 * 18.09.19  		Entwicklungsbeginn
 * 24.09.19  		Class Bruch angefertigt
 * 25.09.19 		MVC Modelle
 * 01.10.19  		Weiter bearbeitet
 * 02.10.19         Zuweisung integriert
 * 08.10.19         vorl. Fertig
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruche
{
    class main
    {
        static void Main(string[] args)
        {
            Controller Test = new Controller();
            Test.run();
        }
    }
}
