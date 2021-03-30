using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Dynamic_Currency_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void currencyList()
        {
            APIRequester currencyListRequest = new APIRequester("https://free.currconv.com/api/v7/currencies?apiKey=6f8ea18f7f98fa33e29a");
            CurrencyList currencyList = CurrencyList.Deserialize(currencyListRequest.SendAndGetResponse());

            CurrencyData[] datas = currencyList.ToArray();
            foreach (CurrencyData currency in datas)
            {
                comboBox1.Items.Add(currency.id);
                comboBox2.Items.Add(currency.id);
            }
        }

        public static double Exchange(string from, string to, string date)
        {
            string url;
            url = "https://free.currencyconverterapi.com/api/v6/" + "convert?q=" + from + "_" + to + "&compact=y&date=" + date + "&apiKey=2e6b5ce5c45e3c732002";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string jsonString;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            return JObject.Parse(jsonString).First.First["val"].First.ToObject<double>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Reset
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        //Convert
        private void button1_Click(object sender, EventArgs e)
        {
                double input = Convert.ToDouble(textBox1.Text);
                double rate = Exchange(comboBox1.Text, comboBox2.Text, dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
                input = input * rate;

                textBox1.Text = Convert.ToString(input);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
