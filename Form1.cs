using System.IO;
using System.Security.Cryptography;

namespace Bloquinho_de_Notas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
                var nomeArquivo = Path.GetFileName(ofd.FileName);
                Text = nomeArquivo;
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != string.Empty)
            {
                salvarArquivo();
                Application.Restart();
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvarArquivo();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvarArquivo();
            Environment.Exit(0);
        }       

        private void salvarArquivo()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, this.richTextBox1.Text);
                var nomeArquivo = Path.GetFileName(sfd.FileName);
                this.Text = nomeArquivo;

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Você tem certeza que deseja sair?", Text, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }
    }
}