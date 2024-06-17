using Forum1.Models.Menu;

namespace Forum1.Models.Menu
{
    public class ListMenu
    {
        public List<ItemMenu> Menu =
        [
            new ItemMenu("Home", "Index", "Главная"),
            new ItemMenu("Employees", "Index", "Сотрудники"),
            new ItemMenu("Authorization", "Login", "Войти"),
        ];

        public List<ItemMenu> UserMenu =
        [
            new ItemMenu("Home", "Index", "Главная"),
            new ItemMenu("Organizations", "Index", "Организации"),
            new ItemMenu("Employees", "Index", "Сотрудники"),
            new ItemMenu("Authorization", "Exit", "Выйти"),
        ];

        public List<ItemMenu> AdminMenu =
        [
            new ItemMenu("Home", "Index", "Главная"),
            new ItemMenu("Organizations", "Index", "Организации"),
            new ItemMenu("Employees", "Index", "Сотрудники"),
            new ItemMenu("UserAccounts", "Index", "Акаунты"),
            new ItemMenu("Authorization", "Exit", "Выйти"),
        ];
    }
}
