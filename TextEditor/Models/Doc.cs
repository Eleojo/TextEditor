using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextEditor.Models
{
    public class Doc
    {
        public string Id { get; set; }    
        public string Title { get; set; }
        public string Content { get; set; }
        [Required] 
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }

    }
}
