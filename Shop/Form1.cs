using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Shop
{
    public partial class Напитки : Form
    {
        public Напитки()
        {
            InitializeComponent();
            ClearInput();
        }
        private void ClearInput()
        {
            ProductName.Text = string.Empty;
            Price.Text = string.Empty;
            Flavor.SelectedIndex = 0;
            Volume.SelectedIndex = 0;
            Quantity.Value = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Flavor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Price_TextChanged(object sender, EventArgs e)
        {

        }

        private void Volume_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Quantity_ValueChanged(object sender, EventArgs e)
        {

        }
        private Beverages DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Beverages));

            using (FileStream fs = new FileStream("Beverages.xml", FileMode.OpenOrCreate))
            {
                return (Beverages)xml.Deserialize(fs);
            }
        }
        private void OpenXML(object sender, EventArgs e)
        {
            ClearInput();
            Beverages beverages = DeserializeXML();
            foreach(Beverage beverage in beverages.BeveragesList)
            {
                Add(beverage);
            }
        }
        private Beverages DeserializeJSON()
        {
            string json;
            using (StreamReader sr = new StreamReader("Beverages.json"))
            {
                json = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<Beverages>(json);
        }
        private void OpenJSON(object sender, EventArgs e)
        {
            ClearInput();
            Beverages beverages = DeserializeJSON();
            foreach (Beverage beverage in beverages.BeveragesList)
            {
                Add(beverage);
            }
        }
        private void LoadToJSON(object sender, EventArgs e)
        {
            Beverages beverages = new Beverages();

            foreach (ListViewItem item in Lv.Items)
            {
                if (item.Tag != null)
                {
                    beverages.BeveragesList.Add((Beverage)item.Tag);
                }
            }

            SerializeJSON(beverages);
        }
        private void SerializeJSON(Beverages beverages)
        {
            string json = JsonConvert.SerializeObject(beverages, Formatting.Indented);
            File.WriteAllText("Beverages.json", json);
        }
        private void Add(Beverage beverage)
        {
            ListViewItem LVI = new ListViewItem(beverage.Product);
            LVI.Tag = beverage;
            Lv.Items.Add(LVI);
        }
        private void SerializeXML(Beverages beverages)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Beverages));

            using (FileStream fs = new FileStream("Beverages.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, beverages);
            }
        }

        private void LoadToXML(object sender, EventArgs e)
        {
            Beverages beverages = new Beverages();

            foreach (ListViewItem item in Lv.Items)
            {
                if (item.Tag != null)
                {
                    beverages.BeveragesList.Add((Beverage)item.Tag);
                }
            }

            SerializeXML(beverages);
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
       

        private void AddProduct(object sender, EventArgs e)
        {
            Beverage beverage = new Beverage(Price.Text,Volume.SelectedIndex,(int)Quantity.Value, ProductName.Text, Flavor.SelectedIndex);

            Add(beverage);

            ClearInput();
        }

        private void Lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Lv.SelectedItems.Count == 1) 
            { 
                Beverage beverage = (Beverage)Lv.SelectedItems[0].Tag;
                if(beverage != null) 
                { 
                    ProductName.Text = beverage.Product;
                    Price.Text = beverage.Price;
                    Volume.SelectedIndex = (int)beverage.Volume;
                    Quantity.Value = beverage.Quantity;
                    Flavor.SelectedIndex = (int)beverage.Flavor;
                }
            }
            else if (Lv.SelectedItems.Count == 0)
            {
                ClearInput();
            }
        }

        
    }
}
