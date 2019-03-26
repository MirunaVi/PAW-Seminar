using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semPAW_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a1 = new Animal(12, "Grivei", 4.5f);
            Animal a2 = a1.Clone();
            a2.Greutate = 3.2f;

            ArrayList listaAnimale = new ArrayList();
            listaAnimale.Add(a1);
            listaAnimale.Add(a2);
            listaAnimale.Sort();
            foreach (Animal a in listaAnimale)
                Console.WriteLine(a);

            Pinguin p1 = new Pinguin(true, 10, "Chilly Willy", 2.3f);
            Urs u1 = new Urs(true, 20, "Balloo", 250f);
            Zoo z1 = new Zoo();
            z1.Denumire = "Baneasa";
            z1.Adresa = "Bucuresti";
            z1.Lista.Add(p1);
            z1.Lista.Add(u1);
            z1.Lista.Add(a1);
            z1.Lista.Add(a2);
            z1.Lista.Sort();

            foreach (Animal a in z1.Lista)
                Console.WriteLine(a);

            Zoo z2 = z1.Clone();
            foreach (Animal a in z2.Lista)
                a.Nume += " copie";
            foreach (Animal a in z2.Lista)
                Console.WriteLine(a);
        }
    }
}
