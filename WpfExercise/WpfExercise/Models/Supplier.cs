using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExercise.Models
{
    [Table("Tb_M_Supplier")]
    public class Supplier
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public Supplier() { }
        public Supplier(string name)
        {
            this.Name = name;
        }
    }
}
