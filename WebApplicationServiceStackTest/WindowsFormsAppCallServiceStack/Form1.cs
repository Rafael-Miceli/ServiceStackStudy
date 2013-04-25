using System;
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
            var client = new JsonServiceClient("http://localhost:28141");// { UserName = "rafael", Password = "password" };

            UnitSoldReponse response = null;

            try
            {
                response = client.Get<UnitSoldReponse>("/unitsold/" + txtBlocRequest.Text + "/" + txtUnitSoldsRequest.Text + "/" + txtDateSoldRequest.Text);
                //response = client.Get(new UnitSold() {BlocName = txtBlocRequest.Text, DateSold = DateTime.Parse(txtDateSoldRequest.Text), UnitSolds = int.Parse(txtUnitSoldsRequest.Text)});
            }
            catch (WebServiceException ex)
            {
                txtNameResponse.Text = ex.ErrorCode + "  " + ex.ErrorMessage;
            }


            if (response != null) txtNameResponse.Text = response.Result;
        }

    }
}
