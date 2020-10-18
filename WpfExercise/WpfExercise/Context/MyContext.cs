using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfExercise.Models;

namespace WpfExercise.Context
{
     public class MyContext : DbContext
    { 
        public MyContext() : base("WpfExercise") { }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
