﻿namespace BlogAppMvc.Web.Models
{
    public class UpdateVM
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePicture { get; set; }
        public string Email { get; set; }
    }
}
