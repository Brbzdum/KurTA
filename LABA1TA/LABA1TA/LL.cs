using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LABA1TA.Token;

namespace LABA1TA
{
    internal class LL
    {

        bool firstEXPR = true;
        int lastEXPRind = 0;
        public List<Troyka> operatsii = new List<Troyka>();

        List<Token> token;
        public bool Succes = false;
        int i;
        public LL(List<Token> tokens)
        {
            this.token = tokens;
        }
        public void Start()
        {
            i = 0;
            try
            {
                Programm();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: #{ex.Message}");
                MessageBox.Show($"Errror! #{ex.Message}");
            }
        }

        public void Next()
        {
            if (i < token.Count - 1)
            {
                i++;
            }
        }
        public void Type()
        {
            if (token[i].Type != Token.TokenType.INT
            && token[i].Type != Token.TokenType.FLOAT
            && token[i].Type != Token.TokenType.DOUBLE)
                throw new Exception($"27\nSTRING: {i + 1} - Ожидалось: INT, FLOAT или DOUBLE, а получено: {token[i].Type}");
            Next();
        }
        public void Programm()
        {
            Succes = false;
            if (token[i].Type != Token.TokenType.VOID)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: goida, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.MAIN)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: cheee, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.LPAR)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: CHEGO скобка, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.RPAR)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: pochemy скобка, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.LBRACE)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: kago фигурная скобка, а получено: {token[i].Type}");
            Next();
            SpisObv();
            Next();
            SpisOper();
            Next();
            if (token[i].Type != Token.TokenType.RBRACE)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: Закрывающая фигурная скобка, а получено: {token[i].Type}");
        }
        public void SpisObv()
        {
            Type();
            Obv();
            DopObv();
        }
        public void Obv()
        {
            if (token[i].Type != Token.TokenType.IDENTIFIER)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: ID, а получено: {token[i].Type}");
            Next();
            p1();
        }
        public void p1()
        {
            switch (token[i].Type)
            {
                case Token.TokenType.SEMICOLON:
                    break;
                case Token.TokenType.COMMA:
                    Next();
                    Obv();
                    break;
                default: throw new Exception($"12\nSTRING: {i + 1} - Ожидалось: ; или , а получено: {token[i].Type}");
            }

        }
        public void DopObv()
        {
            switch (token[i].Type)
            {
                case Token.TokenType.INT:
                    Obv();
                    break;
                case Token.TokenType.DOUBLE:
                    Obv();
                    break;
                case Token.TokenType.FLOAT:
                    Obv();
                    break;
                default:
                    break;
            }
        }
        public void SpisOper()
        {
            Oper();
            DopOper();
        }
        public void Oper()
        {
            switch (token[i].Type)
            {
                case Token.TokenType.FOR:
                    Cycle();
                    break;
                case Token.TokenType.IDENTIFIER:
                    Prisv();
                    break;
                default: throw new Exception($"12\nSTRING: {i + 1} - Ожидалось: for или id, а получено: {token[i].Type}");
            }
        }
        public void Cycle()
        {
            if (token[i].Type != Token.TokenType.FOR)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: for, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.LPAR)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: Открывающая скобка, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.IDENTIFIER)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: ID, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.EQUALS)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: =, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.LITERAL)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: Число, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.SEMICOLON)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: ;, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.IDENTIFIER)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: ID, а получено: {token[i].Type}");
            Next();
            Sign();
            Next();
            if (token[i].Type != Token.TokenType.LITERAL)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: Число, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.SEMICOLON)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: ;, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.IDENTIFIER)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: ID, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.PLUSPLUS)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: ++, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.RPAR)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: Закрывающая скобка, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.LBRACE)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: Открывающая фигурная скобка, а получено: {token[i].Type}");
            Next();
            SpisOper();
            if (token[i].Type != Token.TokenType.RBRACE)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: Закрывающая фигурная скобка, а получено: {token[i].Type}");
            Next();
        }
        public void Sign()
        {
            switch (token[i].Type)
            {
                case Token.TokenType.LESS:
                    break;
                case Token.TokenType.LESSEQ:
                    break;
                case Token.TokenType.GREATER:
                    break;
                case Token.TokenType.GREATEREQ:
                    break;
                default: throw new Exception($"12\nSTRING: {i + 1} - Ожидалось: логические знак, а получено: {token[i].Type}");
            }
        }
        public void Prisv()
        {
            if (token[i].Type != Token.TokenType.IDENTIFIER)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: ID, а получено: {token[i].Type}");
            Next();
            if (token[i].Type != Token.TokenType.EQUALS)
                throw new Exception($"1\nSTRING: {i + 1} - Ожидалось: =, а получено: {token[i].Type}");
            Next();
            expr();
            Next();
        }
        public void expr()
        {
            List<Token> tr1 = new List<Token>();
            while (token[i].Type != Token.TokenType.SEMICOLON)
            {
                tr1.Add(token[i]);
                Next();

            }
 
            if (firstEXPR == true)
            {
                Bower a = new Bower(tr1);
                a.Start();
                foreach (Troyka troyka in a.troyka)
                    operatsii.Add(troyka);
                lastEXPRind = a.Lastindex;
                firstEXPR = false;
            }
            else
            {
                Bower a = new Bower(tr1, lastEXPRind);
                a.Start();
                foreach (Troyka troyka in a.troyka)
                    operatsii.Add(troyka);
                lastEXPRind = a.Lastindex;
            }
           
           
        }

        public void DopOper()
        {
            switch (token[i].Type)
            {
                case Token.TokenType.FOR:
                    SpisOper();
                    break;
                case Token.TokenType.IDENTIFIER:
                    SpisOper();
                    break;
                default:
                    break;
            }
        }
        public static string ConvertLex(TokenType type)
        {
            string s = "";
            switch (type)
            {
                case TokenType.IDENTIFIER:
                    s = "идентификатор";
                    break;
                case TokenType.LITERAL:
                    s = "литерал";
                    break;
                case TokenType.PLUS:
                    s = "+";
                    break;
                case TokenType.MINUS:
                    s = "-";
                    break;
                case TokenType.MULTIPLICATION:
                    s = "*";
                    break;
                case TokenType.DIVISION:
                    s = "/";
                    break;
                case TokenType.EQUALS:
                    s = "=";
                    break;
                case TokenType.GREATER:
                    s = ">";
                    break;
                case TokenType.LESS:
                    s = "<";
                    break;
                case TokenType.LESSEQ:
                    s = "<=";
                    break;
               
                case TokenType.GREATEREQ:
                    s = ">=";
                    break;
                case TokenType.COMMA:
                    s = ",";
                    break;
                case TokenType.LPAR:
                    s = "(";
                    break;
                case TokenType.RPAR:
                    s = ")";
                    break;
            
                case TokenType.INT:
                    s = "integer";
                    break;
                case TokenType.DOUBLE:
                    s = "double";
                    break;
                default:
                    break;
            }
            return s;
        }
    }
}
