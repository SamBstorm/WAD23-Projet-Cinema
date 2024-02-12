namespace ASP_Projet_Cinema.Handlers
{
    public static class HtmlToolbox
    {
        public static IEnumerable<int> GetYearsSince(int minYear) {
            for (int i = DateTime.Now.Year; i >= minYear; i--)
            {
                yield return i;
            }
        }
    }
}
