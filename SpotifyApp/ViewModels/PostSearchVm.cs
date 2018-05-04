using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SpotifyApp.Utils;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyApp.ViewModels
{
    public class SpotifyPostSearchVm
    {
        [Required, Display(Name = "Search String")]
        public string SearchString { get; set; }

        [Required, Display(Name = "Search Option")]
        [EnumDataType(typeof(Enums.SearchType))]
        public Enums.SearchType searchType { get; set; }
    }
}
