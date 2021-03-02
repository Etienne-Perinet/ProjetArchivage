using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archivage
{
    public partial class MergeBD : Form
    {
        SqlControler sqlControler = new SqlControler();

        public MergeBD()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private string GetFilePathForTheBDs()
        {
            string fileSelected = "";

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = sqlControler.GetPathToProgram();
                openFileDialog1.Filter = "bd files (*.bd)|*.bd|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileSelected = openFileDialog1.FileName;
                }
            }

            return fileSelected;
        }

        private void btnSearchFileBD1_Click(object sender, EventArgs e)
        {
            txtPathBD1.Text = GetFilePathForTheBDs();
        }

        private void btnSearchFileBD2_Click(object sender, EventArgs e)
        {

            txtPathBD2.Text = GetFilePathForTheBDs();
        }

        private void btn__Click(object sender, EventArgs e)
        {
            sqlControler.CanMergeTheSecondBDs("URI=file:" + txtPathBD1.Text, "URI=file:" + txtPathBD2.Text);
            
            sqlControler.MergeTheBDs("URI=file:" + txtPathBD1.Text, "URI=file:" + txtPathBD2.Text);

            MessageBox.Show("Fusion des bases de données terminé!");
            
        }

        private void MergeBD_Load(object sender, EventArgs e)
        {
            txtPathBD1.Text = "C:\\Users\\etien\\OneDrive\\Desktop\\1_Gouv\\Archivage\\Archivage\\bin\\Debug\\BDArchive.db";
            txtPathBD2.Text = "C:\\Users\\etien\\OneDrive\\Desktop\\1_Gouv\\Archivage\\2BDArchive.db";
        }
    }
}
