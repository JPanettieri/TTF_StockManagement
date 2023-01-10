// Copyright Skillage I.T. 
// This file is Skillage I.T. software and is made available under license. 
// This software is developed by: Joshua Panettieri  
// Date: 06 October 2022   Time: 12.00
// File Name: TTF_StockManagement.cs  Version: 1-0 
namespace TTF_StockManagement
{
    /// <summary>
    /// Add a Class for the creation of products lists
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string? Supplier { get; set; }
    }
}