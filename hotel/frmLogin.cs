using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hotel
{
    public partial class frmLogin : Form
    {

        private SqlCommand cmd;
        private SqlDataReader reader;

        connect konn = new connect();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Username atau Password tidak boleh kosong!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("SELECT JobID FROM Employee WHERE Username = @Username AND Password = @Password", conn);
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                int job = reader.GetInt32(0);
                if (job == 1)
                {
                    MessageBox.Show("Selamat datang Admin!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dashAdmin admin = new dashAdmin();
                    admin.Show();
                    this.Hide();
                }
                else if (job == 2)
                {
                    MessageBox.Show("Selamat datang Petugas!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dashEmployee employee = new dashEmployee();
                    employee.Show();
                    this.Hide();
                }
                else if (job == 3)
                {
                    MessageBox.Show("Selamat datang House Keeper Supervisor!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dashSupervisor supervisor = new dashSupervisor();
                    supervisor.Show();
                    this.Hide();
                }
                else if (job == 4)
                {
                    MessageBox.Show("Selamat datang House Keeper!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dashHouseKeeper housekeeper = new dashHouseKeeper();
                    housekeeper.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Username atau Password salah atau belum terdaftar!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
