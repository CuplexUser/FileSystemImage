using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemImage.FileSystem;
using FileSystemImage.FileTree;
using Serilog;

namespace FileSystemImage
{
    public partial class FrmSearch : Form
    {
        private FileSystemDrive _fileSystemDrive;
        private CancellationTokenSource _searchCancellation;
        private readonly ILogger _logger;

        private delegate void SearchCompleteEventHandler(object sender, SearchEventArgs e);
        private bool _isSearching = false;

        public FrmSearch(ILogger logger)
        {
            _logger = logger;
            InitializeComponent();
            _searchCancellation = new CancellationTokenSource();
        }

        public void SetFileSystemDrive(FileSystemDrive fsd)
        {
            _fileSystemDrive = fsd;
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
        }

        private void frmSearch_Resize(object sender, EventArgs e)
        {
            const int padding = 20;
            const int innerPadding = 6;
            grpSearch.Width = Width - padding * 2;
            lstResults.Width = grpSearch.Width;
            lstResults.Height = Height - lstResults.Top - statusStrip1.Height - padding * 2;

            txtSearch.Width = txtSearch.Parent.Width - innerPadding * 2;
            btnSearch.Left = btnSearch.Parent.Width - btnSearch.Width - innerPadding;
            chkRegexp.Left = chkRegexp.Parent.Width - chkRegexp.Width - btnSearch.Width - innerPadding * 2;
            chkIgnoreCase.Left = chkRegexp.Left;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                PerformSearch();
        }

        private void PerformSearch()
        {
            if (txtSearch.Text == "")
                return;

            if (_searchCancellation.IsCancellationRequested)
                return;

            if (_isSearching)
            {
                _searchCancellation.Cancel();
                _searchCancellation.Token.Register(() =>
                {
                    _isSearching = false;
                    Invoke(new SearchCompleteEventHandler(SearchComplete), this, new SearchEventArgs(null));
                });
                return;
            }

            btnSearch.Text = "Cancel";
            _isSearching = true;

            var searchAlg = new TreeSearch(_fileSystemDrive);

            try
            {
                string searchString = txtSearch.Text;

                while (!chkRegexp.Checked && searchString.Contains(@"\\"))
                {
                    searchString = searchString.Replace(@"\\", @"\");
                }

                bool includeFolderNames = chkFoldersIncluded.Checked;
                Task.Run(async () =>
                {
                    var searchRes = await searchAlg.Search(searchString, chkRegexp.Checked, chkIgnoreCase.Checked, includeFolderNames);
                    _isSearching = false;
                    Invoke(new SearchCompleteEventHandler(SearchComplete), this, new SearchEventArgs(searchRes));
                }, _searchCancellation.Token);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "SearchException");
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchComplete(object sender, SearchEventArgs e)
        {
            btnSearch.Text = "Search";
            _searchCancellation = new CancellationTokenSource();
            if (e.TreeSearchResults != null)
                PopulateSearchResult(e.TreeSearchResults);
        }

        private void PopulateSearchResult(List<TreeSearchResult> searchResults)
        {
            toolStripSearchResCount.Text = searchResults.Count.ToString();
            bool truncate = false;

            if (searchResults.Count > 5000)
            {
                truncate = true;
                searchResults = searchResults.Take(5000).ToList();
            }

            lstResults.Items.Clear();
            foreach (TreeSearchResult res in searchResults)
                lstResults.Items.Add(res);

            if (truncate)
                MessageBox.Show("The Search result has been truncated to 5000 results");
        }

        private void lstResults_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            var item = lstResults.SelectedItem as TreeSearchResult;
            if (item != null)
            {
                try
                {
                    string p = item.Path + "\\" + item.file.Name;
                    string args = $"/e, /select, \"{p}\"";

                    var info = new ProcessStartInfo
                    {
                        FileName = "explorer",
                        Arguments = args
                    };
                    Process.Start(info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

    internal class SearchEventArgs : EventArgs
    {
        public SearchEventArgs(List<TreeSearchResult> searchRes)
        {
            TreeSearchResults = searchRes;
        }

        public List<TreeSearchResult> TreeSearchResults { get; }
    }
}