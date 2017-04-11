using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using SharpUpdate;
using System.IO;

namespace TestApp
{
    public partial class Form1 : Form, ISharpUpdatable
    {
        private SharpUpdater updater;

        public Form1()
        {
            InitializeComponent();

            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (di != null)
            {
                FileInfo[] subFiles = di.GetFiles();
                if (subFiles.Length > 0)
                {
                    Console.WriteLine("Files:");
                    foreach (FileInfo subFile in subFiles)
                    {
                        Console.WriteLine("   " + subFile.Name + " (" + subFile.Length + " bytes)");
                    }
               }
            }
            this.label1.Text = this.ApplicationAssembly.GetName().Version.ToString();
            this.label3.Text = this.ApplicationAssembly.GetName().Name.ToString();
            updater = new SharpUpdater(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updater.DoUpdate();
        }

        #region SharpUpdate
        public string ApplicationName
        {
            get { return "TestApp"; }
        }

        public string ApplicationID
        {
            get { return "TestApp"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly();}
        }

        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri("https://raw.githubusercontent.com/PrasadHalingale27/UpdateControl/master/SharpUpdate-master/project.xml"); }
        }

        public Form Context
        {
            get { return this; }
        }
        #endregion
    }
}
