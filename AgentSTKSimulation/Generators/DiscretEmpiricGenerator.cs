using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralnaPraca1_Michal_murin_Diss
{
    internal class DiscretEmpiricGenerator
    {
        // List <probability, min, max, generator>
        /// <summary>
        /// zoznm generatorov pe jednotlive javy
        /// </summary>
        public List<(double probability, int min, int max, Random generator)> Generators { get; set; }
        /// <summary>
        /// Generator pravdepodobnosti
        /// </summary>
        private Random _probabilityGenerator;

        /// <summary>
        /// Konstruktor triedy
        /// </summary>
        /// <param name="pGenerators">Zoznam generatorov a jednotlivych intervalov</param>
        /// <param name="seedGenerator">Generator nasad</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DiscretEmpiricGenerator(List<(double probability, int min, int max, Random generator)> pGenerators, Random seedGenerator)
        {
            double counter = 0;
            foreach (var item in pGenerators)
            {
                counter += item.probability;
                if (item.min > item.max)
                    throw new ArgumentOutOfRangeException("Minimum je vacsie ako maximum v empirickom rozdeleni!");
            }
            if (counter != 1)
            {
                throw new ArgumentOutOfRangeException("Sucet pravdepodobnosti empirickeho generatora sa nerovna 1!");
            }
            else
            {
                Generators = new List<(double, int, int, Random)>(pGenerators.OrderByDescending(x => x.probability));
                _probabilityGenerator = new Random(seedGenerator.Next());
            }
        }
        /// <summary>
        /// Metoda na generovanie nahodneho cisla diskretneho empirickeho rozdelenia
        /// </summary>
        /// <returns>nahodne cislo podla definovaneho empirickeho rozdelenia</returns>
        public int GetRandomNumber()
        {
            double probability = _probabilityGenerator.NextDouble();
            double counter = 0;
            foreach (var generator in Generators)
            {
                counter += generator.probability;
                if (probability < counter)
                {
                    // vygenerovane cislo = <0, max - min + 1> + min ..... napr <3,10> == <0,8) + 3
                    return generator.generator.Next(generator.max - generator.min + 1) + generator.min;
                }
            }
            return -1;
        }
    }
}
