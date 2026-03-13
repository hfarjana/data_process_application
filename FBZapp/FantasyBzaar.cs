using FBZapp.Models;
using FBZapp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FBZapp
{
    public partial class FantasyBzaarForm : Form
    {
        private List<Comic> allComics;

        private bool placeholderActive = true;
        private const string SearchPlaceholder = "Author | Year | Publisher";

        private ISearchService _searchService;
        private IComicRepository _repository;
        private ISearchAnalyticsService analyticsService;
        private IFavouriteService favouriteService;

        public FantasyBzaarForm()
        {
            InitializeComponent();
        }

        
        // FORM LOAD 
      
        private void FantasyBzaarForm_Load(object sender, EventArgs e)
        {
            InitialiseUI();

            // Load CSV data
            string path = Path.Combine(Application.StartupPath, "Data", "titles.csv");
            var loader = new CsvDataLoader(path);
            allComics = loader.LoadComics();

            // Create services
            _repository = new ComicRepository(allComics);
            _searchService = new SearchService(_repository);
            analyticsService = new SearchAnalyticsService();
            favouriteService = new FavouriteService();

            // Display data
            dgvComics.DataSource = allComics;
            dgvComics.RowHeadersVisible = false;

            AddSaveButtonColumn();
        }

        // INITIALISE UI
      
        private void InitialiseUI()
        {
            pnlAdvancedSearch.Visible = true;
            pnlReports.Visible = false;

            dgvComics.AutoGenerateColumns = true;
            dgvComics.Visible = true;

            // Search box
            txtSearch.Text = SearchPlaceholder;
            txtSearch.ForeColor = Color.Gray;

            // Advanced search placeholders
            txtAuthorFilter.Text = "Author";
            txtAuthorFilter.ForeColor = Color.Gray;

            txtPublisherFilter.Text = "Publisher";
            txtPublisherFilter.ForeColor = Color.Gray;

            // Year selectors
            numYearFrom.Minimum = 1900;
            numYearFrom.Maximum = DateTime.Now.Year;
            numYearFrom.Value = 1900;

            numYearTo.Minimum = 1900;
            numYearTo.Maximum = DateTime.Now.Year;
            numYearTo.Value = DateTime.Now.Year;
        }

        // GLOBAL SEARCH
      
        private void RunGlobalSearch()
        {
            string query = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(query) || query == SearchPlaceholder)
                return;

            var results = _searchService.GlobalSearch(query);
            dgvComics.DataSource = results;

            analyticsService.TrackSearch(query, results.Count);
        }

        private void pictureSearch_Click(object sender, EventArgs e)
        {
            RunGlobalSearch();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (placeholderActive)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
                placeholderActive = false;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                RunGlobalSearch();
                e.Handled = true;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == SearchPlaceholder)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = SearchPlaceholder;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        // ADVANCED SEARCH
      
        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            pnlAdvancedSearch.Visible = true;
            pnlAdvancedSearch.BringToFront();
        }

        private void btnApplyAdvanced_Click(object sender, EventArgs e)
        {
            // Read raw values
            var author = txtAuthorFilter.Text.Trim();
            var publisher = txtPublisherFilter.Text.Trim();

            // Ignore placeholder text
            if (author == "Author") author = string.Empty;
            if (publisher == "Publisher") publisher = string.Empty;

            int yearFrom = (int)numYearFrom.Value;
            int yearTo = (int)numYearTo.Value;

            // Call service (it already handles lower-casing)
            var results = _searchService.AdvancedSearch(author, publisher, yearFrom, yearTo);
            dgvComics.DataSource = results;

            analyticsService.TrackSearch(
                $"Author:{author}; Publisher:{publisher}; Years:{yearFrom}-{yearTo}",
                results.Count
            );
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAuthorFilter.Text = "Author";
            txtAuthorFilter.ForeColor = Color.Gray;

            txtPublisherFilter.Text = "Publisher";
            txtPublisherFilter.ForeColor = Color.Gray;

            numYearFrom.Value = 1900;
            numYearTo.Value = DateTime.Now.Year;

            dgvComics.DataSource = allComics;
        }

        private void btnCloseAdvanced_Click(object sender, EventArgs e)
        {
            pnlAdvancedSearch.Visible = false;
        }

        // REPORTS
        
        private void btnReports_Click(object sender, EventArgs e)
        {
            pnlReports.Visible = !pnlReports.Visible;
            if (pnlReports.Visible)
            {
                LoadReports();
                pnlReports.BringToFront();
            }
        }

        private void LoadReports()
        {
            // Top searches
            listBox1.Items.Clear();
            foreach (var item in analyticsService.GetTopSearches(10))
                listBox1.Items.Add($"{item.Key} → {item.Value}");

            // Top search result counts
            listBox2.Items.Clear();
            foreach (var item in analyticsService.GetTopResults(10))
                listBox2.Items.Add($"{item.Key} → {item.Value}");

            // Popular comics
            listBox3.Items.Clear();
            foreach (var c in allComics.Where(c => c.Variants.Count >= 100))
                listBox3.Items.Add($"{c.Title} → {c.Variants.Count} copies");
        }

       
        // SORTING & GROUPING
   
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sorted = _searchService.ApplySorting(allComics, cmbSort.Text);
            dgvComics.DataSource = sorted;
        }

        private void cmbGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var groups = _searchService.GroupComics(allComics, cmbGroupBy.Text);

            if (groups.Count == 0)
            {
                dgvComics.DataSource = allComics;
                return;
            }

            var display = groups
                .SelectMany(g => g.Select(c => new
                {
                    Group = g.Key,
                    Title = c.Title,
                    Author = c.Author,
                    Year = c.Year,
                    Publisher = c.Publisher
                }))
                .ToList();

            dgvComics.DataSource = display;
        }

        private void cmbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtered = _searchService.FilterByGenre(allComics, cmbGenre.Text);
            dgvComics.DataSource = filtered;
        }

       
        // FAVOURITES
      
        private void AddSaveButtonColumn()
        {
            if (dgvComics.Columns["Save"] != null)
                return;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Save";
            btn.Name = "Save";
            btn.Text = "★";
            btn.UseColumnTextForButtonValue = true;
            btn.Width = 60;

            dgvComics.Columns.Add(btn);
        }

        private void dgvComics_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvComics.Columns[e.ColumnIndex].Name == "Save")
            {
                var comic = (Comic)dgvComics.Rows[e.RowIndex].DataBoundItem;

                if (!favouriteService.IsFavourite(comic))
                {
                    favouriteService.AddToFavourites(comic);
                    MessageBox.Show($"{comic.Title} added to favourites ❤️");
                }
                else
                {
                    favouriteService.RemoveFromFavourites(comic);
                    MessageBox.Show($"{comic.Title} removed from favourites 🤍");
                }
            }
        }

        private void btnSaved_Click(object sender, EventArgs e)
        {
            dgvComics.DataSource = favouriteService.GetFavourites();
        }

        private void txtAuthorFilter_Enter(object sender, EventArgs e)
        {
            if (txtAuthorFilter.Text == "Author")
            {
                txtAuthorFilter.Text = "";
                txtAuthorFilter.ForeColor = Color.Black;
            }
        }

        private void txtAuthorFilter_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAuthorFilter.Text))
            {
                txtAuthorFilter.Text = "Author";
                txtAuthorFilter.ForeColor = Color.Gray;
            }
        }

        private void txtPublisherFilter_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPublisherFilter.Text))
            {
                txtPublisherFilter.Text = "Publisher";
                txtPublisherFilter.ForeColor = Color.Gray;
            }
        }

        private void cmbSort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (allComics == null || allComics.Count == 0)
                return;

            var sorted = _searchService.ApplySorting(allComics, cmbSort.Text);
            dgvComics.DataSource = sorted;
        }

        private void txtPublisherFilter_Enter(object sender, EventArgs e)
        {
            if (txtPublisherFilter.Text == "Publisher")
            {
                txtPublisherFilter.Text = "";
                txtPublisherFilter.ForeColor = Color.Black;
            }
        }
    }
}




