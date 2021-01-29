using DeliverIT.Domain;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;

namespace DeliverIT.Data
{
    public class DatabaseInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.ContasPagar.Any())
            {
                return;
            }

            var contasPagar = new List<ContaPagar>
            {
                new ContaPagar {
                    Nome = "Conta 1",
                    DataPagamento = new DateTime(2021, 02, 20),
                    DataVencimento = new DateTime(2021, 02, 20),
                    ValorOriginal = 120.00m                    
                },
                new ContaPagar {
                    Nome = "Conta 2",
                    DataPagamento = new DateTime(2021, 03, 15),
                    DataVencimento = new DateTime(2021, 03, 10),
                    ValorOriginal = 70.00m
                },
                new ContaPagar {
                    Nome = "Conta 3",
                    DataPagamento = new DateTime(2021, 05, 12),
                    DataVencimento = new DateTime(2021, 05, 10),
                    ValorOriginal = 250.00m
                },
                new ContaPagar {
                    Nome = "Conta 4",
                    DataPagamento = new DateTime(2021, 05, 25),
                    DataVencimento = new DateTime(2021, 05, 22),
                    ValorOriginal = 50.00m
                },
                new ContaPagar {
                    Nome = "Conta 5",
                    DataPagamento = new DateTime(2021, 06, 10),
                    DataVencimento = new DateTime(2021, 05, 25),
                    ValorOriginal = 50.00m
                }
            };

            context.ContasPagar.AddRange(contasPagar);
            context.SaveChanges(); 
        }
    }
}
