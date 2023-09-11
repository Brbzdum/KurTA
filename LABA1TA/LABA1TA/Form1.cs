using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA1TA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string[] lines = File.ReadAllLines(textBox1.Text);
            foreach (string s in lines)
            {
                richTextBox1.Text += s;
                richTextBox1.Text += Environment.NewLine;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            StringReader reader = new StringReader(richTextBox1.Text);
            string line;
            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    LexicalAnalysis.Analysis(line, richTextBox2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка!\n {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            StringReader reader = new StringReader(richTextBox1.Text);
            string line;
            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    LexicalAnalysisFirst.Analysis(line, richTextBox2);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка!\n {ex.Message}");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StringReader reader = new StringReader(richTextBox1.Text);
            string line;
            string sss = " ";
            while ((line = reader.ReadLine()) != null)
            {
                sss += line + " ";
            }
            List<Token> lex;
            try
            {
                lex = LexicalAnalysis.Analysis(sss, richTextBox2);
                LL rule = new LL(lex);
                rule.Start();
                richTextBox3.Clear();
                int index = 0;
                richTextBox3.Text += "Результат Действие Операнд1 Операнд2\n";
                foreach (Troyka g in rule.operatsii)
                {
                    richTextBox3.Text += $"       m{index}                 {LL.ConvertLex(g.deystvie.Type)}  {g.operand1.Value} {g.operand2.Value}\n"; 
                    index++;
                }
                richTextBox2.Text += "======================" + Environment.NewLine + "Классификация лексем завершена" + Environment.NewLine;
                MessageBox.Show("Разбор завершён");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error!\n {ex.Message}");
            } //rule.Programm();
        }
    }
}
