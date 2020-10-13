using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace FileAccess
{
    public class DataAccess
    {
        public List<T> Load<T>(string path) where T : class
        {
            var engine = new FileHelperEngine<T>(Encoding.UTF8);
            return engine.ReadFile(path).ToList();
        }

        public void Write<T>(string path, IEnumerable<T> records) where T : class
        {
            var engine = new FileHelperEngine<T>(Encoding.UTF8);
            engine.WriteFile(path, records);
        }

    }
}
