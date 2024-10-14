using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAckLibrarry
{
    public class Person

    {
        #region Properties

        public String? Name { get; set; }
        public DateTimeOffset Born { get; set; }
        public List<Person> Children = new();
        public List<Person> Spouses = new();
        public bool Married => Spouses.Count > 0;
        public List<Person> Parents = new();

        #endregion

        #region Methods

        public void WriteToConsole()
        {
            Console.WriteLine($"{Name} was born on a {Born:dddd}");
        }

        public void WriteChildrenToConsole()
        {
            string term = Children.Count == 1 ? "child" : "children";
            Console.WriteLine($"{Name} has {Children.Count} {term}.");
        }

        public static void Marry(Person p1, Person p2)
        {
            ArgumentNullException.ThrowIfNull(p1);
            ArgumentNullException.ThrowIfNull(p2);

            if (p1.Spouses.Contains(p2) || p2.Spouses.Contains(p1))
            {
                throw new ArgumentException(string.Format("{0} is already married to {1}.", arg0: p1.Name, arg1: p2.Name));
            }

            p1.Spouses.Add(p2);
            p2.Spouses.Add(p1);
        }

        public void Marry(Person partner)
        {
            Marry(this, partner);
        }

        public void OutputSpouses()
        {
            if (Married)
            {
                string term = Spouses.Count == 1 ? "person" : "people";
                Console.WriteLine($"{Name} is married to {Spouses.Count} {term}:");

                foreach (var spouse in Spouses)
                {
                    Console.WriteLine($"{spouse.Name}");
                }
            }
            else
            {
                Console.WriteLine($"{Name} is single.");
            }
        }

        public static Person Procreate(Person p1, Person p2)
        {
            ArgumentNullException.ThrowIfNull(p1);
            ArgumentNullException.ThrowIfNull(p2);
            if (!p1.Spouses.Contains(p2) && !p2.Spouses.Contains(p1))
            {
                throw new ArgumentException(string.Format("{0} must be married to {1} to procreate with them.",
                    arg0: p1.Name, arg1: p2.Name));
            }

            Person baby = new()
            {
                Name = $"Baby of {p1.Name} and {p2.Name}",
                Born = DateTimeOffset.Now
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);
            baby.Parents.Add(p1);
            baby.Parents.Add(p2);

            return baby;
        }

        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        // New methods for the requested scenarios

        public bool HasKids()
        {
            return Children.Count > 0;
        }

        public void AdoptKid(Person child)
        {
            if (Married && !HasKids())
            {
                Children.Add(child);
                child.Parents.Add(this);
                child.Parents.Add(Spouses[0]);
                Spouses[0].Children.Add(child);
                Console.WriteLine($"{Name} and {Spouses[0].Name} have adopted {child.Name}!");
            }
            else if (!Married)
            {
                Console.WriteLine($"{Name} must be married to adopt a child.");
            }
            else
            {
                Console.WriteLine($"{Name} and {Spouses[0].Name} already have children.");
            }
        }

        public bool IsStepChild
        {
            get
            {
                if (Parents.Count != 2) return false;
                return !Parents[0].Spouses.Contains(Parents[1]);
            }
        }

        public void ShowParents()
        {
            Console.WriteLine($"{Name}'s parents:");
            if (Parents.Count == 0)
            {
                Console.WriteLine("No parents information available.");
            }
            else
            {
                foreach (var parent in Parents)
                {
                    Console.WriteLine($"- {parent.Name}");
                }
            }
        }

        #endregion

        #region Operators

        public static bool operator +(Person a, Person b)
        {
            Marry(a, b);
            return a.Married && b.Married;
        }

        public static Person operator *(Person a, Person b)
        {
            return Procreate(a, b);
        }

        #endregion
    }
}


    
