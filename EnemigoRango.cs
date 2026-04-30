using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupalTaller3D
{
    internal class EnemigoRango : EnemigoValores
    {
        private int bullets;

        public EnemigoRango(int damage, int health, int bullets) : base(damage, health)
        {
            this.bullets = bullets;
        }

        public int Attack()
        {
            if (bullets > 0)
            {
                bullets--;
                return damage;
            }
            else
            {
                return 0;
            }
        }

        public string Status()
        {
            return IsDead() ? "Muerto" : "Vivo";
        }

        public int GetBullets()
        {
            return bullets;
        }
    }
}
