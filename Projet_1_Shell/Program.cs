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
        string[] animalAges = new string[10];
        string[] animalWeights = new string[10];
        string[] id = new string[10];
        string animalCount;
        
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
            string d= null, animalColor = null;
            Console.WriteLine("Ajouter un animal:");
            d = tap.ToString();
            Console.WriteLine("Veuillez saisir le type d'animal:");
            string animalType = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le nom de l'animal: ");
            string animalName = Console.ReadLine();
            Console.WriteLine("Veuillez saisir l'age de l'animal:");
            string animalAge = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le poids de l'animal:");
            string animalWeight = Console.ReadLine();

            do
            {
                Console.WriteLine("Couleur de l'animal (rouge, bleu ou violet):");
                animalColor = Console.ReadLine();

            } while (animalColor != "rouge" && animalColor != "bleu" && animalColor != "violet");

            Console.WriteLine("Nom du propriétaire:");
            string ownerName = Console.ReadLine();

            id[tap] =d;
            animalNames[tap] = animalName;
            animalTypes[tap] = animalType;
            animalAges[tap]= animalAge;
            animalWeights[tap] = animalWeight;
            animalColors[tap] = animalColor;
            ownerNames[tap]= ownerName;
            tap++;
            StartTheMachine();

        }
        private void VoirListeAnimauxPension()
        {
            Console.WriteLine(" -------------------------------------------------------------------------");
            Console.WriteLine("{0,0} {1,10} {2,10} {3,8} {4,8} {5,10} {6,18}", "| ID", "|TYPE ANIMAL", "|NOM ", "|AGE", "|POIDS", "|COULEUR", "|PROPRIÉTAIRE |");
            Console.WriteLine(" -------------------------------------------------------------------------");

            for (tap = 0; tap < 10; tap++)
            {
                Console.WriteLine("{0,4} {1,8} {2,14} {3,6} {4,6} {5,14} {6,15}", id[tap], animalTypes[tap], animalNames[tap], animalAges[tap], animalWeights[tap], animalColors[tap], ownerNames[tap]);
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
            Console.WriteLine("| NOMBRE ANIMAUX   |");
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
                int totalWeight = int.Parse(animalWeights[tap]);
                tw += totalWeight;
            }

            Console.WriteLine(tw);
            StartTheMachine();
        }

        private void ExtraireAnimauxSelonCouleurs()
        {
            string animalColor;
            do 
            { 
            Console.Write("VEUILLEZ SAISIR LA COULEUR DE RECHERCHE \n");

             animalColor = Console.ReadLine();

            } while (animalColor != "rouge" && animalColor != "bleu" && animalColor != "violet");

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
            do
            {
                int tap = Int32.Parse(Console.ReadLine());
            } while (tap < 10);

            Console.WriteLine("Dans la fonction voir liste animaux pension");

            if (tap == -1)
            {
                Console.WriteLine("Animal non trouvé.");
            }
            else
            {
                id[tap] =null;
                animalTypes[tap] = null;
                animalNames[tap] = null;
                animalAges[tap] = null;
                animalWeights[tap] = null;
                ownerNames[tap] = null;
                animalColors[tap] = null;
            }
            VoirListeAnimauxPension();

            StartTheMachine();
        }
    }
}
