using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace fanucRobotInterface
{
    public partial class addRobot : Form
    {
        public addRobot()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {

            //数据库连接
            SQLiteConnection myCon;
            myCon = new SQLiteConnection("Data Source=robot.sqlite;Version=3;");
            myCon.Open();

            string sql = "insert into robotInfo values ('"+line.Text+"', '"+robotname.Text+"','"+robotip.Text+"',NULL)";
            SQLiteCommand command = new SQLiteCommand(sql, myCon);
            command.ExecuteNonQuery();
            MessageBox.Show("添加成功！");
            myCon.Close();

        }
    }
}
