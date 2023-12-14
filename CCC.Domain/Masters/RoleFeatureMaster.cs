namespace CCC.Domain
{
	public class RoleFeatureMaster : BaseEntity
    {
        public string RoleFeatureId { get; set; }
        public string RoleId { get; set; }
        public string FeatureId { get; set; }
        public string IsAdd { get; set; }
        public string IsEdit { get; set; }
        public string IsDelete { get; set; }
        public string IsView { get; set; }
    }
}
