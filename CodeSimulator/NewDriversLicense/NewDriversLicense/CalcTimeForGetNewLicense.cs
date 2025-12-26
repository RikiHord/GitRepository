namespace NewDriversLicense
{
    public class CalcTimeForGetNewLicense
    {
        const int TIME_PER_PERSON = 20; // minutes
        Queue<string> peopleQueue = new Queue<string>();

        private void CreateQueue(string yourName, string namesOfPeople)
        {
            List<string> names = string.IsNullOrWhiteSpace(namesOfPeople)
                                    ? new List<string>()
                                    : new List<string>(namesOfPeople.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            names.Add(yourName);

            names.Sort(StringComparer.Ordinal);
            
            foreach (var name in names)
            {
                peopleQueue.Enqueue(name);
            }
        }

        public int CalculateTotalTime(string yourName, int numberOfAgents, string namesOfPeople)
        {
            int totalTime = 0;
            CreateQueue(yourName, namesOfPeople);
            
                if (!peopleQueue.Contains(yourName) 
                || numberOfAgents <= 0
                || string.IsNullOrEmpty(yourName))
            {
                return 0;
            }

            while (peopleQueue.Count > 0)
            {
                for (int i = 0; i < numberOfAgents; i++)
                {
                    if (peopleQueue.Count == 0)
                        break;
                    string currentPerson = peopleQueue.Dequeue();
                    if (currentPerson == yourName)
                    {
                        totalTime += TIME_PER_PERSON;
                        return totalTime;
                    }
                }
                totalTime += TIME_PER_PERSON;
            }

            return totalTime;
        }
    }
}
