using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IContract
{
    public class RenameRuleFactory
    {
        private Dictionary<String, IRename> _prototypes;
        public RenameRuleFactory()
        {
            _prototypes = new Dictionary<String, IRename>();
            var exeFolder = AppDomain.CurrentDomain.BaseDirectory;
            var dlls = new DirectoryInfo(exeFolder).GetFiles("*.dll");
            foreach (var dll in dlls)
            {
                var assembly = Assembly.LoadFrom(dll.FullName);
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.IsClass)
                    {
                        if (typeof(IRename).IsAssignableFrom(type))
                        {
                            var ir = Activator.CreateInstance(type) as IRename;
                            _prototypes.Add(ir.Name, ir);
                        }
                    }
                }
            }
        }
        public List<IRename> GetListOfValues()
        {
            return new List<IRename>(_prototypes.Values);
        }
    }
}
