using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Test
{
    class CellPhone
    {
        private string brand;
        private double price;
        private string model;
    
    public CellPhone()
    {
        brand = "";
        price = 0.0;
        model = "";
        
    }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }   
        }
    }