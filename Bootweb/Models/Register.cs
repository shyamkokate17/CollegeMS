using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegePortal.Models
{
    [Table("Registers")]
    public class Register
    {
        [Display(Name ="STUDENT ID :")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int StudentId { get; set; }

        [Required]
        [Display(Name ="STUDENT NAME")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="Only characters are Allowed")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name = "E-MAIL ID")]
        [EmailAddress(ErrorMessage = "{0} is not valid.")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email ID")]
        public string StudentEmail { get; set; }




        #region
        [Required]
        [Display(Name = "DEPARTMENT NAME")]

        public int DptID { get; set; }
        [ForeignKey(nameof(Register.DptID))]

        #endregion

        public Department Dpt { get; set; }

    }
}
