using Core;
using System;
using Ionic.Zip;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        TcpModule _tcpmodule = new TcpModule();
        static HttpClient _client = new HttpClient();
        private HierarchyTree _tree = null;
        private string _path;
        private Stack _history = new Stack();

        public Form1()
        {
            InitializeComponent();
            RunAsync().GetAwaiter().GetResult();
            InitAsync();
        }

        private async void buttonArchieve_ClickAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_path))
            {
                var response = await _client.PostAsJsonAsync("api/tree/getarchive", "");
            }
            else
            {
                var response = await _client.PostAsJsonAsync("api/tree/getarchive", _path);
            }
        }

        private async void InitAsync()
        {
            var response = await _client.GetAsync("api/tree/getroot");
            if (response.IsSuccessStatusCode)
            {
                _tree = await response.Content.ReadAsAsync<HierarchyTree>();
            }
            treeView.Nodes.AddRange(_tree.Directories
                .Select(x => new TreeNode()
                {
                    Text = x
                })
                .ToArray());
            treeView.Nodes.AddRange(_tree.Files
                .Select(x => new TreeNode()
                {
                    Text = x
                })
                .ToArray());
        }

        static async Task RunAsync()
        {
            _client.BaseAddress = new Uri("http://localhost:10833");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.ReadLine();
        }

        private async void treeView_NodeMouseDoubleClickAsync(object sender, TreeNodeMouseClickEventArgs e)
        {
            var response = await _client.PostAsJsonAsync("api/tree/getpath", e.Node.Text);
            if (response.IsSuccessStatusCode)
            {
                _tree = await response.Content.ReadAsAsync<HierarchyTree>();
            }
            if(_tree != null)
            {
                treeView.Nodes.Clear();
                treeView.Nodes.AddRange(_tree.Directories
                    .Select(x => new TreeNode()
                    {
                        Text = x
                    })
                    .ToArray());
                treeView.Nodes.AddRange(_tree.Files
                    .Select(x => new TreeNode()
                    {
                        Text = x
                    })
                    .ToArray());
                if(_path != null)
                {
                    _history.Push(_path);
                }                
                _path = e.Node.Text;
                labelPath.Text = _path;
            }
        }

        private async void buttonHistory_ClickAsync(object sender, EventArgs e)
        {
            HttpResponseMessage response;
            if (_history.Count > 0)
            {
                string path = _history.Pop().ToString();
                response = await _client.PostAsJsonAsync("api/tree/getpath", path);
                _path = path.ToString();
            }
            else
            {
                response = await _client.GetAsync("api/tree/getroot");
                _path = null;
                labelPath.Text = "";
            }
            if (response.IsSuccessStatusCode)
            {
                _tree = await response.Content.ReadAsAsync<HierarchyTree>();
            }
            if (_tree != null)
            {
                treeView.Nodes.Clear();
                treeView.Nodes.AddRange(_tree.Directories
                    .Select(x => new TreeNode()
                    {
                        Text = x
                    })
                    .ToArray());
                treeView.Nodes.AddRange(_tree.Files
                    .Select(x => new TreeNode()
                    {
                        Text = x
                    })
                    .ToArray());
                labelPath.Text = _path;
            }
        }
    }
}
