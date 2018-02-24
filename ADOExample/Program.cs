﻿using System;
using System.Data;
using System.Data.SqlClient;
using ADOExample.DataAccess;

namespace ADOExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLetter = Console.ReadLine();

            var invoiceQuery = new InvoiceQuery();
            var invoices = invoiceQuery.GetInvoiceByTrackFirstLetter(firstLetter);

            foreach (var invoice in invoices)
            {
                Console.WriteLine($"Invoice Id {invoice.InvoiceId} was shipped to {invoice.BillingAddress}.");
            }

            Console.ReadLine();

        }
    }
}