using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wall.Models;
namespace Wall.Controllers{
    public class WallController : Controller{
        private MyContext dbContext;//add this whole block
        public WallController(MyContext context){
            dbContext = context;
        }
        [HttpGet("wall")]
        public IActionResult DisplayWall(){
            if(HttpContext.Session.GetInt32("userid") == null){
                return RedirectToAction("Index", "Home");
            }
            int userIdsession = (int)HttpContext.Session.GetInt32("userid");
            User loggedUser = dbContext.Users.FirstOrDefault(u => u.UserId == userIdsession);
            List<Message> allMessages = dbContext.Messages.Include(comm=>comm.MessageComments).ToList();
            List<Comment> allComment = dbContext.Comments.ToList(); 
            Wrapper newwrap = new Wrapper();
            newwrap.user = loggedUser;
            newwrap.allComments = allComment;
            newwrap.allMessages = allMessages;
            return View("Wall", newwrap);
        }
        [HttpPost("createmessage/{id}")]
        public IActionResult CreatedMessage(int id, Wrapper newWrapper){
            newWrapper.message.UserId = id;
            dbContext.Messages.Add(newWrapper.message);
            dbContext.SaveChanges();
            return RedirectToAction("DisplayWall", "Wall");
        }
        [HttpPost("addcomment/{id}")]
        public IActionResult AddComment(int id, Wrapper newWrapper){
            int userIdsession = (int)HttpContext.Session.GetInt32("userid");
            newWrapper.comment.UserId = userIdsession;
            newWrapper.comment.MessageId = id;
            dbContext.Comments.Add(newWrapper.comment);
            dbContext.SaveChanges();
            return RedirectToAction("DisplayWall", "Wall");
        }
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id){
            Comment delComment = dbContext.Comments.FirstOrDefault(c=>c.CommentId == id);
            dbContext.Comments.Remove(delComment);
            dbContext.SaveChanges();
            return RedirectToAction ("DisplayWall", "Wall");
        }
    }
}