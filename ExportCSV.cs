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
    internal class ExportCSV
    {
        public bool Export(DataGridView dgv)
        {
            bool exported = false;

            BindingList<string> lines = new BindingList<string>();
            //Header
            DataGridViewColumnCollection header = dgv.Columns;
            bool firstDone = false;
            StringBuilder headerLine = new StringBuilder();
            foreach (DataGridViewColumn c in header)
            {
                if (!firstDone)
                {
                    headerLine.Append(c.DataPropertyName);
                    firstDone = true;
                }
                else
                {
                    headerLine.Append("," + c.DataPropertyName);
                }
            }
            lines.Add(headerLine.ToString());

            foreach (DataGridViewRow r in dgv.Rows)
            {
                StringBuilder dataline = new StringBuilder();
                firstDone = false;
                foreach (DataGridViewCell cell in r.Cells)
                {
                    if (!firstDone)
                    {
                        dataline.Append(cell.Value.ToString());
                        firstDone = true;
                    }
                    else
                    {
                        dataline.Append("," + cell.Value.ToString());
                    }
                }
                lines.Add(dataline.ToString());

            }

            string file = "TTFproducts.csv";
            System.IO.File.WriteAllLines(file, lines);

            return exported;
        }
    }
}
