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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace final
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		private DispatcherTimer ShowTimer;
		public MainWindow()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			ShowTime();    //在这里窗体加载的时候不执行文本框赋值，窗体上不会及时的把时间显示出来，而是等待了片刻才显示了出来
			ShowTimer = new System.Windows.Threading.DispatcherTimer();
			ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
			ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
			ShowTimer.Start();
		}

		//private void add_Click(object sender, RoutedEventArgs e)
		//{
		//	string strconn = "server=DESKTOP-4E9GNFB\\SQLEXPRESS;database=student;integrated security=true";
		//	SqlConnection sqlconn = new SqlConnection(strconn);
		//	try
		//	{
		//		sqlconn.Open();
		//		MessageBox.Show("连接数据库成功");
		//		//string sqladd = "insert into user(name, password) values ('" + 用户名.Text + "', '" + password.Text + "')";
		//		//SqlCommand sqlcmd = new SqlCommand(sqladd, sqlconn);
		//		sqlcmd.ExecuteNonQuery();
		//		MessageBox.Show("插入成功");
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show("数据库打开失败，详细信息：" + ex.ToString());
		//	}
		//	finally
		//	{
		//		sqlconn.Close();
		//	}
		//}

		//private void modify_Click(object sender, RoutedEventArgs e)
		//{
		//	string strconn = "server=(localdb)\\MSSQLLocalDB;database=studentdb;integrated security=true";
		//	SqlConnection sqlconn = new SqlConnection(strconn);
		//	try
		//	{
		//		sqlconn.Open();
		//		string strmodify = "Update student set password='" + password.Text + "'" + " where name=" + "'" + name.Text + "'";
		//		SqlCommand sqlcmd = new SqlCommand(strmodify, sqlconn);
		//		sqlcmd.ExecuteNonQuery();
		//		MessageBox.Show("修改成功");
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show("连接错误" + ex.Message);
		//	}
		//	finally
		//	{
		//		sqlconn.Close();
		//	}
		//}

		//private void delete_Click(object sender, RoutedEventArgs e)
		//{
		//	string strconn = "server=(localdb)\\MSSQLLocalDB;database=studentdb;integrated security=true";
		//	SqlConnection sqlconn = new SqlConnection(strconn);
		//	try
		//	{
		//		sqlconn.Open();
		//		string strdelete = "Delete from student where name='" + name.Text + "'";
		//		SqlCommand sqlcmd = new SqlCommand(strdelete, sqlconn);
		//		sqlcmd.ExecuteNonQuery();
		//		MessageBox.Show("删除成功");
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show("连接错误" + ex.Message);
		//	}
		//	finally
		//	{
		//		sqlconn.Close();
		//	}
		//}

		//private void search_Click(object sender, RoutedEventArgs e)
		//{
		//	int flag = 1;
		//	string strconn = "server=(localdb)\\MSSQLLocalDB;database=studentdb;integrated security=true";
		//	SqlConnection sqlconn = new SqlConnection(strconn);
		//	try
		//	{
		//		sqlconn.Open();
		//		//MessageBox.Show("连接数据库成功");
		//		string sqlsearch = "select * from student where name='" + name.Text + "'";
		//		SqlCommand sqlcmd = new SqlCommand(sqlsearch, sqlconn);
		//		SqlDataReader reader = sqlcmd.ExecuteReader();
		//		//读取数据 
		//		while (reader.Read())
		//		{
		//			// 可以使用数据库中的字段名，也可以使用角标访问
		//			if (reader["password"].ToString() == password.Text)
		//			{
		//				flag = 0;
		//				break;
		//			}
		//		}
		//		if (flag == 1)
		//			MessageBox.Show("用户不存在");
		//		else
		//			MessageBox.Show("存在用户");
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show("数据库打开失败，详细信息：" + ex.ToString());
		//	}
		//	finally
		//	{
		//		sqlconn.Close();
		//	}
		//}
		public void ShowCurTimer(object sender, EventArgs e)

		{
			ShowTime();
		}
		private void ShowTime()
		{
			//获得年月日
			this.tbDateText.Text = DateTime.Now.ToString("yyyy/MM/dd");   //yyyy/MM/dd
			//获得时分秒
			this.tbTimeText.Text = DateTime.Now.ToString("HH:mm:ss");
		}

		private void about(object sender, RoutedEventArgs e)
		{
			welecome win = new welecome();
			win.Show();
		}
		private void add(object sender, RoutedEventArgs e)
		{
			if (judgeforit.judge == false) MessageBox.Show("请先登录");
			else {
				addInterface b = new addInterface();
				b.Show();
			}
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			signUp _signUp = new signUp();
			_signUp.Show();
		}

		private void amend(object sender, RoutedEventArgs e)
		{
			if (judgeforit.judge == false) MessageBox.Show("请先登录");
			else {
				theThree c = new theThree();
				c.Show();
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			login a = new login();
			a.Show();
		}
	}
}
