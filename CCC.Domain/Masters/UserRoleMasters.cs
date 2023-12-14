namespace CCC.Domain
{
	public class UserRoleMasters
    {
        public string UserRoleId { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public bool IsActive { get; set; }
    }
    public class UserRoleMasters_Constant : BaseEntity_Constant
    {
        public const string USERROLEID = "UserRoleId";
        public const string USERID = "UserId";
        public const string ROLEID = "RoleId";
        public const string ISACTIVE = "IsActive";

        public const string SPROC_USERROLEMASTERS_UPS = "sproc_UserRoleMasters_ups";
        public const string SPROC_USERROLEMASTERS_SEL = "sproc_UserRoleMasters_sel";
        public const string SPROC_USERROLEMASTERS_LSTALL = "sproc_UserRoleMasters_lstAll";
        public const string SPROC_USERROLEMASTERS_DEL = "sproc_UserRoleMasters_del";
    }
}
