using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using Ninject;
using NUnit.Framework;


namespace TDD_Ninjection
{
    [TestFixture]
    class FileManagerTest
    {
        [Test]
        public void FindLogFileTest6()
        {
            // Ninject Initialization
            IKernel ninjectKernel = new StandardKernel(new ConfigFileObjectData());

            FileManager manager = ninjectKernel.Get<FileManager>();

            Assert.IsTrue(manager.FindLogFile("file2.log"));
        }
    }
}
