using System;
using System.Windows.Forms;


namespace hotel
{
    public partial class dashEmployee : Form
    {
        connect konn = new connect();

        public dashEmployee()
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
            thisform(new reservation());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            thisform(new masterRoomType());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            thisform(new masterRoom());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            thisform(new masterItem());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thisform(new checkIn());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thisform(new requestItems());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            thisform(new checkOut());
        }
    }
}
