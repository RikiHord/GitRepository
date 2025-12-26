namespace Popsicles
{
    public class CalcPotrion
    {
        public static string GivePortionOrNot(int numberOfSiblings, int numberOfIceCream)
        {
            if (numberOfSiblings <= 0 ) return "Number of siblings must be greater than zero.";
            if (numberOfIceCream <= 0) return "Number of ice creams must be greater than zero.";

            string respon = numberOfIceCream % numberOfSiblings == 0 ? "give away": "eat them yourself";
            
            return respon;
        }
    }
}
