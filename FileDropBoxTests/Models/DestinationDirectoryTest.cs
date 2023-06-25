using System.IO;
using NUnit.Framework;
using FileDropBox.Models;

namespace FileDropBoxTests.Models
{
    [TestFixture]
    public class DestinationDirectoryTest
    {
        [Test]
        public void ファイルのコピーテスト()
        {
            var destDir = new DestinationDirectory();

            var destDirectoryInfo = new DirectoryInfo("test");
            destDirectoryInfo.Create();
            destDir.DestPath = destDirectoryInfo.FullName;

            var fileInfo = new FileInfo("a.txt");
            fileInfo.Create().Dispose();

            Assert.IsFalse(File.Exists(@"test\a.txt"));

            destDir.Copy(fileInfo.FullName);

            Assert.IsTrue(File.Exists(@"test\a.txt"));
        }

        [Test]
        public void ディレクトリと中のファイルのコピーのテスト()
        {
            var destDir = new DestinationDirectory();

            var destDirectoryInfo = new DirectoryInfo("test");
            destDirectoryInfo.Create();

            var currentDirectoryInfo = new DirectoryInfo("test0");
            currentDirectoryInfo.Create();

            var fileInfo = new FileInfo(@"test0\a.txt");
            fileInfo.Create().Dispose();

            destDir.DestPath = destDirectoryInfo.FullName;

            Assert.IsFalse(File.Exists(@"test\test0\a.txt"));

            destDir.Copy(currentDirectoryInfo.FullName);

            Assert.IsTrue(File.Exists(@"test\test0\a.txt"), "Copy 実行後、中のファイルごとディレクトリがコピーされるはず");
        }

        [TearDown]
        public void Clean()
        {
            if (File.Exists("a.txt"))
            {
                File.Delete("a.txt");
            }

            if (File.Exists(@"test\a.txt"))
            {
                File.Delete(@"test\a.txt");
            }

            if (File.Exists(@"test\test0\a.txt"))
            {
                File.Delete(@"test\test0\a.txt");
            }

            if (Directory.Exists(@"test\test0"))
            {
                Directory.Delete(@"test\test0");
            }

            if (Directory.Exists("test"))
            {
                Directory.Delete("test");
            }

            if (File.Exists(@"test0\a.txt"))
            {
                File.Delete(@"test0\a.txt");
            }

            if (Directory.Exists("test0"))
            {
                Directory.Delete("test0");
            }
        }
    }
}