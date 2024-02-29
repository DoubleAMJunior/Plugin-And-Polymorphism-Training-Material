using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;

namespace BirdApplication
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        void Update(Object sender, EventArgs e)
        {
            foreach (BirdHolder item in holders)
            {
                item.Move();
            }
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

        private void Load_Click(object sender, EventArgs e)
        {
            string adress = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            adress=adress.Replace("\\bin\\Debug","");
            adress += "\\Plugins";
            string[] filePaths = Directory.GetFiles(adress, "*.dll");
            foreach (var path in filePaths)
            {
                Assembly assembly = Assembly.LoadFrom(path);
                Type birdType = typeof(IBird);
                var types = assembly.GetTypes().Where(p=> birdType.IsAssignableFrom(p));
                foreach (var t in types) {
                    IBird instance = (IBird)Activator.CreateInstance(assembly.GetType(t.FullName));
                    BirdHolder holder = new BirdHolder(addLabel(), instance);
                    holders.Add(holder);
                }
               
            }
        }

        private void appStartPluginCheck()
        {
            string adress = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            adress = adress.Replace("\\bin\\Debug", "");
            adress += "\\Plugins";
            string[] filePaths = Directory.GetFiles(adress, "*.dll");
            foreach (var path in filePaths)
            {
                Assembly assembly = Assembly.LoadFrom(path);
                Type birdType = typeof(IBird);
                var types = assembly.GetTypes().Where(p => birdType.IsAssignableFrom(p));
                foreach (var t in types)
                {
                    IBird instance = (IBird)Activator.CreateInstance(assembly.GetType(t.FullName));
                    BirdHolder holder = new BirdHolder(addLabel(), instance);
                    holders.Add(holder);
                }
            }
            var watcher = new FileSystemWatcher(adress);
            watcher.Filter = "*.dll";
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            watcher.Changed += LoadPlugin;
            //watcher.Created += LoadPlugin;
            //watcher.Renamed += LoadPlugin;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        int invokeCounter = 0;
        private void  LoadPlugin(object sender, FileSystemEventArgs e)
        {
            if (invokeCounter%2!=0)
            {
                invokeCounter = 0;
                return;
            }
            invokeCounter++;
            Assembly assembly = Assembly.LoadFrom(e.FullPath);
            Type birdType = typeof(IBird);
            var types = assembly.GetTypes().Where(p => birdType.IsAssignableFrom(p));
            foreach (var t in types)
            {
                IBird instance = (IBird)Activator.CreateInstance(assembly.GetType(t.FullName));
                BirdHolder holder = (BirdHolder)Invoke(createBird,instance);
                holders.Add(holder);
            }
        }

        private delegate BirdHolder CreateBird(IBird instance);
        private CreateBird createBird;
        private BirdHolder BirdFactory(IBird instance)
        {
           return  new BirdHolder(addLabel(), instance);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
            tmr.Tick += Update;  // set handler
            tmr.Interval = 50;
            tmr.Enabled = true;
            tmr.Start();
            appStartPluginCheck();
            createBird += BirdFactory;
        }
    }
}
