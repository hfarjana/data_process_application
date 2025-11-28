using FBZapp.Models;
using FBZapp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBZapp
{
    public partial class FantasyBzaarForm : Form
    {
        private List<Comic> allComics;
        private void LoadData()
        {
            var loader = new CsvDataLoader(@"Data\names.csv");
            allComics = loader.LoadComics();

            dgvComics.DataSource = allComics;
        }

        public FantasyBzaarForm()
        {
            InitializeComponent();
            LoadData();
            string csvPath = Path.Combine(Application.StartupPath, "Data", "titles.csv");

            var loader = new CsvDataLoader(csvPath);

            try
            {
                var comics = loader.LoadComics();
                MessageBox.Show($"Loaded {comics.Count} comics successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading CSV: " + ex.Message);
            }

        }


        private void btnAccount_Click(object sender, EventArgs e)
        {
            contextMenuStrip5.Show(btnAccount, 0, btnAccount.Height);
        }

       

      

        private void Form1_Load(object sender, EventArgs e)
        {
           
        
            txtSearch.ForeColor = Color.LightGray;
            txtSearch.Text = "Author | Year | Publisher";
        }
            bool placeholderActive = true;
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (placeholderActive)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
                placeholderActive = false; 
                // Allow their first typed character to appear
                txtSearch.SelectionStart = txtSearch.Text.Length;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                placeholderActive = true;
                txtSearch.ForeColor = Color.LightGray;
                txtSearch.Text = "Author | Year | Publisher";
            }
        }

      
    }
}



