﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GaripSozluk.Common.ViewModels
{
    public class EntryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Yorum")]
        [Required(ErrorMessage = "Yorum boş bırakılamaz")]
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
