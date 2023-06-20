using Npgsql;



namespace VoucherAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nama_voucher = textBox1.Text;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;port=5432;database=JT-Apps;username=postgres;password=Tyoganteng1"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand();
                    command.Connection = connection;
                    command.CommandText = "delete from voucher where deskripsi = @deskripsi";
                    command.Parameters.AddWithValue("@deskripsi", nama_voucher);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Voucher berhasil ditukarkan.");
                    }
                    else
                    {
                        MessageBox.Show("Voucher tidak ditemukan.");
                    }
                    connection.Close();
                    textBox1.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Terjadi Kesalahan : " + ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}