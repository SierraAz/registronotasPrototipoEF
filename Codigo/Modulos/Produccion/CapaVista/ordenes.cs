using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CapaVistaProduccion
{
    public partial class ordenes : Form
    {
        string connectionString = @"Server=localhost;Database=colchoneria;Uid=root;Pwd=root;";
        int id_notas_examenes = 0;
        public ordenes()
        {
            InitializeComponent();
        }


        void Clear()
        {
            textBox2.Text = textBox3.Text = textBox1.Text = "";
            id_notas_examenes = 0;

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ordenes_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("pa_produccion_ordenes_agregareditar", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_id_notas_examenes", id_notas_examenes);
                mySqlCmd.Parameters.AddWithValue("_id_alumno_notas_examenes", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_id_curso_notas_examenes", textBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_calificacion_notas_examenes", textBox3.Text.Trim());
                
                mySqlCmd.ExecuteNonQuery();

                MessageBox.Show("Registro ingresado!");

                Clear();

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ver_alumno rep = new ver_alumno();
            rep.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ver_curso rep = new ver_curso();
            rep.Show();
        }
    }
}
