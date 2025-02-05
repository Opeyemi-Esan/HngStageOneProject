using HngStageOneProject.Models;

namespace HngStageOneProject.Services
{
    public interface INumberService
    {
        Task<ApiResponse<NumberProperties>> ClassifyNumber(int number);
    }
}
