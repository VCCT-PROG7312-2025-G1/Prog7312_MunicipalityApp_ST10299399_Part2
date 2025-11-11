using Prog7312_MunicipalityApp_ST10299399.Models;

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
                "Loadshedding" => High_Priority,
                "Water Leak" => High_Priority,
                "Pothole" => High_Priority,
                "Streetlight" => Medium_Priority,
                "Garbage" => Low_Priority,
                "Feature Request" => Low_Priority,
                "Other" => Low_Priority,
                _ => Low_Priority,
            };
        }



    }
}