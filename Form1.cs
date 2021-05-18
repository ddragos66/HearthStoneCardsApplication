using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        private int normalCard;

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

                var normalCard = cards["Classic"][i]["img"];
                var goldCard = cards["Classic"][i]["imgGold"];

                //Debug.WriteLine(classicCardsNumbers1);

                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                this.pictureBox1.Load(normalCard.ToString());

                pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                this.pictureBox2.Load(goldCard.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var normalCard = cards["Classic"][++i]["img"];
            var goldCard = cards["Classic"][i]["imgGold"];
            //Debug.WriteLine("++" + i);
            this.pictureBox1.Load(normalCard.ToString());
            this.pictureBox2.Load(goldCard.ToString());
            //string test = "imgGold";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var normalCard = cards["Classic"][--i]["img"];
            var goldCard = cards["Classic"][i]["imgGold"];
            //Debug.WriteLine("--"+i);
            this.pictureBox1.Load(normalCard.ToString());
            this.pictureBox2.Load(goldCard.ToString());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Aici salvez imaginea
            pictureBox1.Image.Save(@"C:\Users\drago\Documents\card.jpeg" + normalCard, ImageFormat.Jpeg);
        }
    }
}
