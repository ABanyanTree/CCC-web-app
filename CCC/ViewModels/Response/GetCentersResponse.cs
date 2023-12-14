namespace CCC.UI.ViewModels
{
	public class GetCentersResponse : BaseResponse
    {
        public string CenterId { get; set; }
        public string CenterName { get; set; }
        public string CenterAddress { get; set; }
        public string Description { get; set; }
    }
}
