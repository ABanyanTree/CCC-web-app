using System.Collections.Generic;

namespace CCC.UI.ViewModels
{
	public class ErrorResponseVM
    {
        public bool IsSuccess { get; set; }
        public List<ErrorModelVM> Errors { get; set; } = new List<ErrorModelVM>();
    }
}
