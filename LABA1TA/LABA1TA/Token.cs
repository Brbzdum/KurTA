using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA1TA
{
    public class Token
    {
        public enum TokenType
        {
            VOID, MAIN, FOR, INT, FLOAT, DOUBLE, LITERAL, NUMBER, IDENTIFIER,
            LPAR, RPAR, LBRACE, RBRACE, PLUS, MINUS, EQUALS, LESS, GREATER,
            DIVISION, MULTIPLICATION, COMMA, SEMICOLON, PLUSPLUS, GREATEREQ, LESSEQ
        }
        public TokenType Type;
        public string Value;
        public Token(TokenType type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}", Type, Value);
        }
        public static Dictionary<string, TokenType> SpecialWords = new Dictionary<string, TokenType>()
        {
             { "void", TokenType.VOID },
             { "main", TokenType.MAIN },
             { "for", TokenType.FOR },
             { "int", TokenType.INT },
             { "float", TokenType.FLOAT },
             { "double", TokenType.DOUBLE }
         };
        public static bool IsSpecialWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;

            }
            return SpecialWords.ContainsKey(word);
        }
        public static Dictionary<string, TokenType> SpecialSymbols = new Dictionary<string, TokenType>()
             {
                 { "(", TokenType.LPAR },
                 { ")", TokenType.RPAR },
                 { "{", TokenType.LBRACE },
                 { "}", TokenType.RBRACE },
                 { "+", TokenType.PLUS },
                 { "-", TokenType.MINUS },
                 { "=", TokenType.EQUALS },
                 { "<", TokenType.LESS },
                 { ">", TokenType.GREATER },
                 { "/", TokenType.DIVISION },
                 { "*", TokenType.MULTIPLICATION },
                 { ",", TokenType.COMMA },
                 { ";", TokenType.SEMICOLON },
                 { "++", TokenType.PLUSPLUS},
                 { "<=", TokenType.LESSEQ },
                 { ">=", TokenType.GREATEREQ }
             };
        public static bool IsSpecialSymbol(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            return SpecialSymbols.ContainsKey(str);
        }
    }
}