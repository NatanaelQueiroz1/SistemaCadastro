using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;
        public Form1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();

            comboEC.Items.Add("Solteiro");
            comboEC.Items.Add("Casado");
            comboEC.Items.Add("Divorciado");
            comboEC.Items.Add("Viuvo");

            comboEC.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

                    

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Listar()
        {
            lista.Items.Clear();

            foreach (Pessoa p in pessoas)
            {
                lista.Items.Add(p.Nome);
            }
        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Pessoa pessoa in pessoas)
            {
                if(pessoa.Nome == txtNome1.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }

            if (txtNome1.Text =="")
            {
                MessageBox.Show("Preencha o campo nome");
                txtNome1.Focus();
                return;
            }

            if (txtTel.Text =="(  )     -")
            {
                MessageBox.Show("Preencha o campo telefone");
                txtTel.Focus();
                return;
            }

            char sexo;
            if (radioM.Checked)
            {
                sexo = 'M';
            }
            else if (radioM.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            Pessoa p = new Pessoa();
            p.Nome = txtNome1.Text;
            p.DataNascimento = txtData1.Text;
            p.EstadoCivil = comboEC.SelectedItem.ToString();
            p.Telefone = txtTel.Text;
            p.CasaPropria = checkCasa.Checked;
            p.Veiculo = checkVeiculo.Checked;
            p.Sexo = sexo;

            if (index < 0)
            {
                pessoas.Add(p);

            }
            else
            {
                pessoas[index] = p;
            }

            Limpar_Click(Limpar, EventArgs.Empty);

            Listar();
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            int indice = lista.SelectedIndex;
            
            pessoas.RemoveAt(indice);
            Listar();

        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            txtNome1.Text = "";
            txtData1.Text = "";
            comboEC.SelectedIndex = 0;
            txtTel.Text = "";
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioF.Checked = false;
            radioM.Checked = true;
            txtNome1.Focus();
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            txtNome1.Text = p.Nome;
            txtData1.Text = p.DataNascimento;
            comboEC.SelectedItem = p.EstadoCivil;
            txtTel.Text = p.Telefone;
            checkCasa.Checked = p.CasaPropria;
            checkVeiculo.Checked = p.Veiculo;

            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
              
            }
        }
    }
}
