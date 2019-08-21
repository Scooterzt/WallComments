using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace Wall.Models{
    public class Message{
        public int MessageId {get;set;}
        public string MessageText {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public int UserId {get;set;}
        public List<Comment> MessageComments {get;set;}
        public User Creator {get;set;}

    }



}