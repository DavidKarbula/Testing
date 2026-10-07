
using Testing;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {


        [TestMethod]
        [DataRow("Jakub")]
        [DataRow("Kořínek")]
        [DataRow("Helmut")]
        public void TestPridat(string a)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            sprava.PridejUzivatele(a);
            Assert.IsTrue(sprava.ExistujeUzivatel(a));
        }

        [TestMethod]
        [DataRow("")]
        public void TestPridat_exception(string a)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            Assert.ThrowsException<ArgumentException>(() => sprava.PridejUzivatele(a));
        }

        [TestMethod]
        [DataRow("Jakub")]
        [DataRow("Kořínek")]
        [DataRow("Helmut")]
        public void TestOdebrat(string a)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            sprava.PridejUzivatele(a);
            sprava.OdeberUzivatele(a);
            Assert.IsFalse(sprava.ExistujeUzivatel(a));
        }

        [TestMethod]
        [DataRow("Jakub")]
        [DataRow("Kořínek")]
        [DataRow("Helmut")]
        public void TestOdebratFalse(string a)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
                Assert.IsFalse(sprava.OdeberUzivatele(a));
        }

        [TestMethod]
        [DataRow("Jakub", "Ondřej", "Helmut")]
        [DataRow("Kořínek", "Jakub", "Ondra")]
        [DataRow("Helmut", "Vajda", "Lukáš")]
        public void TestPocet(string a, string b, string c)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            sprava.PridejUzivatele(a);
            sprava.PridejUzivatele(b);
            sprava.PridejUzivatele(c);
            Assert.AreEqual(3, sprava.ZiskejPocetUzivatelu());
        }

        [TestMethod]
        [DataRow("Jakub", "Jandřej", "Jalmut")]
        [DataRow("Kořínek", "Kakub", "Kondra")]
        [DataRow("Helmut", "Hajda", "Hukáš")]
        public void TestSmazatVse(string a, string b, string c)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            sprava.PridejUzivatele(a);
            sprava.PridejUzivatele(b);
            sprava.PridejUzivatele(c);
            Assert.AreEqual(3, sprava.ZiskejPocetUzivatelu());
            sprava.VymazVsechny();
            Assert.IsTrue(sprava.ZiskejPocetUzivatelu() == 0);
           
        }

        [TestMethod]
        [DataRow("Jakub")]
        [DataRow("Kořínek")]
        [DataRow("Helmut")]
        public void TestExistuje(string a)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            sprava.PridejUzivatele(a);
            Assert.IsTrue(sprava.ExistujeUzivatel(a));
        }

        [TestMethod]
        public void TestExistujeFalse()
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            sprava.PridejUzivatele("Kuba");
            Assert.IsFalse(sprava.ExistujeUzivatel("Jakub"));
        }

        [TestMethod]
        [DataRow("1990-05-12 14:30:00", "2024-01-15 09:45:00", 33)]
        [DataRow("1985-09-23 08:15:00", "2023-06-20 16:30:00", 37)]
        [DataRow("1978-02-07 21:45:00", "2025-03-10 11:20:00", 47)]
        public void TestVek(string a, string b, int c)
        {
            DateTime narozeni = DateTime.Parse(a);
            DateTime date = DateTime.Parse(b);
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            Assert.AreEqual(c, sprava.SpocitejVek(narozeni, date));
        }
        [TestMethod]
        [DataRow(33)]
        [DataRow(18)]
        [DataRow(47)]
        public void TestPlnolety(int c)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            Assert.IsTrue(sprava.JePlnolety(c));
        }

        [TestMethod]
        [DataRow(3)]
        [DataRow(17)]
        [DataRow(14)]
        public void TestPlnoletyFalse(int c)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            Assert.IsFalse(sprava.JePlnolety(c));
        }

        [TestMethod]
        [DataRow("Jakub", "Jandřej", "Jalmut")]
        [DataRow("Kořínek", "Kakub", "Kondra")]
        [DataRow("Helmut", "Hajda", "Hukáš")]
        public void TestVypsatVse(string a, string b, string c)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            sprava.PridejUzivatele(a);
            sprava.PridejUzivatele(b);
            sprava.PridejUzivatele(c);
            List<String> list = new List<String>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            CollectionAssert.AreEqual(list, sprava.ZiskejVsechnyUzivatele());
        }

        [TestMethod]
        [DataRow("Jakub", "Jandřej", "Jalmut", "Ja")]
        [DataRow("Kořínek", "Kokub", "Kondra", "KO")]
        [DataRow("Helmut", "Hajda", "Hukáš", "h")]
        [DataRow("Helmut", "Hajda", "Hukáš", "")]
        public void TestNajdiPodleZacatku(string a, string b, string c, string d)
        {
            SpravaUzivatelu sprava = new SpravaUzivatelu();
            sprava.PridejUzivatele(a);
            sprava.PridejUzivatele(b);
            sprava.PridejUzivatele(c);

            if (d != "")
            {
                string[] array = new string[3];
                array[0] = a;
                array[1] = b;
                array[2] = c;
                CollectionAssert.AreEqual(array, sprava.NajdiUzivateleDleZacatku(d));
            }
            else
            {
                string[] array = new string[3];
                array[0] = a;
                array[1] = b;
                array[2] = c;
                CollectionAssert.AreNotEqual(array, sprava.NajdiUzivateleDleZacatku(d));
            }
            
        }

        [TestMethod]
        [DataRow("Jakub", "Jandřej", "Jalmut")]
        [DataRow("Kořínek", "Kakub", "Kondra")]
        [DataRow("Helmut", "Hajda", "Hukáš")]
        public void TestNovySeznam(string a, string b, string c)
        {

            SpravaUzivatelu sprava = new SpravaUzivatelu();
            sprava.PridejUzivatele("Marek");
            string[] array = new string[3];
            List<String> list = new List<String>();

            array[0] = a;
            array[1] = b;
            array[2] = c;
            
            list.Add(a);
            list.Add(b);
            list.Add(c);
            sprava.NastavSeznam(array);
            CollectionAssert.AreEqual( list ,sprava.ZiskejVsechnyUzivatele());
        }
    }
}
