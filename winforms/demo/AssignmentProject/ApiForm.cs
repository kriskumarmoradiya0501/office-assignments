using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentProject;

public partial class ApiForm : Form
{
    private readonly ApiService _apiService;
    private List<Post> _posts;

    public ApiForm()
    {
        _apiService = new ApiService("https://jsonplaceholder.typicode.com/");
        InitializeComponent();
        LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        _posts = await _apiService.GetAllAsync<Post>("posts");
        dgview.DataSource = _posts;
    }

    public async void btnRead_Click(object sender, EventArgs e)
    {
        try
        {
            Post _post = await _apiService.GetAsync<Post>("posts", Int32.Parse(txtid.Text));
            txtuserid.Text = Convert.ToString(_post.UserId);
            txttitle.Text = _post.Title;
            txtbody.Text = _post.Body;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Please enter valid data: " + ex.Message, "Api", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public async void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Post post = new Post();
            post.Id = int.Parse(txtid.Text);
            post.UserId = int.Parse(txtuserid.Text);
            post.Title = txttitle.Text;
            post.Body = txtbody.Text;
            string StatusCode = await _apiService.CreateAsync("posts", post);
            if (StatusCode == "201")
                MessageBox.Show("Created sucessfully " + StatusCode, "Api", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Not created some error " + StatusCode, "Api", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Please enter valid data: " + ex.Message, "Api", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public async void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Post post = new Post();
            post.Id = int.Parse(txtid.Text);
            post.UserId = int.Parse(txtuserid.Text);
            post.Title = txttitle.Text;
            post.Body = txtbody.Text;
            string StatusCode = await _apiService.UpdateAsync("posts", Int32.Parse(txtid.Text), post);
            if (StatusCode == "200")
                MessageBox.Show("Updated sucessfully " + StatusCode, "Api", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Not updated some error " + StatusCode, "Api", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Please enter valid data: " + ex.Message, "Api", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public async void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string StatusCode = await _apiService.DeleteAsync("posts", Int32.Parse(txtid.Text));
            if (StatusCode == "200")
                MessageBox.Show("Deleted sucessfully " + StatusCode, "Api", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Not deleted some error " + StatusCode, "Api", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Please enter valid data: " + ex.Message, "Api", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
