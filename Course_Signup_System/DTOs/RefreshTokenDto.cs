﻿namespace Course_Signup_System.DTOs
{
    public class RefreshTokenDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
