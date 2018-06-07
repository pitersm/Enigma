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

namespace CifrasTransposição
{
    public partial class Transposição : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
        TranspositionEncryption encryption;
        string inputString, outputString, encryptedText, decryptedText, key;
        int type;

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (inputString == "" || inputString == null)
            {
                MessageBox.Show("Favor selecionar um arquivo de entrada preenchido primeiro.", "Preencher arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            type = ddlOptions.SelectedIndex;
            key = txtColumns.Text;
            encryptedText = encryption.Encrypt(new String(inputString.Where(Char.IsLetter).ToArray()).ToUpper(), type, key);

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

        private void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOptions.SelectedIndex == 1)
            {
                txtColumns.Text = "SENAI";
            }
            else
            {
                txtColumns.Text = "3";
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (inputString == "" || inputString == null)
            {
                MessageBox.Show("Favor selecionar um arquivo de entrada preenchido primeiro.", "Preencher arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            type = ddlOptions.SelectedIndex;
            key = txtColumns.Text;
            decryptedText = encryption.Decrypt(new String(inputString.Where(Char.IsLetter).ToArray()).ToUpper(), type, key);

            DialogResult result = folderBrowserDialog1.ShowDialog();
            string folderName = "", filePath = "";
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
            }

            filePath = folderName + "\\" + txtName.Text.ToString() + ".txt";
            try
            {
                System.IO.File.WriteAllText(filePath, decryptedText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor selecionar um arquivo.", "Preencher arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtOutput.Text = decryptedText;
        }

        public Transposição()
        {
            InitializeComponent();
        }

        private void Transposição_Load(object sender, EventArgs e)
        {
            ddlOptions.SelectedIndex = 0;
            ofd.Filter = "Arquivos de Text (.txt)| *.txt";
            folderBrowserDialog1.Description =
                "Selecione o diretório onde deseja salvar o arquivo criptografado";
            encryption = new TranspositionEncryption();
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
