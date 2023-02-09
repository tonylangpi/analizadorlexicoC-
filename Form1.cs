using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AnalisisLexico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Descomponer(string palabra)
        {
            string caracterRerpresentado = "";
            switch (palabra)
            {
                case "COMENZAR":
                    caracterRerpresentado = "Palabra reservada de inicio";
                    break;
                case "STR":
                    caracterRerpresentado = "Variable de tipo string";
                    break;
                case ";":
                    caracterRerpresentado = "Signo de cierre de sentencia";
                    break;
                case "%":
                    caracterRerpresentado = "Signo de asignación";
                    break;
                case "==":
                    caracterRerpresentado = "Signo de comparación";
                    break;
                case "+":
                    caracterRerpresentado = "Signo de suma";
                    break;
                case "-":
                    caracterRerpresentado = "Signo de resta";
                    break;
                case ">":
                    caracterRerpresentado = "Signo mayor";
                    break;
                case "<":
                    caracterRerpresentado = "Signo menor";
                    break;
                case "FIN":
                    caracterRerpresentado = "Fin del programa";
                    break;
                case "Fun":
                    caracterRerpresentado = "declaración de función";
                    break;
                default:
                    int val = 0;
                    int validacion = 0;
                    if (int.TryParse(palabra, out val))
                    {
                        caracterRerpresentado = "Es un número";
                        validacion = 1;
                    }
                    if (palabra.StartsWith("'") && palabra.EndsWith("'"))
                    {
                        caracterRerpresentado = "Es un nombre de variable";
                        validacion = 1;
                    }
                    if (validacion == 0)
                    {
                        caracterRerpresentado = "Identificador";
                    }
                    break;
            }
            return caracterRerpresentado;
        }
        public void Analisis()
        {
            string codigo = richTextBox1.Text; 

            char[] jump = { '\n' };

            char[] delimitador = { ' ' };

            string[] lineas = codigo.Split(jump);

            for (int i = 0; i < lineas.Length; i++)
            {
                string[] words = lineas[i].Split(delimitador);

                for (int z = 0; z < words.Length; z++)
                {
                    words[z] = words[z].Replace("\n", "");

                    if (words[z] != "")
                    {
                        DataGridViewRow fila = (DataGridViewRow)dgvInfo.Rows[0].Clone();
                        fila.Cells[0].Value = Descomponer(words[z]);
                        fila.Cells[1].Value = words[z];
                        fila.Cells[2].Value = z + 1;
                        fila.Cells[3].Value = i + 1;
                        dgvInfo.Rows.Add(fila); 
                    }
                }
            }

        }


       public void borrar()
        {
            this.dgvInfo.Rows.Clear(); 
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            borrar();
            Analisis();
            //personalizado(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
