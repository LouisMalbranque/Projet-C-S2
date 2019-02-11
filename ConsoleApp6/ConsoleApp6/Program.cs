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
            Salade salade = new Salade();
            salade.descriptionAliment();
            Steack steack = new Steack(Animal.Cheval);
            steack.descriptionAliment();
            steack.cuire();
            steack.descriptionAliment();
            Poisson poisson = new Poisson();
            poisson.cuire();
            Console.ReadKey();
        }
    }

    public class Salade : Aliment
    {
        public Salade()
            : base("Salade", 1, 3, true)
        {
        }
    }

    public class Poisson : Aliment, cuissonAliment
    {
        private Boolean estCuit;
        public Poisson()
            : base("Poisson", 3, 14, false)
        {
            estCuit = false;
        }

        public void cuire()
        {
            Console.WriteLine("L'aliment " + nom + " a été cuit sur plancha");
            estCuit = true;
        }

        public override void descriptionAliment()
        {
            base.descriptionAliment();
            if (estCuit == true)
            {
                Console.WriteLine("Il est Cuit.");
            }
            else
            {
                Console.WriteLine("Il n'est pas Cuit.");
            }

        }
    }

    public class Steack : Aliment, cuissonAliment
    {
        private Animal viandeDuSteack;
        private Boolean estCuit;
        public Steack(Animal viandeDuSteack)
            : base("Steack",5,25,false)
        {
            this.viandeDuSteack = viandeDuSteack;
            estCuit = false;
        }

        public void cuire()
        {
            Console.WriteLine("L'aliment " + nom + " est cuit à point");
            estCuit = true;
        }

        public override void descriptionAliment()
        {
            base.descriptionAliment();
            if (estCuit == true) {
                Console.WriteLine("Il est Cuit.");
            }
            else
            {
                Console.WriteLine("Il n'est pas Cuit.");
            }

        }
    }
    
    public class Aliment
    { 
        protected string nom;
        protected int prix;
        protected int calorie;
        protected Boolean estVegetarien;
        public Aliment(string nom, int prix, int calorie, Boolean estVegetarien)
        {
            this.nom = nom;
            this.prix = prix;
            this.calorie = calorie;
            this.estVegetarien = estVegetarien;
        }

        public virtual void descriptionAliment()
        {
            Console.WriteLine("Cet aliment est " + nom + " il coute " + prix + " et contient " + calorie + " calories");
            if (estVegetarien == true)
            {
                Console.WriteLine("Il convient aux végétariens");
            }
            else
            {
                Console.WriteLine("Il ne convient pas aux végétariens");
            }
        }
    }

    public interface cuissonAliment
    {
        void cuire();
    }

    public enum Animal
    {
        Cheval,
        Boeuf
    }
}
