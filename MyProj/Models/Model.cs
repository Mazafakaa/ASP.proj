using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProj.Models
{
    public enum Role
    {
        Admin, Moderator, Editor, Developer, User
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime DateReg { get; set; }
        public string Group { get; set; }
        public string Interes { get; set; }
        public Role Access { get; set; }
       
       
    }
    public class Event
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime Date_event { get; set; }
        public int Creator_id { get; set; }
        public string Description { get; set; }


    }
    public class Participiant
    {
        public int Event_id { get; set; }
        public int Participiant_id { get; set; }
        
    }
    public class Message
    {
        public int Id { get; set; }
        public int Sender_id { get; set; }
        public int Recipient_id { get; set; }
        public DateTime Date_send { get; set; }
        public string Message { get;; set; }
    }
    public class Event_Mesaage
    {
        public int Id { get; set; }
        public int Sender_id { get; set; }
        public DateTime Date_send { get; set; }
        public string Message { get; set; }
    }

}