using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupalTaller3D
{
    internal class Game
    {
        private Player player;
        private List<EnemigoValores> enemigos;

        public void Iniciar()
        {
            CrearJugador();
            CrearEnemigos();
            LoopJuego();
        }

        private void CrearJugador()
        {
            int vida, daño;

            do
            {
                Console.Write("Ingrese vida (max 100): ");
                vida = int.Parse(Console.ReadLine());

                Console.Write("Ingrese daño (max 100): ");
                daño = int.Parse(Console.ReadLine());

            } while (vida + daño > 100);

            player = new Player(vida, daño);
        }

        private void CrearEnemigos()
        {
            enemigos = new List<EnemigoValores>();

            enemigos.Add(new EnemigoMelee(10, 50));
            enemigos.Add(new EnemigoRango(8, 40, 3));
            enemigos.Add(new EnemigoMelee(12, 60));
        }

        private void LoopJuego()
        {
            int turno = 0;

            while (true)
            {
                if (player.IsDead())
                {
                    Console.WriteLine("Derrota");
                    break;
                }

                if (enemigos.All(e => e.IsDead()))
                {
                    Console.WriteLine("Victoria");
                    break;
                }

                Console.WriteLine("\nTURNO");

                for (int i = 0; i < enemigos.Count; i++)
                {
                    Console.WriteLine($"{i} - Vida: {enemigos[i].TakeHealth()}");
                }

                Console.Write("Elige enemigo: ");
                int index = int.Parse(Console.ReadLine());

                if (enemigos[index].IsDead())
                {
                    Console.WriteLine("Ese enemigo ya está muerto.");
                    continue;
                }

                int dmg = player.Attack();
                enemigos[index].TakeDamage(dmg);

                Console.WriteLine($"Atacaste por {dmg}");

                var enemigo = enemigos[turno % enemigos.Count];

                if (!enemigo.IsDead())
                {
                    int enemyDamage = 0;

                    if (enemigo is EnemigoMelee melee)
                        enemyDamage = melee.Attack();

                    else if (enemigo is EnemigoRango rango)
                        enemyDamage = rango.Attack();

                    player.TakeDamage(enemyDamage);
                    Console.WriteLine($"Enemigo te atacó por {enemyDamage}");
                }

                turno++;
            }
        }
    }
}
