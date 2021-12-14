using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
	public class SeedingService
	{
		private SalesWebMvcContext _context;

		public SeedingService(SalesWebMvcContext context) 
		{
			_context = context;
		}

		public void Seed()
		{
			if (_context.Department.Any() ||
				_context.Seller.Any() ||
				_context.SalesRecord.Any())
			{
				return; // DB ja foi populado
			}

			Department d1 = new Department(1, "Computers");
			Department d2 = new Department(2, "Eletronics");
			Department d3 = new Department(3, "Fashion");
			Department d4 = new Department(4, "Books");

			Seller s1 = new Seller(1, "Bob Now", "Bobnow@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
			Seller s2 = new Seller(2, "Jack Blue", "Jackblue@gmail.com", new DateTime(1988, 1, 01), 3000.0, d2);
			Seller s3 = new Seller(3, "Silver", "Silver@gmail.com", new DateTime(1991, 9, 30), 10000.0, d3);
			Seller s4 = new Seller(4, "Paul", "Paul@gmail.com", new DateTime(2000, 5, 05), 2000.0, d4);

			SalesRecord r1 = new SalesRecord(1, new DateTime(2021, 12, 13), 11000.0, SaleStatus.Billed, s1);
			SalesRecord r2 = new SalesRecord(2, new DateTime(2021, 12, 11), 1000.0, SaleStatus.Canceled, s2);
			SalesRecord r3 = new SalesRecord(3, new DateTime(2021, 12, 2), 2000.0, SaleStatus.Billed, s2);
			SalesRecord r4 = new SalesRecord(4, new DateTime(2021, 12, 4), 4000.0, SaleStatus.Pending, s1);
			SalesRecord r5 = new SalesRecord(5, new DateTime(2021, 12, 16), 11000.0, SaleStatus.Pending, s3);
			SalesRecord r6 = new SalesRecord(6, new DateTime(2021, 12, 23), 200.0, SaleStatus.Billed, s1);

			_context.Department.AddRange(d1, d2, d3, d4);
			_context.Seller.AddRange(s1, s2, s3, s4);
			_context.SalesRecord.AddRange(r1,r2,r3,r4,r5,r6);

			_context.SaveChanges();
		}
	}
}
