using BlazorApp1.Models;

namespace BlazorApp1.Factories
{
    public static class ToolFactory
    {
        public static ToolModel ToModel(Tool item, byte[] imageContent)
        {
            return new ToolModel
            {
                Id = item.Id,
                ToolName = item.ToolName,
                BuildWith = item.BuildWith,
                RepairWith = item.RepairWith,
                EnchantCategories = item.EnchantCategories,
                ToolMaxDurability = item.ToolMaxDurability,
                ImageContent = imageContent
            };
        }

        public static Tool Create(ToolModel model)
        {
            return new Tool
            {

                Id = model.Id,
                ToolName = model.ToolName,
                BuildWith = model.BuildWith,
                RepairWith = model.RepairWith,
                EnchantCategories = model.EnchantCategories,
                ToolMaxDurability = model.ToolMaxDurability,
            };
        }

        public static void Update(Tool item, ToolModel model)
        {
            item.ToolName = model.ToolName;
            item.BuildWith = model.BuildWith;
            item.RepairWith = model.RepairWith;
            item.EnchantCategories = model.EnchantCategories;
            item.ToolMaxDurability = model.ToolMaxDurability;
        }
    }
}
