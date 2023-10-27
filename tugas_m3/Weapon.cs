using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_m3
{
    internal class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int FireRate { get; set; }

        public Weapon(string name, int damage, int fireRate)
        {
            this.Name = name;
            this.Damage = damage;
            this.FireRate = fireRate;
        }
    }
}
