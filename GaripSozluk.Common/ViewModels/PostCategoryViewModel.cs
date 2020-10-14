using System.ComponentModel.DataAnnotations;

namespace GaripSozluk.Common.ViewModels
{
    public class PostCategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık boş bırakılamaz")]
        public string Title { get; set; }



    }
}
