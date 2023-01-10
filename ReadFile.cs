// Copyright Skillage I.T. 
// This file is Skillage I.T. software and is made available under license. 
// This software is developed by: Joshua Panettieri  
// Date: 06 October 2022   Time: 12.00
// File Name: TTF_StockManagement.cs  Version: 1-0 
using System.ComponentModel;
using System.Text;

namespace TTF_StockManagement
{
    /// <summary>
    /// Class created to read the csv file and create a list
    /// </summary>
    public class ReadFile
    {
  /// <summary>
  /// This method will read the csv file and return the entire contents
  /// </summary>
  /// <returns>List of products in the csv file</returns>
        public static BindingList<Product> ReadCSV()
        {
            var lines = File.ReadAllLines("TTFproducts.csv");
            lines = lines.Skip(1).ToArray();
            var list = new BindingList<Product>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 6)
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