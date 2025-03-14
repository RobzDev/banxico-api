using Newtonsoft.Json;
using System.Text;

namespace banxico_api
{





    public partial class Form1 : Form
    {


        
        ApiResponse api = new ApiResponse();
        Dictionary<int, float> keyValuePairs = new Dictionary<int, float>();

        private async Task<ApiResponse> GetApiResponse()
        {
            {
                string token = "1c189f03f7bce05946b878a418c095e2f6d7dd7bf233fef28f626fae359bd9e9";
                string serieId = "SF17886";
                string url = $"https://www.banxico.org.mx/SieAPIRest/service/v1/series/{serieId}/datos";
                ///string= "https://www.banxico.org.mx/SieAPIRest/service/v1/token";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Bmx-Token", token);

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        string result = await response.Content.ReadAsStringAsync();

                      



                        ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(result);
                        return apiResponse;

                    }
                    catch (HttpRequestException e)
                    {
                        return null;
                    }
                }
            }


        }

        public Form1()
        {
            InitializeComponent();
            ApiConsult();
           


        }

        //add the dictionary to the datagridview
        private void AddToDataGrid(Dictionary<int, float> keyValuePairs)
        {
           
            foreach (var item in keyValuePairs)
            {
                dtviewData.Rows.Add(item.Key, item.Value);
            }
        }


        private async void ApiConsult()
        {
            
           
            ApiResponse apiResponse = await GetApiResponse();
            api = apiResponse;
            ListFixed();
            

        }

        public void ListFixed()
        {
            
            
          
            foreach (var serie in api.Bmx.Series)
            {
                int year = 0;
                float sumofvalues = 0;
                int numberofmonths = 0;
                foreach (var dato in serie.Datos)
                {

                    if ((float.Parse(dato.Valor) > 0)) 
                    {
                        DateTime date = DateTime.Parse(dato.Fecha);
                  
                        int month = date.Month;


                        if (year == 0 )
                        {
                            year = date.Year;
                           
                        }
                        else if(year != date.Year)
                        {
                            //make an average of the values and the number of months
                            float average = sumofvalues / numberofmonths;
                            //get only the first 3 decimals
                            average = (float)Math.Round(average, 2);


                            keyValuePairs.Add(year, average);

                            numberofmonths = 0;
                            sumofvalues = 0;
                            year = date.Year;

                        }



                       numberofmonths++;
                        sumofvalues = sumofvalues + float.Parse(dato.Valor);

                      

                        
                    }
                    
                    

                }  
            }

            AddToDataGrid(keyValuePairs);
        }
     

       

        public class Bmx
        {
            [JsonProperty("series")]
            public List<Serie> Series { get; set; }
        }
        public class ApiResponse
        {
            [JsonProperty("bmx")]
            public Bmx Bmx { get; set; }
        }

        public class Serie
        {
            [JsonProperty("idSerie")]
            public string IdSerie { get; set; }

            [JsonProperty("titulo")]
            public string Titulo { get; set; }

            [JsonProperty("datos")]
            public List<Dato> Datos { get; set; }
        }

        public class Dato
        {
            [JsonProperty("fecha")]
            public string Fecha { get; set; }

            [JsonProperty("dato")]
            public string Valor { get; set; }
        }


    }

}