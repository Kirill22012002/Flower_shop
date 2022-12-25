namespace Flower_shop.EfStuff
{
    public class SeedData : ISeedData
    {
        private WebDbContext _webDbContext;
        public SeedData(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public void Seed()
        {
            SeedUsers();
            SeedTypesProductAndProducts();
            SeedImages();
            SeedColors();
        }

        private void SeedUsers()
        {
            if (!_webDbContext.Users.Any())
            {
                var user = new User
                {
                    FirstName = "admin",
                    LastName = "admin",
                    Email = "admin",
                    Password = "admin",
                    Role = SiteRole.Admin
                };
                _webDbContext.Users.Add(user);
                _webDbContext.SaveChanges();
            }
        }
        private void SeedTypesProductAndProducts()
        {
            if (!_webDbContext.TypesProduct.Any() && !_webDbContext.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Цветы разноцветные",
                        Price = "20 рублей",
                        ImageName = "UploadedFile",
                        ImagePath = "/files/flower22.1.jpg"
                    },
                    new Product()
                    {
                        Name = "Цветы сухоцветы",
                        Price = "15 рублей",
                        ImageName = "UploadedFile",
                        ImagePath = "/files/flower30.jpg"
                    }
                };

                _webDbContext.Products.AddRange(products);
                _webDbContext.SaveChanges();

                var typesProduct = new List<TypeProduct>()
                {
                    new TypeProduct
                    {
                        Name = "Цветы",
                        Products = products
                    },
                    new TypeProduct
                    {
                        Name = "Декор"
                    }
                };

                _webDbContext.TypesProduct.AddRange(typesProduct);
                _webDbContext.SaveChanges();
            }
        }
        private void SeedImages()
        {
            if (!_webDbContext.Images.Any())
            {
                var images = new List<Image>()
                {
                    new Image()
                    {
                        Block = 1,
                        Title = "Цветы для самых любимых",
                        Subtitle = "Порадуйте своих близких",
                        ImageName = "UploadedFile",
                        ImagePath = "/files/flower22.1.jpg"
                    },
                    new Image()
                    {
                        Block = 2,
                        Title = "Цветы для самых любимых",
                        Subtitle = "Порадуйте своих близких",
                        ImageName = "UploadedFile",
                        ImagePath = "/files/flower30.jpg"
                    },
                    new Image()
                    {
                        Block = 3,
                        Title = "Цветы для самых любимых",
                        Subtitle = "Любовь и радость",
                        ImageName = "UploadedFile",
                        ImagePath = "/files/flower23.jpg"
                    },
                    new Image()
                    {
                        Block = 4,
                        Title = "Цветы для самых любимых",
                        Subtitle = "Порадуйте своих близких",
                        ImageName = "UploadedFile",
                        ImagePath = "/files/flower28.jpg"
                    }
                };

                _webDbContext.Images.AddRange(images);
                _webDbContext.SaveChanges();
            }
        }
        private void SeedColors()
        {
            if (!_webDbContext.Colors.Any())
            {
                var colors = new List<Color>()
                {
                    new Color()
                    {
                        AssignmentName = "Поменять цвет кнопок \"Перейти\" и \"Войти\".",
                        ColorHex = "#2930ba"
                    },
                    new Color()
                    {
                        AssignmentName = "Поменять цвет фона у навигационных кнопок.",
                        ColorHex = "#2930ba"
                    },
                    new Color()
                    {
                        AssignmentName = "Поменять цвет кнопки \"Вход\"",
                        ColorHex = "#6d72d1"
                    },
                    new Color()
                    {
                        AssignmentName = "Поменять цвет кнопки \"Регистрация\"",
                        ColorHex = "#2930ba"
                    }
                };

                _webDbContext.Colors.AddRange(colors);
                _webDbContext.SaveChanges();
            }
        }
    }
}
