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


namespace IS_3_19_PankovVA
{
    public partial class Form3 : Form
    {
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
       
        private BindingSource bSource = new BindingSource();
        private DataTable table = new DataTable();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionDB connectionDB = new ConnectionDB();
            try
            {
                connectionDB.connDB().Open();
                string commandStr = "SELECT id AS 'ID', fio AS 'ФИО', theme_kurs AS 'Тема' FROM t_stud";
                MyDA.SelectCommand = new MySqlCommand(commandStr, connectionDB.connDB());
                MyDA.Fill(table);
                bSource.DataSource = table;
                dataGridView1.DataSource = bSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            finally
            {
                MessageBox.Show("Подключение окончено.");
                connectionDB.connDB().Close();
            }
        }
    }
}