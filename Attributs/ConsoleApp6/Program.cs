using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne Jean = new Personne("Mondu","Jean",30);   //On crée un objet de type Personne

            //On utilise la réflexion pour récupérer les attributs
            Type type = typeof(Personne);  
            Attribute[] lesAttributs = Attribute.GetCustomAttributes(type, typeof(DescriptionAttribute));
            foreach (DescriptionAttribute attribut in lesAttributs)
            {
                Console.WriteLine("\t" + attribut.Description);
            }
            Console.ReadKey();
        }
    }
}
