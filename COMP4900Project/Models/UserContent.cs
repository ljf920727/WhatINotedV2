using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COMP4900Project.Models
{
    public class UserContent
    {
        public UserContent()
        {

        }

        public UserContent(string userid, int contentid)
        {
            UserId = userid;
            ContentId = contentid;
        }

        public int UserContentId { get; set; }

        public string UserId { get; set; }
        public int ContentId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual Content Contents { get; set; }
    }
}