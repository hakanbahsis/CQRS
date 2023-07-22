﻿namespace WebUI.CQRSPattern.Results
{
    public class GetProductQueryResult
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
    }
}
