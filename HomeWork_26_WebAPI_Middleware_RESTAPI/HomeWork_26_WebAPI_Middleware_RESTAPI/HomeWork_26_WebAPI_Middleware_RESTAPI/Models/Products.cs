﻿namespace HomeWork_26_WebAPI_Middleware_RESTAPI.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
