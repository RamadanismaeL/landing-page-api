using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using landing_page_api.src.data.Maps;
using landing_page_api.src.models;
using Microsoft.EntityFrameworkCore;
/**
** @author Ramadan Ismael
*/
namespace landing_page_api.src.data
{
    public class Contextdb(DbContextOptions<Contextdb> options) : DbContext(options)
    {
        public required DbSet<ClientModel> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            try
            {
                model.ApplyConfiguration(new ClientMap());
                base.OnModelCreating(model);
            }
            catch(Exception error)
            {
                throw new Exception($"Error : {error.Message}");
            }
        }
    }
}