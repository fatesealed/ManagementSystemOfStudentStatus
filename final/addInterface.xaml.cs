using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace final
{
	/// <summary>
	/// addInterface.xaml 的交互逻辑
	/// </summary>
	public partial class addInterface : Window
	{
		public addInterface()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			String name, xuehao, shenfenzheng, xueyuan, shijian;
			name = name1.Text;
			xuehao = scNumber1.Text;
			shenfenzheng = number1.Text;
			xueyuan = xueyuan1.Text;
			shijian = data1.Text;
			String myconn = @"Data Source=DESKTOP-4E9GNFB\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
			SqlConnection sqlConnection = new SqlConnection(myconn);
			string sql1 = "select 学号 from studentInf where 学号='" + xuehao + "'";
			SqlCommand sqlCommand1 = new SqlCommand(sql1, sqlConnection);
			sqlConnection.Open();
			SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
			if (sqlDataReader1.HasRows)
			{
				MessageBox.Show("学号已存在,请重新输入", "您输入有误");
				this.Show();
			}
			else
			{
				sqlDataReader1.Close();
				String sql2 = "INSERT INTO studentInf(姓名,学号,身份证号,专业,入学时间) VALUES('" + name + "','" + xuehao + "','" + shenfenzheng + "','" + xueyuan + "','" + shijian + "')";
				sqlCommand1 = new SqlCommand(sql2, sqlConnection);
				sqlCommand1.ExecuteNonQuery();
				MessageBox.Show("录入学生信息成功");
				this.Show();
			}
		}
	}
}
