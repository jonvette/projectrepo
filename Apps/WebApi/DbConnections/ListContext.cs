using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DbConnections
{
    public class ListContext: DbContext
    {
        public ListContext (DbContextOptions<ListContext> options)
            : base(options)
        {
        }

    public DbSet<ListItem> ListItems { get; set; }
}
    }

