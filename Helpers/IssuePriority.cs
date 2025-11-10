namespace Prog7312_MunicipalityApp_ST10299399.Helpers
{
    public static class IssuePriority
    {
        private const int High_Priority = 100;
        private const int Medium_Priority = 50;
        private const int Low_Priority = 10;

        public static int GetPriorityValue(string issueType)
        {
            return issueType.ToLower() switch
            {
                "Load shedding" => High_Priority,
                "water outage" => High_Priority,
                "pothole" => High_Priority,
                "streetlight outage" => Medium_Priority,
                "graffiti" => Low_Priority,
                _ => Low_Priority,
            };
        }



    }
}
