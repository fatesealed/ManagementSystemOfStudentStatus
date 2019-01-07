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
	/// login.xaml 的交互逻辑
	/// </summary>
	public partial class login : Window
	{
		public login()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			signUp a = new signUp();
			a.Show();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			String username, password;
			username = this.user.Text;
			password = this.password.Password;

			String myconn = @"Data Source=DESKTOP-4E9GNFB\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
			SqlConnection sqlConnection = new SqlConnection(myconn);//新建数据库连接实例
			sqlConnection.Open();
			String sql = "SELECT Name,PassWord FROM dbuser WHERE Name='" + username + "'AND PassWord='" + password + "'";
			SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

			if (sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				sqlDataReader.Close();
				MessageBox.Show("登陆成功！","OK");
				judgeforit.judge = true;
			}
			else//如果登录失败，询问是否注册新用户
			{
				MessageBox.Show("密码错误或不存在该账号，请重试","Sorry");
			}
		}
	}
}
