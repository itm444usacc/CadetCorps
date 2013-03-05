using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CadetCorps.Models;

namespace CadetCorps.ViewModels
{
    public class CreateMemberViewModel
    {
        public int Id { get; set; }
        public int Admin { get; set; }
        public int Active { get; set; }
        public int AcceptedTerms { get; set; }
        public int TrainingPlansId { get; set; }
        public List<ServiceInformation> Status { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Comments")]
        public string Comments { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        //public int Photo { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Expired { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }
        }
}