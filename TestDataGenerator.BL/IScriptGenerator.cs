using TestDataGenerator.Data;

namespace TestDataGenerator.BL
{
    public interface IScriptGenerator
    {
        UserEntity GenerateUser();
        string GetInsertLine();
        string GetValueLine(UserEntity entity);
        string CreateScript(int entityCount);
    }
}
