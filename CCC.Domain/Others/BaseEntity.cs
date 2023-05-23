using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class BaseEntity
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public string SortExp { get; set; }
        public string sort { get; set; }
        public string sortdir { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatorName { get; set; }
        public string ModifiorName { get; set; }
        public bool IsSuccess { get; set; }
        public string RequesterUserId { get; set; }
        public string LastModifiedDateDisplay { get; set; }
        public bool? IsActive { get; set; }
    }

    public class BaseEntity_Constant
    {
        public const string PAGEINDEX = "PageIndex";
        public const string PAGESIZE = "PageSize";
        public const string SORTEXP = "SortExp";
        public const string CREATEDBY = "CreatedBy";
        public const string MODIFIEDBY = "ModifiedBy";
        public const string CREATEDDATE = "CreatedDate";
        public const string MODIFIEDDATE = "ModifiedDate";
        public const string ISACTIVE = "IsActive";
        public const string REQUESTERUSERID = "RequesterUserId";
        

    }
}
