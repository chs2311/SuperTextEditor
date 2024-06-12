using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;

namespace Super_Text_Editor
{
    internal class ProgrammingCodes
    {
        public static string GetByDataType(string type)
        {
            switch(type.Trim('.').ToLower())
            {
                case "c":
                    return C;
                case "cpp":
                    return CPP;
                case "cs":
                    return CS;
                case "java":
                    return JAVA;
                case "js":
                    return JAVASCRIPT;
                case "py":
                    return PYTHON;
                case "hmtl":
                    return HTML;
                case "xml":
                    return XML;
                case "sql":
                    return SQL;
                default:
                    return "";
            }
        }

        public static string C
        {
            get { return "#include <stdio.h>\r\nint main()\r\n{\r\n    return 0;\r\n}"; }
        }

        public static string CPP
        {
            get { return "#include <iostream>\r\nvoid main()\r\n{\r\n\r\n}"; }
        }

        public static string CS
        {
            get { return "using System;\r\npublic class Program\r\n{\r\n    public static void Main(string[] args)\r\n    {\r\n\r\n    }\r\n}"; }
        }

        public static string JAVA
        {
            get { return "public static class Main\r\n{\r\n    public static void Main(string[] args)\r\n    {\r\n\r\n    }\r\n}"; }
        }

        public static string JAVASCRIPT
        {
            get { return "function main() {\n\r\n}"; }
        }

        public static string PYTHON
        {
            get { return "def main(): "; }
        }

        public static string HTML
        {
            get { return "<!DOCTYPE html>\r\n\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <title></title>\r\n</head>\r\n<body>\r\n\r\n</body>\r\n</html>"; }
        }

        public static string XML
        {
            get { return "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<Startelement>\r\n\t<Element attribute1 =\"\">\r\n\t\t\r\n\t</Element>\r\n</Startelement>"; }
        }

        public static string SQL
        {
            get { return "CREATE TABLE table_name (\r\n    \r\n);"; }
        }
    }
}