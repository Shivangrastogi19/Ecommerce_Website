using Models;

namespace Services.Interface
{
	public interface IAccountServices
	{
		Task<bool> IsRegister(Register model);
		Task<bool> IsLogin(Login model);
	}
}
