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
	/// signUp.xaml 的交互逻辑
	/// </summary>
	public partial class signUp : Window
	{
		public signUp()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
		{

		}

		private void okButton_Click(object sender, RoutedEventArgs e)
		{
			String username, password;
			username = user.Text;
			password = passwordt.Password;
			String myconn = @"Data Source=DESKTOP-4E9GNFB\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
			SqlConnection sqlConnection = new SqlConnection(myconn);
			sqlConnection.Open();
			String sql = "SELECT Name FROM dbuser WHERE Name='" + username + "'";
			SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				MessageBox.Show("用户名已存在", "error");
				user.Clear();
				passwordt.Clear();
				this.Show();
			}
			else
			{
				sqlDataReader.Close();
				String sqlq = "INSERT INTO dbuser(Name,Password) VALUES('" + username + "','" + password + "')";
				SqlCommand sqlCommand1 = new SqlCommand(sqlq, sqlConnection);
				sqlCommand1.ExecuteNonQuery();
				MessageBox.Show("恭喜您注册成功！\n你的用户名是：" + username+"\n密码是："+password+"\n请牢记密码", "OK");
			}
		}
		private void cancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
