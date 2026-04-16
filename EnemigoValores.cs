using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupalTaller3D
{
    internal abstract class EnemigoValores
    {
        protected int damage;
        protected int health;
        public EnemigoValores(int damage, int health)
        {
            this.damage = damage;
            this.health = health;
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }   
        public int TakeHealth() => health;
        public bool IsDead() => health <= 0;
    }
}
