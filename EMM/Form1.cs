using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EMM
{
    public partial class EMM : Form
    {
        private DataTable dataTable;
        private String MyConnection = getSettings.GetConnection("mysql");

        private UserDTO userDTO;
        public EMM(UserDTO userDTO)
        {
            this.userDTO = userDTO;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String pwd = textBox2.Text;
                String login = textBox1.Text;
                Login loginInstance = new Login();
                userDTO = loginInstance.LoginIntoSystem(userDTO, MyConnection, textBox1.Text, textBox2.Text);
                if (userDTO != null)
                {
                    button1.Hide();
                    textBox1.Hide();
                    textBox2.Hide();
                    dataGridView1.Show();
                    listBox1.Show();
                    button2.Show();
                    label2.Show();
                    textBox3.Show();
                    listBox2.Show();
                    getTables tables = new getTables();
                    List<string> data = tables.getAllTables(MyConnection, userDTO);
                    for (int i = 0; i < data.Count; i++)
                    {
                        listBox1.Items.Insert(i, data[i]);
                    }
                    if(!userDTO.getRole().Equals("admin"))
                    {
                        if (!userDTO.getRole().Equals("direc"))
                        {
                            button3.Hide();
                            dataGridView1.ReadOnly = true;
                        }
                    }
                    else
                    {
                        dataGridView1.ReadOnly = false;
                        button3.Show();
                    }                    

                }
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
                label1.Show();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadTable loadTable = new LoadTable();
            try
            {
                dataTable = loadTable.loadSelectedTable(listBox1.Items[listBox1.SelectedIndex].ToString(), MyConnection);
                BindingSource bindingSource = new BindingSource { DataSource =  dataTable};
                dataGridView1.DataSource = bindingSource;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
                label1.Show();
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                listBox2.Items.Insert(i, dataGridView1.Columns[i].Name);
            }
            //listBox2.SetSelected();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            SaveTableChanges saveTableChanges = new SaveTableChanges();
            saveTableChanges.saveAllChanges(dataTable, MyConnection, listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchBySpecifiedColumn searchBySpecifiedColumn = new SearchBySpecifiedColumn();
                dataTable = searchBySpecifiedColumn.search(listBox2.Items[listBox2.SelectedIndex].ToString(), MyConnection, listBox1.Items[listBox1.SelectedIndex].ToString(), textBox3.Text);
                BindingSource bindingSource = new BindingSource { DataSource = dataTable };
                dataGridView1.DataSource = bindingSource;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
                label1.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
