﻿using System;
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
        string connectionString = @"Server=colchoneria.mysql.database.azure.com;Database=colchoneria;Uid=administrador;Pwd=Jm123456;";
        int pk_idordenes_tbl_ordenes = 0;
        public ordenes()
        {
            InitializeComponent();
        }


        void Clear()
        {
            textBox2.Text = textBox3.Text = textBox1.Text = "";
            pk_idordenes_tbl_ordenes = 0;

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
                mySqlCmd.Parameters.AddWithValue("_pk_idordenes_tbl_ordenes", pk_idordenes_tbl_ordenes);
                mySqlCmd.Parameters.AddWithValue("_fk_idrecetas_tbl_recetas", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_fk_idrecetas_tbl_recetas", textBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_prioridad_tbl_ordenes", textBox3.Text.Trim());
                
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
    }
}
