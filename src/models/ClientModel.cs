using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
** @author Ramadan Ismael
*/
namespace landing_page_api.src.models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime DateRegister { get; set; }
    }
}