using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối tới MySQL
        private string connectionString = "Server=DukB0;Database=SimThe;User ID=root;Password=771099;";

        public Form1()
        {
            InitializeComponent();
        }

        // Phương thức để tải dữ liệu từ MySQL và hiển thị lên DataGridView
        private void LoadData()
        {
            // Kết nối MySQL và thực hiện truy vấn
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối với cơ sở dữ liệu
                    conn.Open();
                    MessageBox.Show("Connection opened successfully.");

                    // Câu lệnh SQL truy vấn dữ liệu từ bảng Sim và Mang
                    string query = "SELECT SoSim, TenMang, NgayKichHoat, NgayHetHan FROM Sim s JOIN Mang m ON s.MangID = m.ID ORDER BY s.NgayKichHoat ASC";

                    // Dùng MySqlDataAdapter để thực thi câu lệnh và điền dữ liệu vào DataTable
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable từ MySQL
                    dataAdapter.Fill(dataTable);

                    // Đưa dữ liệu vào DataGridView
                    dataGridView1.DataSource = dataTable;
                    MessageBox.Show("Data loaded successfully.");
                }
                catch (MySqlException sqlEx)
                {
                    // Xử lý lỗi MySQL cụ thể
                    MessageBox.Show("Lỗi MySQL: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi chung
                    MessageBox.Show("Lỗi khi truy xuất dữ liệu: " + ex.Message);
                }
            }
        }

        // Sự kiện Load của Form
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // Tải dữ liệu khi Form được load
        }

        // Không cần phải xử lý sự kiện này nếu không có hành động khi nhấp chuột vào cell
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Không làm gì ở đây
        }
    }
}
