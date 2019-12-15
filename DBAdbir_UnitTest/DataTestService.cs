using System;
using System.Collections.Generic;
using System.Text;
using DBAdbir.Models;

namespace DBAdbir_UnitTest
{
    class DataTestService
    {
        public static List<Category> GetTestCategories()
        {
            var sessions = new List<Category>
            {
                new Category()
                {
                    CategoryId = 1,
                    Name = "Tekstiler"
                },
                new Category()
                {
                    CategoryId = 2,
                    Name = "Biler"
                }
            };
            return sessions;
        }

        public DataTestService()
        { 
        }
    }
}
