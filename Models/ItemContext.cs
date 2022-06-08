using Microsoft.EntityFrameworkCore;
using Scycare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scycare.Apis.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions options) : base(options) { }
        public DbSet<ItemModel> Items { get; set; }
    }
}
