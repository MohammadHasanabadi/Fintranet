using Account.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Contracts
{
    public abstract class IAccountContextDb
    {
       public IMongoCollection<User> Users { get; set; }
    }
}
