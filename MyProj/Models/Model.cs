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
        public DateTime DateEvent { get; set; }
        public string Participiants { get; set; }

    }
    public class Participiant
    {
        public int Event_id { get; set; }
        public int Participiant_id { get; set; }
        
    }

}