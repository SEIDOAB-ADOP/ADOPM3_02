using System;
using System.Drawing;

namespace ADOPM3_02_21
{	
	public class Stock
	{
		public string Symbol {get; set;}
		decimal price;
		public Stock(string symbol) { this.Symbol = symbol; }
		public event EventHandler<(decimal, decimal)> PriceChanged; //Broadcaster event
		protected virtual void OnPriceChanged((decimal, decimal) e) => PriceChanged?.Invoke(this,e);

		public decimal Price
		{
			get { return price; }
			set
			{
				if (price == value) return; 
				decimal oldPrice = price;
				price = value;

				OnPriceChanged((oldPrice, price)); // Call the virtual Method
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			var stock = new Stock("MSFT");
			stock.PriceChanged += ReportPriceChange;
			stock.Price = 123;
			stock.Price = 456;
		}
		static void ReportPriceChange(object sender, (decimal oldPrice, decimal newPrice) e) //Subscriber eventhandler implementation
		{
			var s = sender as Stock;
			Console.WriteLine($"{s.Symbol}: Price changed from {e.oldPrice} to {e.newPrice}");
		}
	}

	//Exercise:
	//1.	With this pattern, add two events that fires if the price increased/decreased more than 20%. 
	//		These events should fire in addition to PriceChanged event
	//2.	Add yet another event that loggs the price change in a file using streams
}
