using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fanucRobotInterfaceComm;
using System.Data.SQLite;


namespace fanucRobotInterface
{
    public partial class main : Form
    {

        robotInterfaceComm robot = new robotInterfaceComm();

        public string[] xyzwpr;
        public string[] joint;

        public main()
        {
            InitializeComponent();
        }

        #region 加载窗体
        private void main_Load(object sender, EventArgs e)
        {
            getrobotinfo();
      
            toolStripStatusLabel1.Text ="版本:V"+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #endregion

        #region 右下角图标
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//判断鼠标的按键
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Minimized;

                    this.Hide();
                }
                else if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                }
            }

        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出程序吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }

        }
        #endregion

        #region 连接机器人，获取信息
        private void robotConn_Click(object sender, EventArgs e)
        {
          
            getxyzwpr(robotIp.Text);
            getjoint(robotIp.Text);
            rescurralarm.Text=robot.readcurrAlarm(robotIp.Text);
            reshisalarm.Text=robot.readhisAlarm(robotIp.Text);
            MessageBox.Show("信息获取成功！");
        }
        #endregion

        #region 方法-获取xyzwpr
        public void getxyzwpr(string ip)
        {
            xyzwpr = robot.xyzwpr(ip);
            x.Text = xyzwpr[0];
            y.Text = xyzwpr[1];
            z.Text = xyzwpr[2];
            w.Text = xyzwpr[3];
            p.Text = xyzwpr[4];
            r.Text = xyzwpr[5];
            eone.Text = xyzwpr[6];

        }

        #endregion

        #region 方法-获取joint
        public void getjoint(string ip)
        {
            joint = robot.joint(ip);
            jone.Text = joint[0];
            jtwo.Text = joint[1];
            jthree.Text = joint[2];
            jfour.Text = joint[3];
            jfive.Text = joint[4];
            jsix.Text = joint[5];
            jseven.Text = joint[6];

        }
        #endregion

        #region 从sqlite数据库获取机器人信息
        public void getrobotinfo()
        {
            //数据库连接
            SQLiteConnection myCon;
            myCon = new SQLiteConnection("Data Source=robot.sqlite;Version=3;");
            myCon.Open();
            //选择所有数据
            SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select * from robotInfo", myCon);
            DataTable dt = new DataTable();
            mAdapter.Fill(dt);
            //绑定数据到DataGridView
            dataGridView1.DataSource = dt;
            //关闭数据库
           myCon.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
     
            robotName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            robotIp.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        #endregion

        #region 菜单，单个测试
        private void singleTest_Click(object sender, EventArgs e)
        {
            demo demotest = new demo();
            demotest.StartPosition = FormStartPosition.CenterScreen;
            demotest.Show();
        }
        #endregion

        #region 菜单-帮助页面
        private void helpMenu_Click(object sender, EventArgs e)
        {
            help helptest = new help();
            helptest.StartPosition = FormStartPosition.CenterScreen;
            helptest.Show();
        }

        #endregion

        #region 菜单-新增机器人信息
        private void addMenu_Click(object sender, EventArgs e)
        {
            addRobot add = new addRobot();
            add.StartPosition = FormStartPosition.CenterScreen;
            add.Show();
        }

        #endregion


        private void refreshlist_Click(object sender, EventArgs e)
        {
            getrobotinfo();
        }


        #region 20210502 搜索功能
        private void searchRobot_TextChanged(object sender, EventArgs e)
        {
            //数据库连接
            SQLiteConnection myCon;
            myCon = new SQLiteConnection("Data Source=robot.sqlite;Version=3;");
            myCon.Open();
            //选择数据
            string sql = "select * from robotInfo where ROBOTNAME like" + "'%" + searchRobot.Text + "%'";
        
            SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, myCon);
            DataTable dt = new DataTable();
            mAdapter.Fill(dt);
            //绑定数据到DataGridView
            dataGridView1.DataSource = dt;
            //关闭数据库
            myCon.Close();
        }
        #endregion

        private void delRobot_Click(object sender, EventArgs e)
        {
            //数据库连接
            SQLiteConnection myCon;
            myCon = new SQLiteConnection("Data Source=robot.sqlite;Version=3;");
            myCon.Open();

            string sql = "delete from robotInfo where ROBOTNAME='"+robotName.Text+"' and ROBOTIP='"+robotIp.Text+"' ";
            SQLiteCommand command = new SQLiteCommand(sql, myCon);
            command.ExecuteNonQuery();
            MessageBox.Show("删除成功！");
            myCon.Close();
            getrobotinfo();
        }
    }
}
