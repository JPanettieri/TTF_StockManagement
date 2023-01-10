// Copyright Skillage I.T. 
// This file is Skillage I.T. software and is made available under license. 
// This software is developed by: Joshua Panettieri  
// Date: 06 October 2022   Time: 12.00
// File Name: TTF_StockManagement.cs  Version: 1-0 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTF_StockManagement
{
    internal class FilteredResults
    {
        public static List<Product> AllInStock(bool allInStockSelcted)
        {
            var lines = File.ReadAllLines("TTFproducts.csv");
            lines = lines.Skip(1).ToArray();
            var list = new List<Product>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (int.Parse(values[3]) > 0)
                {
                    var product = new Product()
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1].ToLower(),
                        Description = values[2].ToLower(),
                        Stock = int.Parse(values[3]),
                        Price = double.Parse(values[4]),
                        Supplier = values[5].ToLower(),
                    };
                    list.Add(product);
                }
            }
            return list;
        }

        public static List<Product> AllOutStock(bool allOutStockSelcted)
        {
            var lines = File.ReadAllLines("TTFproducts.csv");
            lines = lines.Skip(1).ToArray();
            var list = new List<Product>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (int.Parse(values[3]) == 0)
                {
                    var product = new Product()
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1].ToLower(),
                        Description = values[2].ToLower(),
                        Stock = int.Parse(values[3]),
                        Price = double.Parse(values[4]),
                        Supplier = values[5].ToLower(),
                    };
                    list.Add(product);
                }
            }
            return list;
        }

        public static List<Product>? SearchId(string textSearched)
        {
            var list = ReadFile.ReadCSV();
            //Find the centre of the list and start searching, depending on its value
            var min = 0;
            var max = list.Count - 1;
            var mid = (max - min) / 2;
            int searchId = int.Parse(textSearched);

            while (list[mid].Id < searchId)
            {
                if (mid < max)
                {
                    mid += 1;
                }
                else break;
            }
            while (list[mid].Id > searchId)
            {
                if (mid > min)
                {
                    mid -= 1;
                }
                else break;
            }
            if (list[mid].Id == searchId)
            {
                var idSearched = new List<Product>() { list[mid] };
                return idSearched;
            }
            else return null;
        }

        public static List<Product> SearchName(string textSearched)
        {
            var lines = File.ReadAllLines("TTFproducts.csv");
            lines = lines.Skip(1).ToArray();
            var list = new List<Product>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values[1].Contains(textSearched))
                {
                    var product = new Product()
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1].ToLower(),
                        Description = values[2].ToLower(),
                        Stock = int.Parse(values[3]),
                        Price = double.Parse(values[4]),
                        Supplier = values[5].ToLower(),
                    };
                    list.Add(product);
                }
            }
            return list;
        }

        public static List<Product> SearchDescription(string textSearched)
        {
            var lines = File.ReadAllLines("TTFproducts.csv");
            lines = lines.Skip(1).ToArray();
            var list = new List<Product>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values[2].Contains(textSearched))
                {
                    var product = new Product()
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1].ToLower(),
                        Description = values[2].ToLower(),
                        Stock = int.Parse(values[3]),
                        Price = double.Parse(values[4]),
                        Supplier = values[5].ToLower(),
                    };
                    list.Add(product);
                }
            }
            return list;
        }

        public static List<Product> SearchStock(string textSearched)
        {
            var lines = File.ReadAllLines("TTFproducts.csv");
            lines = lines.Skip(1).ToArray();
            var list = new List<Product>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values[3].Contains(textSearched))
                {
                    var product = new Product()
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1].ToLower(),
                        Description = values[2].ToLower(),
                        Stock = int.Parse(values[3]),
                        Price = double.Parse(values[4]),
                        Supplier = values[5].ToLower(),
                    };
                    list.Add(product);
                }
            }
            return list;
        }

        public static List<Product> SearchPrice(string textSearched)
        {
            var lines = File.ReadAllLines("TTFproducts.csv");
            lines = lines.Skip(1).ToArray();
            var list = new List<Product>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values[4].Contains(textSearched))
                {
                    var product = new Product()
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1].ToLower(),
                        Description = values[2].ToLower(),
                        Stock = int.Parse(values[3]),
                        Price = double.Parse(values[4]),
                        Supplier = values[5].ToLower(),
                    };
                    list.Add(product);
                }
            }
            return list;
        }

        public static List<Product> SearchSupplier(string textSearched)
        {
            var lines = File.ReadAllLines("TTFproducts.csv");
            lines = lines.Skip(1).ToArray();
            var list = new List<Product>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values[5].Contains(textSearched))
                {
                    var product = new Product()
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1].ToLower(),
                        Description = values[2].ToLower(),
                        Stock = int.Parse(values[3]),
                        Price = double.Parse(values[4]),
                        Supplier = values[5].ToLower(),
                    };
                    list.Add(product);
                }
            }
            return list;
        }

    }
}
