using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Core.Models;

namespace Backend.Core.Services
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetAllColors();
        Task<Color> GetColorById(int id);
        Task<Color> CreateColor(Color newColor);
        Task UpdateColor(Color colorToBeUpdated, Color color);
        Task DeleteColor(Color color);
    }
}