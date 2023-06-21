using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ExtractFromDifferentJsonFileToOneStoreClass
{
    internal class Store
    {
        public List<Product> Products = new List<Product>();
        public List<Group> Groups = new List<Group>();
        public List<ProductGroup> ProductGroups = new List<ProductGroup>();


        public Store()
        {
            ExtractFromProductsJson();
            ExtractFromGroupsJson();
            AttachGroupToProperProduct();
        }

        private void ExtractFromProductsJson()
        {
            string link = @"C:\Users\erikk\Desktop\Easy_Collection\Easy_Collection\ExtractFromDifferentJsonFileToOneStoreClass\Products.json";

            WebRequest request = WebRequest.Create(link);
            WebResponse response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                RootP root = JsonConvert.DeserializeObject<RootP>(responseFromServer);

                foreach (Product item in root.Products)
                {
                    Products.Add(item);
                }
            }
        }


        private void ExtractFromGroupsJson()
        {
            string link = @"C:\Users\erikk\Desktop\Easy_Collection\Easy_Collection\ExtractFromDifferentJsonFileToOneStoreClass\Groups.json";

            WebRequest request = WebRequest.Create(link);
            WebResponse response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                RootG root = JsonConvert.DeserializeObject<RootG>(responseFromServer);

                foreach (Group item in root.Groups)
                {
                    Groups.Add(item);
                }
            }
        }


        public void AttachGroupToProperProduct()
        {

            foreach (var p in Products)
            {
                var productGroup = new ProductGroup();
                productGroup.Id = p.Id;
                productGroup.Name = p.Name;
                productGroup.Price = p.Price;
                productGroup.Description = p.Description;

                var group = new Group();

                foreach (var g in Groups)
                {
                    if(p.Group == g.Id)
                    {
                        group.Id = g.Id;
                        group.Name = g.Name;
                    }
                }

                productGroup.Group = group;

                ProductGroups.Add(productGroup);
            }
        }




    }
}
