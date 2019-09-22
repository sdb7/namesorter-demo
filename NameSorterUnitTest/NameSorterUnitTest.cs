using NameSorter;
using NUnit.Framework;

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
            var stream = new NamesReader().Read(_filePath);

            Assert.NotNull(stream);
        }

        [Test]
        public void TestReadingLongName()
        {
            var nameReader = new NameSolver();
            var name = nameReader.ExtractName(_specialPerson);

            Assert.AreEqual(name.ToString(), _specialPerson);
        }

        [Test]
        public void TestReadingNormalName()
        {
            var nameReader = new NameSolver();
            var name = nameReader.ExtractName(_normalPersonName);
            Assert.AreEqual(name.ToString(), _normalPersonName);

        }
    }
}