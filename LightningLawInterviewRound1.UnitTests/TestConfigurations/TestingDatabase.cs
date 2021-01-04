using LightningLawInterviewRound1.Data;
using LightningLawInterviewRound1.Models.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightningLawInterviewRound1.UnitTests.TestConfigurations
{
    /// <summary>
    /// This class builds a new Sqlite server into memory and feeds it the DbContext needed to run the tests.
    /// </summary>
    public class TestingDatabase : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly DbContextWithSeedDataForTesting _db;

        protected readonly IRecipe _recipe;
        protected readonly IIngredient _ingredient;


        public TestingDatabase()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new DbContextWithSeedDataForTesting(new DbContextOptionsBuilder<LightningLawInterviewRound1Context>()
                .UseSqlite(_connection)
                .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}
