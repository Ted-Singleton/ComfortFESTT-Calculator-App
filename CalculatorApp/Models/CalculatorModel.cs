using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalculatorApp.Models
{
    public class Condition
    {
        public string Name { get; set; }
        public int NHSWaitTime { get; set; }
        public float PrivateCost { get; set; }

        public Condition(string name, int value, float price)
        {
            Name = name;
            NHSWaitTime = value;
            PrivateCost = price;
        }
    }

    public class CalculatorModel
    {
        public int selectedCondition { get; set; }
        public int CustomWaitTime { get; set; }
        public float Income { get; set; }
        public float Result1 { get; set; }
        public float Result2 { get; set; }


        public List<Condition> Conditions { get; set; }
        public List<SelectListItem> ConditionSelectListItems { get; set; }

        public CalculatorModel()
        {
            Conditions = new List<Condition>()
            {
                new Condition("GP Appointment", 2, 89),
                new Condition("ACL Reconstruction Surgery ", 30, 7450),
                new Condition("Cataract Surgery (per eye)", 35, 2775),
                new Condition("Hip Replacement", 48, 13402),
                new Condition("Diabetes Treatment", 12, 300)
            };

            ConditionSelectListItems = Conditions.Select(c => new SelectListItem
            {
                Value = c.NHSWaitTime.ToString(),
                Text = c.Name
            }).ToList();

            ConditionSelectListItems.Add(new SelectListItem
            {
                Value = "1", // Assuming 1 is not used by other conditions
                Text = "Custom Wait Time"
            });
        }
    }
}
