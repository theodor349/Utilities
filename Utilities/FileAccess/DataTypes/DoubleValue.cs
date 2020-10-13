using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileAccess.DataTypes
{

    [DelimitedRecord("\t")]
    public class DoubleValue<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
    }
}
