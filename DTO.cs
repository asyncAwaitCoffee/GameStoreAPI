using System.ComponentModel.DataAnnotations;

namespace GameStoreApi;


public record GameDTO
    (
        int Id,
        string Name,
        string Genre,
        decimal Price,
        DateTime ReleaseDate,
        string ImageURI
    );

public record CreateGameDTO
    (
        [Required][StringLength(30)]
        string Name,
        [Required][StringLength(20)]
        string Genre,
        [Range(1, 200)]
        decimal Price,
        DateTime ReleaseDate,
        [Url][StringLength(100)]
        string ImageURI
    );

public record UpdateGameDTO
    (
        [Required][StringLength(30)]
        string Name,
        [Required][StringLength(20)]
        string Genre,
        [Range(1, 200)]
        decimal Price,
        DateTime ReleaseDate,
        [Url][StringLength(100)]
        string ImageURI
    );