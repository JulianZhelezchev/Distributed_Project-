using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
 public class BaseEntity
    {
       [Key]
        public int  Id { get; set; }

        public int CreatedBy { get; set; } // id of the creator of the record
        public DateTime? CreatedOn { get; set; } // date of creation/?-not necessary to fill in  field/

        public int UpdatedBy { get; set; } // id of the last person who updates the record/?-not necessary to fill in  field/
        public DateTime? UpdatedOn { get; set; } // data of edit
    }
}
