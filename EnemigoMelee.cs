using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupalTaller3D
{
    internal class EnemigoMelee : EnemigoValores
    {
        public EnemigoMelee(int damage, int health) : base(damage, health)
        {
        }

        public int Attack()
        {
            return damage;
        }

        public string Status()
        {
            return IsDead() ? "Muerto" : "Vivo";
        }
    }
}
