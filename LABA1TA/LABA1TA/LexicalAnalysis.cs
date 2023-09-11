using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LABA1TA.Token;

namespace LABA1TA
{
    public class LexicalAnalysis
    {
        public static List<Token> Analysis(string ss, System.Windows.Forms.RichTextBox writebox)
        {
            List<Token> tokens = new List<Token>();
            List<string> listBuf = new List<string>();
            List<string> forToken = new List<string>();
            List<char> forChar = new List<char>();
            int i = 0;
            ss += ' ';
            string subText = "";
            foreach (char s in ss)
            {
                if (Lexem.IsOperator(subText) && (s == ' ' || s == '<' || s == '>' || s == ';' || s == '+' || s == '-' || s == '*' || s == '/' || s == ',' || s == ':' || s == '.'))
                {
                    listBuf.Add(subText + " ");
                    forToken.Add("I");
                    forChar.Add(' '); 
                    subText = "";
                }
                else if (Lexem.IsLiteral(subText) && (s == ' ' || s == ';' || s == ')' || s == ':' || s == '.' || s == '+' || s == '-' || s == '*' || s == '/'))
                {
                    listBuf.Add(subText + " ");
                    forToken.Add("D");
                    forChar.Add(' ');
                    subText = "";
                }
                else if (Lexem.IsSeparator(subText) && (s == ' ' || s == '(' || s == ')' || char.IsDigit(s) || char.IsLetter(s)))
                {
                    listBuf.Add(subText + " ");
                    forToken.Add("R");
                    forChar.Add(' ');
                    subText = "";
                }
                else if (Lexem.IsIDVariable(subText) && !Lexem.IsOperator(subText) && (s == ' ' || s == '<' || s == '>' || s == ';' || s == '+' || s == '-' || s == '*' || s == '/' || s == ',' || s == ':' || s == '.' || s == '>' || s == '<' || s == '='))
                {
                    listBuf.Add(subText + " ");
                    forToken.Add("P");
                    forChar.Add(' ');
                    subText = "";
                }
                else if (subText == Environment.NewLine || subText == " ")
                {
                    subText = "";
                }
                else if (Lexem.IsLiteral(subText) && char.IsLetter(s))
                {
                    throw new Exception($"Cимвол {subText + s} не является литералом");
                }
                subText += s;
            }
            string str;
            string type;
            Token token;
            for (i = 0; i < listBuf.Count; i++)
            {
                str = listBuf[i].Split()[0];
                type = forToken[i];
                if (type == "I")
                {
                    if (Token.IsSpecialWord(str))
                    {
                        token = new Token(Token.SpecialWords[str]);
                        tokens.Add(token);
                        continue;
                    }
                    else
                    {
                        token = new Token(TokenType.IDENTIFIER);
                        token.Value = str;
                        tokens.Add(token);
                        continue;
                    }
                }
                else if (type == "D")
                {
                    token = new Token(TokenType.LITERAL);
                    token.Value = str;
                    tokens.Add(token);
                    continue;
                }
                else if (type == "P")
                {
                    token = new Token(TokenType.IDENTIFIER);
                    token.Value = str;
                    tokens.Add(token);
                    continue;
                }
                else if (type == "R")
                {
                    if (Token.IsSpecialSymbol(str))
                    {
                        token = new Token(Token.SpecialSymbols[str]);

                        tokens.Add(token);
                        continue;
                    }
                }
            }
            foreach (Token lexem in tokens)
            {
                writebox.Text += lexem + " " + Environment.NewLine;
            }
            return tokens;
        }
    }
}