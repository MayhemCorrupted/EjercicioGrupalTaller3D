using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupalTaller3D
{
    internal class Jugador
    {
        private int health;
        private int damage;

        public Jugador(int health, int damage)
        {
            this.health = health;
            this.damage = damage;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
        }

        public int Attack()
        {
            return damage;
        }

        public int TakeHealth()
        {
            return health;
        }

        public bool IsDead()
        {
            if (health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}