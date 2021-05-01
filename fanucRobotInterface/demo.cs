using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fanucRobotInterfaceComm;

namespace fanucRobotInterface
{
    public partial class demo : Form
    {
        public demo()
        {
            InitializeComponent();
        }

        public string[] xyzwpr;
        public string[] joint;



        robotInterfaceComm robot = new robotInterfaceComm();

       

        private void readcuralarm_Click(object sender, EventArgs e)
        {
            rescurralarm.Text = robot.readcurrAlarm("127.0.0.1");
        }

        private void readhisalarm_Click(object sender, EventArgs e)
        {
            reshisalarm.Text = robot.readhisAlarm("127.0.0.1");
        }

        private void readjoint_Click(object sender, EventArgs e)
        {
            joint = robot.joint("127.0.0.1");
        }

        private void readxyzwpr_Click(object sender, EventArgs e)
        {
            xyzwpr=robot.xyzwpr("127.0.0.1");
        }
    }
}
