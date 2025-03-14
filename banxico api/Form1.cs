namespace banxico_api
{





    public partial class Form1 : Form
    {

        private async Task<string> GetApiResponse()
        {
            {
                string token = "1c189f03f7bce05946b878a418c095e2f6d7dd7bf233fef28f626fae359bd9e9";
                string url = "https://www.banxico.org.mx/SieAPIRest/service/v1/token";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Bmx-Token", token);

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();

                        return await response.Content.ReadAsStringAsync();
                    }
                    catch (HttpRequestException e)
                    {
                        return $"Error: {e.Message}";
                    }
                }
            }


        }

        public Form1()
        {
            InitializeComponent();
        }




        private async void button1_Click(object sender, EventArgs e)
        {
            string result = await GetApiResponse();
            lblResponse.Invoke((MethodInvoker)(() => lblResponse.Text = result));

        }

    }

}
