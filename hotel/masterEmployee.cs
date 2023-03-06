using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hotel
{
    public partial class masterEmployee : Form
    {

        public SqlCommand cmd;
        public DataTable dt;
        public SqlDataAdapter sda;
        public SqlDataReader reader;

        connect konn = new connect();

        public masterEmployee()
        {
            InitializeComponent();
        }

        public void clean()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            textBox6.Text = "";
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void masterEmployee_Load(object sender, System.EventArgs e)
        {
            SqlConnection conn = konn.GetConn();
            cmd = new SqlCommand("SELECT * FROM Employee", conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd = new SqlCommand("SELECT ID FROM Job", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            comboBox1.Items.Clear();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["ID"].ToString());
            }
            conn.Close();

            clean();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Username password dan nama wajib di isi", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SqlConnection conn = konn.GetConn();
            cmd = new SqlCommand("INSERT INTO Employee VALUES (@Username, @Password, @Name, @Email, @Address, @DateOfBirth, @JobID)", conn);
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@Name", textBox4.Text);
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@JobID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);

            if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("Confirm password tidak sama", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Data berhasil ditambah", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            masterEmployee_Load(this, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Rubah data?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SqlConnection conn = konn.GetConn();
                cmd = new SqlCommand("UPDATE Employee SET Username = @Username, Password = @Password, Name = @Name, Email = @Email, Address = @Address, DateOfBirth = @DateOfBirth, JobID = @JobID WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", textBox7.Text);
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                cmd.Parameters.AddWithValue("@Name", textBox4.Text);
                cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@JobID", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox6.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data berhasil dirubah", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            masterEmployee_Load(this, null);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Hapus data?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SqlConnection conn = konn.GetConn();
                cmd = new SqlCommand("DELETE FROM Employee WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", textBox7.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data berhasil dihapus", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            masterEmployee_Load(this, null);
        }
    }
}
