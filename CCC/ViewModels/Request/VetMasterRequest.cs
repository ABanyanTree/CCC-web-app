using System.ComponentModel.DataAnnotations;

namespace CCC.UI.ViewModels
{
	public class VetMasterRequest : BaseRequestVM
    {
        public string VetId { get; set; }

        [RegularExpression(@"^[a-zA-Z ']*$", ErrorMessage = "Please enter valid vet name.")]
        [Required(ErrorMessage = "Please enter vet name")]
        //[Remote("IsVetNameInUse", "VetMaster", ErrorMessage = "vet name is already exists.", HttpMethod = "GET")]
        public string VetName { get; set; }

        [Required(ErrorMessage = "Please enter registration no")]
        public string RegistrationNo { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Please enter valid email address")]
        [Required(ErrorMessage = "Please enter email address")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter valid mobile no")]
        [Required(ErrorMessage = "Please enter mobile no")]
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
