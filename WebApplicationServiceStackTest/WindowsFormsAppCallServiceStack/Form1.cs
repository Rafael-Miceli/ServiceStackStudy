using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceStack.ServiceClient.Web;
using WebApplicationServiceStackTest;

namespace WindowsFormsAppCallServiceStack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new JsonServiceClient("http://localhost:28141") { UserName = "rafael", Password = "password" };

            var response = client.Get<HelloWorldReponse>("/hello/" + txtNameRequest.Text);

            txtNameResponse.Text = response.Result;
        }
    }
}
