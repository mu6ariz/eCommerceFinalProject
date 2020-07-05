using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elazone.UI.Areas.Admin.Models
{
    public class AdminSocialLinkModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string CssClass { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
