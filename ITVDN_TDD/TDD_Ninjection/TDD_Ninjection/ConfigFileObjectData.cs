using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;

namespace TDD_Ninjection
{
    class ConfigFileObjectData : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDataAccessObject>().To<StubFileDataObject>();
            this.Bind<FileManager>().ToSelf();
        }
    }
}
