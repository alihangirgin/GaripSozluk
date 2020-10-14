using System.ComponentModel.DataAnnotations;

namespace GaripSozluk.Common.ViewModels
{
    public class PostViewModel
    {
        [Display(Name = "Kategori")]
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık boş bırakılamaz")]
        public string Title { get; set; }

        public int UserId { get; set; }

        public int ClickCount { get; set; }

    }
}
