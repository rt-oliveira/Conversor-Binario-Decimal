using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversorBinarioDecimal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string entrada = txtBox_bin.Text;
            // Vai testar se foi digitado um número binário válido, isto é, só com 0s e 1s.
            // Caso tenha algo diferente desses dois caracteres, o programa perceberá e avisará que foi digitado algo inválido.
            if (!Conversao.EhValido(entrada))
            {
                MessageBox.Show("O conteúdo digitado não é um número inteiro binário válido.\nPor favor, digite um número inteiro binário válido!","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtBox_dec.Text = "";
            }
            else{
                string saida = Conversao.ConverterParaBinario(entrada);
                /* Este teste é feito, pois caso tenha digitado um número binário muito grande,
                   a ponto de não caber numa variável inteira de 64 bits, a função de conversão retornará null,
                   e o programa informa ao usuário que terá que digitar um número menor, já que o programa não suporta um
                   número tão grande como esse.
                */
                if (saida == null)
                {
                    MessageBox.Show("O número binário digitado gera um número decimal não suportado pela aplicação.\nPor favor, digite um número inteiro binário menor!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBox_dec.Text = "";
                }
                else
                    txtBox_dec.Text = saida;
            }
        }
    }
}
