using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarRentalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Models
{
    public class SeedData
    {
    }
}
public static class SeedData
{

    public static void EnsurePopulated(IApplicationBuilder app)
    {
        StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        if (!context.Cars.Any())
        {
            context.Cars.AddRange(
                new Car
                {
                    Name = "Honda 1",
                    Description = "A Two door Car",
                    Category = "Sedan",
                    Price = 275
                },
                new Car
                {
                    Name = "BMW 1",
                    Description = "Sport and suitable for long rides",
                    Category = "SUV",
                    Price = 48.95m
                },
                new Car
                {
                    Name = "Cheverlot 1",
                    Description = "Fancy Car for Fancy Ocassions",
                    Category = "Muscle",
                    Price = 19.50m
                },
                new Car
                {
                    Name = "Hyundai 1",
                    Description = "Best Ride for you to go to work",
                    Category = "Sedan",
                    Price = 34.95m
                },
                new Car
                {
                    Name = "Benz 1",
                    Description = "Luxury Car for You",
                    Category = "SUV",
                    Price = 79500
                },
                new Car
                {
                    Name = "Audi 1",
                    Description = "If You Love Speed, this is your car",
                    Category = "Muscle",
                    Price = 16
                },
                new Car
                {
                    Name = "Mitsubishi 1",
                    Description = "Cheap Car for inner city rides",
                    Category = "Sedan",
                    Price = 29.95m
                },
                new Car
                {
                    Name = "Range Rover 1",
                    Description = "A Beast For journeys through Deserts and Jungles",
                    Category = "SUV",
                    Price = 75
                },
                new Car
                {
                    Name = "Tesla 1",
                    Description = "Wanna travel between cities without problem? This is The right choice",
                    Category = "Sedan",
                    Price = 1200
                }
            );
            context.SaveChanges();
        }
    }
}


