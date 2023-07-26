// See https://aka.ms/new-console-template for more information

using Insight.Database;
using Microsoft.Data.SqlClient;

using SqlConnection connection = new(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;");
Insight.Database.Providers.MsSqlClient.SqlInsightDbProvider.RegisterProvider();

Beer beer = new() { ID=1, Type = "ipa", Description = "Sly Fox 113" };
IBeerRepositoryDb repo = connection.As<IBeerRepositoryDb>();

repo.InsertBeer(beer);
IList<Beer> beerList = repo.GetBeerByType("ipa");
repo.InsertBeerTable(beerList);

Console.ReadLine();
