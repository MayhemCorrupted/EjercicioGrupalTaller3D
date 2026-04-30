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

        public override int Attack()
        {
            return damage;
        }

        public string Status() => IsDead() ? "Vivo" : "Muerto";
    }
}