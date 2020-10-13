using Converter;
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
            var converter = new Parser();

            string path = "";
            var data = new DataAccess();
            var records = data.Load<DoubleValue<string, string>>(path + "Input.txt");
            records.ForEach(x => x.Item2 = converter.TypeToParser(x.Item2, "value"));
            var outPut = MakeSwitchCases(records, "car");
            data.Write(path + "Output.txt", outPut);
        }

        public List<SingleValue<string>> MakeSwitchCases(List<DoubleValue<string, string>> records, string variableName)
        {
            var outPut = new List<SingleValue<string>>();
            Set(ref outPut, i => "case (\"", records.Count);
            Append(ref outPut, i => records[i].Item1 + "\"):\n");
            Append(ref outPut, i => "\t" + variableName + "." + records[i].Item1 + " = " + records[i].Item2 + ";\n");
            Append(ref outPut, i => "\tbreak;");
            return outPut;
        }

        public List<SingleValue<string>> MakePublicVariable(List<DoubleValue<string, string>> records)
        {
            var outPut = new List<SingleValue<string>>();
            Set(ref outPut, i => "public ", records.Count);
            Append(ref outPut, i => records[i].Item2 + " ");
            Append(ref outPut, i => records[i].Item1 + " ");
            Append(ref outPut, i => "{ get; set; }");
            return outPut;
        }

        public void Append(ref List<SingleValue<string>> list, Func<int, string> f)
        {
            for (int i = 0; i < list.Count; i++)
                list[i].Item1 += f(i);
        }

        public void Set(ref List<SingleValue<string>> list, Func<int, string> f, int length)
        {
            for (int i = 0; i < length; i++)
                list.Add(new SingleValue<string>() { Item1 = f(i) });
        }

    }
}
