using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicGenericExample
{

    public interface ISpell
    {
        void Cast();
        int GetPower();
    }


    public interface IDarkMagic
    {
        void DarkEffect();
    }


    public class Fireball : ISpell, IComparable<Fireball>
    {
        private int power;

        public Fireball()
        {
            power = new Random().Next(10, 50);
        }

        public void Cast()
        {
            Console.WriteLine($"Fireball deals {power} damage");
        }

        public int GetPower() => power;

        public int CompareTo(Fireball other)
        {
            return power.CompareTo(other.power);
        }
    }


    public class HealingWave : ISpell, IComparable<HealingWave>
    {
        private int power;

        public HealingWave()
        {
            power = new Random().Next(5, 40);
        }

        public void Cast()
        {
            Console.WriteLine($"Healing restores {power} HP");
        }

        public int GetPower() => power;

        public int CompareTo(HealingWave other)
        {
            return power.CompareTo(other.power);
        }
    }


    public class DarkCurse : ISpell, IDarkMagic, IComparable<DarkCurse>
    {
        private int power;

        public DarkCurse()
        {
            power = new Random().Next(30, 80);
        }

        public void Cast()
        {
            Console.WriteLine($"Dark curse hits with {power}");
        }

        public void DarkEffect()
        {
            Console.WriteLine("Dark aura spreads...");
        }

        public int GetPower() => power;

        public int CompareTo(DarkCurse other)
        {
            return power.CompareTo(other.power);
        }
    }


    public class Spellbook<T>
        where T : class, ISpell, IComparable<T>, new()
    {
        private List<T> spells = new List<T>();

        public void SortSpells()
        {
            spells.Sort();
        }

        
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Firebook ===");
            var fireBook = new Spellbook<Fireball>();



   

            Console.WriteLine("\n=== Darkbook ===");
            var darkBook = new Spellbook<DarkCurse>();



            Console.WriteLine("\n=== Mixed test ===");
            var healBook = new Spellbook<HealingWave>();



        }
    }
}
