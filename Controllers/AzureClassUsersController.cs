using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using odata_error.Models;
using System.Linq;


namespace odata_error
{
    public class AzureClassUsersController : ODataController
    {
        private TestDbContext dbContext;

        public AzureClassUsersController(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [EnableQuery]
        public IQueryable<AzureClassUser> Get() => dbContext.AzureClassUsers.AsQueryable().AsNoTracking();

    }


}
