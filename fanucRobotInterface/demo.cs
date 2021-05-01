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
            getjoint(robotIp.Text);
        }

        private void readxyzwpr_Click(object sender, EventArgs e)
        {
            getxyzwpr(robotIp.Text);
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



    }
}
