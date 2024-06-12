using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Text_Editor
{
    internal class ScientificEvaluter
    {
        public static double Evalute(string expression)
        {
            expression = expression.Replace("cos", "Math.Cos");
            expression = expression.Replace("tan", "Math.Tan");
            expression = expression.Replace("sin", "Math.Sin");
            expression = expression.Replace("cosh", "Math.Cosh");
            expression = expression.Replace("tanh", "Math.Tanh");
            expression = expression.Replace("sinh", "Math.Sinh");
            expression = expression.Replace("acos", "Math.Acos");
            expression = expression.Replace("atan", "Math.Atan");
            expression = expression.Replace("asin", "Math.Asin");
            expression = expression.Replace("trun", "Math.Truncate");
            expression = expression.Replace("ceil", "Math.Ceiling");
            expression = expression.Replace("round", "Round");
            expression = expression.Replace("floor", "Math.Floor");
            expression = expression.Replace("abs", "Math.Abs");
            expression = expression.Replace("sqrt", "Math.Sqrt");
            expression = expression.Replace("cbrt", "Cbrt");
            expression = expression.Replace("exp", "Math.Exp");
            expression = expression.Replace("log", "Math.Log");
            expression = expression.Replace("log10", "Math.Log10");
            expression = expression.Replace("fac", "Fac");
            expression = expression.Replace("pot", "Pot");
            expression = expression.Replace("root", "Root");
            expression = expression.Replace("square", "Square");
            expression = expression.Replace("cube", "Cube");
            expression = expression.Replace("e", "2.7182818284590451");
            expression = expression.Replace("π", "3.1415926535897931");
            expression = expression.Replace(",", ".");

            try
            {
                CSharpCodeProvider c = new CSharpCodeProvider();
                CompilerParameters cp = new CompilerParameters();
                ICodeCompiler icc = c.CreateCompiler();

                cp.ReferencedAssemblies.Add("system.dll");
                cp.CompilerOptions = "/t:library";
                cp.GenerateInMemory = true;

                StringBuilder sb = new StringBuilder("");
                sb.Append("using System;");
                sb.Append("namespace CSCodeEvaler {");
                sb.Append("public class CSCodeEvaler {");
                sb.Append("public static double Round(double num) {");
                sb.Append("return Math.Round(num, 5);");
                sb.Append("}");
                sb.Append("public static double Cbrt(double num) {");
                sb.Append("return Math.Pow(num, 1.0 / 3.0);");
                sb.Append("}");
                sb.Append("public static int Fac(double num) {");
                sb.Append("int number = Convert.ToInt32(num);");
                sb.Append("int result = 1;");
                sb.Append("for(int i = number; i > 0; i--) {");
                sb.Append("result *= i;");
                sb.Append("}");
                sb.Append("return result;");
                sb.Append("}");
                sb.Append("public static double Pot(double power, double num) {");
                sb.Append("return Math.Pow(num, power);");
                sb.Append("}");
                sb.Append("public static double Root(double root, double num) {");
                sb.Append("return Math.Pow(num, 1.0 / root);");
                sb.Append("}");
                sb.Append("public static double Square(double num) {");
                sb.Append("return num * num;");
                sb.Append("}");
                sb.Append("public static double Cube(double num) {");
                sb.Append("return num * num * num;");
                sb.Append("}");
                sb.Append("public static double EvalCode() {");
                sb.Append("return " + expression + ";");
                sb.Append("}");
                sb.Append("}");
                sb.Append("}");

                CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());

                Assembly a = cr.CompiledAssembly;
                object o = a.CreateInstance("CSCodeEvaler.CSCodeEvaler");

                Type t = o.GetType();
                MethodInfo mi = t.GetMethod("EvalCode");

                double s = Convert.ToDouble(mi.Invoke(o, null));
                return s;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return double.NaN;
            }
        }
    }
}
