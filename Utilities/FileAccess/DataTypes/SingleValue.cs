using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileAccess.DataTypes
{
    [DelimitedRecord("\t")]
    public class SingleValue<T1>
    {
        public T1 Item1 { get; set; }
    }
}
