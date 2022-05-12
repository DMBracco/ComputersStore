using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ComputersStore.Models {

    public static class SeedData {

        public static void EnsurePopulated(IApplicationBuilder app) {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Product {
                        Name = "MSI NVIDIA GeForce 210", Description = "Видеочипсет NVIDIA GeForce 210; Частота графического процессора 460 МГц",
                        Category = "Видеокарты", Price = 275
                    },
                    new Product {
                        Name = "ASUS NVIDIA GeForce RTX 3090",
                        Description = "Видеочипсет NVIDIA GeForce RTX 3090; Частота графического процессора 1695 МГц (1725 МГц, в режиме Boost)",
                        Category = "Видеокарты", Price = 48.95m
                    },
                    new Product {
                        Name = "AMD A6 9500E",
                        Description = "Ядро Excavator; Гнездо процессора SocketAM4",
                        Category = "Процессоры", Price = 19.50m
                    },
                    new Product {
                        Name = "Intel Core i9 10980XE",
                        Description = "Ядро Cascade Lake; Гнездо процессора LGA 2066",
                        Category = "Процессоры", Price = 34.95m
                    },
                    new Product {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Процессоры", Price = 79500
                    },
                    new Product {
                        Name = "GIGABYTE B450M S2H",
                        Description = "Гнездо процессора SocketAM4 Чипсет AMD B450",
                        Category = "Материнские платы", Price = 16
                    },
                    new Product {
                        Name = "GIGABYTE Z690 GAMING X DDR4",
                        Description = "Гнездо процессора LGA 1700 Чипсет Intel Z690",
                        Category = "Материнские платы", Price = 29.95m
                    },
                    new Product {
                        Name = "ASUS TUF GAMING B550-PLUS",
                        Description = "Гнездо процессора SocketAM4 Чипсет AMD B550",
                        Category = "Материнские платы", Price = 75
                    },
                    new Product {
                        Name = " GIGABYTE H410M S2H",
                        Description = "Гнездо процессора LGA 1200 Чипсет Intel H510",
                        Category = "Материнские платы", Price = 1200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
