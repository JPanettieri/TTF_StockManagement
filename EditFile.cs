// Copyright Skillage I.T. 
// This file is Skillage I.T. software and is made available under license. 
// This software is developed by: Joshua Panettieri  
// Date: 06 October 2022   Time: 12.00
// File Name: TTF_StockManagement.cs  Version: 1-0 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTF_StockManagement
{
    /// <summary>
    /// Class to remove an Item from the list of Products
    /// </summary>
    internal class EditFile
    {
        /// <summary>
        /// Checks which text box has information in it and then removes the product accordingly. 
        /// </summary>
        /// <returns>New list with the specified product removed</returns>
        public static BindingList<Product> RemoveProduct(string idTextSearched, string productSearched, string productDescriptionSearched, string productStockSearched, string priceTextSearched, string supplierTextSearched)
        {
            var list = ReadFile.ReadCSV();
            var listLine = 0;
            string stringStock = list[listLine].Stock.ToString();
            string stringId = list[listLine].Id.ToString();
            string stringPrice = list[listLine].Price.ToString();
            while (listLine < list.Count)
                if (list[listLine].Name == productSearched || list[listLine].Description == productDescriptionSearched || stringId == idTextSearched || stringStock == productStockSearched || stringPrice == priceTextSearched || list[listLine].Supplier == supplierTextSearched)
                {
                    list.Remove(list[listLine]);
                    listLine -= 1;
                    stringStock = list[listLine].Stock.ToString();
                    stringId = list[listLine].Id.ToString();
                    stringPrice = list[listLine].Price.ToString();
                }
                else
                {
                    listLine += 1;
                    if (listLine < list.Count)
                    {
                        stringStock = list[listLine].Stock.ToString();
                        stringId = list[listLine].Id.ToString();
                        stringPrice = list[listLine].Price.ToString();
                    }
                }
            //Update the list and csv
            var newList = list;
            File.WriteAllText("TTFproducts.csv", "ID,Product Name,Price\n");
            foreach (var p in newList)
            {
                File.AppendAllText("TTFproducts.csv", $"{p.Id},{p.Name}, {p.Description}, {p.Stock}, {p.Price}, {p.Supplier}\n");
            }
            return newList;
        }
        /// <summary>
        /// Calculates what the next ID should be an adds product to list. 
        /// </summary>
        /// <returns></returns>
        public static BindingList<Product> AddProduct(string productSearched, string productDescriptionSearched, string productStockSearched, string priceTextSearched, string supplierTextSearched)
        {
            var list = ReadFile.ReadCSV();
            int newId = FindId();
            string newProductName = productSearched;
            string newProductDescription = productDescriptionSearched;
            string newProductStock = productStockSearched;
            string newPrice = priceTextSearched;
            string newProductSupplier = supplierTextSearched;
            var newProductList = new BindingList<Product>();
            var newProduct = new Product()
            {
                Id = newId,
                Name = newProductName.ToLower(),
                Description = newProductDescription.ToLower(),
                Stock = int.Parse(newProductStock),
                Price = double.Parse(newPrice),
                Supplier = newProductSupplier.ToLower(),
            };
            newProductList.Add(newProduct);
            foreach (var p in newProductList)
            {
                File.AppendAllText("TTFproducts.csv", $"{p.Id},{p.Name}, {p.Description}, {p.Stock}, {p.Price}, {p.Supplier}\n");
            }
            return newProductList;
        }

        public static int FindId()
        {
            var list = ReadFile.ReadCSV();
            int findSize = 0;
            int newId = 100;
            if (list.Count > 0)
            {
                findSize = list.Count - 1;
                var findId = list[findSize].Id;
                newId = findId + 1;
                return newId;
            }
            else
                return newId;
        }
    }

}
