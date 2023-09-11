using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA1TA
{
    public class LexicalAnalysisFirst
    {
        public static void Analysis(string ss, System.Windows.Forms.RichTextBox writebox)
        {
            List<string> lexemes = new List<string>();
            lexemes = new List<string>();
            ss += ' ';
            string sText = "";
            foreach (char s in ss)
            {
                if (Lexem.IsLiteral(sText) && (s == ' ' || s == ';' || s == ')' || s == ':' || s == '.' || s == '+' || s == '-' || s == '*' || s == '/'))
                {
                    lexemes.Add(sText + " - Литерал;");
                    sText = "";
                }
                else if (Lexem.IsSeparator(sText) && (s == ' ' || s == '(' || s == ')' || char.IsDigit(s) || char.IsLetter(s)))
                {
                    lexemes.Add(sText + " - Разделитель;");
                    sText = "";
                }
                else if (Lexem.IsIDVariable(sText) && (s == ' ' || s == '<' || s == '>' || s == ';' || s == '+' || s == '-' || s == '*' || s == '/' || s == ',' || s == ':' || s == '.' || s == '>' || s == '<' || s == '='))
                {
                    lexemes.Add(sText + " - Идентификатор;");
                    sText = "";
                }
                else if (sText == Environment.NewLine || sText == " ")
                {
                    sText = "";
                }
                else if (Lexem.IsLiteral(sText) && char.IsLetter(s))
                {
                    throw new Exception($"Cимвол {sText + s} не является литералом");
                }
                sText += s;
            }
            foreach (string lexem in lexemes)
            {
                writebox.Text += lexem + " " + Environment.NewLine;
            }
        }
    }
}