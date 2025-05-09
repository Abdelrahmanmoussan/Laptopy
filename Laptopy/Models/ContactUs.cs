﻿using System.ComponentModel.DataAnnotations;

namespace Laptopy.Models
{
    public class ContactUs
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Message { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }
}
