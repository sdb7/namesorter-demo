using NameSorter;
using NUnit.Framework;
using System.IO;

namespace Tests
{
    [TestFixture(@"c:\unsorted-names-list.txt", "Selle Bellison", "Orson Milka Iddins", "Leonerd Adda Mitchell Monaghan", 
        Author = "sdb.developer@gmail.com")]
    public class NameSorterUnitTest
    {
        private string _filePath;
        private string _normalPersonName;
        private string _specialPerson;
        private string _overlyAttachedName;

        public NameSorterUnitTest(string path, string normalPersonName, string specialPersonName, string overlyAttachedMotherNamedHerSonThisLong)
        {
            _filePath = path;
            _normalPersonName = normalPersonName;
            _specialPerson = specialPersonName;
            _overlyAttachedName = overlyAttachedMotherNamedHerSonThisLong;
        }

        [Test]
        public void TestReadingFileToStream()
        {
            var stream = new NamesFileReader().Read(_filePath);

            Assert.NotNull(stream);
        }

        [Test]
        public void TestReadingLongName()
        {
            var nameSolver = new NameSolver();
            var name = nameSolver.ExtractName(_specialPerson);

            Assert.AreEqual(name.ToString(), _specialPerson);
        }

        [Test]
        public void TestReadingNormalName()
        {
            var nameSolver = new NameSolver();
            var name = nameSolver.ExtractName(_normalPersonName);
            Assert.AreEqual(name.ToString(), _normalPersonName);
        }

        [Test]
        public void TestReadingTextFromStream()
        {
            var nameReader = new NamesFileReader();
            var result = nameReader.Read(_filePath);

            using (StreamReader sr = new StreamReader(result))
            {
                while (sr.Peek() >= 0)
                {
                    Assert.DoesNotThrow(() =>
                    {
                        TestContext.Out.WriteLine(sr.ReadLine());
                    });
                    

                }
            }
        }

        [Test]
        public void TestSorter()
        {
           

            Assert.DoesNotThrow(() => {

                var sorter = new Sorter(new NamesFileReader());
                sorter.ReadSource(_filePath);
                var tempSortedItem = sorter.Sort();
                sorter.ShowResult(new ConsoleNamesWriter());
            });
        }
    }
}