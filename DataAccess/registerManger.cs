using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Kiwiland.Models;
using Microsoft.Extensions.Logging;

namespace Kiwiland.DataAccess
{
    public class registerManger
    {
        RegisterDbContext regDb = new RegisterDbContext();
        //private readonly ILogger<registerManger> _regManager;

        //public registerManger(ILogger<registerManger> regManager)
        //{
        //    this._regManager=regManager;
        //}
        bool Success = false;

        public IEnumerable<TestRegister> GetAllAccomodation()
        {
            return (IEnumerable<TestRegister>)regDb.TestRegisters.ToList();
        }

        public bool AddtoTestRegister(TestRegister test)
        {
            try
            {
                using (regDb = new RegisterDbContext())
                {

                        regDb.TestRegisters.Add(test);
                        int status = regDb.SaveChanges();
                        if (status > 0)
                        {
                            Success = true;

                        }
                        else
                        {

                        }

                    
                }
                return Success;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
