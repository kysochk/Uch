using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uch
{
    class LoadList
    {
        public List<Product> product;
        public List<Client> clients;
        public LoadList()
        {
            product = skidka(); //вызывает метод подсчета скидки и формирования листа на вывод
            clients = BaseConnect.BaseModel.Client.ToList(); //заполняем лист клиентами

        }
        int flag = 0;
        public LoadList(int i)
        {
            flag = 1;
            product = skidka(); //вызывает метод подсчета скидки и формирования листа на вывод
            clients = BaseConnect.BaseModel.Client.ToList(); //заполняем лист клиентами


        }
        List<Product> skidka()
        {
            product = BaseConnect.BaseModel.Product.ToList();
            foreach (Product s in product)
            {
                if (flag == 1)
                {
                    s.visiblebtn = "Visible";
                }
                else
                {
                    s.visiblebtn = "Collapsed";
                }
                s.newcost = s.Cost;
                if (s.Discount > 0)
                {
                    s.Visible = "Visible";
                    s.VisibleD = "Visible";
                    s.Decor = "Strikethrough";
                    s.green = "LightGreen";
                    s.newcost = Convert.ToDecimal(Convert.ToDouble(s.Cost) - Convert.ToDouble(s.Cost) * s.Discount);

                }
                else
                {
                    s.green = "none";
                    s.Visible = "Collapsed";
                    s.VisibleD = "Hidden";
                }
            }
            return product;

        }
    }
}
}
