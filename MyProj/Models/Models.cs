using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProj.Models
{
    public enum Gender
    {
        Male, Female,NoMater
    }
    public enum Role
    {
        Admin, Moderator, Editor, Developer, User
    }

    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }  
        public string Salt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateReg { get; set; }
        public int Group { get; set; }
        public int City { get; set; }
        public Role Access { get; set; }
        public string CookieKey { get; set; }
        public string VerifyCode { get; set; }
        public bool Verification { get; set; }
        public string Email { get; set; }
        public int CountCreateEvent { get; set; }
        public double Rating { get; set; }
       
       
    }
    public class Event
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime Date_event { get; set; }
        public User Creator { get; set; }
        public string Description { get; set; }
        public bool Confirmation { get; set; }
        public bool Completed { get; set; }
        public Gender Gender { get; set; }
        public int InitAge { get; set; }
        public int EndAge { get; set; }
        public int ParticipiantCount { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public float AVGMark { get; set; }
        public int CountMark { get; set; }


    }
    public class Participiant
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
        
    }
    public class Message
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }
        public bool Read { get; set; }
        public DateTime Date_send { get; set; }
        public string TMessage { get; set; }
    }
    public class Event_Mesaage
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public DateTime Date_send { get; set; }
        public string Message { get; set; }
    }
}