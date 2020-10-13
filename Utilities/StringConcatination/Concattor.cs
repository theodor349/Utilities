using FileAccess;
using FileAccess.DataTypes;
using System;
using System.Collections.Generic;

namespace StringConcatination
{
    public class Concattor
    {
        public void Run()
        {
            string path = "";
            var data = new DataAccess();
            var records = data.Load<DoubleValue<string, string>>(path + "Input.txt");
            var outPut = new List<SingleValue<string>>();

            Set(ref outPut, i => "public ", records.Count);
            Append(ref outPut, i => records[i].Item2 + " ");
            Append(ref outPut, i => records[i].Item1 + " ");
            Append(ref outPut, i => "{ get; set; }");

            data.Write(path + "Output.txt", outPut);
        }

        private void Append(ref List<SingleValue<string>> list, Func<int, string> f)
        {
            for (int i = 0; i < list.Count; i++)
                list[i].Item1 += f(i);
        }

        private void Set(ref List<SingleValue<string>> list, Func<int, string> f, int length)
        {
            for (int i = 0; i < length; i++)
                list.Add(new SingleValue<string>() { Item1 = f(i) });
        }

    }
}
