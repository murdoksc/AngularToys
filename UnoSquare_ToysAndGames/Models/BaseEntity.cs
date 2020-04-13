using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UnoSquare_ToysAndGames.Models
{
    public class BaseEntity : IEntity
    {
        //base entity for repository pattern
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
