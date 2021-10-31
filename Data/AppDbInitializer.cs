using e_organic.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                /*context.Database.EnsureCreated();*/
                context.Database.EnsureCreated();

                //Vendor
                if (!context.Vendors.Any())
                {
                    context.Vendors.AddRange(new List<Vendor>()
                    {
                        new Vendor()
                        {
                            Name = "Cinema 1",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema",
                            Address="kathamndu"
                        },
                        new Vendor()
                        {
                            Name = "Cinema 2",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema",
                            Address="kathamndu"
                        },
                        new Vendor()
                        {
                            Name = "Cinema 3",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema",
                            Address="kathamndu"
                        },
                        new Vendor()
                        {
                            Name = "Cinema 4",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema",
                            Address="kathamndu"

                        },
                        new Vendor()
                        {
                            Name = "Cinema 5",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema",
                            Address="kathamndu"
                        },
                    }); ;
                    context.SaveChanges();
                }
                //Product
                if (!context.Products.Any())
                {

                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            ProductCatagory=ProductCatagory.Dairy,
                            VendorId=1,
                           


                        },
                        new Product()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            ProductCatagory=ProductCatagory.Dairy,
                            VendorId=2,
                        },
                        new Product()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",

                             ProductCatagory=ProductCatagory.Dairy,
                            VendorId=3,
                        },
                        new Product()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                              ProductCatagory=ProductCatagory.DryFood,
                            VendorId=3,
                        },
                        new Product()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                              ProductCatagory=ProductCatagory.Fruits,
                            VendorId=3,
                        },
                        new Product()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                               ProductCatagory=ProductCatagory.Vegitables,
                            VendorId=3,
                        }
                    }); ; ;
                    context.SaveChanges();

                }
            }
        }
    }
}
