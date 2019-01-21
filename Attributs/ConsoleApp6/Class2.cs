using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    [Description(Description = "Cette classe correspond à une personne")]
    public class Personne
    {
        string Nom;
        string Prenom;
        int Age;

        [Description(Description = "Ce constructeur permet d'assigner l'identité de la personne")]
        public Personne(string nom, string prenom, int age)
        {
            Nom = nom;
            Prenom = prenom;
            Age = age;
        }

        [Description(Description = "Cette méthode permet d'écrire dans la console ce que l'utilisateur dit")]
        public void Parler(string parole)
        {
            Console.WriteLine(parole);
        }

    }
}
