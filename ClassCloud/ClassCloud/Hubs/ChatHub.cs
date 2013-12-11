using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using ClassCloud.Models;

namespace ClassCloud.Hubs
{
    public class ChatHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Send(string name, string message, int lecture)
        {

            if (string.IsNullOrWhiteSpace(message))
                return;

            //save the message to the db.
            var Lecture = (from _Lecture in db.Lectures
                           where _Lecture.ID == lecture
                           select _Lecture).FirstOrDefault();
            Lecture.Discussion.Add(new Comment(name, message));
            db.SaveChanges();
            // Call the addNewMessageToPage method to update clients.


            Clients.All.addNewMessageToPage(name, message, lecture);
        }
    }
}

