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

        private void robotConn_Click(object sender, EventArgs e)
        {
            getxyzwpr(robotIp.Text);
            getjoint(robotIp.Text);
            rescurralarm.Text=robot.readcurrAlarm(robotIp.Text);
            reshisalarm.Text=robot.readhisAlarm(robotIp.Text);
           
        }



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

        private void main_Load(object sender, EventArgs e)
        {
            getrobotinfo();
        }
    }
}
