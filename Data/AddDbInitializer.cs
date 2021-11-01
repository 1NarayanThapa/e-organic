using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace e_organic.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<AddDbContext>();
                /*context.Database.EnsureCreated();*/
                context.Database.EnsureCreated();

                //Vendor
                if (!context.Vendors.Any()) {
                    context.Vendors.AddRange(new List<Vendor>()
                    {
                        new Vendor()
                        {
                            name = "Vendor 1",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Discription = "This is the description of the first cinema",
                            Address="kathamndu"
                        },
                        new Vendor()
                        {
                            name = "Vendor 2",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Discription = "This is the description of the first cinema",
                            Address="kathamndu"
                        },
                        new Vendor()
                        {
                            name = "Vendor 3",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Discription = "This is the description of the first cinema",
                            Address="kathamndu"
                        },
                        new Vendor()
                        {
                            name = "Vendor 4",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Discription = "This is the description of the first cinema",
                            Address="kathamndu"

                        },
                        new Vendor()
                        {
                            name = "Vendor 5",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Discription = "This is the description of the first cinema",
                            Address="kathamndu"
                        },
                    });
                    context.SaveChanges();
                }
                //Product
                if (!context.Products.Any()) {

                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            name = "Life",
                            Discription = "This is the Life movie description",
                            price = 39.50,
                            imageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            ProductCategory=ProductCategory.Dairy,
                            VendorId=1,



                        },
                        new Product()
                        {
                            name = "The Shawshank Redemption",
                            Discription = "This is the Shawshank Redemption description",
                            price = 29.50,
                            imageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            ProductCategory=ProductCategory.Dairy,
                            VendorId=2,
                        },
                        new Product()
                        {
                            name = "Ghost",
                            Discription = "This is the Ghost movie description",
                            price = 39.50, imageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg", ProductCategory = ProductCategory.Dairy,
                            VendorId=3,
                        },
                        new Product()
                        {
                            name = "Race",
                            Discription = "This is the Race movie description",
                            price = 39.50,
                            imageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                              ProductCategory=ProductCategory.Vegetables,
                            VendorId=3,
                        },
                        new Product()
                        {
                            name = "Scoob",
                            Discription = "This is the Scoob movie description",
                            price = 39.50,
                            imageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                              ProductCategory=ProductCategory.Fruits,
                            VendorId=3,
                        },
                        new Product()
                        {
                            name = "Cold Soles",
                            Discription = "This is the Cold Soles movie description",
                            price = 39.50,
                            imageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                               ProductCategory=ProductCategory.Dairy,
                            VendorId=3,
                        }
                    });
                    context.SaveChanges();

                }
            }
        }
    }
}



