﻿namespace Shipping.DTO
{
    public class GetAllEmployee
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public string Branch { get; set; }
    }
}
