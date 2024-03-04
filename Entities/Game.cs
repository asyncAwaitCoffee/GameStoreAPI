using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Entities
{
    public class Game
    {
        public int Id { get; set; }
        [StringLength(30)]
        public required string Name { get; set; }
        [StringLength(20)]
        public required string Genre { get; set; }
        [Range(1, 200)]
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        [StringLength(100)]
        public required string ImageURI { get; set; }
    }
}
