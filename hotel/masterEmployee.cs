using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hotel
{
    public partial class masterEmployee : Form
    {

        public SqlCommand cmd;
        public SqlDataAdapter sda;
        public DataTable dt;

        connect konn = new connect();

        public masterEmployee()
        {
            InitializeComponent();

            textBox7.Visible = false;
        }


        private void masterEmployee_Load(object sender, System.EventArgs e)
        {
            SqlConnection conn = konn.GetConn();
            cmd = new SqlCommand("SELECT Employee.ID, Employee.Username, Employee.Password, Employee.Name, Employee.Email, Employee.DateOfBirth, Job.Name AS Job, Employee.Address FROM Employee JOIN Job ON Employee.JobID = Job.ID", conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd = new SqlCommand("SELECT ID FROM Job", conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["ID"].ToString());
            }

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Username, Password dan Name wajib diisi!");
                return;
            }

            SqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("INSERT INTO Employee VALUES(@Username, @Password, @Name, @Email, @Address, @DateOfBirth, @JobID)", conn);
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@Name", textBox4.Text);
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@JobID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password tidak sesuai!");
                return;
            }

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            SqlConnection conn = konn.GetConn();
            cmd = new SqlCommand("UPDATE Employee SET Username = @Username, Password = @Password, Name = @Name, Email = @Email, DateOfBirth = @DateOfBirth, JobID = @JobID, Address = @Address WHERE ID = @ID", conn);
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
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            SqlConnection conn = konn.GetConn();
            cmd = new SqlCommand("DELETE FROM EMployee WHERE ID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", textBox7.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
