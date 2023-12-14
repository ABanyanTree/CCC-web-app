using System.Collections.Generic;

namespace CCC.Domain.Email
{
	public class EmailSenderEntity : BaseEntity
    {
        public string EmailType { get; set; }
        public string EmailTo { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string HtmlFileName { get; set; }
        public string GroupId { get; set; }
        public string Body { get; set; }

        public List<string> AttachmentFilePath { get; set; }
    }
}
