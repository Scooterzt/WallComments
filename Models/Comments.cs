using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace Wall.Models{
    public class Comment{
        public int CommentId {get;set;}
        public string CommentText {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public int MessageId {get;set;}
        public int UserId {get;set;}
        

    }

}