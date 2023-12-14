namespace CCC.Domain
{
	public class LookupMaster : BaseEntity
    {
        public string LookupId { get; set; }
        public string LookupType { get; set; }
        public string LookupTypeText { get; set; }
        public string LookupName { get; set; }
        public string LookupValue { get; set; }
        public int DisplayOrder { get; set; }
        //public bool IsActive { get; set; }
        //public int TotalCount { get; set; }

    }

    public class LookupMaster_Constant
    {
        public const string LOOKUPID = "LookupId";
        public const string LOOKUPTYPE = "LookupType";
        public const string LOOKUPTYPETEXT = "LookupTypeText";
        public const string LOOKUPNAME = "LookupName";
        public const string LOOKUPVALUE = "LookupValue";
        public const string DISPLAYORDER = "DisplayOrder";
        public const string ISACTIVE = "IsActive";

        public const string SPROC_GETLOOKUPBYTYPE = "sproc_GetLookupByType";
        public const string SPROC_LOOKUPMASTER_UPS = "sproc_LookupMaster_ups";
        public const string SPROC_LOOKUPMASTER_SEL = "sproc_LookupMaster_sel";
        public const string SPROC_LOOKUPMASTER_LSTALL = "sproc_LookupMaster_lstAll";
        public const string SPROC_LOOKUPMASTER_DEL = "sproc_LookupMaster_del";

        public const string SPROC_LOOKUPMASTER_ISLOOKUPVALUEINUSE = "sproc_LookupMaster_IsLookupValueInUse";
        public const string SPROC_LOOKUPMASTER_ISINCOUNTUSE = "sproc_LookupMaster_IsInCountUse";
        public const string SPROC_GETLOOKUPTYPES_LSTALL = "sproc_GetLookupTypes_lstAll";
    }
}
