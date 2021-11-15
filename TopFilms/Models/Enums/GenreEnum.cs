using System;

namespace TopFilms.Models
{
    [Flags]
    public enum GenreEnum
    {
        None = 0, 
        Action = 1, 
        Adventure = 2,
        Comedy = 4,
        Drama = 8,
        Fantasy = 16,
        Historical = 32,
        Horror = 64,
        Mystery = 128,
        Romance = 256,
        Thriller = 512,
        Western = 1024,
        Crime = 2048
    }
}
