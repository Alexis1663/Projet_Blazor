namespace BlazorApp1.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string ToolName { get; set; }

        public const int StackSize = 1;

        public int ToolMaxDurability { get; set; }

        public List<string> EnchantCategories { get; set; }

        public List<string> RepairWith { get; set; }

        public List<string> BuildWith { get; set; }
    }
}
