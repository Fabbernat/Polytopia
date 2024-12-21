namespace Polytopia.Models.Tribes
{
    public enum HumanTribesEnum
    {
        XinXi,
        Imperius,
        Bardur,
        Oumaji,
        Kickoo,
        Hoodrick,
        Luxidoor,
        Zebasi,
        Vengir,
        AiMo,
        Quetzali,
        Yadakk
    }

    public class HumanTribes
    {
        public List<string> GetAll()
        {
            // Get all enum values as an array
            var enumValues = Enum.GetValues(typeof(HumanTribesEnum));

            // Convert the array to a list of strings
            return enumValues.Cast<HumanTribesEnum>().Select(val => val.ToString()).ToList();
        }
    }
}