using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPostgreSQL.Models
{
    public class User  
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;  // null forgiving оператор. Гарантирует, что значение не будет null во время выполнения, даже если сейчас это не видно
        public int Age { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>(); //Навигационное свойство

        
    }
}
