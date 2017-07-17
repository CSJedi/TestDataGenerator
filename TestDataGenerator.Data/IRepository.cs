
namespace TestDataGenerator.Data
{
    public interface IRepository
    {
        void Init();
        string GetRandomName();
        string GetRandomSurName();
        string GetRandomPatronymic();
        string GetRandomUniqLogin();
        string GetRandomEmailDomain();
    }
}
