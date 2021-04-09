using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HearthStoneCardsApplication
{
    public partial class Form1 : Form
    {
        int i = 300;
        JObject cards;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://omgvamp-hearthstone-v1.p.rapidapi.com/cards"),
                Headers =
                    {
                        { "x-rapidapi-key", "b71eccfbffmshec01617fe7d5e91p1e1f11jsn0f3a44a8de84" },
                        { "x-rapidapi-host", "omgvamp-hearthstone-v1.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                cards = JObject.Parse(body);

                var classicCardsNumbers = cards["Classic"][i]["img"];

                //Debug.WriteLine(classicCardsNumbers);

                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                this.pictureBox1.Load(classicCardsNumbers.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var classicCardsNumbers = cards["Classic"][++i]["img"];
            //Debug.WriteLine("++" + i);
            this.pictureBox1.Load(classicCardsNumbers.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var classicCardsNumbers = cards["Classic"][--i]["img"];
            //Debug.WriteLine("--"+i);
            this.pictureBox1.Load(classicCardsNumbers.ToString());
        }
    }
}
