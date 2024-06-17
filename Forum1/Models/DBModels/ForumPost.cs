namespace Forum1.Models.DBModels
{
    public class ForumPost
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual UserAccount User { get; set; }

        public virtual ProfileInformation Profile { get; set; }

        public virtual ICollection<ForumComment> ForumComments { get; set; }
    }


    public static class BiologyPosts
    {
        public static IEnumerable<ForumPost> GetPosts()
        {
            List<ForumPost> posts = new List<ForumPost>();

            // Пример создания нескольких постов на тему биологии
            var post1 = new ForumPost
            {
                Title = "Эволюция и её механизмы",
                Content = "Обсуждаем основные механизмы эволюции: естественный отбор, мутации и генетический дрифт.",
                CreatedAt = DateTime.Now.AddDays(-5), // Пример даты создания поста
                User = new UserAccount { FullName = "Иван Петров" } // Пример пользователя
            };
            posts.Add(post1);

            var post2 = new ForumPost
            {
                Title = "Строение клетки",
                Content = "Подробно рассматриваем структуру клетки и её органеллы.",
                CreatedAt = DateTime.Now.AddDays(-3), // Пример даты создания поста
                User = new UserAccount { FullName = "Мария Сидорова" } // Пример пользователя
            };
            posts.Add(post2);

            var post3 = new ForumPost
            {
                Title = "Генетические законы Менделя",
                Content = "Обсуждаем основные законы наследования, открытые Грегором Менделем.",
                CreatedAt = DateTime.Now.AddDays(-1), // Пример даты создания поста
                User = new UserAccount { FullName = "Петр Иванов" } // Пример пользователя
            };
            posts.Add(post3);

            return posts;
        }
    }
}
