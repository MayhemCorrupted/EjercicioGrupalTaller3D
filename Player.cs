using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupalTaller3D
{
    internal class Player
    {
        private int health;
        private int damage;

        public Player(int health, int damage)
        {
            this.health = health;
            this.damage = damage;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public int Attack()
        {
            return damage;
        }

        public int GetHealth()
        {
            return health;
        }

        public bool IsDead()
        {
            return health <= 0;
        }
    }
}
