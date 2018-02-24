using System;
using System.Data.SqlClient;

namespace ADOExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLetter = Console.ReadLine();

            using (var connection = new SqlConnection("Server=(local);Database=Chinook;Trusted_Connection=True;"))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = $@"select  x.invoiceid,BillingAddress
                                from invoice i
	                                join InvoiceLine x on x.InvoiceId = i.InvoiceId
                                where exists (select TrackId from Track where Name like '{firstLetter}%' and TrackId = x.TrackId)";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var invoiceId = reader.GetInt32(0);
                    var billingAddress = reader["BillingAddress"].ToString();

                    Console.WriteLine($"Invoice {invoiceId} is going to {billingAddress}");
                }
            }

            Console.ReadLine();

        }
    }
}