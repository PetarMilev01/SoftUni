using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] info = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                if (trainers.Any(x=>x.Name == trainerName))
                {
                    Trainer trainer = trainers.Where(x => x.Name == trainerName).First();
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    trainers.Add(trainer);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string element = input;

                foreach (var trainer in trainers)
                {
                    bool havingElement = false;
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element == element)
                        {
                            havingElement = true;
                            break;
                        }
                    }
                    if (havingElement)
                    {
                        trainer.BadgesCount++;
                    }
                    else
                    {
                        List<Pokemon> pokemons = new List<Pokemon>(trainer.Pokemons);
                        for (int i = 0; i < pokemons.Count; i++)
                        {
                            pokemons[i].Health -= 10;
                            if (pokemons[i].Health <=0)
                            {
                                pokemons.RemoveAt(i);
                                i--;
                            }
                        }
                        trainer.Pokemons = pokemons;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x=>x.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
