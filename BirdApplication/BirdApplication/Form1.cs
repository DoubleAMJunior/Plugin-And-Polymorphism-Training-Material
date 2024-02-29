using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;

namespace BirdApplication { 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
            tmr.Tick += Update;  // set handler
            tmr.Interval = 50;
            tmr.Enabled = true;
            tmr.Start();
        }

        void Update(Object sender,EventArgs e)
        {
            foreach (BirdHolder item in holders)
            {
                item.Move();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BirdHolder newBird = new BirdHolder(addLabel(), new Eagle(new Point(50, 400)));
            holders.Add(newBird);
        }

        private List<BirdHolder> holders = new List<BirdHolder>();

        public Label addLabel()
        {
            Label newLabel = new Label();
            newLabel.AutoSize = true;
            newLabel.Location = new Point(50, 400);
            newLabel.AutoSize = true;
            newLabel.Font = new Font("Calibri", 11);
            newLabel.Text = "Test";
            this.Controls.Add(newLabel);
            return newLabel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BirdHolder newBird = new BirdHolder(addLabel(), new Chicken(new Point(50, 400)));
            holders.Add(newBird);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BirdHolder newBird = new BirdHolder(addLabel(), new Crow(new Point(50, 400)));
            holders.Add(newBird);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }
    }

    class BirdHolder
    {
        IBird bird;
        Label label;

        public BirdHolder(Label l,IBird b)
        {
            bird = b;
            label = l;
            l.Text = bird.getName();
        }

        public void Move()
        {
            label.Location = bird.Move();
        }
    }
}
