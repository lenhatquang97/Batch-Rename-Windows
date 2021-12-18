using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IContract
{
    public interface IDao
    {
        string Description { get; }
        Dictionary<String, String> Preset { get; set; }
        Boolean Contains(String key);
        Boolean Create(String key, String value);
        String Read(String key);
        Boolean Update(String key, String value);
        Boolean Delete(String key);
        Boolean SavePreset();
        List<String> GetKeys();
    }
}
