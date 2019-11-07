# Album Photo Viewer

## A simple API returning a users photo albums and links the photo images therein.
* https://localhost:44347/AlbumPhotos/{userId}/albums
* https://localhost:44347/AlbumPhotos/{userId}/albums/{albumId}
* https://localhost:44347/AlbumPhotos/{userId}/albums/{albumId}/photos/{photoId}

### Example usage

To get a collection of a users Album titles and IDs where the users ID is 1.
`GET https://localhost:44347/AlbumPhotos/1/albums`

To get a collection of Photos (and aditional metadata) in users ID 1's Album ID 2

`GET https://localhost:44347/AlbumPhotos/1/albums/2`

To get data on a Photo in Album ID 2, specify the Photos ID in the last position e.g Photo ID 75 in Album ID 

`GET https://localhost:44347/AlbumPhotos/1/albums/2/photo/75`

If a Photo does not exist in an album a 404 HTTP status NOT FOUND is returned e.g.

`GET https://localhost:44347/AlbumPhotos/1/albums/2/photo/1175`

```Note use Postman to validate the correct status codes if necessary.```

ToDo:
* add logging
* better test coverage
* error handling