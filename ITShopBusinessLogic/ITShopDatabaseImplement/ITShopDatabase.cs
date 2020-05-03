﻿using ITShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;


namespace ITShopDatabaseImplement
{
    public class ITShopDatabase:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0S6SE5G\SQLEXPRESS;Initial Catalog=ITShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ITShopDatebase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<ProductComponent> ProductComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Request> Requests{ get; set; }
        public virtual DbSet<RequestComponent> RequestComponents { get; set; }
    }
}
