using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    public partial class MappingEdit : Form
    {
        private Enigma enigma;

        public MappingEdit()
        {
            InitializeComponent();
        }

        public MappingEdit(Enigma enigma)
        {
            InitializeComponent();
            this.enigma = enigma;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enigma.encryption.mapping[1, 0] = Convert.ToChar(textBox1.Text.ToUpper());
            enigma.encryption.mapping[1, 1] = Convert.ToChar(textBox2.Text.ToUpper());
            enigma.encryption.mapping[1, 2] = Convert.ToChar(textBox3.Text.ToUpper());
            enigma.encryption.mapping[1, 3] = Convert.ToChar(textBox4.Text.ToUpper());
            enigma.encryption.mapping[1, 4] = Convert.ToChar(textBox5.Text.ToUpper());
            enigma.encryption.mapping[1, 5] = Convert.ToChar(textBox6.Text.ToUpper());
            enigma.encryption.mapping[1, 6] = Convert.ToChar(textBox7.Text.ToUpper());
            enigma.encryption.mapping[1, 7] = Convert.ToChar(textBox8.Text.ToUpper());
            enigma.encryption.mapping[1, 8] = Convert.ToChar(textBox9.Text.ToUpper());
            enigma.encryption.mapping[1, 9] = Convert.ToChar(textBox10.Text.ToUpper());
            enigma.encryption.mapping[1, 10] = Convert.ToChar(textBox11.Text.ToUpper());
            enigma.encryption.mapping[1, 11] = Convert.ToChar(textBox12.Text.ToUpper());
            enigma.encryption.mapping[1, 12] = Convert.ToChar(textBox13.Text.ToUpper());
            enigma.encryption.mapping[1, 13] = Convert.ToChar(textBox14.Text.ToUpper());
            enigma.encryption.mapping[1, 14] = Convert.ToChar(textBox15.Text.ToUpper());
            enigma.encryption.mapping[1, 15] = Convert.ToChar(textBox16.Text.ToUpper());
            enigma.encryption.mapping[1, 16] = Convert.ToChar(textBox17.Text.ToUpper());
            enigma.encryption.mapping[1, 17] = Convert.ToChar(textBox18.Text.ToUpper());
            enigma.encryption.mapping[1, 18] = Convert.ToChar(textBox19.Text.ToUpper());
            enigma.encryption.mapping[1, 19] = Convert.ToChar(textBox20.Text.ToUpper());
            enigma.encryption.mapping[1, 20] = Convert.ToChar(textBox21.Text.ToUpper());
            enigma.encryption.mapping[1, 21] = Convert.ToChar(textBox22.Text.ToUpper());
            enigma.encryption.mapping[1, 22] = Convert.ToChar(textBox23.Text.ToUpper());
            enigma.encryption.mapping[1, 23] = Convert.ToChar(textBox24.Text.ToUpper());
            enigma.encryption.mapping[1, 24] = Convert.ToChar(textBox25.Text.ToUpper());
            enigma.encryption.mapping[1, 25] = Convert.ToChar(textBox26.Text.ToUpper());

            char[] from = enigma.encryption.mapping.Cast<char>().Skip(26).Take(26).ToArray();
            string abs = new string(from);
            if (abs.Any(a => !Char.IsLetter(a)))
            {
                MessageBox.Show("A chave deve conter apenas caracteres simples alfabéticos", "Chave Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (abs.GroupBy(c => c).Any(g => g.Count() > 1))
            {
                MessageBox.Show("A chave não pode ter caracteres repetidos", "Chave Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Mapeamento Editado Com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
