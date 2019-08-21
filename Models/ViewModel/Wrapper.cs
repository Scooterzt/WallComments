using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Wall.Models{
    public class Wrapper{
        public User user {get;set;}
        public Message message {get;set;}
        public Comment comment {get;set;}
        public List<Message> allMessages {get;set;}
        public List<Comment> allComments {get;set;}

    }
}