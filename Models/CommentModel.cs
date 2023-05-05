using System;
using System.ComponentModel.DataAnnotations;

namespace ChatGPTModeration
{
    public class CommentModel
    {
        [Key]
        public Guid CommnetId { get; set; }
        public string Comment { get; set; }        
        public bool Approved { get; set; }        
        public string ChatGPTResults { get; set; }
    }
}
