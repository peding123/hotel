using System;
using System.Windows.Forms;


namespace hotel
{
    public partial class dashSupervisor : Form
    {
        connect konn = new connect();

        public dashSupervisor()
        {
            InitializeComponent();
        }

        public void thisform(object form)
        {
            content.Controls.Clear();
            Form frm = form as Form;
            frm.TopLevel = false;
            content.Controls.Add(frm);
            content.Tag = frm;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thisform(new houseKeeping());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }
    }
}
