using MonsteHunterWorld.VO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsteHunterWorld.BUS
{
    public partial class FormMonster : Form
    {
        public FormMonster()
        {
            InitializeComponent();
        }

        Form1 owner;
        string getName;
        private void FormMonster_Load(object sender, EventArgs e)
        {
            owner = this.Owner as Form1;
            //owner.Visible = false; // 메인화면 안보이게하기
            owner.Enabled = false;
            getName = "monsters";
            JArray ja = JArray.Parse(owner.GetJson(new Parameter(getName)));
            //textBox1.Text = ja.ToString();
            textBox1.Text = ja.ToString();
            
        }
    }
}
