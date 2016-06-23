using Bursify.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Bursify.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly BursifyDbContext _context;

        public InitialHostDbBuilder(BursifyDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
