using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Core;
using Backend.Core.Models;
using Backend.Core.Services;

namespace Backend.Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ColorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Color> CreateColor(Color newColor)
        {
            await _unitOfWork.Colors
                .AddAsync(newColor);
            await _unitOfWork.CommitAsync();                    
            
            return newColor;
        }

        public async Task DeleteColor(Color color)
        {
            _unitOfWork.Colors.Remove(color);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Color>> GetAllColors()
        {
            return await _unitOfWork.Colors.GetAllAsync();
        }

        public async Task<Color> GetColorById(int id)
        {
            return await _unitOfWork.Colors.GetByIdAsync(id);
        }

        public async Task UpdateColor(Color colorToBeUpdated, Color color)
        {
            colorToBeUpdated.Name = color.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}