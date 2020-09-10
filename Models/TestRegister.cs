using System;
using System.Collections.Generic;

namespace Kiwiland.Models
{
    public partial class TestRegister
    {
        public int TestRegisterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string FavoriteFood { get; set; }
        public string Comment { get; set; }
    }
}
