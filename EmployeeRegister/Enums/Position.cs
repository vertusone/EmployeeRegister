using System.ComponentModel;

namespace EmployeeRegister.Enums
{
    public enum Position
    {
        [Description("Разработчик")]
        Developer = 0,
        
        [Description("Тестировщик")]
        Tester = 1,
        
        [Description("Бизнес-аналитик")]
        BusinessAnalyst = 2,
        
        [Description("Менеджер")]
        Manager = 3
    }
}