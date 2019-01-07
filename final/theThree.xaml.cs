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
	/// theThree.xaml 的交互逻辑
	/// </summary>
	public partial class theThree : Window
	{
		public theThree()
		{
			InitializeComponent();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (xuanze.Text == "学号")
			{
				string a = xuanzejieguo.Text;
				String myconn = @"Data Source=DESKTOP-4E9GNFB\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";//引号内为数据库连接字符串
				SqlConnection sqlConnection = new SqlConnection(myconn);//新建数据库连接实例
				sqlConnection.Open();//打开数据库连接
				String sql = "SELECT 学号 FROM studentInf WHERE 学号='" + a + "'";
				SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);//SQL语句实现表数据的读取
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)//学号正确，进入查询结果界面，并把学号以参数形式传给下一from
				{
					sqlConnection.Close();
					sqlConnection.Open();
					sql = "SELECT studentInf.* FROM studentInf WHERE 学号='" + a + "'";
					SqlCommand aa = new SqlCommand(sql, sqlConnection);
					SqlDataReader aaa = aa.ExecuteReader();
					aaa.Read();
					judgeforit.oldxuehao = aaa["学号"].ToString();
					xuehaoText.Text = aaa["学号"].ToString();
					xingmingText.Text = aaa["姓名"].ToString();
					zhuanyeText.Text = aaa["专业"].ToString();
					shenfenzhenghaoText.Text = aaa["身份证号"].ToString();
					ruxueshijianText.Text = aaa["入学时间"].ToString();
					sqlConnection.Close();
				}
				else
				{
					MessageBox.Show("学号有误，请重新输入");
				}

			}
			if (xuanze.Text == "姓名")
			{
				string a = xuanzejieguo.Text;
				String myconn = @"Data Source=DESKTOP-4E9GNFB\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";//引号内为数据库连接字符串
				SqlConnection sqlConnection = new SqlConnection(myconn);//新建数据库连接实例
				sqlConnection.Open();//打开数据库连接
				String sql = "SELECT 姓名 FROM studentInf WHERE 姓名='" + a + "'";
				SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);//SQL语句实现表数据的读取
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)//学号正确，进入查询结果界面，并把学号以参数形式传给下一from
				{
					sqlConnection.Close();
					sqlConnection.Open();
					sql = "SELECT studentInf.* FROM studentInf WHERE 姓名='" + a + "'";
					SqlCommand aa = new SqlCommand(sql, sqlConnection);
					SqlDataReader aaa = aa.ExecuteReader();
					aaa.Read();
					xuehaoText.Text = aaa["学号"].ToString();
					xingmingText.Text = aaa["姓名"].ToString();
					zhuanyeText.Text = aaa["专业"].ToString();
					shenfenzhenghaoText.Text = aaa["身份证号"].ToString();
					ruxueshijianText.Text = aaa["入学时间"].ToString();
					sqlConnection.Close();
				}
				else
				{
					MessageBox.Show("姓名有误，请重新输入");
				}

			}
			if (xuanze.Text == "身份证号")
			{
				string a = xuanzejieguo.Text;
				String myconn = @"Data Source=DESKTOP-4E9GNFB\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";//引号内为数据库连接字符串
				SqlConnection sqlConnection = new SqlConnection(myconn);//新建数据库连接实例
				sqlConnection.Open();//打开数据库连接
				String sql = "SELECT 姓名 FROM studentInf WHERE 身份证号='" + a + "'";
				SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);//SQL语句实现表数据的读取
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)//学号正确，进入查询结果界面，并把学号以参数形式传给下一from
				{
					sqlConnection.Close();
					sqlConnection.Open();
					sql = "SELECT studentInf.* FROM studentInf WHERE 身份证号='" + a + "'";
					SqlCommand aa = new SqlCommand(sql, sqlConnection);
					SqlDataReader aaa = aa.ExecuteReader();
					aaa.Read();
					xuehaoText.Text = aaa["学号"].ToString();
					xingmingText.Text = aaa["姓名"].ToString();
					zhuanyeText.Text = aaa["专业"].ToString();
					shenfenzhenghaoText.Text = aaa["身份证号"].ToString();
					ruxueshijianText.Text = aaa["入学时间"].ToString();
					sqlConnection.Close();
				}
				else
				{
					MessageBox.Show("身份证号有误，请重新输入");
				}

			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			xuanzejieguo.Text = "";
			xingmingText.Text = "";
			xuehaoText.Text = "";
			shenfenzhenghaoText.Text = "";
			zhuanyeText.Text = "";
			ruxueshijianText.Text = "";
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			{
				string name = xingmingText.Text;
				string xuehao = xuehaoText.Text;
				string shenfenzheng = shenfenzhenghaoText.Text;
				string zhuanye = zhuanyeText.Text;
				string ruxueshijian = ruxueshijianText.Text;

				String myconn = @"Data Source=DESKTOP-4E9GNFB\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";//引号内为数据库连接字符串
				SqlConnection sqlConnection = new SqlConnection(myconn);//新建数据库连接实例
				sqlConnection.Open();//打开数据库连接
				string sql1 = "select 学号 from (select 学号 from studentInf where 学号!='" + judgeforit.oldxuehao + "') as w(学号) where 学号='" + xuehao + "'";//输入的学号不能与除原学号以外的学号重复
				SqlCommand sqlCommand1 = new SqlCommand(sql1, sqlConnection);//SQL语句实现表数据的读取
				SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
				if (sqlDataReader1.HasRows)//学号已存在，重新输入
				{
					MessageBox.Show("学号已存在", "您输入有误");
				}
				else
				{
					sqlDataReader1.Close();
					String sql2 = "UPDATE studentInf SET 姓名='" + name + "',学号='" + xuehao + "',身份证号='" + shenfenzheng + "',专业='" + zhuanye + "',入学时间='" + ruxueshijian + "' WHERE 学号='" + xuehao + "'";
					sqlCommand1 = new SqlCommand(sql2, sqlConnection);
					sqlCommand1.ExecuteNonQuery();
					MessageBox.Show("保存成功");
					sqlConnection.Close();
				}
			}
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			string name = xingmingText.Text;
			string xuehao = xuehaoText.Text;
			string shenfenzheng = shenfenzhenghaoText.Text;
			string zhuanye = zhuanyeText.Text;
			string ruxueshijian = ruxueshijianText.Text;
			String myconn = @"Data Source=DESKTOP-4E9GNFB\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";//引号内为数据库连接字符串
			SqlConnection sqlConnection = new SqlConnection(myconn);//新建数据库连接实例
			sqlConnection.Open();//打开数据库连接
			string sql2 = "delete  from studentInf where 学号='" + xuehao + "'";
			SqlCommand sqlCommand2 = new SqlCommand(sql2, sqlConnection);//SQL语句实现表数据的读取
			sqlCommand2.ExecuteNonQuery();
			MessageBox.Show("删除学生信息成功");
			xuanzejieguo.Text = "";
			xingmingText.Text = "";
			xuehaoText.Text = "";
			shenfenzhenghaoText.Text = "";
			zhuanyeText.Text = "";
			ruxueshijianText.Text = "";
		}

		private void newclick(object sender, RoutedEventArgs e)
		{
				{
					string name = xingmingText.Text;
					string xuehao = xuehaoText.Text;
					string shenfenzheng = shenfenzhenghaoText.Text;
					string zhuanye = zhuanyeText.Text;
					string ruxueshijian = ruxueshijianText.Text;

					String myconn = @"Data Source=DESKTOP-4E9GNFB\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";//引号内为数据库连接字符串
					SqlConnection sqlConnection = new SqlConnection(myconn);//新建数据库连接实例
					sqlConnection.Open();//打开数据库连接
					String sql2 = "UPDATE studentInf SET 姓名='" + name + "',学号='" + xuehao + "',身份证号='" + shenfenzheng + "',专业='" + zhuanye + "',入学时间='" + ruxueshijian + "' WHERE 学号='" + xuehao + "'";
					SqlCommand sqlCommand1 = new SqlCommand(sql2, sqlConnection);
					sqlCommand1.ExecuteNonQuery();
					MessageBox.Show("保存成功");
					sqlConnection.Close();
			}
		}
	}
}
