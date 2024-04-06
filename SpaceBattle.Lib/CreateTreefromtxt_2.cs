using Hwdtech;

namespace SpaceBattle.Lib;

public class CreateTreeFromtxt_2 : IStrategy
{
    public object ExecuteStrategy(params object[] args)
    {

        var CollisionTree = IoC.Resolve<Dictionary<string, object>>("GetCollisionTree");
        StreamReader fileReader;

        try
        {
            fileReader = new StreamReader((string)args[0]);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }

        while (!fileReader.EndOfStream)
        {
            string[] values = fileReader.ReadLine()!.Split(" ");

            var branch = CollisionTree;

            foreach (string value in values)
            {
                branch.TryAdd(value, new Dictionary<string, object>());
                branch = (Dictionary<string, object>) branch[value];
            }
        }
        return CollisionTree;
        
    }
}
