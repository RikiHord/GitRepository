namespace ItsASign
{
    public class CheckClass
    {
        public static bool CheckPalindrom(List<string> signNames)
        {
            foreach (string signName in signNames)
            {
                string reversedName = new string(signName.Reverse().ToArray());
                if (signName == reversedName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
