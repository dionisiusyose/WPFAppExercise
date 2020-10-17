using WpfExercise.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExercise.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("WpfExercise") { }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
