using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Models;
using Backend.Core.Repositories;

namespace Backend.Data.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(RaiseAndReviewDbContext context)
            : base(context)
            { }
    }
}