using System;

namespace Converter
{
    public class Parser
    {
        public string TypeToParser(string type, string valueName)
        {
            var res = "";
            switch (type)
            {
                case "long":
                    res = "long.Parse(" + valueName + ")";
                    break;
                case "int":
                    res = "int.Parse(" + valueName + ")";
                    break;
                case "float":
                    res = "float.Parse(" + valueName + ")";
                    break;
                case "decimal":
                    res = "decimal.Parse(" + valueName + ")";
                    break;
                case "DateTime":
                    res = "DateTime.Parse(" + valueName + ", CultureInfo.CurrentCulture)";
                    break;
                case "bool":
                    res = "bool.Parse(" + valueName + ")";
                    break;
                default:
                    res = valueName;
                    break;
            }
            return res;
        }
    }
}
