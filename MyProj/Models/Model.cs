using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProj.Models
{
    public enum Gender
    {
        Male, Female
    }
    public enum Role
    {
        Admin, Moderator, Editor, Developer, User
    }

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateReg { get; set; }
        public int Group { get; set; }
        public Role Access { get; set; }
       
       
    }
    public class Event
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime Date_event { get; set; }
        public User Creator { get; set; }
        public string Description { get; set; }


    }
    public class Participiant
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
        
    }
    public class _Message
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }
        public DateTime Date_send { get; set; }
        public string Message { get; set; }
    }
    public class Event_Mesaage
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public DateTime Date_send { get; set; }
        public string Message { get; set; }
    }
}