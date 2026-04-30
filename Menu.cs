using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupalTaller3D
{
    internal class Menu
    {
        private Jugador jugador;
        private List<EnemigoValores> enemies = new List<EnemigoValores>();

        public void Execute()
        {
            CreatePlayer();
            CreateEnemies();
            StartCombat();
        }

        void CreatePlayer()
        {
            int health;
            int damage;

            Console.WriteLine("Crea tu jugador, Asignale la vida");

            Console.Write("Vida (max 100): ");
            if (!int.TryParse(Console.ReadLine(), out health) || health > 100)
            {
                Console.WriteLine("Valor invalido, se asigna 100 por defecto");
                health = 100;
            }

            Console.Write("Daño (max 100): ");
            if (!int.TryParse(Console.ReadLine(), out damage) || damage > 100)
            {
                Console.WriteLine("Valor invalido, se asigna 10 por defecto");
                damage = 10;
            }

            jugador = new Jugador(health, damage);
        }

        void CreateEnemies()
        {
            enemies.Clear();

            enemies.Add(new EnemigoMelee(10, 50));
            enemies.Add(new EnemigoMelee(15, 60));
            enemies.Add(new EnemigoMelee(20, 70));
        }
        void StartCombat()
        {
            int enemyIndex = 0;

            while (true)
            {
                if (AllEnemiesDead())
                {
                    Console.WriteLine("Ganaste");
                    break;
                }

                if (jugador.IsDead())
                {
                    Console.WriteLine("Perdiste...");
                    break;
                }

                Console.WriteLine("Tu vida: " + jugador.TakeHealth());
                ShowEnemies();

                Console.Write("Elige enemigo: ");
                int option;

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Entrada invalida");
                    continue;
                }

                if (option >= 0 && option < enemies.Count)
                {
                    EnemigoValores enemy = enemies[option];

                    if (!enemy.IsDead())
                    {
                        enemy.TakeDamage(jugador.Attack());
                        Console.WriteLine("Atacaste al enemigo");
                    }
                    else
                    {
                        Console.WriteLine("Ese enemigo ya esta muerto");
                    }
                }
                else
                {
                    Console.WriteLine("Opcion fuera de rango");
                    continue;
                }

                if (enemyIndex < enemies.Count)
                {
                    EnemigoValores enemy = enemies[enemyIndex];

                    if (!enemy.IsDead())
                    {
                        jugador.TakeDamage(enemy.Attack());
                        Console.WriteLine("El enemigo te ataca!");
                    }

                    enemyIndex++;
                }
                else
                {
                    enemyIndex = 0;
                }
            }
        }
        void ShowEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine(i + ": Vida " + enemies[i].TakeHealth());
            }
        }

        bool AllEnemiesDead()
        {
            foreach (var enemy in enemies)
            {
                if (!enemy.IsDead())
                {
                    return false;
                }
            }
            return true;
        }
    }
}