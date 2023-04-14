using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime;
using System.Threading;
using Microsoft.VisualBasic;

namespace Projet_1_Shell
{
    public class Program
    {
        string[,] tableau = new string[10, 7];
        string[] colors = { "rouge", "bleu", "violet" };
        string[] animalTypes = new string[10];
        string[] animalNames = new string[10];
        string[] ownerNames = new string[10];
        string[] animalColors = new string[10];
        int[] animalAges = new int[10];
        int[] animalWeights = new int[10];
        int[] id = new int[10];
        int animalCount = 0;
        int totalWeight = 0;
        int tap = 0;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartTheMachine();
        }

        private void afficherMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1- Ajouter un animal");
            Console.WriteLine("2- Voir la liste de tous les animaux en pension");
            Console.WriteLine("3- Voir la liste de tous les propriétaires");
            Console.WriteLine("4- Voir le nombre total d’animaux en pension");
            Console.WriteLine("5- Voir le poids total de tous les animaux en pension");
            Console.WriteLine("6- Voir la liste des animaux d’une couleur (rouge, bleu ou violet)");
            Console.WriteLine("7- Retirer un animal de la liste");
            Console.WriteLine("8- Quitter");
        }

        private void StartTheMachine()
        {
            selectChoice();
        }

        private void selectChoice()
        {
            afficherMenu();
            Console.Write("Sélectionnez une option: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                AjouterUnAnimal();
            }
            else if (choice == 2)
            {
                VoirListeAnimauxPension();
            }
            else if (choice == 3)
            {
                VoirListeProprietaire();
            }
            else if (choice == 4)
            {
                VoirNombreTotalAnimaux();
            }
            else if (choice == 5)
            {
                VoirPoidsTotalAnimaux();
            }
            else if (choice == 6)
            {
                ExtraireAnimauxSelonCouleurs();
            }
            else if (choice == 7)
            {
                RetirerUnAnimalDeListe();
            }
            else if (choice == 8)
            {
                Console.WriteLine("Programme terminé.");

            }
            else
            {
                AfficherMessageErreur();
            }

            Console.WriteLine();
        }

        private void AfficherMessageErreur()
        {
            Console.WriteLine("Erreur: choix invalide.");
            StartTheMachine();
        }

        private void AjouterUnAnimal()
        {
            string animalColor = null;


            Console.WriteLine("Ajouter un animal:");
            Console.WriteLine("Type de l'animal:");
            string animalType = Console.ReadLine();
            Console.WriteLine("Nom de l'animal: ");
            string animalName = Console.ReadLine();
            Console.WriteLine("Age de l'animal:");
            int animalAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Poids de l'animal:");
            int animalWeight = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("Couleur de l'animal (rouge, bleu ou violet):");
                animalColor = Console.ReadLine();

            } while (animalColor != "rouge" && animalColor != "bleu" && animalColor != "violet");

            Console.WriteLine("Nom du propriétaire:");
            string ownerName = Console.ReadLine();

            animalNames[tap] = animalName;
            animalTypes[tap] = animalType;
            animalAges[tap] = animalAge;
            animalWeights[tap] = animalWeight;
            animalColors[tap] = animalColor;
            ownerNames[tap] = ownerName;
            tap++;
            StartTheMachine();

        }
        private void VoirListeAnimauxPension()
        {
            Console.WriteLine(" ---------------------------------------------------------");
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", "|ID", "|TYPE ANIMAL", "|NOM  ", "|AGE", "|POIDS", "|COULEUR", "|PROPRIÉTAIRE |");
            Console.WriteLine(" ---------------------------------------------------------");

            for (tap = 0; tap < 10; tap++)
            {
                Console.Write("{0}\t {1}\t {2}\t {3}\t {4}\t {5}\t {6}\n", tap, animalTypes[tap], animalNames[tap], animalAges[tap], animalWeights[tap], animalColors[tap], ownerNames[tap]);

            }
            StartTheMachine();

        }

        private void VoirListeProprietaire()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("| PROPRIÉTAIRE   |");
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < tap; i++)
            {
                if (Array.IndexOf(ownerNames, ownerNames[i], 0, i) == -1)
                {
                    Console.WriteLine(ownerNames[i]);
                }
            }
            StartTheMachine();
        }

        private void VoirNombreTotalAnimaux()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("| NOMBRE ANIMEAUX   |");
            Console.WriteLine("----------------------------------------");
            int nb = 0;
            for (int tab = 0; tab < 10; tab++)
            {
                if (animalNames[tab] != null)
                {
                    nb += 1;
                }
            }
            Console.WriteLine(nb);

            StartTheMachine();
        }

        private void VoirPoidsTotalAnimaux()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("| POIDS TOTAL   |");
            Console.WriteLine("----------------------------------------");
            int tw = 0;
            for (int tap = 0; tap < 10; tap++)
            {
                tw += animalWeights[tap];
            }

            Console.WriteLine(tw);
            StartTheMachine();
        }

        private void ExtraireAnimauxSelonCouleurs()
        {
            Console.Write("VEUILLEZ SAISIR LA COULEUR DE RECHERCHE \n");

            string animalColor = Console.ReadLine();

            Console.WriteLine("Dans la fonction voir liste animaux pension");
            Console.WriteLine("Animaux de couleur {0}:", animalColor);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("ID |TYPE ANIMAL  |  NOM  |  COULEUR  | ");
            Console.WriteLine("----------------------------------------");



            for (int tap = 0; tap < 10; tap++)
            {
                if (animalColors[tap] == animalColor)
                {
                    Console.WriteLine("{0}\t {1}\t {2}\t {3}\n", tap, animalTypes[tap],
                        animalNames[tap], animalColors[tap]);
                }
            }

            StartTheMachine();
        }


        private void RetirerUnAnimalDeListe()
        {
            Console.Write("VEUILLEZ SAISIR ID DE L'ANIMAL\n");

            int tap = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Dans la fonction voir liste animaux pension");

            if (tap == -1)
            {
                Console.WriteLine("Animal non trouvé.");
            }
            else
            {
                id[tap] = Convert.ToInt32(null);
                animalTypes[tap] = null;
                animalNames[tap] = null;
                animalAges[tap] = Convert.ToInt32(null);
                animalWeights[tap] = Convert.ToInt32(null);
                ownerNames[tap] = null;
                animalColors[tap] = null;
                totalWeight -= animalWeights[tap];
            }
            VoirListeAnimauxPension();

            StartTheMachine();
        }
    }
}
