using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartEntity
{
    [Table("CustomExceptionHandler")]
    public class CustomExceptionHandler
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExceptionId { get; set; }
        [Required]
        public string ExceptionMessage { get; set; }
        [Required]
        public string TraceException { get; set; }
        [Required]
        public string ControllerName { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public DateTime ExceptionLogTime { get; set; }
    }
}
