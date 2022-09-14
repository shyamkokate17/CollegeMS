using CollegePortal.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CollegePortal.Models

{
    [Table("Departments")]
    public class Department
    {

        [Required]
        [Display(Name ="Department Name")]
        public string DptName { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int DptID { get; set; }

        #region 

        public ICollection<Register>Registers { get; set; }

        #endregion

    }
}
