namespace BlazorApp1.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string ToolName { get; set; }

        public int ToolMaxDurability { get; set; }

        public List<string> EnchantCategories { get; set; }

        public List<string> RepairWith { get; set; }

        public List<string> BuildWith { get; set; }

        /*
        public string BuildWith64 { get; set; }

        */
    }
}
