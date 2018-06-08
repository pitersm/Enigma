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

namespace Enigma
{
    public partial class Enigma : Form
    {
        public Enigma()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
        EnigmaMachine encryption;
        string inputString, outputString, encryptedText, decryptedText, key;
        int type;

        private void Enigma_Load(object sender, EventArgs e)
        {
            ofd.Filter = "Arquivos de Text (.txt)| *.txt";
            folderBrowserDialog1.Description =
                "Selecione o diretório onde deseja salvar o arquivo criptografado";
            encryption = new EnigmaMachine();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (inputString == "" || inputString == null)
            {
                MessageBox.Show("Favor selecionar um arquivo de entrada preenchido primeiro.", "Preencher arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            encryptedText = encryption.Encrypt(new String(inputString.Where(Char.IsLetter).ToArray()).ToUpper());

            if (encryptedText == "")
            {
                return;
            }

            DialogResult result = folderBrowserDialog1.ShowDialog();
            string folderName = "", filePath = "";
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
            }

            filePath = folderName + "\\" + txtName.Text.ToString() + ".txt";
            try
            {
                System.IO.File.WriteAllText(filePath, encryptedText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor selecionar um arquivo.", "Preencher arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtOutput.Text = encryptedText;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            //if (inputString == "" || inputString == null)
            //{
            //    MessageBox.Show("Favor selecionar um arquivo de entrada preenchido primeiro.", "Preencher arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //decryptedText = encryption.Decrypt(new String(inputString.Where(Char.IsLetter).ToArray()).ToUpper(), type, key);

            //DialogResult result = folderBrowserDialog1.ShowDialog();
            //string folderName = "", filePath = "";
            //if (result == DialogResult.OK)
            //{
            //    folderName = folderBrowserDialog1.SelectedPath;
            //}

            //filePath = folderName + "\\" + txtName.Text.ToString() + ".txt";
            //try
            //{
            //    System.IO.File.WriteAllText(filePath, decryptedText);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Favor selecionar um arquivo.", "Preencher arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //txtOutput.Text = decryptedText;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                inputString = File.ReadAllText(ofd.FileName);
                txtInput.Text = inputString;
            }
        }
    }
}
