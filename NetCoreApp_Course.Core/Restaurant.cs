using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp_Course.Core
{


    public class Restaurant
    {
        public int Id { get; set; }

        //validazione a livello di model
        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(80)]
        public string Location { get; set; }
        public CusineType CusineType { get; set; }


    }
}
