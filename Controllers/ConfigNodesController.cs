using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using odata_error.Models;
using System.Linq;


namespace odata_error
{
    public class ConfigNodesController : ODataController
    {
        private TestDbContext dbContext;

        public ConfigNodesController(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [EnableQuery]
        public IQueryable<ConfigNode> Get() => dbContext.ConfigNodes.AsQueryable().AsNoTracking();

    }


}
