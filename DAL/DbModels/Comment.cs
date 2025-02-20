﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ImageId { get; set; }
        public string? CommentText { get; set; }

        //Navigation properties
        public Image Image { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}