using Kolokwium_02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_02.DTOs.Responses
{
    public class LabelResponse
    {
        [Required]
        public int IdMusicLabel { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public List<Album> Albums { get; set; }


    }
}
