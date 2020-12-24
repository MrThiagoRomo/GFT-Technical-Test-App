using GFT_Technical_Test_App.Domain.Models;

namespace GFT_Technical_Test_App.ApplicationService
{
    public interface IOrderAppService
    {
        Post OrderWorkflow(Post post);
    }
}
